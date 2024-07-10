using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Star_Rush.Class
{
    class Background
    {
        public static GraphicsDeviceManager graphics;
        private Rectangle rBg, rBg2;

        public Background()
        {
            rBg = new Rectangle(0,0,graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            rBg2 = new Rectangle(graphics.PreferredBackBufferWidth, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
        }

        public Rectangle GetRectangle()
        {
            return rBg;
        }

        public Rectangle GetRectangle2()
        {
            return rBg2;
        }
        
        public void MoveBg()
        {
            rBg.X--;
            rBg2.X--;

            if (rBg.X <= -graphics.PreferredBackBufferWidth)
            {
                rBg.X = graphics.PreferredBackBufferWidth;
            }

            if (rBg2.X <= -graphics.PreferredBackBufferWidth)
            {
                rBg2.X = graphics.PreferredBackBufferWidth;
            }
        }
    }
}
