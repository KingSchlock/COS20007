using System;
using System.Collections.Generic;
using SplashKitSDK;

/*! The GameManager class is responsible for handling all the initalization 
 *  and update data for our CustomProject. */

namespace _6._3D_CustomProject
{
    public class GameManager
    {
        //! Fields
        private List<GameObject> _gameObjects;

        //! Constructors
        public GameManager()
        {
            _gameObjects = new List<GameObject>();
        }

        //! Properties

        //! Methods
        public void AddObject(GameObject gameObject)
        {
            _gameObjects.Add(gameObject);
        }

        /* I'd imagine splashkit optimisation isn't great
         *  Code's dedicated to removing objects if they leave
         *  the screen. */
        public void RemoveAndRespawnScreenScenery()
        {
            List<GameObject> _removeObjects = new();

            foreach (GameObject aGameObject in _gameObjects)
            {
                /*? This line works (do not get fucked and redo it!),
                        tested with the constant set to 100px*/
                if (aGameObject.Position.X + SplashKit.ScreenWidth() < 100)
                {
                    _removeObjects.Add(aGameObject);
                }
            }

            foreach (GameObject aGameObject in _removeObjects)
            {
                _gameObjects.Remove(aGameObject);
            }
        }

        public void DrawObjects()
        {
            foreach(GameObject gameObject in _gameObjects)
            {
                gameObject.Draw();
            }
        }

        public void UpdateObjects()
        {
            foreach(GameObject gameObject in _gameObjects)
            {
                gameObject.Update();
            }
        }
    }
}
