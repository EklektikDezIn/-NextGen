/*################# Main.cs #######################################
# Eklektik Design
# Micah Richards
# 12/28/2017
#           
# Purpose: 
#           
###############################################################*/

namespace NextGen
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;

    /// <summary>
    /// Defines the <see cref="Main" />
    /// </summary>
    internal class Main
    {
        /*################# Title #######################################
        # Purpose: 
        #          
        ###############################################################*/
        public static void addFlash()
        {
            if (Flash > 0)
            {
                Map.Insert(0, new Block(FlashVec[1], Main.Archives[0].Clone()));

                if (Flash > 1)
                {
                    Map.Insert(0, new Block(FlashVec[0], Main.Archives[0].Clone()));
                }
            }
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        ###############################################################*/
        public static OpenTK.Vector3 CalcSiz()
        {
            int size = (int)Math.Pow(2, RLevel) + 1;
            return new OpenTK.Vector3(size, size, size);
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        ###############################################################*/
        public static Room convertToRoom(List<String> inpt)
        {
            siz = new OpenTK.Vector3(alpha.SetXYZ(inpt[0]));
            FlashVec[0] = FlashVec[0].SetXYZ(0, (int)siz.Y - 1, 0);
            FlashVec[1] = FlashVec[1].SetXYZ(0, (int)siz.Y - 2, 0);

            Room load = new Room(siz);
            load.SetEmpty();
            inpt.RemoveAt(0);
            int y = 0;
            int x = 0;
            int z = 0;
            foreach (string i in inpt)
            {
                for (int j = 0; j < i.Length; j++)
                {
                    if (i[j].Equals('|'))
                    {
                        x++;
                        z = 0;
                        j++;
                    }
                    load.SetObject(alpha.SetXYZ(x, y, z), i[j]);
                    z++;
                }
                y++;
                x = 0;
                z = 0;
            }
            return load;
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        ###############################################################*/
        public static void createRoom()
        {
            List<String> Values = File.Read(Main.path[0] + "\\Resources\\Values.txt");
            Program.Wind.stopTimer();
            Load Loading = new Load();
            Loading.setStatus("Creating Room...", 10);
            FlashVec[0] = FlashVec[0].SetXYZ(0, (int)siz.Y - 1, 0);
            FlashVec[1] = FlashVec[1].SetXYZ(0, (int)siz.Y - 2, 0);
            siz = CalcSiz();
            FEmpty = new Room(siz); //Set Room to size Level^2+1
            Loading.setStatus("Clearing...", 20);
            FEmpty.SetEmpty();
            Loading.setStatus("Adding Water...", 30);
            FEmpty.AddLevel('~', WaterHeight);
            Loading.setStatus("Generating Terrain...", 40);
            FEmpty.TerrainGen(RLevel, corners);
            Loading.setStatus("Landscaping...", 50);
            FEmpty = FEmpty.ModTerrain();
            Loading.setStatus("Adding Lava...", 70);
            FEmpty.AddLava(LavaHeight);
            Loading.setStatus("Hollowing Map...", 90);
            maps[0] = FEmpty.Hollow().ToDisplay();
            Loading.setStatus("Preparing For Display...", 95);
            siz = CalcSiz();
            Map = maps[0];
            Program.Wind.setBlock();
            Program.Wind.setName();
            Loading.setStatus("Loaded", 100);
            Loading.Close();
            Program.Wind.startTimer();
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        ###############################################################*/
        public static void DrawScene()
        {

            Draw.BoxScene(ii, alpha.SetXYZ(0, 0, 0), siz.OffSetS(-1, -1, -1), 0);//Generate Frame
            if (Flash > 0)
            {
                if (Program.Wind.Check2())
                {
                    Draw.BoxScene(ii, FlashVec[0], FlashVec[1], 2);
                }
                if (Program.Wind.Check3())
                {
                    int rad = Program.Wind.getRad();
                    switch (Program.Wind.RB3())
                    {
                        case "Red": Draw.BoxScene(ii, FlashVec[0].OffSetS(rad, rad, rad), FlashVec[0].OffSetS(-rad, -rad, -rad), 6); break;
                        case "Blue": Draw.BoxScene(ii, FlashVec[1].OffSetS(rad, rad, rad), FlashVec[1].OffSetS(-rad, -rad, -rad), 6); break;
                    }
                }
                if (Program.Wind.Check4())
                {
                    int rad = Scene.GetXDim() - 1;
                    switch (Program.Wind.RB4())
                    {
                        case "Red": Draw.BoxScene(ii, FlashVec[0].OffSetS(rad, rad, rad), FlashVec[0], 1); break;
                        case "Blue": Draw.BoxScene(ii, FlashVec[1].OffSetS(rad, rad, rad), FlashVec[1], 1); break;
                    }
                }
                if (Program.Wind.Check5())
                {
                    int rad = Program.Wind.getS();
                    switch (Program.Wind.RB5())
                    {
                        case "Red": Draw.BoxScene(ii, FlashVec[0], FlashVec[0].OffSetS(rad, rad, rad), 3); break;
                        case "Blue": Draw.BoxScene(ii, FlashVec[1], FlashVec[1].OffSetS(rad, rad, rad), 3); break;
                    }
                }
            }
            //AddItems
            foreach (Block ent in Map)
            {
                Draw.Cube(ii, ent);
            }
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        ###############################################################*/
        public static void loadVar()
        {
            //alpha = alpha.setXYZ("<(123, 423, 0123)]>");
            String local = Directory.GetCurrentDirectory();
            local = local.Remove(local.LastIndexOf("\\"));
            path[0] = local.Remove(local.LastIndexOf("\\"));

            //Create Archive
            List<String> SD = File.Read(path[0] + "\\Resources\\Archive.txt");
            for (int i = 0; i < SD.Count; i += 9)
            {
                Archives.Add(new BlockType(SD[i + 0], SD[i + 1], SD[i + 2], SD[i + 3], SD[i + 4], SD[i + 5], SD[i + 6], SD[i + 7]));
            }
            //0)Selection
            //1)Empty
            //2)Character
            //3)Dirt
            //4)Grass
            //5)Stone
            //6)Dark_Stone
            //7)Sand
            //8)Log
            //9)Leaves
            //10)Clouds
            //11)Water
            //12)Lava







            // Load textures
            //Textures[0] = new Texture("Wood");
            //Textures[1] = new Texture("Dirt");
            //Textures[2] = new Texture("Grass", "Dirt", "GDirt", "GDirt", "GDirt", "GDirt");
            //Textures[3] = new Texture("Stone");
            //Textures[4] = new Texture("DStone");
            //Textures[5] = new Texture("Sand");
            //Textures[6] = new Texture("Water");
            //Textures[7] = new Texture("Cloud");
            //Textures[8] = new Texture("SSide", "SSide", "Slime", "SSide", "SSide", "SSide");
            //Textures[9] = new Texture("TRings", "TRings", "Trunk", "Trunk", "Trunk", "Trunk");
            //Textures[10] = new Texture("Leaves");
            //Textures[11] = new Texture("Lava");
            //Textures[12] = new Texture("CCube");
            //Textures[13] = new Texture("Select");
            //Hey Micah, don't be stupid. If you add another texture, change that ^^^^^^^^^


            //Set Colors
            Colors[0] = new Tint(Color.FromArgb(255, 255, 255, 255)); // White
            Colors[1] = new Tint(Color.FromArgb(255, 0, 255, 255)); // Teal
            Colors[2] = new Tint(Color.FromArgb(255, 255, 0, 255)); // Purple
            Colors[3] = new Tint(Color.FromArgb(255, 255, 255, 0)); // Yellow
            Colors[4] = new Tint(Color.FromArgb(255, 0, 0, 255)); // Blue
            Colors[5] = new Tint(Color.FromArgb(255, 255, 0, 0)); // Red
            Colors[6] = new Tint(Color.FromArgb(255, 0, 255, 0)); // Green
            Colors[7] = new Tint(Color.FromArgb(255, 0, 0, 0)); // Black

            //Set Transparency
            //TransP[0] = new Transparency(0);
            //TransP[1] = new Transparency(.1f);
            //TransP[2] = new Transparency(.2f);
            //TransP[3] = new Transparency(.3f);
            //TransP[4] = new Transparency(.4f);
            //TransP[5] = new Transparency(.5f);
            //TransP[6] = new Transparency(.6f);
            //TransP[7] = new Transparency(.7f);
            //TransP[8] = new Transparency(.8f);
            //TransP[9] = new Transparency(.9f);
            //TransP[10] = new Transparency(1);

            //Rotation Axis
            //rotAxis = rotAxis.setXYZ(0, 1, 0);
            Scene = convertToRoom(File.Read(path[0] + "\\Parts\\Tree.ngs"));
            createRoom();
            potato = new Intelligence(alpha.SetXYZ(-1, -1, -1), -1, -1, -1, -1, -1, -1, -1, -1);
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        ###############################################################*/
        public static void Refresh()
        {

            Program.Wind.MRef(0);

            Program.Wind.stopTimer();
            Load Loading = new Load();
            Loading.setStatus("Hollowing Map...", 90);
            maps[0] = FEmpty.Hollow().ToDisplay();
            Loading.setStatus("Preparing For Display...", 95);
            Map = maps[0];
            Program.Wind.setBlock();
            Program.Wind.setName();
            Loading.setStatus("Loaded", 100);
            Loading.Close();
            Program.Wind.startTimer();
            Program.Wind.MRef(1);
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        ###############################################################*/
        public static void Time(int itt)
        {
            for (int i = 0; i < itt; i++)
            {
                foreach (Intelligence Character in IA)
                {
                    OpenTK.Vector3 newpos = Character.Psyche();
                    FEmpty.MoveObject(Character.me, newpos);
                    Character.last = new OpenTK.Vector3(Character.me);
                    Character.me = newpos;
                    Character.TimeWear();
                    Character.Harvest();
                    Character.stat[5] -= (int)Character.Energy(Character.me, newpos);
                    Character.CheckStat();
                    if (!Character.alive)
                    {
                        Main.FEmpty.RemoveObject(Character.me);
                        Main.IA.Remove(Character);
                    }
                    Refresh();
                    Map = Character.Inpt.ToDisplay();
                }
            }
        }

        public static Texture[] Textures = new Texture[14];//Texture packs

        public static Tint[] Colors = new Tint[8];//Color scheme

        public static Transparency[] TransP = new Transparency[11];//Transparency

        public static List<Block>[] maps = new List<Block>[2];

        public static List<Block> Map;//Output list

        public static List<Intelligence> IA = new List<Intelligence>();

        public static Intelligence potato;

        public static Room FEmpty = new Room(3, 3, 3);//Room

        public static Room Scene;

        public static Room Stored;

        public static Camera cam = new Camera(45, 45, -10, -7, -.7f, -.5f, 45, 1.5f, 0.004f);//Camera set up

        public static int Range = 10;

        public static int ii = 0;//Current iteration

        public static int[] corners = { 5, 2, 4, 3 };//Corner heights

        public static int RLevel = 5;// Room level

        public static int WaterHeight = 5;//Water Height

        public static int LavaHeight = 5;//Lava Height

        public static int BeachWidth = 2;

        public static int MaxScent = 10;

        public static int MaxSound = 10;

        public static int Flash = 0;

        public static double TreeProb = 2;//Tree Probability

        public static double BushProb = 10;// Bush Probability

        public static double CloudProb = 2;// Cloud Probability

        public static double CaveProb = 2;// Cave Probability

        public static float roughness = 5;

        public static string[] path = new String[5];

        public static bool Error = false;

        public static bool MapOpen = false;

        public static bool MiniMap = false;

        public static OpenTK.Vector3[] FlashVec = new OpenTK.Vector3[2];

        public static OpenTK.Vector3 siz = new OpenTK.Vector3(33, 33, 33);// Room size

        public static OpenTK.Vector3 rotAxis = new OpenTK.Vector3(0, 0, 0);//Sets the axis of rotation

        internal static OpenTK.Vector3 alpha = new OpenTK.Vector3(0, 0, 0);//Class vector

        public static List<BlockType> Archives = new List<BlockType>();
    }
}
