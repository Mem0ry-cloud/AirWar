using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using AIRWAR.Classes;
using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework.Content;

namespace AIRWAR.Classes.UI
{
    class Label
    {
        private SpriteFont spriteFont;
        private Color colorDefault;
        public Vector2 position { get; set; }
        public string Text { get; set; }
        public Color Color { get; set; }

        public Label()
        {
            position = new Vector2(100, 100);
            Text = "Label";
            Color = Color.White;
            colorDefault = Color;
        }
        public Label(string Text, Vector2 position, Color c)
        {
            this.Text = Text;
            this.position = position;
            Color = c;
            colorDefault = Color;
        }

        public void LoadContent(ContentManager manager)
        {
            spriteFont = manager.Load<SpriteFont>("GameFont");
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(spriteFont, Text, position, Color);
        }
        public void ResetColor()
        {
            Color = colorDefault;
        }
    }
}
