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
  public class scrollBackground
    {
        GraphicsDeviceManager graphics;
        public List<Texture2D> tileTextures = new List<Texture2D>();
        int screenWidth;
        int screenHeight;
        int tileMapWidth;
        int tileMapHeight;
        int[,] tilemap = new int[,]
        {
        {0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,},
        {0,0,0,0,0,0,0,0,3,3,2,3,2,3,2,3,2,3,3,3,3,3,3,0,0,0,0,},
        {0,0,3,3,3,3,3,3,1,1,1,1,1,4,4,4,4,4,4,4,4,4,4,4,4,4,4,},
        {4,4,4,4,4,4,4,4,4,4,4,4,4,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
        {1,1,1,1,1,1,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,},
        {0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,},
        {0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,2,1,1,1,1,1,1,0,0,0,0,},
        {0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,2,1,1,1,1,1,1,0,0,0,0,},

         {0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,},
        {0,0,0,0,0,0,0,0,3,3,2,3,2,3,2,3,2,3,3,3,3,3,3,0,0,0,0,},
        {0,0,3,3,3,3,3,3,1,1,1,1,1,4,4,4,4,4,4,4,4,4,4,4,4,4,4,},
        {4,4,4,4,4,4,4,4,4,4,4,4,4,2,2,2,2,2,2,2,2,2,2,2,2,2,2,},
        {2,2,2,2,2,2,0,0,0,0,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,0,},
        {0,0,0,0,0,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,0,0,0,0,0,0,0,},
        {0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,2,1,1,1,1,1,1,0,0,0,0,},
        {0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,2,1,1,1,1,1,1,0,0,0,0,},

        {0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,},
        {0,0,0,0,0,0,0,0,3,3,2,3,2,3,2,3,2,3,3,3,3,3,3,0,0,0,0,},
        {0,0,3,3,3,3,3,3,1,1,1,1,1,4,4,4,4,4,4,4,4,4,4,4,4,4,4,},
        {4,4,4,4,4,4,4,4,4,4,4,4,4,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
        {1,1,1,1,1,1,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,},
        {0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,},
        {0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,2,1,1,1,1,1,1,0,0,0,0,},
        {0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,2,1,1,1,1,1,1,0,0,0,0,}
        };

        int tileWidth = 64;
        int tileHeight = 64;
        float cameraSpeed = 1.5f;
        Vector2 cameraPosition = Vector2.Zero;


        public scrollBackground(GraphicsDeviceManager graphics)
        {

            this.graphics = graphics;
            screenWidth = graphics.GraphicsDevice.Viewport.Width;
            screenHeight = graphics.GraphicsDevice.Viewport.Height;
            tileMapWidth = tilemap.GetLength(1);
            tileMapHeight = tilemap.GetLength(0);

            cameraPosition.X = tileMapWidth - screenWidth;
            cameraPosition.Y = tileMapHeight - screenHeight;
        }
        public void Update(GameTime gameTime)
        {



            cameraPosition.Y -= cameraSpeed;

            if (cameraPosition.X < 0)
            {
                cameraPosition.X = tileMapWidth * tileWidth - screenWidth;
            }
            if (cameraPosition.Y < 0)
            {
                cameraPosition.Y = tileMapHeight * tileHeight - (screenHeight + (screenHeight % 64));
            }


        }
        public void Draw( SpriteBatch sprite)
        {



            for (int x = 0; x < tileMapWidth; x++)
            {

                for (int y = 0; y < tileMapHeight; y++)
                {
                    int textureindex = tilemap[y, x];
                    Texture2D texture = tileTextures[textureindex];
                    sprite.Draw(texture, new Rectangle(x * tileWidth - (int)cameraPosition.X, y * tileHeight - (int)cameraPosition.Y, tileWidth, tileHeight), Color.White);


                }

            }

        }
    }
}
