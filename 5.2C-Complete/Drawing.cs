using System;
using System.Collections.Generic;
using System.IO;
using SplashKitSDK;

namespace _5._2C_Not_Complete
{
    class Drawing
    {
        //! Fields 
        private readonly List<Shape> _shapes;
        private Color _background;


        //! Constructors
        //? Default constructor, should draw a white background when initialised.
        public Drawing(Color background)
        {
            _background = background;
            _shapes = new();
        }

        public Drawing()
            : this(Color.White)
        {

        }


        //! Properties
        public Color Background
        {
            get { return _background; }
            set { _background = value; }
        }

        //? Readonly
        public int ShapeCount
        {
            get { return _shapes.Count; }
        }

        //? Readonly, adds a selected shape to the selectedShapes array
        public List<Shape> SelectedShapes
        {
            get 
            {
                List<Shape> selectedShapes = new();

                foreach(Shape genericShape in _shapes)
                {
                    if (genericShape.Selected)         
                    {
                        selectedShapes.Add(genericShape);
                    }
                }
                return selectedShapes;
            }
        }

        //! Methods and Fields
        public void AddShape(Shape genericShape)
        {
            _shapes.Add(genericShape);
        }

        public void RemoveShape(Shape genericShape)
        {
            _shapes.Remove(genericShape);
        }

        //? Turns selected to true if shape is at mouselocation
        public void SelectShapesAt(Point2D mouseLocation)
        {
            foreach(Shape genericShape in _shapes)
            {
                if (!genericShape.Selected)
                {
                    genericShape.Selected = genericShape.IsAt(mouseLocation);
                }
            }
        }

        //? Draw da shapes
        public void Draw()
        {
            SplashKit.ClearScreen(Background);

            foreach (Shape genericShape in _shapes)
            {
                genericShape.Draw();
            }
        }

        //! 5.2C Code Relating to saving and loading functionality
        public void Save(string filename)
        {
            StreamWriter writer = new(filename);

            try
            {
                writer.WriteColor(Background);
                writer.WriteLine(ShapeCount);

                foreach (Shape genericShape in _shapes)
                {
                    genericShape.SaveTo(writer);
                }
            }
            finally
            {
                writer.Close();
            }
        }

        public void Load(string filename)
        {
            StreamReader reader = new(filename); //TODO create exception to handle opening non-existent files
            try
            {
                Shape genericShape;
                int count;
                string kind;

                Background = reader.ReadColor();
                count = reader.ReadInteger();

                _shapes.Clear();

                for (int i = 0; i < count; i++)
                {
                    kind = reader.ReadLine();

                    genericShape = kind switch
                    {
                        "Rectangle" => new MyRectangle(),
                        "Circle" => new MyCircle(),
                        "Line" => new MyLine(),
                        _ => throw new Exception(kind + "is not a valid ShapeKind"),
                    };

                    genericShape.LoadFrom(reader);
                    AddShape(genericShape);
                }
            }

            finally
            {
                reader.Close();
            }                 
        }
    }
}

