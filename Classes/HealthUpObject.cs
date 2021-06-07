using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;     // для ContentManager
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace AIRWAR.Classes
{
    class HealthUpObject : FlyingObject
    {
        public int HealthBoost { get; set; }
        public HealthUpObject(Texture2D texture, Vector2 position,int healthBoost,int size) : base(texture, position,size)
        {
            color = Color.Yellow;
            base.Speed = 8;
            HealthBoost = healthBoost;
        }
    }
}
