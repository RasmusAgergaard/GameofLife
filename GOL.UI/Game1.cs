using System;
using GOL.BL;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GOL.UI
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        CellHandler cellHandler = new CellHandler();

        Grid grid = new Grid(100, 100);

        //Textures
        Texture2D spriteCellAlive;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 400;
            graphics.PreferredBackBufferHeight = 400;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            IsMouseVisible = true;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            spriteCellAlive = Content.Load<Texture2D>(@"alive");
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            grid = cellHandler.UpdateCells(grid);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            GraphicsDevice.Clear(Color.Black);
            

            DrawCells(grid);


            base.Draw(gameTime);
            spriteBatch.End();
        }

        private void DrawCells(Grid grid)
        {
            for (int column = 0; column < grid.Columns; column++)
            {
                for (int row = 0; row < grid.Rows; row++)
                {
                    if (grid.GridofCells[column, row].State == Cell.states.alive)
                    {
                        var gridSize = 4;
                        var columnPos = column * gridSize;
                        var rowPos = row * gridSize;
                        var position = new Vector2(columnPos, rowPos);

                        spriteBatch.Draw(spriteCellAlive, position, Color.White);
                    }
                }
            }
        }
    }
}
