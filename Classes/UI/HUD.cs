using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;     // для ContentManager
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace AIRWAR.Classes.UI
{
    class HUD
    {
        private Label lblScore;
        private HealthBar healthBar;

        private bool isVIsible;
        public HUD()
        {
            lblScore = new Label("Score:100", new Vector2(0, 70), Color.White);
            isVIsible = true;

            healthBar = new HealthBar(health:5,Color.White,50,50,new Vector2(0,0));
        }
        public void LoadContent(ContentManager manager)
        {
            lblScore.LoadContent(manager);
            healthBar.LoadContent(manager);
        }
        public void Update(int Score, int health)
        {
            lblScore.Text = $"Score {Score.ToString()}";
            healthBar.Update(health);
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            if (isVIsible)
            {
                lblScore.Draw(_spriteBatch);
                healthBar.Draw(_spriteBatch);
            }
        }
    }
}
