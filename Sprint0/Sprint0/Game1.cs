using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;

namespace Sprint0
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // sprite textures
        private Texture2D luigis;
        private Texture2D toad;

        // enum to represent sprite states
        public enum Sprite
        {
            fixedNonAni,
            fixedAni,
            nonFixedNonAni,
            nonFixedAni
        };
        // object to track current sprite
        public Sprite currSprite{ get; set; }

        // controllers
        private KeyboardController keyboardController;
        private MouseController mouseController;
        private ArrayList controllerList;

        //  commands
        private ICommand exitCommand;
        private ICommand nonMovNonAniCommand;
        private ICommand nonMovAniCommand;
        private ICommand movNonAniCommand;
        private ICommand movAniCommand;

        //  sprites
        private ISprite nonMovNonAniSprite;
        private ISprite nonMovAniSprite;
        private ISprite movNonAniSprite;
        private ISprite movAniSprite;
        private ISprite textSprite1;
        private ISprite textSprite2;
        private ISprite textSprite3;
        private SpriteFont font;

        // list to store sprites
        private ArrayList sprites;

        // dictionary to map enum to ISprite
        private Dictionary<Sprite, ISprite> spriteMap;

        // locations for sprites
        private int quad1X = 200;
        private int quad1Y = 120;
        private int quad2X = 600;
        private int quad2Y = 120;
        private int quad3X = 200;
        private int quad3Y = 340;
        private int quad4X = 600;
        private int quad4Y = 340;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            // initialize controllers and add them to a list
            controllerList = new ArrayList();
            keyboardController = new KeyboardController();
            mouseController = new MouseController();
            controllerList.Add(keyboardController);
            controllerList.Add(mouseController);

            // initialize commands
            exitCommand = new ExitCommand(this);
            nonMovNonAniCommand = new NonMovNonAniCommand(this);
            nonMovAniCommand = new NonMovAniCommand(this);
            movNonAniCommand = new MovNonAniCommand(this);
            movAniCommand = new MovAniCommand(this);

            // register commands to keyboard inputs
            keyboardController.RegisterCommand(Keys.D0, exitCommand);
            keyboardController.RegisterCommand(Keys.D1, nonMovNonAniCommand);
            keyboardController.RegisterCommand(Keys.D2, nonMovAniCommand);
            keyboardController.RegisterCommand(Keys.D3, movNonAniCommand);
            keyboardController.RegisterCommand(Keys.D4, movAniCommand);

            // register commands to mouse inputs
            mouseController.RegisterCommand(new Rectangle(0, 0, 640, 480), exitCommand, 1);
            mouseController.RegisterCommand(new Rectangle(0, 0, 320, 240), nonMovNonAniCommand, 0);
            mouseController.RegisterCommand(new Rectangle(320, 0, 640, 240), nonMovAniCommand, 0);
            mouseController.RegisterCommand(new Rectangle(0, 240, 400, 240), movNonAniCommand, 0);
            mouseController.RegisterCommand(new Rectangle(400, 240, 640, 240), movAniCommand, 0);
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            // load textures font for sprites from mgcb
            luigis = Content.Load<Texture2D>("luigisheet");
            toad = Content.Load<Texture2D>("toadsheet");
            font = Content.Load<SpriteFont>("Credits");

            // initialize sprites with location
            nonMovNonAniSprite = new NonMovNonAniSprite(toad, new Vector2(quad1X,quad1Y));
            nonMovAniSprite = new NonMovAniSprite(luigis, new Vector2(quad2X,quad2Y), 6,14);
            movNonAniSprite = new MovNonAniSprite(toad, new Vector2(quad3X,quad3Y));
            movAniSprite = new MovAniSprite(luigis, new Vector2(quad4X, quad4Y), 6, 14);

            // initialize text sprites with font and location
            textSprite1 = new TextSprite("Credits:", new Vector2(100, 400), font);
            textSprite2 = new TextSprite("Program Made By: Joshua Han", new Vector2(100, 420), font);
            textSprite3 = new TextSprite("Sprites from: https://www.mariomayhem.com/downloads/sprites/super_mario_bros_sprites.php", new Vector2(100, 440), font);

            // map enum values to sprites
            spriteMap = new Dictionary<Sprite, ISprite>
            {
                { Sprite.fixedNonAni, nonMovNonAniSprite },
                { Sprite.fixedAni, nonMovAniSprite },
                { Sprite.nonFixedNonAni, movNonAniSprite },
                { Sprite.nonFixedAni, movAniSprite }
            };
        }

        protected override void Update(GameTime gameTime)
        {
            // update controllers
            foreach (IController controller in controllerList)
            {
                controller.Update();
            }

            // TODO: Add your update logic here

            // update sprite based on user input
            if (spriteMap.ContainsKey(currSprite))
            {
                spriteMap[currSprite].Update();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            // begin drawing
            _spriteBatch.Begin();

            // draw sprite based on user input
            if (spriteMap.ContainsKey(currSprite))
            {
                spriteMap[currSprite].Draw(_spriteBatch);
            }

            // draw text sprites
            textSprite1.Draw(_spriteBatch);
            textSprite2.Draw(_spriteBatch);
            textSprite3.Draw(_spriteBatch);

            // end draw
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
