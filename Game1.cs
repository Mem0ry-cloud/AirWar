using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using AIRWAR.Classes;
using System.Collections.Generic;
using System;
using AIRWAR.Classes.UI;
namespace AIRWAR
{
    public class Game1 : Game
    {
        public enum GameState
        {
            Menu, Game, Exit,GameOver
        }
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Player player;
        private Mainbackground mainbackground;
        private List<Explosition> explositions;
        private List<Mine> mines;
        private List<HealthUpObject> healthUpObjects;
        private Texture2D mineTexture= null;
        private Texture2D healthUpObjectTexture = null;
        private Random random;
        HUD HUD = new HUD();
        public static GameState gameState = GameState.Menu;
        Menu menu = new Menu();
        private 
        int FlyingObjectsTime = 0;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            //Размер экрана
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 480;
            random = new Random();
        }

        protected override void Initialize()
        {
            player = new Player();
            mainbackground = new Mainbackground();
            explositions = new List<Explosition>();
            mines = new List<Mine>();
            healthUpObjects = new List<HealthUpObject>();
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            player.LoadContent(Content);
            mainbackground.LoadContent(Content);
            mineTexture = Content.Load<Texture2D>("mine");
            healthUpObjectTexture = Content.Load<Texture2D>("Heart");
            menu.LoadContent(Content);
            menu.SetMenuPosition(new Vector2(370, 240));
            HUD.LoadContent(Content);
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                gameState = GameState.Menu;
            // TODO: Add your update logic here
            switch (gameState)
            {
                case GameState.Menu:
                    menu.Update();
                    mainbackground.Update();
                    break;
                case GameState.Game:
                    UpdateGame(gameTime);
                    mainbackground.Update();
                    break;
                case GameState.Exit:
                    Exit();
                    break;
                case GameState.GameOver:
                    Exit();
                    break;
                default:
                    break;
            }
            base.Update(gameTime);
        }
        private void UpdateGame(GameTime gameTime)
        {
            player.Update();
            HUD.Update(player.GetScore(), player.Health);
            UpdateFlyingObjects();
            UpdateExplosions(gameTime);
            Bounding();
            if (player.Health <= 0)
            {
                gameState = GameState.GameOver;
            }
        }
        private void UpdateFlyingObjects()
        {
            FlyingObjectsTime++;
            if (FlyingObjectsTime % 15 == 0)
            {
                int positiona = random.Next(-400, 600);
                Mine m = new Mine(mineTexture, new Vector2(800, positiona),50);
                mines.Add(m);
            }
            if (FlyingObjectsTime % 450 == 0)
            {
                int positionb = random.Next(-400, 600);
                HealthUpObject h = new HealthUpObject(healthUpObjectTexture, new Vector2(800, positionb),healthBoost:1,50);
                healthUpObjects.Add(h);
            }

            for (int i = 0; i < mines.Count; i++)
            {
                if (mines[i].IsVisible)
                {
                    mines[i].Update();
                }
                else
                {
                    mines.RemoveAt(i);
                    i--;
                }
            }
            for (int j = 0; j < healthUpObjects.Count; j++)
            {
                if (healthUpObjects[j].IsVisible)
                {
                    healthUpObjects[j].Update();
                }
                else
                {
                    healthUpObjects.RemoveAt(j);
                    j--;
                }
            }
        }
        private void UpdateExplosions(GameTime gameTime)
        {
            for (int i = 0; i < explositions.Count; i++)
            {
                if (explositions[i].IsVisible)
                {
                    explositions[i].Update(gameTime);
                }
                else
                {
                    explositions.RemoveAt(i);
                    i--;
                }
            }
        }
        public void Bounding()
        {

            #region Мины
            for (int j = 0; j < mines.Count; j++)
            {
                Mine b = mines[j];
                for (int i = 0; i < player.laserList.Count; i++)
                {
                    Laser a = player.laserList[i];
                    if (a.BoundingBox.Intersects(b.BoundingBox))
                    {
                        Explosition e = new Explosition(new Vector2(a.BoundingBox.X, a.BoundingBox.Y));
                        e.LoadContent(Content);
                        explositions.Add(e);

                        b.IsVisible = false;
                        a.IsVisible = false;
                    }
                }
                if (b.BoundingBox.Intersects(player.BoundingBox))
                {
                    Explosition explosition = new Explosition(new Vector2(b.BoundingBox.X, b.BoundingBox.Y));
                    explosition.LoadContent(Content);
                    explositions.Add(explosition);

                    b.IsVisible = false;
                    player.Health--;
                    player.AddScore(-1);
                }
                #endregion
            }
            #region Усилители
            for (int j = 0; j < healthUpObjects.Count; j++)
            {
                HealthUpObject h = healthUpObjects[j];
                for (int i = 0; i < player.laserList.Count; i++)
                {
                    Laser a = player.laserList[i];
                    if (a.BoundingBox.Intersects(h.BoundingBox))
                    {
                        Explosition e = new Explosition(new Vector2(a.BoundingBox.X, a.BoundingBox.Y));
                        e.LoadContent(Content);
                        explositions.Add(e);

                        h.IsVisible = false;
                        a.IsVisible = false;
                        player.AddScore(-1);
                    }
                }
                if (h.BoundingBox.Intersects(player.BoundingBox))
                {
                    h.IsVisible = false;
                    player.Health += h.HealthBoost;
                    player.AddScore(+10);
                }
            }
            #endregion
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            switch (gameState)
            {
                case GameState.Menu:
                    menu.Draw(_spriteBatch);
                    break;
                case GameState.Game:
                    mainbackground.Draw(_spriteBatch);
                    DrawGame();
                    break;
                case GameState.Exit:
                    break;
                case GameState.GameOver:
                    break;
                default:
                    break;
            }
            _spriteBatch.End();
            base.Draw(gameTime);
        }
        public void DrawGame()
        {
            for (int i = 0; i < mines.Count; i++)
            {
                mines[i].Draw(_spriteBatch);
            }
            for (int i = 0; i < healthUpObjects.Count; i++)
            {
                healthUpObjects[i].Draw(_spriteBatch);
            }
            for (int i = 0; i < explositions.Count; i++)
            {
                explositions[i].Draw(_spriteBatch);
            }
            HUD.Draw(_spriteBatch);
            player.Draw(_spriteBatch);
        }
    }
}
