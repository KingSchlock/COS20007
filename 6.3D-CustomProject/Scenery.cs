using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _6._3D_CustomProject
{
    public class Scenery : GameObject
    {
        //! Fields

        //! Constructors
        public Scenery()
            : base(ObjectType.background, 0, 0, 0, 0)
        {

        }

        public Scenery(ObjectType objectType, double xPos, double yPos,
            double xVel, double yVel) 
            : base(objectType, xPos, yPos, xVel, yVel)
        {
            
        }

        //! Methods
        protected override Bitmap DetermineObjectType()
        {
            return base.DetermineObjectType();
        }

        // Draws bitmap based on the object type, x pos and y pos
        public override void Draw()
        {
            SplashKit.DrawBitmap(DetermineObjectType(), Position.X, Position.Y);
        }

        // Updates the position with respect to velocity
        public override void Update()
        {

        }
    }
}
