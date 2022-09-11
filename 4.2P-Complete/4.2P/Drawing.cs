using System;
using System.Collections.Generic;
using SplashKitSDK;

namespace _4._2P
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
    }
}
