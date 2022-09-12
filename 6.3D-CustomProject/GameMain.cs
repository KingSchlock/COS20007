using System;
using _6._3D_CustomProject;
using SplashKitSDK;

//TODO Talk with Josh about loading images from wrong directory. Paths might be fucked.
public class GameMain
{
    //! Loads all the resources used during the game.
    public static void LoadAssets()
    {
        SplashKit.LoadBitmap("Skybox", "SkyArt_1.png");
        SplashKit.LoadBitmap("Ground", "Ground800px.png");
    }

    //! Game Entry Point
    public static void Main()
    {
        //? Resources are preloaded to save performance at the cost of startup time.
        LoadAssets();

        GameManager game = new();
        Window gameWindow = new("6.3D - Custom Project, Thomas Horsley - 103071494", 800, 600);
        
        //? Using the default constructor will call the skybox automatically
        GameObject background = new Scenery();
        GameObject floor = new Scenery(ObjectType.floor, 0, (gameWindow.Height - 125), 0, 0);
        GameObject player = new Player();

        game.AddObject(background);
        game.AddObject(floor);
        game.AddObject(player);

        do
        {
            SplashKit.ProcessEvents();
            SplashKit.ClearScreen();

            game.DrawObjects();
            game.RemoveAndRespawnScreenScenery();
            game.UpdateObjects();

            if (SplashKit.KeyReleased(KeyCode.SpaceKey))
            {

            }

            SplashKit.RefreshScreen(60);
        } while (!gameWindow.CloseRequested);

    }
}
