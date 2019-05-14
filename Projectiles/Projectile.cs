using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Projectiles
{
    public class Projectile : Sprite
    {
        private float timer;
        public Projectile(Texture2D tx):base(tx)
        {

        }

        public override void Draw(SpriteBatch sb)
        {
            base.Draw(sb);
        }

        public override void Update(GameTime gt, List<Sprite> sprites)
        {
            base.Update(gt, sprites);

            timer += (float)gt.ElapsedGameTime.Seconds;

            if(timer > LifeSpan)
            {
                IsRemoved = true;
            }

            Position += Direction * LinearVelocity;
        }
    }
}
