using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;     // для ContentManager
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace AIRWAR.Classes
{
    class Laser
    {
        //поля
        private int speed;
        private Texture2D texture;
        private Vector2 position;
        private Rectangle rectangle;
        private bool isVisible;

        private Rectangle boundingBox;

        public bool IsVisible
        {
            set { isVisible = value; }
            get { return isVisible; }
        }
        public Rectangle BoundingBox
        {
            get{ return boundingBox; }
        }

        //конструктор
        public int Speed
        {
            set { speed = value; }
        }
        public Laser(Texture2D texture, Vector2 position)
        {
            speed = 0;
            this.texture = texture;
            isVisible = true;
            this.position = position;
            rectangle = new Rectangle((int)position.X,(int)position.Y,30,50);
        }
        //методы
        public void Draw(SpriteBatch brush)
        {
            if (isVisible)
            {
                brush.Draw(texture, rectangle, Color.White);
            }
        }
        public void Update()
        {
            if (rectangle.X > 900)
            {
                isVisible = false;
            }
            else
            {
                rectangle.X += speed;
            }
            boundingBox = new Rectangle(rectangle.X,rectangle.Y,rectangle.Width, rectangle.Height);
        }
    }
}
