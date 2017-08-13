using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace SpaceMaverick
{
    class InputHandler : GameComponent
    {
        static KeyboardState keyBoardState;
        static KeyboardState lastkeyBoardState;


        public static KeyboardState KeyBoardState
        {
            get
            {
                return keyBoardState;
            }
        }

        public static KeyboardState LastKeyBoardState
        {
            get
            {
                return lastkeyBoardState;
            }
        }



        public InputHandler(Game game)
            : base(game)
        {
            keyBoardState = Keyboard.GetState();
        }

        public override void Update(GameTime gameTime)
        {
            lastkeyBoardState = keyBoardState;
            keyBoardState = Keyboard.GetState();

            base.Update(gameTime);
        }

        public override void Initialize()
        {
            base.Initialize();
        }


        public static void Flush()
        {
            lastkeyBoardState = keyBoardState;
        }


        public static bool KeyReleased(Keys key)
        {
            return keyBoardState.IsKeyUp(key) && lastkeyBoardState.IsKeyDown(key);
        }

        public static bool KeyPressed(Keys key)
        {
            return keyBoardState.IsKeyDown(key) && lastkeyBoardState.IsKeyUp(key);
        }

        public static bool KeyDown(Keys key)
        {
            return keyBoardState.IsKeyDown(key);
        }


    }
}
