using System;
using System.Collections;
using System.Numerics;
using SplashKitSDK;

/* TODO Implement collision boxes and detection if splashkit doesn't support by 
 *      default.
 *      
 *      Turn GameObject into an abstract class and build floor, background and player 
 *      objects. */

/*! To save on performance and time, make the world move instead of the player
 *  and perpetually spawn new assets infront of the old ones and despawn assets 
 *  off screen to the left.
 *  
 *  This will give the illusion of movement to the user and allow for the background
 *  to maintain a different velocity to the floor, allowing for difficulty to increase
 *  with respect to time. 
 
    fuck that just animate it to give the illusion of giving the illusion */

namespace _6._3D_CustomProject
{
    public abstract class GameObject
    {
        //! Fields
        protected ObjectType _objectType;
        protected Point2D _position;

        protected Vector2D _velocity;

        //! Constructors
        public GameObject() 
            : this(ObjectType.background, 0, 0, 0, 0) 
        { 
        
        }

        public GameObject(ObjectType objectType, double xPos, double yPos,
            double xVel, double yVel)
        {
            _objectType = objectType;

            _position.X = xPos;
            _position.Y = yPos;

            _velocity.X = xVel;
            _velocity.Y = yVel;
        }


        //! Properties
        public ObjectType ObjectType
        {
            get { return this._objectType; }
            set { this._objectType = value; }
        }
        public Point2D Position
        {
            get { return this._position; }
            set { this._position = value; }
        }

        public Vector2D Velocity
        {
            get { return this._velocity; }
            set { this._velocity = value; }
        }


        //! Methods
        //  Determines the type of object based off an enum
        protected virtual Bitmap DetermineObjectType()
        {
            switch (_objectType)
            {
                case ObjectType.background:
                    return SplashKit.LoadBitmap("Skybox", "SkyArt_1.png");
                case ObjectType.floor:
                    return SplashKit.LoadBitmap("Ground", "Ground600px.png");
                default:
                    return SplashKit.LoadBitmap("Player", "Player.png");
            }
        }

        // All gameobjects must be shown on screen and update each frame
        public abstract void Draw(); // Takes type, position and velocity

        public abstract void Update(); // updates objects position with respect to velocity                             
    }
}
