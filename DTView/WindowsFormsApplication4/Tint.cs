/*################# Tint.cs #######################################
# Eklektik Design
# Micah Richards
# 12/28/2017
#           
# Purpose: Handles the storage of Tints for NextGen Blocks
#           
###############################################################*/

namespace NextGen
{
    /*################# Includes #####################################*/
    using System;
    using System.Drawing;

    internal class Tint
    {

        /*################# Variables #####################################*/
        internal Color[] Palate = new Color[6];        /*## Stores the six colors for the blocks Tint ##*/


        /*################# Functions #####################################*/

        /*################# GetBack #######################################
        # Purpose: Returns the back Color for the Block
        #          
        ###############################################################*/
        public Color GetBack()
        {
            return Palate[3];
        }

        /*################# GetBottom #######################################
        # Purpose: Returns the bottom Color for the Block
        #          
        ###############################################################*/
        public Color GetBottom()
        {
            return Palate[1];
        }

        /*################# GetFront #######################################
        # Purpose: Returns the front Color for the Block
        #          
        ###############################################################*/
        public Color GetFront()
        {
            return Palate[2];
        }

        /*################# GetLeft #######################################
        # Purpose: Returns the left Color for the Block
        #          
        ###############################################################*/
        public Color GetLeft()
        {
            return Palate[4];
        }

        /*################# GetRight #######################################
        # Purpose: Returns the right Color for the Block
        #          
        ###############################################################*/
        public Color GetRight()
        {
            return Palate[5];
        }

        /*################# GetTop #######################################
        # Purpose: Returns the top Color for the Block
        #          
        ###############################################################*/
        public Color GetTop()
        {
            return Palate[0];
        }

        /*################# ToString #######################################
        # Purpose: Returns the string representation of the Tint object
        #          
        ###############################################################*/
        public override String ToString()
        {
            return "(" + Palate[0].ToString() + "," + Palate[1].ToString() + "," + Palate[2].ToString() + "," + Palate[3].ToString() + "," + Palate[4].ToString() + "," + Palate[5].ToString() + ")";
        }


        /*################# Constructors #####################################*/

        /*################# Tint #######################################
        # Purpose: Creates a Tint object with six unique sides
        #          
        ###############################################################*/
        public Tint(Color alpha, Color beta, Color gamma, Color delta, Color epsilon, Color zeta)
        {
            Palate[0] = alpha;
            Palate[1] = beta;
            Palate[2] = gamma;
            Palate[3] = delta;
            Palate[4] = epsilon;
            Palate[5] = zeta;
        }

        /*################# Tint #######################################
        # Purpose: Creates a tint object with six identical sides
        #          
        ###############################################################*/
        public Tint(Color alpha)
        {
            Palate[0] = alpha;
            Palate[1] = alpha;
            Palate[2] = alpha;
            Palate[3] = alpha;
            Palate[4] = alpha;
            Palate[5] = alpha;
        }
    }
}
