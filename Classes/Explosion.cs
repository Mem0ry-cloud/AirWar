using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace AIRWAR.Classes
{
    class Explosition
    {
        //поля
        private Texture2D texture;
        private Vector2 position;
        private float timer;
        private float interval;
        private Vector2 origin;
        private int currentFrame;
        private int spriteWidth;
        private int spriteHeight;
        private Rectangle sourceRectangle;
        private Rectangle destinationRec;
        private bool visible;
        public Explosition(Vector2 position)
        {
            this.position = position;
            texture = null;
            timer = 0;
            interval = 20;
            currentFrame = 1;
            spriteHeight = 134;
            spriteWidth = 133;
            origin = Vector2.Zero;
            visible = true;
        }
        public bool IsVisible
        { get { return visible; } }


        public void LoadContent(ContentManager manager)
        {
            texture = manager.Load<Texture2D>("explosion");
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Vector2(position.X,position.Y - spriteWidth / 2), sourceRectangle, Color.White,
                0, origin, 1, SpriteEffects.None, 0);
        }
        public void Update(GameTime gameTime)
        {
            float t = (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            timer += t;

            if (timer > interval)  // если таймер переполнился
            {
                currentFrame++;
                timer = 0;
            }

            // если дошли до 17-го кадра, значит включаем нулевой = LOOP
            if (currentFrame == 12)
            {
                currentFrame = 0;

                visible = false;
            }

            sourceRectangle = new Rectangle(spriteWidth * currentFrame, 0, spriteWidth, spriteHeight);
            System.Diagnostics.Debug.WriteLine(timer);
        }
    }
}
