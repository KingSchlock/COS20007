using SplashKitSDK;

namespace _6._3D_CustomProject
{
    public class Player : GameObject
    {
        //! Fields
        private bool _isJumping = false;
        private double _maxJumpHeight = SplashKit.ScreenHeight() - 150;
        private double _floorHeight = SplashKit.ScreenHeight() - 100;

        //! Constructors
        public Player()
            :this(ObjectType.player, 250, (SplashKit.ScreenHeight() - 100), 0, 0)
        {

        }

        public Player(ObjectType objectType, double xPos, double yPos,
            double xVel, double yVel) 
            : base(objectType, xPos, yPos, xVel, yVel)
        {

        }

        //! Properties
        public bool IsJumping 
        { 
            get { return this._isJumping; } 
        }


        //! Methods
        protected override Bitmap DetermineObjectType()
        {
            return base.DetermineObjectType();
        }
        public override void Draw()
        {
            SplashKit.DrawBitmap(DetermineObjectType(), Position.X, Position.Y);
        }

        public override void Update()
        {
            CheckIsJumping();
            Jump();
            Gravity();
        }

        public bool CheckIsJumping()
        {
            if (!_isJumping && _position.Y <= _floorHeight && SplashKit.KeyReleased(KeyCode.SpaceKey))
            {
                return _isJumping = true;
            }
            else
            {
                return _isJumping = false;
            }
        }

        public void Jump()
        {
            if (_isJumping)
            {
                _velocity.Y = -50;
                _position.Y += _velocity.Y;

                _velocity = SplashKit.VectorAdd(_velocity, SplashKit.VectorTo(0, 10));
            }
        }

        public void Gravity()
        {
            if (!_isJumping && _position.Y < _floorHeight)
            {
                _velocity.Y += 10;
                _position.Y += _velocity.Y;
            }
        }
    }
}