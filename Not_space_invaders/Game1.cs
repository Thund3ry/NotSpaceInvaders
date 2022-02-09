using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Not_space_invaders
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D myTexture;

        private Texture2D enemy1Texture;
        private Texture2D enemy2TextureUp;
        private Texture2D enemy2TextureDown;
        private Texture2D enemy3Texture;
        private Texture2D extraEnemyTexture;
        private Texture2D spriteSheet;

        private Player player1;
        private bool fired;
        private Bullet bullet;

        private const int enemyWidth = 30;
        private const int enemyHeight = 20;
        private const int gapWidth = 10;

        private Enemy[,] enemies = new Enemy[8, 5];
        private int windowWidth = 1500;

        private bool moveLeft = true;
        private bool moveRight;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 1500;
            _graphics.PreferredBackBufferHeight = 800;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here

            myTexture = Content.Load<Texture2D>("Brick");
            enemy1Texture = Content.Load<Texture2D>("Enemy1");
            enemy2TextureDown = Content.Load<Texture2D>("Enemy2ArmDown");
            enemy2TextureUp = Content.Load<Texture2D>("Enemy2ArmUp");
            enemy3Texture = Content.Load<Texture2D>("Enemy3");
            extraEnemyTexture = Content.Load<Texture2D>("EnemyExtra");
            spriteSheet = Content.Load<Texture2D>("sprite_sheet_not_space_invaders");

            player1 = new Player(myTexture, new Rectangle(Window.ClientBounds.Width/2 - myTexture.Width/2,
                Window.ClientBounds.Height - myTexture.Height*2, myTexture.Width, myTexture.Height), Color.LemonChiffon);

            bullet = new Bullet(myTexture, new Rectangle(player1.GetPosition().X + myTexture.Width / 2 - 5, player1.GetPosition().Y + 2, 10, 10), Color.Red);

            for (int i = 0; i <= enemies.GetUpperBound(0); i++)
            {
                for (int x = 0; x <= enemies.GetUpperBound(1); x++)
                {
                    if (x < 1)
                    {
                        enemies[i, x] = new Enemy(enemy3Texture, new Rectangle((myTexture.Width + gapWidth) * i + (windowWidth / 2 - ((myTexture.Width + gapWidth) * 4)),
                            (myTexture.Height + gapWidth) * x + 20, myTexture.Width, myTexture.Height), Color.White, true, enemies[i, x]);
                    }
                    else if (x < 3)
                    {
                        enemies[i, x] = new Enemy(enemy2TextureUp, new Rectangle((myTexture.Width + gapWidth) * i + (windowWidth / 2 - ((myTexture.Width + gapWidth) * 4)),
                            (myTexture.Height + gapWidth) * x + 20, myTexture.Width, myTexture.Height), Color.White, true, enemies[i, x]);
                    }
                    else
                    {
                        enemies[i, x] = new Enemy(enemy1Texture, new Rectangle((myTexture.Width + gapWidth) * i + (windowWidth / 2 - ((myTexture.Width + gapWidth) * 4)),
                            (myTexture.Height + gapWidth) * x + 20, myTexture.Width, myTexture.Height), Color.White, true, enemies[i, x]);
                    }
                }
            }
            foreach (Enemy e in enemies)
            {
                e.IsDrawn = true;
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            //moves player
            if (player1.GetPosition().X >= 0)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Left) || Keyboard.GetState().IsKeyDown(Keys.A))
                {
                    player1.SetPosition(new Rectangle(player1.GetPosition().X - 1, player1.GetPosition().Y,
                                                        myTexture.Width, myTexture.Height));
                    bullet.SetPosition(new Rectangle(bullet.GetPosition().X - 1, bullet.GetPosition().Y,
                                                        10, 10));
                }
            }
            if (player1.GetPosition().X + myTexture.Width <= Window.ClientBounds.Width)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Right) || Keyboard.GetState().IsKeyDown(Keys.D))
                {
                    player1.SetPosition(new Rectangle(player1.GetPosition().X + 1, player1.GetPosition().Y,
                                                        myTexture.Width, myTexture.Height));
                    bullet.SetPosition(new Rectangle(bullet.GetPosition().X + 1, bullet.GetPosition().Y,
                                                        10, 10));
                } 
            }

            //fires the bullet
            if (Keyboard.GetState().IsKeyDown(Keys.Space) || fired == true)
            {
                bullet.Fire (player1.GetPosition().Y, player1.GetPosition().X);
                fired = true;
                if (bullet.GetPosition().Y > player1.GetPosition().Y)
                {
                    fired = false;
                }
            }

            //determines which way the enemies should move
            if (enemies[enemies.GetLowerBound(0), 0].GetPosition().X <= 0)
            {
                moveLeft = false;
                moveRight = true;
            }
            else if (enemies[enemies.GetUpperBound(0), 0].GetPosition().X + myTexture.Width >= windowWidth)
            {
                moveLeft = true;
                moveRight = false;
            }
            //calls the subroutines that move the enemies
            if (moveLeft == true)
            {
                foreach (Enemy e in enemies)
                {
                    e.MoveLeft();
                }
            }
            if (moveRight == true)
            {
                foreach (Enemy e in enemies)
                {
                    e.MoveRight();
                }
            }

            foreach (Enemy e in enemies)
            {
                if (e.GetPosition().Intersects(bullet.GetPosition()) == true)
                {
                    e.IsDrawn = false;
                    bullet.Return(player1.GetPosition().Y, player1.GetPosition().X);
                }
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            player1.DrawSprite(_spriteBatch);
            bullet.DrawSprite(_spriteBatch);
            foreach (Enemy e in enemies)
            {
                if(e.IsDrawn == true)
                {
                    e.DrawSprite(_spriteBatch);
                }
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
