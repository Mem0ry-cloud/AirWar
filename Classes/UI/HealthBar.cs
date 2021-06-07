using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using AIRWAR.Classes;
using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework.Content;
using AIRWAR.Classes.UI;
using AIRWAR;
namespace AIRWAR.Classes.UI
{
    class HealthBar
    {
        private int health;
        private Texture2D texture;
        private Vector2 position;
        private Color color;
        private int width;
        private int height;
        private Rectangle Bar;
        private Rectangle Destination;
        public HealthBar(int health,Color color,int width,int height,Vector2 position)
        {
            this.health = health;
            this.color = color;
            this.position = position;

            this.width = width;
            this.height = height;
        }
        
        public void Update(int amount)
        {
            if (amount > 0)
            {
                health = amount;
            }
        }
        public void LoadContent(ContentManager manager)
        {
            texture = manager.Load<Texture2D>("Heart");
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            int pos = (int)position.X;
            Bar = new Rectangle(0, 0, texture.Width, texture.Height);
            for (int i = 0; i < health; i++)
            {
                Destination = new Rectangle((int)position.X + pos, (int)position.Y,width,height);
                _spriteBatch.Draw(texture, Destination, Bar,color);
                pos += width;
            }
        }
    }

}
