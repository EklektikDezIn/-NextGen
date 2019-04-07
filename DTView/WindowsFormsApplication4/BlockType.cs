/*################# BlockType.cs #######################################
# Eklektik Design
# Micah Richards
# 12/28/2017
#           
# Purpose: Handles the recording of all BlockType objects for NextGen
#           
###############################################################*/

namespace NextGen
{

    /*################# Includes #####################################*/
    using OpenTK;
    using System;

    internal class BlockType
    {

        /*################# Variables #####################################*/
        public string Name;     /*## The name of the block ##*/

        public char Symbol;     /*## The symbol of the block ##*/

        public Texture Textr;     /*## The texture for the block ##*/

        public Vector3 RotAxis;     /*## The axis of rotation for the block ##*/

        public float[] UserSees = new float[4];     /*## Properties for what the user can see (Rotspeed Size Transparency Tint) ##*/

        public int[] CharSees = new int[4];     /*## Properties for what teh character can see (Density Transparency Scent sound) ##*/

        public int[] Benefits = new int[3];     /*## The benefits of the block to the character (Food Water Healing) ##*/

        public char MapRender;     /*## (L)evel OR (R)andom OR (N) Height ##*/

        public int Probability;     /*## Probability of block occuring (0-100) ##*/


        /*################# Functions #####################################*/

        /*################# Clone #######################################
        # Purpose: Creates a unique BlockType object with matching
        #           properties
        #          
        ###############################################################*/
        public BlockType Clone()
        {
            float[] temp = new float[] { UserSees[0], UserSees[1], UserSees[2], UserSees[3] };

            int[] temp2 = new int[] { CharSees[0], CharSees[1], CharSees[2], CharSees[3] };

            int[] temp3 = new int[] { Benefits[0], Benefits[1], Benefits[2] };

            return new BlockType(Name, Symbol, Textr, RotAxis, temp, temp2, temp3, MapRender, Probability);
        }

        /*################# CopyBlockType #######################################
        # Purpose: Sets the current BlockBlocktype object to the properties of a
        #           given block
        #          
        ###############################################################*/
        public void CopyBlockType(BlockType target)
        {
            this.Name = target.Name;
            this.Symbol = target.Symbol;
            this.Textr = target.Textr;
            this.UserSees = target.UserSees;
            this.CharSees = target.CharSees;
            this.Benefits = target.Benefits;
            this.MapRender = target.MapRender;
            this.Probability = target.Probability;
        }

        /*################# Self #######################################
        # Purpose: Returns this BlockType object
        #          
        ###############################################################*/
        public BlockType Self()
        {
            return this;
        }

        /*################# SetTint #######################################
        # Purpose: Sets the tint property of the UserSees structure
        #          
        ###############################################################*/
        public void SetTint(int ti)
        {
            UserSees[3] = ti;
        }


        /*################# Constructors #####################################*/

        /*################# BlockType #######################################
        # Purpose: Creates an BlockType item from a collection of Strings
        #          
        ###############################################################*/
        public BlockType(String nam, String sym, String tex, String rot, String user, String car, String bene, String map)
        {
            Name = nam;
            Symbol = sym[0];
            if (tex.Contains("ALL"))
            {
                Textr = new Texture(tex.Substring(0, tex.IndexOf(" ")), 64);
            }
            else
            {
                String[] text = new String[6];
                for (int i = 0; i < 6; i++)
                {
                    text[i] = tex.Substring(0, tex.IndexOf(" "));
                    tex = tex.Substring(tex.IndexOf(" ") + 1);
                }

                Textr = new Texture(text[0], text[1], text[2], text[3], text[4], text[5], 64);
            }


            float[] rots = new float[3];
            for (int i = 0; i < 3; i++)
            {
                rots[i] = Convert.ToSingle(rot.Substring(0, rot.IndexOf(" ")));
                rot = rot.Substring(rot.IndexOf(" ") + 1);
            }
            RotAxis = new Vector3(rots[0], rots[1], rots[2]);


            for (int i = 0; i < 4; i++)
            {
                UserSees[i] = Convert.ToSingle(user.Substring(0, user.IndexOf(" ")));
                user = user.Substring(user.IndexOf(" ") + 1);
            }
            UserSees[2] = (10 - UserSees[2]) / 10;

            for (int i = 0; i < 4; i++)
            {
                CharSees[i] = Convert.ToInt32(car.Substring(0, car.IndexOf(" ")));
                car = car.Substring(car.IndexOf(" ") + 1);
            }


            for (int i = 0; i < 3; i++)
            {
                Benefits[i] = Convert.ToInt32(bene.Substring(0, bene.IndexOf(" ")));
                bene = bene.Substring(bene.IndexOf(" ") + 1);
            }


            MapRender = map.Substring(0, map.IndexOf(" "))[0];
            map = map.Substring(map.IndexOf(" "));
            Probability = Convert.ToInt32(map);
        }

        /*################# BlockType #######################################
        # Purpose: Creates an BlockType object from a premade set of inputs
        #          
        ###############################################################*/
        public BlockType(string name, char symbol, Texture textr, Vector3 rotaxis, float[] user, int[] car, int[] bene, char map, int prob)
        {
            Name = name;
            Symbol = symbol;
            Textr = textr;
            UserSees = user;
            CharSees = car;
            Benefits = bene;
            MapRender = map;
            Probability = prob;
        }

        /*################# BlockType #######################################
        # Purpose: Creates a blank BlockType object
        #          
        ###############################################################*/
        public BlockType()
        {
        }
    }
}
