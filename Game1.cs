using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Star_Rush.Class;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Documents;
namespace Star_Rush
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D tBg, tFalcon, tShot, tKirby;
        Background back;
        FalconShip falcon;
        Shot shot;
        List<Kirby> arrayKirby;
        Song bgMusic;


        private bool isGameOver = false;
        private int score = 0;
        private SpriteFont font;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            Background.graphics = graphics;
            FalconShip.graphics = graphics;
            Shot.graphics = graphics;
            Kirby.graphics = graphics;
            back = new Background();
            falcon = new FalconShip();
            shot = new Shot();

            arrayKirby = new List<Kirby>();
            for (int i = 0; i<5; i++)
            {
                arrayKirby.Add(new Kirby());
            }

            base.Initialize();
        }


        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);
            tBg = Content.Load<Texture2D>("city");
            tFalcon = Content.Load<Texture2D>("falcon");
            tShot = Content.Load<Texture2D>("shot");
            tKirby = Content.Load<Texture2D>("Kirby");
            font = Content.Load<SpriteFont>("font");
            bgMusic = Content.Load<Song>("background_2112");
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(bgMusic);
        }


        protected override void UnloadContent()
        {

        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (isGameOver)
            {
                arrayKirby.Clear();

                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {

                    for (int i = 0; i < 5; i++)
                    {
                        arrayKirby.Add(new Kirby());
                    }
                    falcon.ShipInitPosition();
                    isGameOver = false;
                }
            }
            else
            {
                falcon.ShipPotition();

                shot.ShotPosition(falcon);

                foreach (var kirby in arrayKirby)
                {
                    kirby.KirbyPosition();

                    if (kirby.boundingBox.Intersects(shot.boundingBox))
                    {
                        kirby.KirbyShotCollision(gameTime);
                        score = score + 1;
                    }

                    if (kirby.boundingBox.Intersects(falcon.boundingBox))
                    {
                        falcon.ShipCollision();
                        isGameOver = true;
                        score = 0;
                    }
                }

                for (int i = 0; i < arrayKirby.Count; i++)
                {
                    if (arrayKirby[i].GetVisible() == false)
                    {
                        arrayKirby.RemoveAt(i);
                        i--;
                        arrayKirby.Add(new Kirby());
                    }
                }

                back.MoveBg();
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(tBg, back.GetRectangle(), Color.White);
            spriteBatch.Draw(tBg, back.GetRectangle2(), Color.White);

            spriteBatch.DrawString(font, "Score: "+score, new Vector2(graphics.PreferredBackBufferWidth-100, 0), Color.White);

            falcon.ShipDraw();
            if (falcon.GetLife()) {
                spriteBatch.Draw(tFalcon, falcon.GetPosition(), falcon.GetRectangle(), falcon.GetColor(), falcon.GetRotation(), falcon.GetOrgRotation(), falcon.GetScale(), falcon.GetEffect(), 0f);
            }

            shot.ShotDraw();
                if (shot.GetVisible()==true) {
                    spriteBatch.Draw(tShot, shot.GetPosition(), shot.GetRectangle(), shot.GetColor(), shot.GetRotation(), shot.GetOrgRotation(), shot.GetScale(), shot.GetEffect(), 0f);
                }

            foreach (Kirby kirby in arrayKirby)
            {
                kirby.KirbyMoveDraw(gameTime, shot);

                if (kirby.GetVisible() == true)
                {
                    spriteBatch.Draw(tKirby, kirby.GetPosition(), kirby.GetRectangle(), kirby.GetColor(), kirby.GetRotation(), kirby.GetOrgRotation(), kirby.GetScale(), kirby.GetEffect(), 0f);
                }
                
            }

            if (isGameOver)
            {
                spriteBatch.DrawString(font, text: "Has perdido, presiona Enter para jugar de nuevo. ", position: new Vector2(0, 0), color: Color.White);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
