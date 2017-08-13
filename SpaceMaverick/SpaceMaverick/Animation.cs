using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceMaverick
{
  public class Animation
    {
        public Vector2 Position;
        public Texture2D Sheet;
        public  Point SheetSize;
       public Point SheetWidth;
        Point CurrentPos;
        int TimePerFrame;
        int TimeSinceLastFrame;
        float LayerDepths=0.9f;
        //private float layerDepths;

        public Animation(Texture2D Sheet, Point SheetSize, Point SheetWidth, Point CurrentPos, int TimePerFrame, int TimeSinceLastFrame)
        {
            this.Sheet = Sheet;
            this.SheetSize = SheetSize;
            this.SheetWidth = SheetWidth;
            this.CurrentPos = CurrentPos;
            this.TimePerFrame = TimePerFrame;
            this.TimeSinceLastFrame = TimeSinceLastFrame;
            
        }

        public Animation(Animation Copy)
        {
            this.Sheet = Copy.Sheet;
            this.SheetSize = Copy.SheetSize;
            this.SheetWidth = Copy.SheetWidth;
            this.CurrentPos = Copy.CurrentPos;
            this.TimePerFrame = Copy.TimePerFrame;
            this.TimeSinceLastFrame = Copy.TimeSinceLastFrame;
            this.LayerDepths = Copy.LayerDepths;
        }

        public Animation(Texture2D Sheet, Point SheetSize, Point SheetWidth, Point CurrentPos, int TimePerFrame, int TimeSinceLastFrame, float LayerDepth)
        {
            this.Sheet = Sheet;
            this.SheetSize = SheetSize;
            this.SheetWidth = SheetWidth;
            this.CurrentPos = CurrentPos;
            this.TimePerFrame = TimePerFrame;
            this.TimeSinceLastFrame = TimeSinceLastFrame;
            this.LayerDepths = LayerDepth;
        }

        public void Update(GameTime gameTime, Vector2 Position)
        {
            this.Position = Position;
            TimeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (TimeSinceLastFrame > TimePerFrame)
            {
                CurrentPos.X++;
                TimeSinceLastFrame = 0;

                if (CurrentPos.X >= SheetSize.X)
                {
                    CurrentPos.Y++;
                    CurrentPos.X = 0;

                }

                if (CurrentPos.Y >= SheetSize.Y)
                {
                    CurrentPos.Y = 0;
                }
            }
        }



        public void UpdateB(GameTime gameTime, Vector2 Position)
        {
            this.Position = Position;
            TimeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (TimeSinceLastFrame > TimePerFrame)
            {
                CurrentPos.X++;
                TimeSinceLastFrame = 0;

                if (CurrentPos.X >= SheetSize.X)
                {
                    CurrentPos.Y -= 2;
                    CurrentPos.X = 0;

                }

                if (CurrentPos.Y <= 0)
                {
                    CurrentPos.Y = 1200;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Sheet, Position, new Rectangle(CurrentPos.X * SheetWidth.X, CurrentPos.Y * SheetWidth.Y, SheetWidth.X, SheetWidth.Y), Color.White,0,Vector2.Zero,1.0f,SpriteEffects.None,LayerDepths);

        }

        public void DrawB(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Sheet, Position, new Rectangle(CurrentPos.X * SheetWidth.X, CurrentPos.Y * 1, SheetWidth.X, SheetWidth.Y), Color.White, 0, Vector2.Zero, 1.0f, SpriteEffects.None, LayerDepths);

        }
    }
}
