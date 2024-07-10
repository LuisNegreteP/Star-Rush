using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Star_Rush.Class
{
    class Kirby
    {
        public static GraphicsDeviceManager graphics;
        private Rectangle rKirby;
        private Vector2 position;
        private float rotation;
        private Vector2 orgRotation;
        private float scale;
        private SpriteEffects effect;
        private Color color;
        private float speed = 0;
        private int i = 0;
        private int j = 0;
        private bool visible = false;
        public static Random random = new Random(DateTime.Now.Millisecond);
        public Rectangle boundingBox;

        public Kirby()
        {
            rKirby = new Rectangle(0, 0, 31, 24);
            position = new Vector2(random.Next(graphics.PreferredBackBufferWidth-200, graphics.PreferredBackBufferWidth), random.Next(0, graphics.PreferredBackBufferHeight-rKirby.Height));
            rotation = 0f;
            orgRotation = Vector2.Zero;
            scale = 1f;
            effect = SpriteEffects.FlipHorizontally;
            color = Color.White;
            speed = 2;
            visible = true;
        }

        public void KirbyMoveDraw(GameTime gameTime, Shot shot)
        {
            if (boundingBox.Intersects(shot.boundingBox))
            {
                i = 6;
                rKirby.X = rKirby.Width * i;
                rKirby.Y = rKirby.Height * j;
            }
            else
            {
                if (i > 5)
                {
                    i = 0;
                }
                j = 0;
                rKirby.X = rKirby.Width * i;
                rKirby.Y = rKirby.Height * j;
                if (gameTime.TotalGameTime.Milliseconds % 20 == 0)
                    i++;
            }
        }

        public void KirbyPosition()
        {
            boundingBox = new Rectangle((int)position.X, (int)position.Y, rKirby.Width, rKirby.Height);
            if (position.X <= (graphics.PreferredBackBufferWidth))
                position.X -= speed;
            if (position.X <= -1)
                visible = false;
        }

        public void KirbyShotCollision(GameTime gameTime)
        {
            if (gameTime.TotalGameTime.Milliseconds % 25 == 0)
                visible = false;
        }


        public Rectangle GetRectangle()
        {
            return rKirby;
        }

        public Vector2 GetPosition()
        {
            return position;
        }

        public float GetRotation()
        {
            return rotation;
        }

        public Vector2 GetOrgRotation()
        {
            return orgRotation;
        }

        public float GetScale()
        {
            return scale;
        }

        public SpriteEffects GetEffect()
        {
            return effect;
        }

        public Color GetColor()
        {
            return color;
        }

        public bool GetVisible()
        {
            return visible;
        }
    }
}
