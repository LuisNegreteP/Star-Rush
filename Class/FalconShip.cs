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
    class FalconShip
    {
        public static GraphicsDeviceManager graphics;
        private Rectangle rFalcon;
        private Vector2 position;
        private float rotation;
        private Vector2 orgRotation;
        private float scale;
        private SpriteEffects effect;
        private Color color;
        private float speed = 0;
        private int i = 0;
        private int j = 0;
        private bool left = false;
        private bool up = false;
        private bool life = true;
        public Rectangle boundingBox;

        public FalconShip()
        {
            rFalcon = new Rectangle(0, 0, 65, 65);
            position = new Vector2(0, graphics.PreferredBackBufferHeight/2);
            rotation = 0f;
            orgRotation = Vector2.Zero;
            scale = 1f;
            effect = SpriteEffects.None;
            color = Color.White;
            speed = 10;
            left = false;
            up = false;
            life = true;
        }

        public void ShipPositionStable()
        {
            i = 0;
            j = 1;
            rFalcon.X = rFalcon.Width * i;
            rFalcon.Y = rFalcon.Height * j;
        }


        public void ShipDrawUp()
        {
            if (i >7)
            {
                i = 7;
            }
            j = 1;
            rFalcon.X = rFalcon.Width * i;
            rFalcon.Y = rFalcon.Height * j;

            i++;
        }


        public void ShipDrawDown()
        {
            if (i > 7)
            {
                i = 7;
            }
            j = 0;
            rFalcon.X = rFalcon.Width * i;
            rFalcon.Y = rFalcon.Height * j;

            i++;
        }

        public void ShipPotition()
        {

            boundingBox = new Rectangle((int)position.X, (int)position.Y, rFalcon.Width, rFalcon.Height);

            KeyboardState kbs = Keyboard.GetState();

            if (kbs.IsKeyDown(Keys.Right))
                if(position.X <= (graphics.PreferredBackBufferWidth - rFalcon.Width))
                    position.X += speed;
            if (kbs.IsKeyDown(Keys.Left))
                if (position.X >= 0)
                    position.X -= speed;
            


            if (kbs.IsKeyDown(Keys.Up))
                if (position.Y >= 0)
                    position.Y -= speed;
            if (kbs.IsKeyDown(Keys.Down))
                if (position.Y <= (graphics.PreferredBackBufferHeight - rFalcon.Height))
                    position.Y += speed;


            if (up && left)
            {
                if (kbs.IsKeyDown(Keys.Down) && kbs.IsKeyDown(Keys.Right))
                {
                    position.Y += (float)0.1 * speed;
                    position.X += (float)0.1 * speed;
                }

                if (kbs.IsKeyDown(Keys.Down) && kbs.IsKeyDown(Keys.Left))
                {
                    position.Y += (float)0.1 * speed;
                    position.X -= (float)0.1 * speed;
                }

                if (kbs.IsKeyDown(Keys.Up) && kbs.IsKeyDown(Keys.Right))
                {
                    position.Y -= (float)0.1 * speed;
                    position.X += (float)0.1 * speed;
                }


                if (kbs.IsKeyDown(Keys.Up) && kbs.IsKeyDown(Keys.Left))
                {
                    position.Y -= (float)0.1 * speed;
                    position.X -= (float)0.1 * speed;
                }
            }

        }

        public void ShipDraw()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                ShipDrawUp();
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                ShipDrawDown();
            }
            else
            {
                ShipPositionStable();
            }
        }

        public void ShipCollision()
        {
            life = false;
        }

        public void ShipInitPosition()
        {
            position = new Vector2(0, graphics.PreferredBackBufferHeight / 2);
            life = true;
        }

        public Rectangle GetRectangle()
        {
            return rFalcon;
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

        public bool GetLife()
        {
            return life;
        }
    }
}
