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
    class Shot
    {
        public static GraphicsDeviceManager graphics;
        private Rectangle rShot;
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
        public Rectangle boundingBox;

        public Shot()
        {
            rShot = new Rectangle(0, 0, 60, 16);
            position = new Vector2(0,0);
            rotation = 0f;
            orgRotation = Vector2.Zero;
            scale = 0.4f;
            effect = SpriteEffects.None;
            color = Color.White;
            speed = 20;
            visible = false;
        }

        public void ShotPosition(FalconShip falcon)
        {
            boundingBox = new Rectangle((int)position.X, (int)position.Y, rShot.Width, rShot.Height);
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                visible = true;
            }

            if (visible)
            {
               if(position.X <= (graphics.PreferredBackBufferWidth))
                {
                    position.X += speed;
                }
                else
                {
                    position.X = falcon.GetPosition().X - (falcon.GetRectangle().Width)/10;
                    position.Y = falcon.GetPosition().Y + falcon.GetRectangle().Height * (float)0.5;
                    visible = false;
                }
            }
            else
            {
                position.X = falcon.GetPosition().X + (falcon.GetRectangle().Width)/10;
                position.Y = falcon.GetPosition().Y + falcon.GetRectangle().Height * (float)0.5;
            }
        }

        public void ShotDraw()
        {
            if (visible)
            {
                if (i > 3)
                {
                    i = 3;
                }
                rShot.X = rShot.Width * i;
                rShot.Y = rShot.Height * j;
                i++;
            }
            else
            {
                i = 0;
                j = 0;
                rShot.X = rShot.Width * i;
                rShot.Y = rShot.Height * j;
            }
        }

        public bool GetVisible()
        {
            return visible;
        }

        public Rectangle GetRectangle()
        {
            return rShot;
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
    }
}
