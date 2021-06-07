using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content; 
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace AIRWAR.Classes
{
    class Player
    {

        private Texture2D texture;
        private Vector2 position;
        private int speed;
        private int snos;
        //пулька
        private Laser Laser;
        private Texture2D TextureLaser;
        private List<Laser> LaserList = new List<Laser>();
        private int Lasercooldown;
        private Texture2D TextureMine;

        public Rectangle BoundingBox { get; set; }
        public int Health { get; set; }
        private int score;
        public void AddScore(int amount)
        {
            score += amount;
        }
        public int GetScore() { return score; }
        public List<Laser> laserList
        {
            get { return LaserList; }
        }
        public Player()
        {
            snos = 1;
            score = 10;
            Health = 5;
            Lasercooldown = 20;
            texture = null;
            position = new Vector2(10, 200);
            speed = 10;
        }
        public void LoadContent(ContentManager manager)
        {
            TextureLaser = manager.Load<Texture2D>("laser");
            TextureMine = manager.Load<Texture2D>("mine");
            texture = manager.Load<Texture2D>("player");
        }
        //методы
        public void Draw(SpriteBatch brush)
        {
            brush.Draw(texture, position, Color.White);
            for (int i = 0; i < LaserList.Count; i++)
            {
                LaserList[i].Draw(brush);
            }
        }
        public void Update()
        {
            position.X -= snos;
            if (Health > 5)
            {
                score += 50;
                Health--;
            }
            //Player
            BoundingBox = new Rectangle((int)position.X, (int)position.Y,texture.Width,texture.Height);
            KeyboardState state = Keyboard.GetState();
            //создание Laser
            if (state.IsKeyDown(Keys.Space) && Lasercooldown >= 40)
            {
                if (score > 0)
                {
                    Laser = new Laser(TextureLaser, new Vector2(position.X + texture.Width / 2, position.Y + texture.Height / 2));
                    Laser.Speed = 10;
                    LaserList.Add(Laser);
                    Lasercooldown = 0;
                }
            }
            Lasercooldown++;
            //создание Mine
            Random random = new Random();
            if (state.IsKeyDown(Keys.D))
            {
                position.X += speed;
            }
            if (state.IsKeyDown(Keys.A))
            {
                position.X -= speed;
            }
            if (state.IsKeyDown(Keys.W))
            {
                position.Y -= speed;
            }
            if (state.IsKeyDown(Keys.S) )
            {
                position.Y += speed;
            }
            if (position.X <= 0)
            {
                position.X = 0;
            }
            if (position.X >= 800 - texture.Width)
            {
                position.X = 800 - texture.Width;
            }
            if (position.Y <= 0)
            {
                position.Y = 0;
            }
            if (position.Y >= 480 - texture.Height)
            {
                position.Y = 480 -texture.Height;
            }


            //Laser
            for (int i = 0; i < LaserList.Count; i++)
            {
                if (!LaserList[i].IsVisible)
                {
                    LaserList.RemoveAt(i);
                    i--;
                }
                else
                {
                    LaserList[i].Update();
                }
            }
        }
    }
}
