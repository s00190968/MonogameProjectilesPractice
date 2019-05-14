using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Projectiles
{
    public class Player : Sprite
    {
        public Projectile Bullet;
        public Player(Texture2D tx) : base(tx)
        {
        }

        public override void Update(GameTime gt, List<Sprite> sprites)
        {
            //base.Update(gt, sprites);
            previousKey = currentKey;
            currentKey = Keyboard.GetState();

            //rotating
            if (currentKey.IsKeyDown(Keys.A)){
                rotation -= MathHelper.ToRadians(RotationVelocity);
            } else if (currentKey.IsKeyDown(Keys.D))
            {
                rotation += MathHelper.ToRadians(RotationVelocity);
            }

            Direction = new Vector2((float)Math.Cos(rotation), (float)Math.Sin(rotation));

            //moving
            if (currentKey.IsKeyDown(Keys.W))
            {
                Position += Direction * LinearVelocity;
            }
            if (currentKey.IsKeyDown(Keys.S))
            {
                Position -= Direction * LinearVelocity;
            }

            //shooting
            if(currentKey.IsKeyDown(Keys.Space) && previousKey.IsKeyUp(Keys.Space))
            {
                AddBullet(sprites);
            }
        }

        public override void Draw(SpriteBatch sb)
        {
            base.Draw(sb);
        }     
        
        private void AddBullet(List<Sprite>sprites)
        {
            var bullet = Bullet.Clone() as Projectile;
            bullet.Direction = this.Direction;
            bullet.Position = this.Position;
            bullet.LinearVelocity = this.LinearVelocity * 2;
            bullet.LifeSpan = 2f;
            bullet.Parent = this;

            sprites.Add(bullet);
        }
    }
}
