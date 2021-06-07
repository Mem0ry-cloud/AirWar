using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;     // для ContentManager
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AIRWAR.Classes
{
    class Mainbackground
    {
        private Texture2D texture;
        private Texture2D texture2;
        private Texture2D texture3;
        private Vector2[] positions = new Vector2[6];
        private int[] speeds = {1,4,2};
        //свойста


        //конструктор
        public Mainbackground()
        {
            texture = null;
            texture2 = null;
            texture3 = null;
            for (int i = 0; i < positions.Length; i+= 2)
            {
                positions[i] = new Vector2(0, 0);
                positions[i + 1] = new Vector2(800, 0);
            }

        }
        public void LoadContent(ContentManager manager)
        {
            texture = manager.Load<Texture2D>("mainbackground");
            texture2 = manager.Load<Texture2D>("bgLayer1");
            texture3 = manager.Load<Texture2D>("bgLayer2");
        }
        //методы
        public void Draw(SpriteBatch brush)
        {
            brush.Draw(texture, positions[0], Color.White);
            brush.Draw(texture, positions[1], Color.White);

            brush.Draw(texture2, positions[2], Color.White);
            brush.Draw(texture2, positions[3], Color.White);

            brush.Draw(texture3, positions[4], Color.White);
            brush.Draw(texture3, positions[5], Color.White);
        }
        public void Update()
        {
            for (int i = 0; i < speeds.Length; i++)
            {
                positions[i * 2].X -= speeds[i];
                if (positions[i * 2].X <= -800)
                {
                    positions[i * 2].X = 800;
                }
                positions[(i * 2) + 1].X -= speeds[i];
                if (positions[(i * 2)+ 1].X <= -800)
                {
                    positions[(i * 2) + 1].X = 800;
                }
            }
        }
    }
}
