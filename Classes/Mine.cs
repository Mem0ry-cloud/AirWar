using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;     // для ContentManager
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace AIRWAR.Classes
{
    class Mine : FlyingObject
    {
        public Mine(Texture2D texture, Vector2 position,int size) : base(texture, position,size)
        {
            base.Speed = 6;
        }
    }
}
