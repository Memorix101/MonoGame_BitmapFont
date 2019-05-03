using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace monogame_bitmapfont
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private BitmapFont test;
        private BitmapFont test2;
        private int abc = 0;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            test = new BitmapFont();
            test2 = new BitmapFont();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            test.LoadContent(Content); //default charset
            test2.LoadContent(Content, "conchars_set13"); //set custom charset
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            abc++;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp);
            test2.setText("!\"#$%&0123456789:;<=>", 16, new Vector2(100, 75), Color.White, spriteBatch);
            test2.setText("!\"#$%&0123456789:;<=>", 8, new Vector2(100, 50), Color.White, spriteBatch);
            test.setText("?@ABCDEFGHIJKLMNOPQRST", 24, new Vector2(100, 100), Color.White, spriteBatch);
            test.setText("?@ABCDEFGHIJKLMNOPQRST", 64, new Vector2(100, 200), Color.OrangeRed, spriteBatch);
            test.setText("SCore:" + abc, 32, new Vector2(100, 130), Color.RoyalBlue, spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}