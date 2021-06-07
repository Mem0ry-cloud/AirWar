using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using AIRWAR.Classes;
using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework.Content;
using AIRWAR.Classes.UI;
using AIRWAR;
namespace AIRWAR.Classes
{
    class Menu
    {
        private List<Label> items;
        private string[] texts = { "Play", "Level", "Info","Exit" };
        private int selected = 0;
        private KeyboardState keyboard;
        private KeyboardState prevkeyboard;
        public Vector2 Position { get; set; }
        private Texture2D menuBackground;
        public Menu()
        {
            menuBackground = null;
            items = new List<Label>();

            Vector2 position = Position;
            for (int i = 0; i < texts.Length; i++)
            {
                Label label = new Label(texts[i], position, Color.White);
                items.Add(label);

                position.Y += 30;
            }
        }

        public void SetMenuPosition(Vector2 Position)
        {
            this.Position = Position;
            for (int i = 0; i < items.Count; i++)
            {
                items[i].position = Position;
                Position.Y += 30;
            }
        }

        public void LoadContent(ContentManager Content)
        {
            foreach (Label item in items)
            {
                item.LoadContent(Content);
            }
            menuBackground =  Content.Load<Texture2D>("mainMenu");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(menuBackground,new Vector2(0,0), Color.White);
            items[selected].Color = Color.Red;
            foreach (var item in items)
            {
                item.Draw(spriteBatch);
            }
        }
        public void Update()
        {
            keyboard = Keyboard.GetState();

            if (keyboard.IsKeyDown(Keys.S) && (keyboard != prevkeyboard))
            {
                if (selected < items.Count - 1)
                {
                    items[selected].ResetColor();
                    selected++;
                }
            }
            if (keyboard.IsKeyDown(Keys.W) && (keyboard != prevkeyboard))
            {
                if (selected > 0)
                {
                    items[selected].ResetColor();
                    selected--;
                }
            }
            if (keyboard.IsKeyDown(Keys.Enter))
            {
                switch (selected)
                {
                    case 0:
                        Game1.gameState = Game1.GameState.Game;
                        break;  //Play
                    case 1:
                        //Выбор сложности
                        break;
                    case 2:
                        //Инфо
                        break;
                    case 3:
                        Game1.gameState = Game1.GameState.Exit;
                        break;
                    default:
                        break;
                }
            }

            prevkeyboard = keyboard;
        }
    }
}
