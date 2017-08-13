

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace SpaceMaverick
{


    /// <summary>
    ///
    /// This is the main type for your game
    /// </summary>
    ///


    public class Game1 : Microsoft.Xna.Framework.Game
    {

        public Vector2[] EnemyWeaponSpeed;
        //Start Screen
        Texture2D MenuScreen;
        public Boolean StartScreen = true;
        int score = 0;

        int AmountofRockets;


        //Texture for rockets.
        Weapon[] EnemyWeapon = new Weapon[4];
        Animation[] EnemyWeaponAnimation = new Animation[4];
        String EnemyWeaponName = "EFire";
        Texture2D Animrock;
        Texture2D Singrock;

      

        Texture2D[] BonusCollection = new Texture2D[6];

        List<PowerUp> Bonus = new List<PowerUp>();

        //Animation of startingScreen
        Texture2D Screen;
        int ScreeinIndex;
        String ScreenString;
        int levelup = 0;
        Texture2D EnemyfireA;
        Texture2D Enemyfire;

        SpriteFont Font1;
        Vector2 FontPos;

        Texture2D InstructionsScreen;

        public static Rectangle ClientWindow;

        //OurBackGround
        Texture2D background;
        Animation AnimBackground;
        Texture2D HealthBar;
        int HealthBarInt = 20;
        //Variables Needed for the MenuScreen
        Texture2D OptionsScreen;
        int OptionsScreenIndex;
        String Option;
        int TimeDelayForMenuSwitch;


        //Select Screen Stuff
        public String PlayerSelectString;
        public int PlayerSelectIndex;
        public Texture2D PlayerSelection;

        //weaponNo
        int AmountofWep1=40;
        int AmountofWep2=20;
        int AmountofWep3=10;


        //Variables for boss fight
        public bool BossFight;
        public bool BossFightWon;
        public bool SpawnBoss;
        
        int Level;
        int TimeForthislevel;
        String GameState;
        Texture2D InLevelScreen;
        public int[] SpawnTimeCollection = { 0, 2500, 2250, 2000, 1750, 1500, 1250, 1000, 750, 500 };
        public int[] TimeForThisLevel = { 0, 35, 35, 50, 50, 50, 60, 60, 50, 50 };
        public Vector2 EnemySpeed = new Vector2(0, 0);   
         

        String[] BossNames;
        Texture2D[] Boss;
        Animation[] BossAnim;
        Texture2D[] BossSingle;

        //Our SpaceShip
        MotherShip MyShip;
        Vector2 MyShipPos;
        Texture2D MotherShip;
        Texture2D ship;
        Animation myShipAnim;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public static String MotherName = "MotherShip";
        public static int MotherCount = -1;
        public static String MotherDamage = "Damage";
        public static int MotherShipIndex=1;
        public int numPressed=0;

        AudioCategory musicCategory;

        Cue menusong;
        Cue explosion;
        Cue changeMenuScreenChangeSound;
        //Cue introSong;
        Cue misileLaunch;
        Cue bgMusic1;
        Cue bgMusic2;
        Cue bgMusic3;
        Cue wandFlick;

        //Cue enemyDestroy;
        public static Cue enemyFireSound;
        Cue getBonus;

        
        //Enemy List
        private List<Enemy> EnemiesUsed;
        Texture2D[] MotherShipFire = new Texture2D[4];
        Texture2D[] MotherShipFireSingle = new Texture2D[4];
        private static int MotherShipFireIndex = 1;


        Animation EnemyAnimation;
        Texture2D[] EnemyTextureCollection = new Texture2D[10];
        Texture2D EnemyTexture;
        Animation[] EnemyAnimationCollection=new Animation[10];


        private Texture2D[] StartScreens;

        public int SpawnTime;
        int SpawnTimeElasped;
        Texture2D[] EnemyShipSpriteCollection = new Texture2D[10];
        Texture2D eship;
        String[] EnemyNames = new String[10];
        int EnemySelect;
        int EnemyWeaponNo;
        //sounds
      

        //Projectiles
        private List<Weapon> Rockets;
        private List<Weapon> Fire;
        
        String name;
        int no = 10000;

        String ResumeScene;
        public Game1()
        {
            Components.Add(new InputHandler(this));
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
           graphics.IsFullScreen = true;
            TargetElapsedTime = new TimeSpan(0, 0, 0, 0, 20);
            StartScreens = new Texture2D[12];
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content. Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            AmountofRockets = 20;
            Window.Title = "SpaceMaverick";
            Window.AllowUserResizing = true;
            IsMouseVisible = false;
            EnemiesUsed = new List<Enemy>();
            Rockets = new List<Weapon>();
            Fire = new List<Weapon>();
            Level = 1;
            TimeForthislevel = 30;
            BossFight = false;
            //sounds
            SoundHandler.Initailise();
            menusong = SoundHandler.soundBank.GetCue("menu_music");
            explosion = SoundHandler.soundBank.GetCue("player_missile_launch");
            enemyFireSound = SoundHandler.soundBank.GetCue("enemy_fire");
            bgMusic1 = SoundHandler.soundBank.GetCue("bg_music_first");
            bgMusic2 = SoundHandler.soundBank.GetCue("bg_music_second");
            bgMusic3 = SoundHandler.soundBank.GetCue("bg_music_last");
            changeMenuScreenChangeSound = SoundHandler.soundBank.GetCue("button_sound");
            musicCategory = SoundHandler.engine.GetCategory("Default");
            getBonus = SoundHandler.soundBank.GetCue("power_up");
            wandFlick =SoundHandler.soundBank.GetCue("silver_sages_intro");
            misileLaunch = SoundHandler.soundBank.GetCue("player_missile_launch");


            
            
            SoundHandler.playBackGround(menusong);
    
            SoundHandler.playBackGround(bgMusic1);
            SoundHandler.pauseSound(bgMusic1);
            SoundHandler.playBackGround(bgMusic2); 
            SoundHandler.pauseSound(bgMusic2);
            SoundHandler.playBackGround(bgMusic3);
            SoundHandler.pauseSound(bgMusic3);
        
           
            

            PlayerSelectIndex = 1;
            PlayerSelectString = "SelectShip";
            PlayerSelection = Content.Load<Texture2D>(PlayerSelectString+PlayerSelectIndex);

            TimeOnSpentOnThisLevel = 1;
            TimeDelayForMenuSwitch = 100;
            GameState = "StartingScreen";
            OptionsScreenIndex = 1;
            Option = "Options";
            SpawnTime = 3000;
            SpawnTimeElasped = 0;
            ClientWindow = Window.ClientBounds;
            randomizer = new Random();
            MyShipPos = new Vector2(Window.ClientBounds.Width / 2, Window.ClientBounds.Height -100);



            base.Initialize();

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            ResumeScene = "";

            ScreenString = "MainScreen";
            ScreeinIndex = 1;
            Screen = Content.Load<Texture2D>(ScreenString + ScreeinIndex);


            GameOver = Content.Load<Texture2D>("GameOver");


            for (int i = 0; i < 12; i++)
            {
                StartScreens[i] = Content.Load<Texture2D>(ScreenString + (i + 1));
            }

//Our Start Splash Screen
            InLevelScreen = Content.Load<Texture2D>("LevelScreen1");
            MenuScreen = Content.Load<Texture2D>("Silver Sages10000");
            //Everything About our Ship is being loaded and initialized
            ship = Content.Load<Texture2D>("MotherShip"+MotherShipIndex);
            myShipAnim = new Animation(ship, new Point(4, 1), new Point(95, 100), new Point(0, 0), 50, 1);
            
            MotherShip = Content.Load<Texture2D>("MotherShip"+MotherShipIndex+"Single");
            MyShip = new MotherShip(MyShipPos, MotherShip, myShipAnim, 100, 0, new Vector2(7,5));

            //Boss loading
            Boss = new Texture2D[9];
            BossSingle = new Texture2D[9];
            BossAnim = new Animation[9];
            BossNames = new String[9];

            for (int i = 0; i < 9; i++)
            {
                BossNames[i] = "Boss" + (i+1);

                BossSingle[i] = Content.Load<Texture2D>("Boss" + (i + 1) + "Single");
                Boss[i] = Content.Load<Texture2D>("Boss" + (i + 1));
                BossAnim[i] = new Animation(Boss[i], new Point(4, 1), new Point(BossSingle[i].Width, BossSingle[i].Height), new Point(0, 0), 50, 0);
               // Console.WriteLine("Boss" + (i + 1) + "Single");
            }
            

            InstructionsScreen = Content.Load<Texture2D>("instruction");

            //Loading Our BackGround
            background = Content.Load<Texture2D>("Background1");
            AnimBackground = new Animation(background, new Point(1, 2048), new Point(1920, 733), new Point(0, 0), 50, 1);
        
            //loading Healthbar
            HealthBar = Content.Load<Texture2D>("HealthBar" + HealthBarInt);

            OptionsScreen = Content.Load<Texture2D>(Option + OptionsScreenIndex);

            spriteBatch = new SpriteBatch(GraphicsDevice);
            Font1 = Content.Load<SpriteFont>("SpriteFont1");

            // TODO: Load your game content here
            FontPos = new Vector2(graphics.GraphicsDevice.Viewport.Width - 100, 10);


            // TODO: use this.Content to load your game content here
            //Loading the texture of the rockets
            Singrock = Content.Load<Texture2D>("Rocket1Single");
            Animrock = Content.Load<Texture2D>("Rocket1");


            for (int i = 0; i < EnemyWeapon.Length; i++)
            {
                Texture2D Temp = Content.Load<Texture2D>(EnemyWeaponName + (i + 1) + "Single");

                EnemyWeaponAnimation[i] = new Animation(Content.Load<Texture2D>(EnemyWeaponName + (i + 1)), new Point(4, 1), new Point(Content.Load<Texture2D>(EnemyWeaponName + (i + 1)).Width / 4, Content.Load<Texture2D>(EnemyWeaponName + (i + 1)).Height), new Point(0, 0), 60, 0, 0.5f);
                EnemyWeapon[i] = new Weapon(true,0,Temp, new Vector2(0, 3), EnemyWeaponAnimation[i], i + 1, Vector2.Zero, "DOWN", 1);
            }

            for (int i = 0; i < EnemyShipSpriteCollection.Length; i++)
            {
                EnemyNames[i] = "Enemy" + (i + 1);
                EnemyShipSpriteCollection[i] = Content.Load<Texture2D>("Enemy" + (i + 1));
                EnemyTextureCollection[i] = Content.Load<Texture2D>("Enemy" + (i + 1) + "Single");
            }

            for (int i = 0; i < EnemyAnimationCollection.Length; i++)
            {
                EnemyAnimationCollection[i] = new Animation(EnemyShipSpriteCollection[i], new Point(4, 1), new Point(EnemyShipSpriteCollection[i].Width / 4, EnemyShipSpriteCollection[i].Height), new Point(0, 0), 50, 0, 0);
            }

            for (int i = 0; i < MotherShipFire.Length; i++)
            {

                MotherShipFireSingle[i] = Content.Load<Texture2D>("Fire" + (i + 1) + "Single");
                MotherShipFire[i] = Content.Load<Texture2D>("Fire" + (i + 1));
            }

            for (int i = 0; i < BonusCollection.Length; i++) {

                BonusCollection[i] = Content.Load<Texture2D>("Bonus"+(i+1));
            }
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        ///
        int PlayerFiringCooldown;
        int ElaspedTimeSinceMenuSwitch;
        int TimeOnSpentOnThisLevel;
        int TimeSpentmills;
        
        int TimeDelayed;
        protected override void Update(GameTime gameTime)
        {
            KeyboardState KeyState = Keyboard.GetState();
            // Allows the game to exit
            if (KeyState.IsKeyDown(Keys.E))
                this.Exit();

            

            if (KeyState.IsKeyDown(Keys.Escape))
            {
                ResumeScene = "R";
                GameState = "MenuScreen"; 
            }

           
                if (GameState == "StartingScreen")
                {
                    TimeDelayed += gameTime.ElapsedGameTime.Milliseconds;
                    

                        if (InputHandler.KeyReleased(Keys.Enter))
                        {
                            GameState = "MenuScreen";
                            TimeDelayed = 0;
                        }
                        AnimateScreen(gameTime);
                    
                }
                else if (GameState == "MenuScreen")
                {
                    
                    KeyState = MenuScreenChanges(gameTime, KeyState);
                    //GC.Collect();
                }

                else if (GameState == "Arcade")
                {
                    SoundHandler.pauseSound(menusong);
                    if (ResumeScene == "R")
                    {

                        if (!BossFight)
                        { TimeSpentmills += gameTime.ElapsedGameTime.Milliseconds; }
                        if (TimeSpentmills > 1000)
                        {
                            TimeSpentmills = 0;
                            TimeOnSpentOnThisLevel += 1;
                        }

                        LevelTime();
                        AddBonus(gameTime);

                        if (TimeOnSpentOnThisLevel >= TimeForthislevel)
                        {
                            if (!BossFight)
                            {
                                BossFight = true;
                                EnemiesUsed.Clear();
                                Fire.Clear();
                                Rockets.Clear();
                               // GC.Collect();
                            }

                            if (BossFightWon)
                            {
                                if (levelup > 50)
                                {
                                    BossFightWon = false;
                                    BossFight = false;
                                    SpawnBoss = false;
                                    Level++;
                                    background = Content.Load<Texture2D>("Background" + Level);
                                    AnimBackground.Sheet = background;
                                    TimeOnSpentOnThisLevel = 0;
                                    GameState = "InBetweenLevel";
                                    MyShipPos = new Vector2(Window.ClientBounds.Width / 2, Window.ClientBounds.Height - 100);
                                    levelup = 0;
                                }
                                else {
                                    levelup++;
                                }
                               
                               
                               // GC.Collect();
                            }

                        }

                        if (MotherCount < 0)
                        {
                            MotherDamage = "";
                            myShipAnim.SheetSize.Y = 1;
                        }
                        else
                        {
                            MotherDamage = "Damage";
                            myShipAnim.SheetSize.Y = 2;

                            MotherCount--;
                        }

                        ChooseWeapon();
                        MyShip.Update(gameTime);
                        ship = Content.Load<Texture2D>(MotherName);
                        myShipAnim.Sheet = ship;

                        MyShip.InBoundry(Window.ClientBounds.Width, Window.ClientBounds.Height);

                        //For projectile Updating and Creating
                        PlayerFiringCooldown = PlayerFiringCooldown + gameTime.ElapsedGameTime.Milliseconds;
                        KeyState = UpdatePlayerProjectiles(gameTime, KeyState);
                        // End of Projectile Code
                        AnimBackground.UpdateB(gameTime, new Vector2(0, 0));

                        if (MyShip.Health > 5)
                        {
                            HealthBarInt = HealthbarInt(MyShip.Health);
                            HealthBar = Content.Load<Texture2D>("HealthBar" + HealthBarInt);
                        }
                        //Code For Enemies
                        AddEnemy(gameTime);
                        UpdateEnemies(gameTime);
                        CheckCollision();
                    }
                    else
                    {
                         if (InputHandler.KeyReleased(Keys.Right))
                            {
                                
                                SoundHandler.playSound(changeMenuScreenChangeSound);
                                PlayerSelectIndex++;
                                if (PlayerSelectIndex > 2)
                                {
                                    PlayerSelectIndex = 1;
                                }

                                PlayerSelection = Content.Load<Texture2D>(PlayerSelectString + PlayerSelectIndex);
                            }
                            else if (InputHandler.KeyReleased(Keys.Left))
                            {
                                SoundHandler.playSound(changeMenuScreenChangeSound);
                                PlayerSelectIndex--;
                                if (PlayerSelectIndex < 1)
                                {
                                    PlayerSelectIndex = 2;
                                }

                                PlayerSelection = Content.Load<Texture2D>(PlayerSelectString + PlayerSelectIndex);
                            }

                            if (InputHandler.KeyReleased(Keys.Enter))
                            {
                                ResumeScene = "R";
                                MotherShipIndex = PlayerSelectIndex;
                                GameState = "InBetweenLevel";

                            }
                        }



                    
                }
                else if (GameState == "InBetweenLevel")
                {

                    InLevelScreen = Content.Load<Texture2D>("LevelScreen" + Level);
                    TimeDelayed += gameTime.ElapsedGameTime.Milliseconds;
                    if (TimeDelayed > 200)
                    {
                        //GC.Collect();
                        if (InputHandler.KeyReleased(Keys.Enter))
                        {
                            TimeDelayed = 0;
                            AmountofRockets = 20;
                            MyShip.Health = 100;
                            GameState = "Arcade";
                            ResumeScene = "R";
                        }
                    }
                }

                else if (GameState == "Instructions")
                {
                    SoundHandler.resumeSound(menusong);
                    TimeDelayed += gameTime.ElapsedGameTime.Milliseconds;
                    if (TimeDelayed > 300)
                    {

                        //GC.Collect();
                        if (KeyState.IsKeyDown(Keys.Enter))
                        {
                            TimeDelayed = 0;
                            GameState = "MenuScreen";
                        }
                    }
                }
                else if (GameState == "GameOver")
                {
                    GameOver = Content.Load<Texture2D>("GameOver");
          
                    if (InputHandler.KeyReleased(Keys.Enter))
                        {
                            TimeDelayed = 0;
                            GameState = "StartingScreen";
                            Level = 1;
                            EnemiesUsed.Clear();
                            Fire.Clear();
                            Rockets.Clear();
                            ResumeScene = "";
                            score = 0;
                            MyShip.Health = 100;
                            TimeOnSpentOnThisLevel = 0;

                        }             
                
                }


            //}
            base.Update(gameTime);

        }
        int bonuschance;
        int choosebonus;
        public int BonusDelay;
        private void AddBonus(GameTime gameTime)
        {
            if (!BossFight)
            {
                BonusDelay += gameTime.ElapsedGameTime.Milliseconds;
                if (BonusDelay > 4000)
                {
                    BonusDelay = 0;
                    bonuschance = randomizer.Next(0, 3);
                    if (bonuschance == 1 )
                    {
                        choosebonus = randomizer.Next(0, 6);
                        Bonus.Add(new PowerUp(BonusCollection[choosebonus], new Vector2(randomizer.Next(30, Window.ClientBounds.Width - BonusCollection[choosebonus].Width - 30), -BonusCollection[choosebonus].Height), new Vector2(0, 3), choosebonus));
                    }

                }
            }

        }

        Texture2D GameOver;

        int framecheck;

        public void ChooseWeapon(){
        if(InputHandler.KeyReleased(Keys.D1)){
        numPressed=0;
        }else if(InputHandler.KeyReleased(Keys.D2)){
        numPressed=1;
        }else if(InputHandler.KeyReleased(Keys.D3)){
        numPressed=2;
        }else if(InputHandler.KeyReleased(Keys.D4)){
        numPressed=3;
        }

        }

        public void AnimateScreen(GameTime gameTime)
        {
            framecheck += gameTime.ElapsedGameTime.Milliseconds;
            if( framecheck >= 50)
            {
                framecheck = 0;
                ScreeinIndex++;
                if (ScreeinIndex > 11)
                {
                    ScreeinIndex = 0;
                }
                Screen = StartScreens[ScreeinIndex];
            }
        }

        private void LevelTime()
        {
             TimeForthislevel = TimeForThisLevel[Level];
             
        }

        

        private KeyboardState MenuScreenChanges(GameTime gameTime, KeyboardState KeyState)
        {
                  if (InputHandler.KeyReleased(Keys.Down))
                    {
                        

                        SoundHandler.playSound(changeMenuScreenChangeSound);
                        //SoundHandler.pauseSound(menusong);

                        OptionsScreenIndex++;
                        if (OptionsScreenIndex > 3)
                        {
                            OptionsScreenIndex = 1;
                        }

                        OptionsScreen = Content.Load<Texture2D>(ResumeScene + Option + OptionsScreenIndex);
                    }
                    else if (InputHandler.KeyReleased(Keys.Up))
                    {
                        SoundHandler.playSound(changeMenuScreenChangeSound);
                        OptionsScreenIndex--;
                        if (OptionsScreenIndex < 1)
                        {
                            OptionsScreenIndex = 3;
                        }

                        OptionsScreen = Content.Load<Texture2D>(ResumeScene + Option + OptionsScreenIndex);
                    }
                


                if (InputHandler.KeyReleased(Keys.Enter))
                {
                    if (OptionsScreenIndex == 1)
                    {

                        GameState = "Arcade";

                    }
                    else if (OptionsScreenIndex == 3)
                    {
                        this.Exit();
                    }
                    else if (OptionsScreenIndex == 2)
                    {
                        GameState = "Instructions";
                    }

                }
                
            
            return KeyState;
        }

        private KeyboardState UpdatePlayerProjectiles(GameTime gameTime, KeyboardState KeyState)
        {

            if ((KeyState.IsKeyDown(Keys.LeftControl) || KeyState.IsKeyDown(Keys.RightControl) )&& (PlayerFiringCooldown > 500))
            {

                    SoundHandler.playSound(misileLaunch);
                    AddProjectile();
                    PlayerFiringCooldown = 0;
                
            }

            if (KeyState.IsKeyDown(Keys.Space) && (PlayerFiringCooldown > 150))
            {

                AddFire();
                PlayerFiringCooldown = 0;
            }


            if (Rockets.Count > 0)
            {
                for (int i = Rockets.Count - 1; i >= 0; i--)
                {
                    Rockets[i].Update(gameTime);
                    if (Rockets[i].Damage < 0)
                    {
                        Rockets[i].Active = false;
                    }
                    if (!Rockets[i].Active)
                    {
                        Rockets[i] = null;
                        Rockets.RemoveAt(i);
                       // GC.Collect();
                    }


                }
            }
            if (Fire.Count > 0)
            {
                for (int i = Fire.Count - 1; i >= 0; i--)
                {
                    Fire[i].Update(gameTime);
                    if (!Fire[i].Active)
                    {
                        Fire[i] = null;
                        Fire.RemoveAt(i);
                        //GC.Collect();
                    
                    }


                }
            }

            return KeyState;
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            //Draw Display Screen or Splash Screen This will be our silverSages Screen for 5 Seconds And after that Draw our Ship at the center.


            if (no < 10041)
            {
                name = "Silver Sages" + no;
                no += 1;
                if (no == 10020)
                {
                  
                    SoundHandler.playSound(wandFlick);
                }
            }


            if (!DisplayScreen(gameTime))
            {

                if (GameState == "StartingScreen")
                {
                    spriteBatch.Draw( Screen, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                
                }
                else if (GameState == "MenuScreen")
                {
                    spriteBatch.Draw(OptionsScreen, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                }
                else if (GameState == "Arcade")
                {

                    //Draw Healthbar
                    if (ResumeScene == "R")
                    {
                        spriteBatch.Draw(HealthBar, new Vector2(Window.ClientBounds.Width- HealthBar.Width-40, 0), null, Color.White, 0, new Vector2(0, 0), 1, SpriteEffects.None, 0.9f);



                        //Draw Our MotherShip
                        MyShip.Draw(spriteBatch, gameTime);
                        //Draw All the Bullets and Rockets on the Screen
                        DrawProjectiles();
                        //Draw All the enemies
                        DrawEnemies(gameTime);
                        AnimBackground.DrawB(spriteBatch);
                        String output = "Score: " + score;

                        // Find the center of the string
                        Vector2 FontOrigin = Font1.MeasureString(output) / 2;
                        // Draw the string
                        spriteBatch.DrawString(Font1, output, new Vector2(60, 40), Color.LightGreen,
                        0, FontOrigin, 1.0f, SpriteEffects.None, 0.5f);

                        //spriteBatch.Draw(HealthBar, new Vector2(graphics.GraphicsDevice.Viewport.Width - 110, 40), Color.White);
                        //spriteBatch.DrawString(Font1, "Health: " + MyShip.Health, new Vector2(graphics.GraphicsDevice.Viewport.Width - 110, 40), Color.LightGreen,
                        //0, FontOrigin, 1.0f, SpriteEffects.None, 0.5f);
                        spriteBatch.DrawString(Font1, "Time Left till Boss:" + (TimeForthislevel - TimeOnSpentOnThisLevel), new Vector2(60, 20), Color.LightGreen,
                        0, FontOrigin, 1.0f, SpriteEffects.None, 0.5f);
                        spriteBatch.DrawString(Font1, "Level: " + Level , new Vector2(graphics.GraphicsDevice.Viewport.Width / 2, 20), Color.LightGreen,
                        0, FontOrigin, 1.0f, SpriteEffects.None, 0.5f);
              

                        for (int i = 0; i < BonusCollection.Length-2;i++)
                        {
                            if (i < 2)
                            {
                                spriteBatch.Draw(BonusCollection[i + 2], new Rectangle(130 * (i)+10, graphics.GraphicsDevice.Viewport.Height - 100, BonusCollection[i+2].Width, BonusCollection[i+2].Height), Color.White);
                            }
                            else {
                                spriteBatch.Draw(BonusCollection[i + 2], new Rectangle(130 * (i-2) + 10, graphics.GraphicsDevice.Viewport.Height - 50, BonusCollection[i].Width, BonusCollection[i].Height), Color.White);
                            
                            }
                            
                            }
                        spriteBatch.DrawString(Font1, "" + AmountofRockets, new Vector2(120, graphics.GraphicsDevice.Viewport.Height - 80), Color.LightGreen,
                       0, FontOrigin, 1.0f, SpriteEffects.None, 0.5f);
                        spriteBatch.DrawString(Font1, ""+AmountofWep1, new Vector2(250, graphics.GraphicsDevice.Viewport.Height-80), Color.LightGreen,
                        0, FontOrigin, 1.0f, SpriteEffects.None, 0.5f);

                        spriteBatch.DrawString(Font1, "" + AmountofWep2, new Vector2(120, graphics.GraphicsDevice.Viewport.Height - 30), Color.LightGreen,
                        0, FontOrigin, 1.0f, SpriteEffects.None, 0.5f);

                        spriteBatch.DrawString(Font1, "" + AmountofWep3, new Vector2(250, graphics.GraphicsDevice.Viewport.Height - 30), Color.LightGreen,
                        0, FontOrigin, 1.0f, SpriteEffects.None, 0.5f);
                        
                        if (numPressed == 1) {
                            spriteBatch.Draw(Content.Load<Texture2D>("Bonus4s"), new Rectangle(130 * (1) + 10, graphics.GraphicsDevice.Viewport.Height - 100, BonusCollection[3].Width, BonusCollection[3].Height), Color.White);
                            
                        }
                        else if (numPressed == 2) {
                            spriteBatch.Draw(Content.Load<Texture2D>("Bonus5s"), new Rectangle(130 * (0) + 10, graphics.GraphicsDevice.Viewport.Height - 50, BonusCollection[4].Width, BonusCollection[4].Height), Color.White);
                           
                        }
                        else if (numPressed == 3) {
                            spriteBatch.Draw(Content.Load<Texture2D>("Bonus6s"), new Rectangle(130 * (1) + 10, graphics.GraphicsDevice.Viewport.Height - 50, BonusCollection[5].Width, BonusCollection[5].Height), Color.White);
                           
                        }


                    }

                    else
                    {
                        spriteBatch.Draw(PlayerSelection, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                    }
                }
                else if (GameState == "InBetweenLevel")
                {
                    InLevelScreen = Content.Load<Texture2D>("LevelScreen"+Level);
                    spriteBatch.Draw(InLevelScreen, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                    

                }
                else if (GameState == "Instructions")
                {
                    spriteBatch.Draw(InstructionsScreen, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                    
                }
                else if (GameState == "GameOver")
                {
                    spriteBatch.Draw(GameOver, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                 
                }
            }





            // Draw Hello World



            spriteBatch.End();
            // TODO: Add your drawing code here
            
            base.Draw(gameTime);
        }

        private void DrawEnemies(GameTime gameTime)
        {
            for (int i = EnemiesUsed.Count - 1; i >= 0; i--)
            {
                EnemiesUsed[i].Draw(spriteBatch, gameTime);

            }

         
        }

        private void DrawProjectiles()
        {
            for (int i = Rockets.Count - 1; i >= 0; i--)
            {

                Rockets[i].Draw(spriteBatch);

            }

            for (int i = Fire.Count - 1; i >= 0; i--)
            {

                Fire[i].Draw(spriteBatch);

            }


            for (int i = 0; i < Bonus.Count; i++)
            {
                Bonus[i].Draw(spriteBatch);

            }
        }

        private bool DisplayScreen(GameTime gameTime)
        {

            int TimePerFrame = 4;
            int TimeSinceLastFrame = 0;
            if (!StartScreen)
            {
                return false;
            }

            if (gameTime.TotalGameTime.Seconds < 4)
            {
                TimeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
                if (TimeSinceLastFrame > TimePerFrame)
                {
                    TimeSinceLastFrame = 0;

                    MenuScreen = Content.Load<Texture2D>(name);
                    spriteBatch.Draw(MenuScreen, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                    return true;
                }
            }
            else
            {
                StartScreen = false;
                //Console.WriteLine("Done");
            }
            return false;

        }



        Random randomizer;
        Vector2 EnemLocation;
        int EnemHealth;
        int[] EnemyStuff;
        Vector2 EnemSpeed;
        Weapon EnemWeapon;
        int EnemFireDelay;
        int EnemyAmountOfFire;
        int[] EnemyFireOffset;
        int AmountOfEnemyToSpawnSimultaneouly;
        String EnemyName;
        int Switheroo;

        private void AddEnemy(GameTime gameTime)
        {

            SpawnTimes(Level);

            SpawnTimeElasped += gameTime.ElapsedGameTime.Milliseconds;

            if (SpawnTimeElasped >= SpawnTime)
            {

                SpawnTimeElasped = 0;
                if (!BossFight)
                {
                    if (Level == 1)
                    {

                        SoundHandler.resumeSound(bgMusic1);

                        if (Switheroo == 0)
                        {

                            EnemySpeed.X = 1;
                            EnemySpeed.Y = 1;
                            EnemySelect = 0;//put the enemy no here(0-9)
                            EnemyWeaponNo = 2;//put the weapon no here(0-3)
                            this.eship = EnemyShipSpriteCollection[EnemySelect]; // SpriteSheet
                            EnemyStuff = new int[1];
                            EnemyStuff[0] = EnemyTextureCollection[EnemySelect].Width/2;
                            
                            SetLevelEnemyDetails(EnemyShipSpriteCollection[EnemySelect], EnemyAnimationCollection[EnemySelect], EnemyTextureCollection[EnemySelect], new Vector2(0 , -EnemyShipSpriteCollection[EnemySelect].Height),
                            3, EnemySpeed, 2000, EnemyStuff.Length, EnemyStuff, 2, EnemyNames[EnemySelect], 1, EnemyWeapon[EnemyWeaponNo]);
                        }
                        else
                        {

                            EnemySpeed.X = -1;
                            EnemySpeed.Y = 1;
                            EnemySelect = 1;//put the enemy no here(0-9)
                            EnemyWeaponNo = 2;//put the weapon no here(0-3)
                            this.eship = EnemyShipSpriteCollection[EnemySelect]; // SpriteSheet
                            EnemyStuff = new int[2];
                            EnemyStuff = new int[1];
                            EnemyStuff[0] = EnemyTextureCollection[EnemySelect].Width / 2;
                            SetLevelEnemyDetails(EnemyShipSpriteCollection[EnemySelect], EnemyAnimationCollection[EnemySelect], EnemyTextureCollection[EnemySelect], new Vector2(Window.ClientBounds.Width, -EnemyShipSpriteCollection[EnemySelect].Height),

                            3, EnemySpeed, 3000, EnemyStuff.Length, EnemyStuff, 2, EnemyNames[EnemySelect], 0, EnemyWeapon[EnemyWeaponNo]);

                        }

                    }
                    else if (Level == 2)
                    {
                        SoundHandler.pauseSound(bgMusic1);
                        SoundHandler.resumeSound(bgMusic2);                        
                        if (Switheroo == 0)
                        {
                            EnemySpeed.X = 0;
                            EnemySpeed.Y = 1;
                            EnemySelect = 0;//put the enemy no here(0-9)
                            EnemyWeaponNo = 1;//put the weapon no here(0-3)
                            this.eship = EnemyShipSpriteCollection[EnemySelect]; // SpriteSheet
                            EnemyStuff = new int[2];
                            EnemyStuff[0] = 5;
                            EnemyStuff[1] = (EnemyTextureCollection[EnemySelect].Width) - 5;
                            SetLevelEnemyDetails(EnemyShipSpriteCollection[EnemySelect], EnemyAnimationCollection[EnemySelect], EnemyTextureCollection[EnemySelect], /*Controls the spawn location of the enemy */ new Vector2(randomizer.Next(0, Window.ClientBounds.Width - (EnemyShipSpriteCollection[EnemySelect].Width / 4) - 5), -EnemyShipSpriteCollection[EnemySelect].Height),

                            /*enemys Health */ 5, EnemySpeed, /*Delay in fire*/ 3000, EnemyStuff.Length, EnemyStuff, /*Enemies to spawn simultaneously*/2, EnemyNames[EnemySelect], /*Switeroo*/1, EnemyWeapon[EnemyWeaponNo]);
                        }
                        else if (Switheroo == 1)
                        {

                            EnemySpeed.X = 0;
                            EnemySpeed.Y = 1;
                            EnemySelect = 1;//put the enemy no here(0-9)
                            EnemyWeaponNo = 2;//put the weapon no here(0-3)
                            this.eship = EnemyShipSpriteCollection[EnemySelect]; // SpriteSheet
                            EnemyStuff = new int[2];
                            EnemyStuff[0] = 5;
                            EnemyStuff[1] = (EnemyTextureCollection[EnemySelect].Width) - 5;
                            SetLevelEnemyDetails(EnemyShipSpriteCollection[EnemySelect], EnemyAnimationCollection[EnemySelect], EnemyTextureCollection[EnemySelect], new Vector2(randomizer.Next(0, Window.ClientBounds.Width - (EnemyShipSpriteCollection[EnemySelect].Width / 4) - 5), -EnemyShipSpriteCollection[EnemySelect].Height),

                            5, EnemySpeed, 3000, EnemyStuff.Length, EnemyStuff, 2, EnemyNames[EnemySelect], 2, EnemyWeapon[EnemyWeaponNo]);

                        }

                        else if (Switheroo == 2)
                        {

                            EnemySpeed.X = 0;
                            EnemySpeed.Y = 2;
                            EnemySelect = 2;//put the enemy no here(0-9)
                            EnemyWeaponNo = 3;//put the weapon no here(0-3)
                            this.eship = EnemyShipSpriteCollection[EnemySelect]; // SpriteSheet
                            EnemyStuff = new int[2];
                            EnemyStuff[0] = 5;
                            EnemyStuff[1] = (EnemyTextureCollection[EnemySelect].Width) - 10;
                            SetLevelEnemyDetails(EnemyShipSpriteCollection[EnemySelect], EnemyAnimationCollection[EnemySelect], EnemyTextureCollection[EnemySelect], new Vector2(randomizer.Next(0, Window.ClientBounds.Width - (EnemyShipSpriteCollection[EnemySelect].Width / 4) - 5), -EnemyShipSpriteCollection[EnemySelect].Height),

                            4, EnemySpeed, 3000, EnemyStuff.Length, EnemyStuff, 1, EnemyNames[EnemySelect], 0, EnemyWeapon[EnemyWeaponNo]);

                        }
                    }
                    else if (Level == 3)
                    {
                        SoundHandler.pauseSound(bgMusic1);
                        SoundHandler.pauseSound(bgMusic2);
                        SoundHandler.resumeSound(bgMusic3);

                        if (Switheroo == 0)
                        {

                            EnemySpeed.X = 0;
                            EnemySpeed.Y = 1;
                            EnemySelect = 3;//put the enemy no here(0-9)
                            EnemyWeaponNo = 2;//put the weapon no here(0-3)
                            this.eship = EnemyShipSpriteCollection[EnemySelect]; // SpriteSheet

                            EnemyStuff = new int[2]; //number of enemyfire
                            EnemyStuff[0] = 5;    //ofsett
                            EnemyStuff[1] = (EnemyTextureCollection[EnemySelect].Width) - 5;//offset
                            SetLevelEnemyDetails(EnemyShipSpriteCollection[EnemySelect], EnemyAnimationCollection[EnemySelect], EnemyTextureCollection[EnemySelect], new Vector2(randomizer.Next(0, Window.ClientBounds.Width - (EnemyShipSpriteCollection[EnemySelect].Width / 4) - 5), -EnemyShipSpriteCollection[EnemySelect].Height),

                            5/*health*/, EnemySpeed/*speed*/, 3000/*delay in firing */, EnemyStuff.Length, EnemyStuff, 3/*enemies to spawn simultaniously*/, EnemyNames[EnemySelect], 1, EnemyWeapon[EnemyWeaponNo]);
                        }
                        else if (Switheroo == 1)
                        {

                            EnemySpeed.X = 1;
                            EnemySpeed.Y = 2;
                            EnemySelect = 5;//put the enemy no here(0-9)
                            EnemyWeaponNo = 1;//put the weapon no here(0-3)
                            this.eship = EnemyShipSpriteCollection[EnemySelect]; // SpriteSheet

                            EnemyStuff = new int[2];
                            EnemyStuff[0] = 5;
                            EnemyStuff[1] = (EnemyTextureCollection[EnemySelect].Width) - 5;
                            SetLevelEnemyDetails(EnemyShipSpriteCollection[EnemySelect], EnemyAnimationCollection[EnemySelect], EnemyTextureCollection[EnemySelect], new Vector2(randomizer.Next(0, Window.ClientBounds.Width - (EnemyShipSpriteCollection[EnemySelect].Width / 4) - 5), -EnemyShipSpriteCollection[EnemySelect].Height),

                            2, EnemySpeed, 3000, EnemyStuff.Length, EnemyStuff, 3, EnemyNames[EnemySelect], 2, EnemyWeapon[EnemyWeaponNo]);

                        }
                        else if (Switheroo == 2)
                        {

                            EnemySpeed.X = 2;
                            EnemySpeed.Y = 2;
                            EnemySelect = 1;//put the enemy no here(0-9)
                            EnemyWeaponNo = 3;//put the weapon no here(0-3)
                            this.eship = EnemyShipSpriteCollection[EnemySelect]; // SpriteSheet
                            EnemyStuff = new int[2];
                            EnemyStuff[0] = 5;
                            EnemyStuff[1] = (EnemyTextureCollection[EnemySelect].Width) - 10;
                            SetLevelEnemyDetails(EnemyShipSpriteCollection[EnemySelect], EnemyAnimationCollection[EnemySelect], EnemyTextureCollection[EnemySelect], new Vector2(randomizer.Next(0, Window.ClientBounds.Width - (EnemyShipSpriteCollection[EnemySelect].Width / 4) - 5), -EnemyShipSpriteCollection[EnemySelect].Height),

                            1, EnemySpeed, 1000, EnemyStuff.Length, EnemyStuff, 1, EnemyNames[EnemySelect], 0, EnemyWeapon[EnemyWeaponNo]);
                        }

                    }

                    else if (Level == 4)
                    {
                        SoundHandler.resumeSound(bgMusic1);
                        SoundHandler.pauseSound(bgMusic2);
                        SoundHandler.pauseSound(bgMusic3);

                        if (Switheroo == 0)
                        {

                            EnemySpeed.X = -1;
                            EnemySpeed.Y = 1;
                            EnemySelect = 2;//put the enemy no here(0-9)
                            EnemyWeaponNo = 2;//put the weapon no here(0-3)
                            this.eship = EnemyShipSpriteCollection[EnemySelect]; // SpriteSheet

                            EnemyStuff = new int[2];
                            EnemyStuff[0] = 5;
                            EnemyStuff[1] = (EnemyTextureCollection[EnemySelect].Width) - 5;
                            SetLevelEnemyDetails(EnemyShipSpriteCollection[EnemySelect], EnemyAnimationCollection[EnemySelect], EnemyTextureCollection[EnemySelect], new Vector2(randomizer.Next(0, Window.ClientBounds.Width - (EnemyShipSpriteCollection[EnemySelect].Width / 4) - 5), -EnemyShipSpriteCollection[EnemySelect].Height),

                            2, EnemySpeed, 3500, EnemyStuff.Length, EnemyStuff, 3, EnemyNames[EnemySelect], 1, EnemyWeapon[EnemyWeaponNo]);
                        }
                        else if (Switheroo == 1)
                        {

                            EnemySpeed.X = 0;
                            EnemySpeed.Y = 2;
                            EnemySelect = 4;//put the enemy no here(0-9)
                            EnemyWeaponNo = 1;//put the weapon no here(0-3)
                            this.eship = EnemyShipSpriteCollection[EnemySelect]; // SpriteSheet

                            EnemyStuff = new int[2];
                            EnemyStuff[0] = 5;
                            EnemyStuff[1] = (EnemyTextureCollection[EnemySelect].Width) - 5;
                            SetLevelEnemyDetails(EnemyShipSpriteCollection[EnemySelect], EnemyAnimationCollection[EnemySelect], EnemyTextureCollection[EnemySelect], new Vector2(randomizer.Next(0, Window.ClientBounds.Width - (EnemyShipSpriteCollection[EnemySelect].Width / 4) - 5), -EnemyShipSpriteCollection[EnemySelect].Height),

                            2, EnemySpeed, 3000, EnemyStuff.Length, EnemyStuff, 3, EnemyNames[EnemySelect], 2, EnemyWeapon[EnemyWeaponNo]);

                        }
                        else if (Switheroo == 2)
                        {

                            EnemySpeed.X = 0;
                            EnemySpeed.Y = 1;
                            EnemySelect = 6;//put the enemy no here(0-9)
                            EnemyWeaponNo = 3;//put the weapon no here(0-3)
                            this.eship = EnemyShipSpriteCollection[EnemySelect]; // SpriteSheet

                            EnemyStuff = new int[2];
                            EnemyStuff[0] = 5;
                            EnemyStuff[1] = (EnemyTextureCollection[EnemySelect].Width) - 5;
                            SetLevelEnemyDetails(EnemyShipSpriteCollection[EnemySelect], EnemyAnimationCollection[EnemySelect], EnemyTextureCollection[EnemySelect], new Vector2(randomizer.Next(0, Window.ClientBounds.Width - (EnemyShipSpriteCollection[EnemySelect].Width / 4) - 5), -EnemyShipSpriteCollection[EnemySelect].Height),

                            3, EnemySpeed, 3000, EnemyStuff.Length, EnemyStuff, 2, EnemyNames[EnemySelect], 0, EnemyWeapon[EnemyWeaponNo]);

                        }

                    }

                    else if (Level == 5)
                    {
                        SoundHandler.pauseSound(bgMusic1);
                        SoundHandler.resumeSound(bgMusic2);
                        SoundHandler.pauseSound(bgMusic3);

                        if (Switheroo == 0)
                        {

                            EnemySpeed.X = 1;
                            EnemySpeed.Y = 1;
                            EnemySelect = 7;//put the enemy no here(0-9)
                            EnemyWeaponNo = 1;//put the weapon no here(0-3)
                            this.eship = EnemyShipSpriteCollection[EnemySelect]; // SpriteSheet

                            EnemyStuff = new int[2];
                            EnemyStuff[0] = 5;
                            EnemyStuff[1] = (EnemyTextureCollection[EnemySelect].Width) - 5;
                            SetLevelEnemyDetails(EnemyShipSpriteCollection[EnemySelect], EnemyAnimationCollection[EnemySelect], EnemyTextureCollection[EnemySelect], new Vector2(randomizer.Next(0, Window.ClientBounds.Width / 2), randomizer.Next(0, 100)),

                            3, EnemySpeed, 5000, EnemyStuff.Length, EnemyStuff, 3, EnemyNames[EnemySelect], 1, EnemyWeapon[EnemyWeaponNo]);
                        }
                        else
                        {

                            EnemySpeed.X = -1;
                            EnemySpeed.Y = 2;
                            EnemySelect = 4;//put the enemy no here(0-9)
                            EnemyWeaponNo = 2;//put the weapon no here(0-3)
                            this.eship = EnemyShipSpriteCollection[EnemySelect]; // SpriteSheet

                            EnemyStuff = new int[2];
                            EnemyStuff[0] = 5;
                            EnemyStuff[1] = (EnemyTextureCollection[EnemySelect].Width) - 5;
                            SetLevelEnemyDetails(EnemyShipSpriteCollection[EnemySelect], EnemyAnimationCollection[EnemySelect], EnemyTextureCollection[EnemySelect], new Vector2(randomizer.Next(0, Window.ClientBounds.Width - (EnemyShipSpriteCollection[EnemySelect].Width / 4) - 5), -EnemyShipSpriteCollection[EnemySelect].Height),

                            1, EnemySpeed, 3000, EnemyStuff.Length, EnemyStuff, 3, EnemyNames[EnemySelect], 0, EnemyWeapon[EnemyWeaponNo]);

                        }
                    }

                    else if (Level == 6)
                    {
                        SoundHandler.pauseSound(bgMusic1);
                        SoundHandler.pauseSound(bgMusic2);
                        SoundHandler.resumeSound(bgMusic3);


                        if (Switheroo == 0)
                        {

                            EnemySpeed.X = 0;
                            EnemySpeed.Y = 1;
                            EnemySelect = 8;//put the enemy no here(0-9)
                            EnemyWeaponNo = 2;//put the weapon no here(0-3)
                            this.eship = EnemyShipSpriteCollection[EnemySelect]; // SpriteSheet

                            EnemyStuff = new int[2];
                            EnemyStuff[0] = 5;
                            EnemyStuff[1] = (EnemyTextureCollection[EnemySelect].Width) - 5;
                            SetLevelEnemyDetails(EnemyShipSpriteCollection[EnemySelect], EnemyAnimationCollection[EnemySelect], EnemyTextureCollection[EnemySelect], new Vector2(randomizer.Next(0, Window.ClientBounds.Width - (EnemyShipSpriteCollection[EnemySelect].Width / 4) - 5), -EnemyShipSpriteCollection[EnemySelect].Height),

                            2, EnemySpeed, 3000, EnemyStuff.Length, EnemyStuff, 2, EnemyNames[EnemySelect], 1, EnemyWeapon[EnemyWeaponNo]);
                        }
                        else if (Switheroo == 1)
                        {

                            EnemySpeed.X = -1;
                            EnemySpeed.Y = 1;
                            EnemySelect = 4;//put the enemy no here(0-9)
                            EnemyWeaponNo = 1;//put the weapon no here(0-3)
                            this.eship = EnemyShipSpriteCollection[EnemySelect]; // SpriteSheet

                            EnemyStuff = new int[2];
                            EnemyStuff[0] = 5;
                            EnemyStuff[1] = (EnemyTextureCollection[EnemySelect].Width) - 5;
                            SetLevelEnemyDetails(EnemyShipSpriteCollection[EnemySelect], EnemyAnimationCollection[EnemySelect], EnemyTextureCollection[EnemySelect], new Vector2(randomizer.Next(0, Window.ClientBounds.Width - (EnemyShipSpriteCollection[EnemySelect].Width / 4) - 5), -EnemyShipSpriteCollection[EnemySelect].Height),

                            2, EnemySpeed, 3000, EnemyStuff.Length, EnemyStuff, 3, EnemyNames[EnemySelect], 2, EnemyWeapon[EnemyWeaponNo]);

                        }
                        else if (Switheroo == 2)
                        {

                            EnemySpeed.X = 2; //Controls X of the enemy's speed
                            EnemySpeed.Y = 2; //Controls Y of the enemy's speed
                            EnemySelect = 2;//put the enemy no here(0-9)
                            EnemyWeaponNo = 3;//put the weapon no here(0-3)
                            this.eship = EnemyShipSpriteCollection[EnemySelect]; // SpriteSheet

                            EnemyStuff = new int[2];
                            EnemyStuff[0] = 5;
                            EnemyStuff[1] = (EnemyTextureCollection[EnemySelect].Width) - 5;
                            SetLevelEnemyDetails(EnemyShipSpriteCollection[EnemySelect], EnemyAnimationCollection[EnemySelect], EnemyTextureCollection[EnemySelect], new Vector2(randomizer.Next(0, Window.ClientBounds.Width - (EnemyShipSpriteCollection[EnemySelect].Width / 4) - 5), -EnemyShipSpriteCollection[EnemySelect].Height),

                            1, EnemySpeed, 3000, EnemyStuff.Length, EnemyStuff, 4, EnemyNames[EnemySelect], 0, EnemyWeapon[EnemyWeaponNo]);

                        }
                    }
                    else if (Level == 7)
                    {
                        SoundHandler.resumeSound(bgMusic1);
                        SoundHandler.pauseSound(bgMusic2);
                        SoundHandler.pauseSound(bgMusic3);

                        if (Switheroo == 0)
                        {

                            EnemySpeed.X = 2;
                            EnemySpeed.Y = 2;
                            EnemySelect = 1;//put the enemy no here(0-9)
                            EnemyWeaponNo = 1;//put the weapon no here(0-3)
                            this.eship = EnemyShipSpriteCollection[EnemySelect]; // SpriteSheet

                            EnemyStuff = new int[2];
                            EnemyStuff[0] = 5;
                            EnemyStuff[1] = (EnemyTextureCollection[EnemySelect].Width) - 5;
                            SetLevelEnemyDetails(EnemyShipSpriteCollection[EnemySelect], EnemyAnimationCollection[EnemySelect], EnemyTextureCollection[EnemySelect], new Vector2(randomizer.Next(0, 100), randomizer.Next(0, 100)),

                            1, EnemySpeed, 3000, EnemyStuff.Length, EnemyStuff, 5, EnemyNames[EnemySelect], 1, EnemyWeapon[EnemyWeaponNo]);
                        }
                        else
                        {
                            EnemySpeed.X = 0;
                            EnemySpeed.Y = 1;
                            EnemySelect = 8;//put the enemy no here(0-9)
                            EnemyWeaponNo = 2;//put the weapon no here(0-3)
                            this.eship = EnemyShipSpriteCollection[EnemySelect]; // SpriteSheet

                            EnemyStuff = new int[2];
                            EnemyStuff[0] = 5;
                            EnemyStuff[1] = (EnemyTextureCollection[EnemySelect].Width) - 5;
                            SetLevelEnemyDetails(EnemyShipSpriteCollection[EnemySelect], EnemyAnimationCollection[EnemySelect], EnemyTextureCollection[EnemySelect], new Vector2(randomizer.Next(0, Window.ClientBounds.Width - (EnemyShipSpriteCollection[EnemySelect].Width / 4) - 5), -EnemyShipSpriteCollection[EnemySelect].Height),

                            3, EnemySpeed, 5000, EnemyStuff.Length, EnemyStuff, 1, EnemyNames[EnemySelect], 0, EnemyWeapon[EnemyWeaponNo]);

                        }
                    }
                    else if (Level == 8)
                    {
                        SoundHandler.pauseSound(bgMusic1);
                        SoundHandler.resumeSound(bgMusic2);
                        SoundHandler.pauseSound(bgMusic3);

                        if (Switheroo == 0)
                        {
                            EnemySpeed.X = 1;
                            EnemySpeed.Y = 1;
                            EnemySelect = 1;//put the enemy no here(0-9)
                            EnemyWeaponNo = 0;//put the weapon no here(0-3)
                            this.eship = EnemyShipSpriteCollection[EnemySelect]; // SpriteSheet

                            EnemyStuff = new int[2];
                            EnemyStuff[0] = 5;
                            EnemyStuff[1] = (EnemyTextureCollection[EnemySelect].Width) - 5;
                            SetLevelEnemyDetails(EnemyShipSpriteCollection[EnemySelect], EnemyAnimationCollection[EnemySelect], EnemyTextureCollection[EnemySelect], new Vector2(randomizer.Next(0, Window.ClientBounds.Width - (EnemyShipSpriteCollection[EnemySelect].Width / 4) - 5), -EnemyShipSpriteCollection[EnemySelect].Height),

                            2, EnemySpeed, 2000, EnemyStuff.Length, EnemyStuff, 4, EnemyNames[EnemySelect], 1, EnemyWeapon[EnemyWeaponNo]);
                        }
                        else if (Switheroo == 1)
                        {
                            EnemySpeed.X = 0;
                            EnemySpeed.Y = 1;
                            EnemySelect = 5;//put the enemy no here(0-9)
                            EnemyWeaponNo = 1;//put the weapon no here(0-3)
                            this.eship = EnemyShipSpriteCollection[EnemySelect]; // SpriteSheet

                            EnemyStuff = new int[2];
                            EnemyStuff[0] = 5;
                            EnemyStuff[1] = (EnemyTextureCollection[EnemySelect].Width) - 5;
                            SetLevelEnemyDetails(EnemyShipSpriteCollection[EnemySelect], EnemyAnimationCollection[EnemySelect], EnemyTextureCollection[EnemySelect], new Vector2(randomizer.Next(0, Window.ClientBounds.Width - (EnemyShipSpriteCollection[EnemySelect].Width / 4) - 5), -EnemyShipSpriteCollection[EnemySelect].Height),

                            3, EnemySpeed, 3000, EnemyStuff.Length, EnemyStuff, 1, EnemyNames[EnemySelect], 2, EnemyWeapon[EnemyWeaponNo]);

                        }
                        else if (Switheroo == 2)
                        {
                            EnemySpeed.X = 0;
                            EnemySpeed.Y = 1;
                            EnemySelect = 6;//put the enemy no here(0-9)
                            EnemyWeaponNo = 3;//put the weapon no here(0-3)
                            this.eship = EnemyShipSpriteCollection[EnemySelect]; // SpriteSheet

                            EnemyStuff = new int[2];
                            EnemyStuff[0] = 5;
                            EnemyStuff[1] = (EnemyTextureCollection[EnemySelect].Width) - 5;
                            SetLevelEnemyDetails(EnemyShipSpriteCollection[EnemySelect], EnemyAnimationCollection[EnemySelect], EnemyTextureCollection[EnemySelect], new Vector2(randomizer.Next(0, Window.ClientBounds.Width - (EnemyShipSpriteCollection[EnemySelect].Width / 4) - 5), -EnemyShipSpriteCollection[EnemySelect].Height),

                            1, EnemySpeed, 3000, EnemyStuff.Length, EnemyStuff, 1, EnemyNames[EnemySelect], 3, EnemyWeapon[EnemyWeaponNo]);

                        }
                        else if (Switheroo == 3)
                        {
                            EnemySpeed.X = -1;
                            EnemySpeed.Y = 1;
                            EnemySelect = 3;//put the enemy no here(0-9)
                            EnemyWeaponNo = 2;//put the weapon no here(0-3)
                            this.eship = EnemyShipSpriteCollection[EnemySelect]; // SpriteSheet

                            EnemyStuff = new int[2];
                            EnemyStuff[0] = 5;
                            EnemyStuff[1] = (EnemyTextureCollection[EnemySelect].Width) - 5;
                            SetLevelEnemyDetails(EnemyShipSpriteCollection[EnemySelect], EnemyAnimationCollection[EnemySelect], EnemyTextureCollection[EnemySelect], new Vector2(randomizer.Next(0, Window.ClientBounds.Width - (EnemyShipSpriteCollection[EnemySelect].Width / 4) - 5), -EnemyShipSpriteCollection[EnemySelect].Height),

                            2, EnemySpeed, 3000, EnemyStuff.Length, EnemyStuff, 3, EnemyNames[EnemySelect], 0, EnemyWeapon[EnemyWeaponNo]);

                        }

                    }
                    else if (Level == 9)
                    {
                        SoundHandler.pauseSound(bgMusic1);
                        SoundHandler.pauseSound(bgMusic2);
                        SoundHandler.resumeSound(bgMusic3);

                        if (Switheroo == 0)
                        {
                            EnemySpeed.X = 1;
                            EnemySpeed.Y = 2;
                            EnemySelect = 2;//put the enemy no here(0-9)
                            EnemyWeaponNo = 1;//put the weapon no here(0-3)
                            this.eship = EnemyShipSpriteCollection[EnemySelect]; // SpriteSheet

                            EnemyStuff = new int[2];
                            EnemyStuff[0] = 5;
                            EnemyStuff[1] = (EnemyTextureCollection[EnemySelect].Width) - 5;
                            SetLevelEnemyDetails(EnemyShipSpriteCollection[EnemySelect], EnemyAnimationCollection[EnemySelect], EnemyTextureCollection[EnemySelect], new Vector2(randomizer.Next(0, Window.ClientBounds.Width - (EnemyShipSpriteCollection[EnemySelect].Width / 4) - 5), -EnemyShipSpriteCollection[EnemySelect].Height),

                            1, EnemySpeed, 2000, EnemyStuff.Length, EnemyStuff, 2, EnemyNames[EnemySelect], 1, EnemyWeapon[EnemyWeaponNo]);
                        }
                        else if (Switheroo == 1)
                        {
                            EnemySpeed.X = -1;
                            EnemySpeed.Y = 1;
                            EnemySelect = 4;//put the enemy no here(0-9)
                            EnemyWeaponNo = 2;//put the weapon no here(0-3)
                            this.eship = EnemyShipSpriteCollection[EnemySelect]; // SpriteSheet

                            EnemyStuff = new int[2];
                            EnemyStuff[0] = 5;
                            EnemyStuff[1] = (EnemyTextureCollection[EnemySelect].Width) - 5;
                            SetLevelEnemyDetails(EnemyShipSpriteCollection[EnemySelect], EnemyAnimationCollection[EnemySelect], EnemyTextureCollection[EnemySelect], new Vector2(randomizer.Next(0, Window.ClientBounds.Width - (EnemyShipSpriteCollection[EnemySelect].Width / 4) - 5), -EnemyShipSpriteCollection[EnemySelect].Height),

                            2, EnemySpeed, 3000, EnemyStuff.Length, EnemyStuff, 1, EnemyNames[EnemySelect], 2, EnemyWeapon[EnemyWeaponNo]);

                        }
                        else if (Switheroo == 2)
                        {
                            EnemySpeed.X = 0;
                            EnemySpeed.Y = 1;
                            EnemySelect = 7;//put the enemy no here(0-9)
                            EnemyWeaponNo = 3;//put the weapon no here(0-3)
                            this.eship = EnemyShipSpriteCollection[EnemySelect]; // SpriteSheet

                            EnemyStuff = new int[2];
                            EnemyStuff[0] = 5;
                            EnemyStuff[1] = (EnemyTextureCollection[EnemySelect].Width) - 5;
                            SetLevelEnemyDetails(EnemyShipSpriteCollection[EnemySelect], EnemyAnimationCollection[EnemySelect], EnemyTextureCollection[EnemySelect], new Vector2(randomizer.Next(0, Window.ClientBounds.Width - (EnemyShipSpriteCollection[EnemySelect].Width / 4) - 5), -EnemyShipSpriteCollection[EnemySelect].Height),

                            1, EnemySpeed, 3000, EnemyStuff.Length, EnemyStuff, 1, EnemyNames[EnemySelect], 3, EnemyWeapon[EnemyWeaponNo]);

                        }
                        else if (Switheroo == 3)
                        {


                            EnemySpeed.X = 0;
                            EnemySpeed.Y = 1;
                            EnemySelect = 8;//put the enemy no here(0-9)
                            EnemyWeaponNo = 0;//put the weapon no here(0-3)
                            this.eship = EnemyShipSpriteCollection[EnemySelect]; // SpriteSheet

                            EnemyStuff = new int[2];
                            EnemyStuff[0] = 5;
                            EnemyStuff[1] = (EnemyTextureCollection[EnemySelect].Width) - 5;
                            SetLevelEnemyDetails(EnemyShipSpriteCollection[EnemySelect], EnemyAnimationCollection[EnemySelect], EnemyTextureCollection[EnemySelect], new Vector2(randomizer.Next(0, Window.ClientBounds.Width - (EnemyShipSpriteCollection[EnemySelect].Width / 4) - 5), -EnemyShipSpriteCollection[EnemySelect].Height),

                            2, EnemySpeed, 3000, EnemyStuff.Length, EnemyStuff, 1, EnemyNames[EnemySelect], 0, EnemyWeapon[EnemyWeaponNo]);

                        }
                    }
                }
                else
                {
                    //info about bosses for all levels same parameters as used above to set normal enemies i.e SetLeveleEnemyDetails
                    if (Level == 1)
                    {

                        EnemySelect = 0;//put the enemy no here(0-9)
                        EnemyWeaponNo = 0;//put the weapon no here(0-3)
                        this.eship = Boss[Level - 1]; // SpriteSheet
                        EnemyStuff = new int[11];
                        EnemyWeaponSpeed = new Vector2[11] { new Vector2(0, 8), new Vector2(0, 8), new Vector2(0, 8), new Vector2(3, 8), new Vector2(-3, 8), new Vector2(-2, 8), new Vector2(2, 8), new Vector2(-5, 8), new Vector2(-5, 8), new Vector2(-4, 8), new Vector2(4, 8) };
                        EnemyStuff[0] = 5;
                        EnemyStuff[1] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[2] = (BossSingle[Level - 1].Width) - 5;
                        EnemyStuff[3] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[4] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[5] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[6] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[7] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[8] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[9] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[10] = (BossSingle[Level - 1].Width) / 2;
                        
                        SetLevelEnemyDetails(Boss[Level - 1], new Animation(Boss[Level - 1], new Point(4, 1), new Point(Boss[Level - 1].Width / 4, Boss[Level - 1].Height), new Point(0, 0), 50, 0, 0), BossSingle[Level - 1], new Vector2((Window.ClientBounds.Width / 2), -Boss[Level - 1].Height),
                        75 * Level, new Vector2(2, 1), 2000, EnemyStuff.Length, EnemyStuff, 2, BossNames[Level - 1], 1, EnemyWeapon[EnemyWeaponNo]);
                    }else if(Level==2){

                        EnemySelect = 0;//put the enemy no here(0-9)
                        EnemyWeaponNo = 1;//put the weapon no here(0-3)
                        this.eship = Boss[Level - 1]; // SpriteSheet
                        EnemyStuff = new int[11];
                        EnemyWeaponSpeed = new Vector2[11] { new Vector2(0, 8), new Vector2(0, 8), new Vector2(0, 8), new Vector2(3, 8), new Vector2(-3, 8), new Vector2(-2, 8), new Vector2(2, 8), new Vector2(-5, 8), new Vector2(-5, 8), new Vector2(-4, 8), new Vector2(4, 8) };
                        EnemyStuff[0] = 5;
                        EnemyStuff[1] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[2] = (BossSingle[Level - 1].Width) - 5;
                        EnemyStuff[3] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[4] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[5] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[6] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[7] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[8] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[9] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[10] = (BossSingle[Level - 1].Width) / 2;
                        
                        SetLevelEnemyDetails(Boss[Level - 1], new Animation(Boss[Level - 1], new Point(4, 1), new Point(Boss[Level - 1].Width / 4, Boss[Level - 1].Height), new Point(0, 0), 50, 0, 0), BossSingle[Level - 1], new Vector2((Window.ClientBounds.Width / 2), -Boss[Level - 1].Height),
                        75 * Level, new Vector2(2, 1), 2000, EnemyStuff.Length, EnemyStuff, 2, BossNames[Level - 1], 1, EnemyWeapon[EnemyWeaponNo]);

                    }
                    else if (Level == 3)
                    {

                        EnemySelect = 0;//put the enemy no here(0-9)
                        EnemyWeaponNo = 2;//put the weapon no here(0-3)
                        this.eship = Boss[Level - 1]; // SpriteSheet
                        EnemyStuff = new int[11];
                        EnemyWeaponSpeed = new Vector2[11] { new Vector2(0, 8), new Vector2(0, 8), new Vector2(0, 8), new Vector2(3, 8), new Vector2(-3, 8), new Vector2(-2, 8), new Vector2(2, 8), new Vector2(-5, 8), new Vector2(-5, 8), new Vector2(-4, 8), new Vector2(4, 8) };
                        EnemyStuff[0] = 5;
                        EnemyStuff[1] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[2] = (BossSingle[Level - 1].Width) - 5;
                        EnemyStuff[3] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[4] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[5] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[6] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[7] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[8] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[9] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[10] = (BossSingle[Level - 1].Width) / 2;

                        SetLevelEnemyDetails(Boss[Level - 1], new Animation(Boss[Level - 1], new Point(4, 1), new Point(Boss[Level - 1].Width / 4, Boss[Level - 1].Height), new Point(0, 0), 50, 0, 0), BossSingle[Level - 1], new Vector2((Window.ClientBounds.Width / 2), -Boss[Level - 1].Height),
                        75 * Level, new Vector2(2, 1), 2000, EnemyStuff.Length, EnemyStuff, 2, BossNames[Level - 1], 1, EnemyWeapon[EnemyWeaponNo]);

                    }
                    else if (Level == 4)
                    {

                        EnemySelect = 0;//put the enemy no here(0-9)
                        EnemyWeaponNo = 1;//put the weapon no here(0-3)
                        this.eship = Boss[Level - 1]; // SpriteSheet
                        EnemyStuff = new int[11];
                        EnemyWeaponSpeed = new Vector2[11] { new Vector2(0, 8), new Vector2(0, 8), new Vector2(0, 8), new Vector2(3, 8), new Vector2(-3, 8), new Vector2(-2, 8), new Vector2(2, 8), new Vector2(-5, 8), new Vector2(-5, 8), new Vector2(-4, 8), new Vector2(4, 8) };
                        EnemyStuff[0] = 5;
                        EnemyStuff[1] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[2] = (BossSingle[Level - 1].Width) - 5;
                        EnemyStuff[3] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[4] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[5] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[6] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[7] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[8] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[9] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[10] = (BossSingle[Level - 1].Width) / 2;

                        SetLevelEnemyDetails(Boss[Level - 1], new Animation(Boss[Level - 1], new Point(4, 1), new Point(Boss[Level - 1].Width / 4, Boss[Level - 1].Height), new Point(0, 0), 50, 0, 0), BossSingle[Level - 1], new Vector2((Window.ClientBounds.Width / 2), -Boss[Level - 1].Height),
                        75 * Level, new Vector2(2, 1), 2000, EnemyStuff.Length, EnemyStuff, 2, BossNames[Level - 1], 1, EnemyWeapon[EnemyWeaponNo]);

                    }
                    else if (Level == 5)
                    {

                        EnemySelect = 0;//put the enemy no here(0-9)
                        EnemyWeaponNo = 3;//put the weapon no here(0-3)
                        this.eship = Boss[Level - 1]; // SpriteSheet
                        EnemyStuff = new int[11];
                        EnemyWeaponSpeed = new Vector2[11] { new Vector2(0, 8), new Vector2(0, 8), new Vector2(0, 8), new Vector2(3, 8), new Vector2(-3, 8), new Vector2(-2, 8), new Vector2(2, 8), new Vector2(-5, 8), new Vector2(-5, 8), new Vector2(-4, 8), new Vector2(4, 8) };
                        EnemyStuff[0] = 5;
                        EnemyStuff[1] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[2] = (BossSingle[Level - 1].Width) - 5;
                        EnemyStuff[3] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[4] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[5] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[6] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[7] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[8] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[9] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[10] = (BossSingle[Level - 1].Width) / 2;

                        SetLevelEnemyDetails(Boss[Level - 1], new Animation(Boss[Level - 1], new Point(4, 1), new Point(Boss[Level - 1].Width / 4, Boss[Level - 1].Height), new Point(0, 0), 50, 0, 0), BossSingle[Level - 1], new Vector2((Window.ClientBounds.Width / 2), -Boss[Level - 1].Height),
                        75 * Level, new Vector2(2, 1), 2000, EnemyStuff.Length, EnemyStuff, 2, BossNames[Level - 1], 1, EnemyWeapon[EnemyWeaponNo]);

                    }
                    else if (Level == 6)
                    {

                        EnemySelect = 0;//put the enemy no here(0-9)
                        EnemyWeaponNo = 2;//put the weapon no here(0-3)
                        this.eship = Boss[Level - 1]; // SpriteSheet
                        EnemyStuff = new int[11];
                        EnemyWeaponSpeed = new Vector2[11] { new Vector2(0, 8), new Vector2(0, 8), new Vector2(0, 8), new Vector2(3, 8), new Vector2(-3, 8), new Vector2(-2, 8), new Vector2(2, 8), new Vector2(-5, 8), new Vector2(-5, 8), new Vector2(-4, 8), new Vector2(4, 8) };
                        EnemyStuff[0] = 5;
                        EnemyStuff[1] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[2] = (BossSingle[Level - 1].Width) - 5;
                        EnemyStuff[3] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[4] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[5] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[6] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[7] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[8] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[9] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[10] = (BossSingle[Level - 1].Width) / 2;

                        SetLevelEnemyDetails(Boss[Level - 1], new Animation(Boss[Level - 1], new Point(4, 1), new Point(Boss[Level - 1].Width / 4, Boss[Level - 1].Height), new Point(0, 0), 50, 0, 0), BossSingle[Level - 1], new Vector2((Window.ClientBounds.Width / 2), -Boss[Level - 1].Height),
                        75 * Level, new Vector2(2, 1), 2000, EnemyStuff.Length, EnemyStuff, 2, BossNames[Level - 1], 1, EnemyWeapon[EnemyWeaponNo]);

                    }
                    else if (Level == 7)
                    {

                        EnemySelect = 0;//put the enemy no here(0-9)
                        EnemyWeaponNo = 1;//put the weapon no here(0-3)
                        this.eship = Boss[Level - 1]; // SpriteSheet
                        EnemyStuff = new int[11];
                        EnemyWeaponSpeed = new Vector2[11] { new Vector2(0, 8), new Vector2(0, 8), new Vector2(0, 8), new Vector2(3, 8), new Vector2(-3, 8), new Vector2(-2, 8), new Vector2(2, 8), new Vector2(-5, 8), new Vector2(-5, 8), new Vector2(-4, 8), new Vector2(4, 8) };
                        EnemyStuff[0] = 5;
                        EnemyStuff[1] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[2] = (BossSingle[Level - 1].Width) - 5;
                        EnemyStuff[3] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[4] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[5] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[6] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[7] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[8] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[9] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[10] = (BossSingle[Level - 1].Width) / 2;

                        SetLevelEnemyDetails(Boss[Level - 1], new Animation(Boss[Level - 1], new Point(4, 1), new Point(Boss[Level - 1].Width / 4, Boss[Level - 1].Height), new Point(0, 0), 50, 0, 0), BossSingle[Level - 1], new Vector2((Window.ClientBounds.Width / 2), -Boss[Level - 1].Height),
                        75 * Level, new Vector2(2, 1), 2000, EnemyStuff.Length, EnemyStuff, 2, BossNames[Level - 1], 1, EnemyWeapon[EnemyWeaponNo]);

                    }
                    else if (Level == 8)
                    {

                        EnemySelect = 0;//put the enemy no here(0-9)
                        EnemyWeaponNo = 2;//put the weapon no here(0-3)
                        this.eship = Boss[Level - 1]; // SpriteSheet
                        EnemyStuff = new int[11];
                        EnemyWeaponSpeed = new Vector2[11] { new Vector2(0, 8), new Vector2(0, 8), new Vector2(0, 8), new Vector2(3, 8), new Vector2(-3, 8), new Vector2(-2, 8), new Vector2(2, 8), new Vector2(-5, 8), new Vector2(-5, 8), new Vector2(-4, 8), new Vector2(4, 8) };
                        EnemyStuff[0] = 5;
                        EnemyStuff[1] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[2] = (BossSingle[Level - 1].Width) - 5;
                        EnemyStuff[3] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[4] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[5] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[6] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[7] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[8] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[9] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[10] = (BossSingle[Level - 1].Width) / 2;

                        SetLevelEnemyDetails(Boss[Level - 1], new Animation(Boss[Level - 1], new Point(4, 1), new Point(Boss[Level - 1].Width / 4, Boss[Level - 1].Height), new Point(0, 0), 50, 0, 0), BossSingle[Level - 1], new Vector2((Window.ClientBounds.Width / 2), -Boss[Level - 1].Height),
                        75 * Level, new Vector2(2, 1), 2000, EnemyStuff.Length, EnemyStuff, 2, BossNames[Level - 1], 1, EnemyWeapon[EnemyWeaponNo]);

                    }
                    else if (Level == 9)
                    {

                        EnemySelect = 0;//put the enemy no here(0-9)
                        EnemyWeaponNo = 1;//put the weapon no here(0-3)
                        this.eship = Boss[Level - 1]; // SpriteSheet
                        EnemyStuff = new int[11];
                        EnemyWeaponSpeed = new Vector2[11] { new Vector2(0, 8), new Vector2(0, 8), new Vector2(0, 8), new Vector2(3, 8), new Vector2(-3, 8), new Vector2(-2, 8), new Vector2(2, 8), new Vector2(-5, 8), new Vector2(-5, 8), new Vector2(-4, 8), new Vector2(4, 8) };
                        EnemyStuff[0] = 5;
                        EnemyStuff[1] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[2] = (BossSingle[Level - 1].Width) - 5;
                        EnemyStuff[3] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[4] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[5] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[6] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[7] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[8] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[9] = (BossSingle[Level - 1].Width) / 2;
                        EnemyStuff[10] = (BossSingle[Level - 1].Width) / 2;

                        SetLevelEnemyDetails(Boss[Level - 1], new Animation(Boss[Level - 1], new Point(4, 1), new Point(Boss[Level - 1].Width / 4, Boss[Level - 1].Height), new Point(0, 0), 50, 0, 0), BossSingle[Level - 1], new Vector2((Window.ClientBounds.Width / 2), -Boss[Level - 1].Height),
                        75 * Level, new Vector2(2, 1), 2000, EnemyStuff.Length, EnemyStuff, 2, BossNames[Level - 1], 1, EnemyWeapon[EnemyWeaponNo]);

                    }

                    //EnemyStuff = new int[2];
                    //EnemyStuff[0] = 10;
                    //EnemyStuff[1] = (BossSingle[Level - 1].Width) - 10;
                    //SetLevelEnemyDetails(Boss[Level - 1], new Animation(BossAnim[Level - 1]), BossSingle[Level - 1], new Vector2(Window.ClientBounds.Width / 2 , -BossSingle[Level - 1].Height),

                    //100, new Vector2(4, 2), 3000, EnemyStuff.Length, EnemyStuff, 1, BossNames[Level - 1], 1, EnemyWeapon[3]);


                }


                for (int i = 0; i < AmountOfEnemyToSpawnSimultaneouly; i++)
                {
                    if (!(i == 0))
                    {
                        EnemLocation.X += eship.Width / 4;
                    }
                    if (!BossFight)
                    {
                        //EnemyAnimation = 
                        //  MyEnemy = new Enemy(EnemLocation, EnemyTexture, new Animation(EnemyAnimation), EnemHealth, 0, EnemSpeed, EnemyfireA, Enemyfire, EnemFireDelay, EnemyAmountOfFire, EnemyFireOffset, EnemyName, EnemWeapon);
                        EnemiesUsed.Add(new Enemy(EnemLocation, EnemyTexture, new Animation(EnemyAnimation), EnemHealth, 0, EnemSpeed, EnemyfireA, Enemyfire, EnemFireDelay, EnemyAmountOfFire, EnemyFireOffset, EnemyName, EnemWeapon));
                    }
                    else
                    {
                        if (!SpawnBoss)
                        {
                            EnemiesUsed.Add(new Boss(Level, EnemLocation, EnemyTexture, new Animation(EnemyAnimation), EnemHealth, 0, EnemSpeed, EnemyfireA, Enemyfire, EnemFireDelay, EnemyAmountOfFire, EnemyFireOffset, EnemyWeaponSpeed, EnemyName, EnemWeapon));
                            SpawnBoss = true;
                        }
                    }

                }

            }
        }


        
        private void SetLevelEnemyDetails(Texture2D eship, Animation EnemyAnimation, Texture2D EnemyTexture, Vector2 EnemLocation, int EnemHealth, Vector2 EnemSpeed, int EnemFireDelay, int EnemyAmountOfFire, int[] EnemFrieArray, int AmountOfEnemyToSpawnSimultaneouly, String EnemyName, int Switheroo, Weapon EnemWeapon)
        {

            this.eship = eship;
            this.EnemyAnimation = EnemyAnimation;
            this.EnemyTexture = EnemyTexture;
            this.EnemLocation = EnemLocation;
            this.EnemHealth = EnemHealth;
            this.EnemSpeed = EnemSpeed;
            this.EnemFireDelay = EnemFireDelay;
            this.EnemyAmountOfFire = EnemyAmountOfFire;
            this.EnemyFireOffset = EnemFrieArray;
            this.AmountOfEnemyToSpawnSimultaneouly = AmountOfEnemyToSpawnSimultaneouly;
            this.EnemyName = EnemyName;
            this.EnemWeapon = EnemWeapon;
            this.Switheroo = Switheroo;
        }

        private void UpdateEnemies(GameTime gameTime)
        {

            
            for (int i = Bonus.Count-1; i >= 0 ; i--)
            {
                Bonus[i].Update();
                if (!Bonus[i].Active)
                {
                    Bonus.RemoveAt(i);
                }


            }

            if (EnemiesUsed.Count > 0)
            {
                for (int i = EnemiesUsed.Count - 1; i >= 0; i--)
                {

                    EnemiesUsed[i].Update(gameTime);
                    EnemiesUsed[i].EnemyMiscStuff(gameTime);
                    if (EnemiesUsed[i].DamageCount < 0)
                    {
                        EnemyTexture = Content.Load<Texture2D>(EnemiesUsed[i].EnemyDamage + EnemiesUsed[i].EnemyName);
                         EnemiesUsed[i].animation.Sheet = EnemyTexture; 
                    }
                    if (EnemiesUsed[i].Health <= 0 && EnemiesUsed[i].Active)
                    {

                        EnemiesUsed[i].Active = false;
                        EnemiesUsed[i].DamageCount = 20;
                        if (BossFight)
                        {
                            BossFightWon = true;
                        }
                    }
                    if (!EnemiesUsed[i].Active)
                    {
                        if (EnemiesUsed[i].DamageCount > 0)
                        {
                            EnemyTexture = Content.Load<Texture2D>("Blast");

                            EnemiesUsed[i].Destruction(EnemyTexture);
                        }
                        else
                        {
                            EnemiesUsed[i] = null;
                            EnemiesUsed.RemoveAt(i);
                            //GC.Collect();
                        }

                    }


                }

            }
        }

        private void CheckCollision()
        {
            //Collision Detection Between player Heavy Rockets and Enemy
            foreach (Weapon x in Rockets)
            {
                Rectangle colrock = x.CollisionRect();
                foreach (Enemy thisEnemy in EnemiesUsed)
                {
                    Rectangle enemrect = thisEnemy.CollisionRect();
                    if (enemrect.Intersects(colrock))
                    {
                        //x.Health--;
                        if (x.Health <= 0 || thisEnemy is Boss)
                        {
                            x.Active = false;
                        }
                        thisEnemy.Health -= x.Damage;
                        score++;
                        break;
                    }
                }
            }

            //Collision Detection between Player bullets and Enemy
            foreach (Weapon x in Fire)
            {
                Rectangle colrock = x.CollisionRect();
                foreach (Enemy thisEnemy in EnemiesUsed)
                {
                    Rectangle enemrect = thisEnemy.CollisionRect();
                    if (enemrect.Intersects(colrock))
                    {
                        x.Health--;
                        if (x.Health <= 0)
                        {
                            x.Active = false;
                        }
                        thisEnemy.Health -= x.Damage;
                        thisEnemy.EnemyCount = 8;
                        score++;
                        break;
                    }
                }
            }

            //Collision Detection Between Enemy Bullets and Our Ship.
            foreach (Enemy thisEnemy in EnemiesUsed)
            {
                List<Weapon> EnemFire = thisEnemy.fire;
                for (int i = EnemFire.Count - 1; i >= 0; i--)
                {
                    Rectangle PlayerRect = MyShip.CollisionRect();
                    if (EnemFire[i].CollisionRect().Intersects(PlayerRect))
                    {
                        MyShip.Health -= EnemFire[i].Damage;
                        MotherCount = 20;
                        EnemFire[i].Active = false;

                        if (MyShip.Health <= 0)
                        {
                            GameState = "GameOver";
                        }
                    }
                    if (EnemFire[i].Active == false)
                    {
                        EnemFire.RemoveAt(i);
                        //GC.Collect();
                    }
                }
                thisEnemy.ModedFire(EnemFire);


            }

            foreach (PowerUp power in Bonus)
            {
                Rectangle x = power.CollisionRect();
                if (x.Intersects(MyShip.CollisionRect()))
                {
                    SoundHandler.playSound(getBonus);
                    if (power.IdNo == 0)
                    {
                        if (MyShip.Health <= 90)
                        {
                            MyShip.Health += 10;
                        }
                        else
                        {
                            MyShip.Health = 100;
                        }
                        

                    }
                    else if (power.IdNo == 1)
                    {
                        AmountofRockets += 2;    
                    }
                    else if (power.IdNo == 2)
                    {
                        AmountofRockets += 5;
                    }
                    else if (power.IdNo == 3)
                    {
                        AmountofWep1 += 35;
                    }
                    else if (power.IdNo == 4)
                    {
                        AmountofWep2 += 25;
                    }
                    else if (power.IdNo == 5)
                    {
                        AmountofWep3 += 15;
                    }
                    power.Active = false;


                }
            }

        }


        private void AddProjectile()
        {
            if (AmountofRockets > 0)
            {
                AmountofRockets--;
                //            Animation x = new Animation(Animrock, new Point(1, 4), new Point(21, 50), new Point(0, 0), 60, 0, 0.5f);
                Rockets.Add(new Weapon(true,0,Singrock, new Vector2(0, -5), new Animation(Animrock, new Point(1, 4), new Point(21, 50), new Point(0, 0), 60, 0, 0.5f), 4, new Vector2(MyShip.Position.X + 10, MyShip.Position.Y), "UP", 8));
                Rockets.Add(new Weapon(true, 0, Singrock, new Vector2(0, -5), new Animation(Animrock, new Point(1, 4), new Point(21, 50), new Point(0, 0), 60, 0, 0.5f), 4, new Vector2(MyShip.Position.X + 60, MyShip.Position.Y), "UP", 8));
            
            }
        }
        private void AddFire()
        {
            if (numPressed == 0)
            {
                
                    Fire.Add(new Weapon(true, 0, MotherShipFireSingle[0], new Vector2(0, -8), new Animation(MotherShipFire[0], new Point(1, 1), new Point(MotherShipFire[0].Width / 4, MotherShipFire[0].Height), new Point(0, 0), 60, 0, 0.5f), 1, new Vector2(MyShip.Position.X + 10, MyShip.Position.Y), "UP", 1));
                    Fire.Add(new Weapon(true, 0, MotherShipFireSingle[0], new Vector2(0, -8), new Animation(MotherShipFire[0], new Point(1, 1), new Point(MotherShipFire[0].Width / 4, MotherShipFire[0].Height), new Point(0, 0), 60, 0, 0.5f), 1, new Vector2(MyShip.Position.X + (MotherShip.Width - 20), MyShip.Position.Y), "UP", 1));

                
            }
            else if (numPressed == 1)
            {
                if (AmountofWep1 > 0)
                {
                    AmountofWep1--;
                    Fire.Add(new Weapon(true, 1, MotherShipFireSingle[1], new Vector2(0, -8), new Animation(MotherShipFire[0], new Point(1, 1), new Point(MotherShipFire[0].Width / 4, MotherShipFire[0].Height), new Point(0, 0), 60, 0, 0.5f), 1, new Vector2(MyShip.Position.X + 10, MyShip.Position.Y), "UP", 1));
                    Fire.Add(new Weapon(true, 1, MotherShipFireSingle[1], new Vector2(0, -8), new Animation(MotherShipFire[0], new Point(1, 1), new Point(MotherShipFire[0].Width / 4, MotherShipFire[0].Height), new Point(0, 0), 60, 0, 0.5f), 1, new Vector2(MyShip.Position.X + (MotherShip.Width - 20), MyShip.Position.Y), "UP", 1));
                    Fire.Add(new Weapon(true, 1, MotherShipFireSingle[2], new Vector2(-3, -8), new Animation(MotherShipFire[3], new Point(1, 1), new Point(MotherShipFire[3].Width / 4, MotherShipFire[3].Height), new Point(0, 0), 60, 0, 0.5f), 1, new Vector2(MyShip.Position.X + 10, MyShip.Position.Y), "UP", 1));
                    Fire.Add(new Weapon(true, 1, MotherShipFireSingle[2], new Vector2(3, -8), new Animation(MotherShipFire[3], new Point(1, 1), new Point(MotherShipFire[3].Width / 4, MotherShipFire[3].Height), new Point(0, 0), 60, 0, 0.5f), 1, new Vector2(MyShip.Position.X + (MotherShip.Width - 20), MyShip.Position.Y), "UP", 1));
                }
            }
            else if (numPressed == 2)
            {
                if (AmountofWep2 > 0)
                {
                    AmountofWep2--;
                    Fire.Add(new Weapon(true, 2, MotherShipFireSingle[1], new Vector2(3, -4), new Animation(MotherShipFire[0], new Point(1, 1), new Point(MotherShipFire[0].Width / 4, MotherShipFire[0].Height), new Point(0, 0), 60, 0, 0.5f), 1, new Vector2(MyShip.Position.X + MyShip.img.Width / 2, MyShip.Position.Y), "UP", 1));
                    Fire.Add(new Weapon(false, 2, MotherShipFireSingle[1], new Vector2(3, -4), new Animation(MotherShipFire[0], new Point(1, 1), new Point(MotherShipFire[0].Width / 4, MotherShipFire[0].Height), new Point(0, 0), 60, 0, 0.5f), 1, new Vector2(MyShip.Position.X + MyShip.img.Width / 2, MyShip.Position.Y), "UP", 1));
                    Fire.Add(new Weapon(true, 1, MotherShipFireSingle[2], new Vector2(0, -8), new Animation(MotherShipFire[3], new Point(1, 1), new Point(MotherShipFire[3].Width / 4, MotherShipFire[3].Height), new Point(0, 0), 60, 0, 0.5f), 1, new Vector2(MyShip.Position.X + 10, MyShip.Position.Y), "UP", 1));
                    Fire.Add(new Weapon(true, 1, MotherShipFireSingle[2], new Vector2(0, -8), new Animation(MotherShipFire[3], new Point(1, 1), new Point(MotherShipFire[3].Width / 4, MotherShipFire[3].Height), new Point(0, 0), 60, 0, 0.5f), 1, new Vector2(MyShip.Position.X + (MotherShip.Width - 20), MyShip.Position.Y), "UP", 1));
                }
            }
            else if (numPressed == 3)
            {
                if (AmountofWep3 > 0)
                {
                    AmountofWep3--;
                    Fire.Add(new Weapon(true, 1, MotherShipFireSingle[3], new Vector2(-3, -8), new Animation(MotherShipFire[3], new Point(1, 1), new Point(MotherShipFire[3].Width / 4, MotherShipFire[3].Height), new Point(0, 0), 60, 0, 0.5f), 1, new Vector2(MyShip.Position.X + (MotherShip.Width / 2), MyShip.Position.Y), "UP", 1));
                    Fire.Add(new Weapon(true, 1, MotherShipFireSingle[3], new Vector2(3, -8), new Animation(MotherShipFire[3], new Point(1, 1), new Point(MotherShipFire[3].Width / 4, MotherShipFire[3].Height), new Point(0, 0), 60, 0, 0.5f), 1, new Vector2(MyShip.Position.X + (MotherShip.Width / 2), MyShip.Position.Y), "UP", 1));
                    Fire.Add(new Weapon(true, 1, MotherShipFireSingle[2], new Vector2(-4, -8), new Animation(MotherShipFire[3], new Point(1, 1), new Point(MotherShipFire[3].Width / 4, MotherShipFire[3].Height), new Point(0, 0), 60, 0, 0.5f), 1, new Vector2(MyShip.Position.X + (MotherShip.Width / 2), MyShip.Position.Y), "UP", 1));
                    Fire.Add(new Weapon(true, 1, MotherShipFireSingle[2], new Vector2(4, -8), new Animation(MotherShipFire[3], new Point(1, 1), new Point(MotherShipFire[3].Width / 4, MotherShipFire[3].Height), new Point(0, 0), 60, 0, 0.5f), 1, new Vector2(MyShip.Position.X + (MotherShip.Width / 2), MyShip.Position.Y), "UP", 1));
                    Fire.Add(new Weapon(true, 1, MotherShipFireSingle[3], new Vector2(-2, -8), new Animation(MotherShipFire[3], new Point(1, 1), new Point(MotherShipFire[3].Width / 4, MotherShipFire[3].Height), new Point(0, 0), 60, 0, 0.5f), 1, new Vector2(MyShip.Position.X + (MotherShip.Width / 2), MyShip.Position.Y), "UP", 1));
                    Fire.Add(new Weapon(true, 1, MotherShipFireSingle[3], new Vector2(2, -8), new Animation(MotherShipFire[3], new Point(1, 1), new Point(MotherShipFire[3].Width / 4, MotherShipFire[3].Height), new Point(0, 0), 60, 0, 0.5f), 1, new Vector2(MyShip.Position.X + (MotherShip.Width / 2), MyShip.Position.Y), "UP", 1));
                    Fire.Add(new Weapon(true, 1, MotherShipFireSingle[2], new Vector2(-1, -8), new Animation(MotherShipFire[3], new Point(1, 1), new Point(MotherShipFire[3].Width / 4, MotherShipFire[3].Height), new Point(0, 0), 60, 0, 0.5f), 1, new Vector2(MyShip.Position.X + (MotherShip.Width / 2), MyShip.Position.Y), "UP", 1));
                    Fire.Add(new Weapon(true, 1, MotherShipFireSingle[2], new Vector2(1, -8), new Animation(MotherShipFire[3], new Point(1, 1), new Point(MotherShipFire[3].Width / 4, MotherShipFire[3].Height), new Point(0, 0), 60, 0, 0.5f), 1, new Vector2(MyShip.Position.X + (MotherShip.Width / 2), MyShip.Position.Y), "UP", 1));
                }

            }

            
            }
        private int HealthbarInt(double Health)
        {
            return (int)Math.Round(((Health / 10) * 2));
        }

        public void SpawnTimes(int Level)
        {
            // Make AN array.
          
            SpawnTime = SpawnTimeCollection[Level];
        }

    }



}



