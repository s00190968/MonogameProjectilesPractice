using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projectiles
{
    public class Sprite : ICloneable
    {
        protected Texture2D texture;
        protected float rotation;
        protected KeyboardState currentKey;
        protected KeyboardState previousKey;

        public Vector2 Position { get; set; }
        public Vector2 Origin { get; protected set; }

        public Vector2 Direction { get; set; }
        public float RotationVelocity { get; protected set; } = 3f;
        public float LinearVelocity { get; set; } = 4f;

        public Sprite Parent { get; set; }

        public float LifeSpan;
        public bool IsRemoved = false;

        public Sprite(Texture2D tx)
        {
            this.texture = tx;
            Origin = new Vector2(texture.Width / 2, texture.Height / 2);
        }

        public virtual void Update(GameTime gt, List<Sprite> sprites)
        {

        }

        public virtual void Draw(SpriteBatch sb)
        {
            sb.Draw(texture, Position, null, Color.White, rotation, Origin, 1, SpriteEffects.None, 0);
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
