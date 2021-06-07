using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;     // для ContentManager
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AIRWAR.Classes
{
    class FlyingObject
    {
        //поля
        protected Color color;
        protected int speed;
        protected Texture2D texture;
        private Rectangle rectangle;
        protected bool isVisible;

        private Rectangle boundingBox;

        public Rectangle BoundingBox
        {
            get { return boundingBox; }
        }
        //конструктор
        public int Speed
        {
            set { speed = value; }
        }
        public bool IsVisible
        {
            get { return isVisible; }
            set { isVisible = value; }
        }
        public FlyingObject(Texture2D texture, Vector2 position,int size)
        {
            color = Color.White;
            speed = 7;
            this.texture = texture;
            isVisible = true;
            rectangle = new Rectangle((int)position.X, (int)position.Y, size, size);
        }
        //методы
        public void Draw(SpriteBatch brush)
        {
            if (isVisible)
            {
                brush.Draw(texture, rectangle, color);
            }
        }
        public virtual void Update()
        {
            if (rectangle.X < 0)
            {
                isVisible = false;
            }
            rectangle.X -= speed;
            boundingBox = new Rectangle(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
        }

    }
}
