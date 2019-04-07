/*################# Variables.cs #######################################
# Eklektik Design
# Micah Richards
# 12/28/2017
#           
# Purpose: Stores a collection of booleans for managing NextGen
#           
###############################################################*/

namespace NextGen
{

    /*################# Includes #####################################*/
    using System;
    
    internal class Variables
    {

        /*################# Variables #####################################*/
        public static Boolean[] booleans = { false };     /*## Checks if OpenGL Window is active ##*/


        /*################# Functions #####################################*/

        /*################# Getboolean #######################################
        # Purpose: Gets a boolean from a specified index
        #          
        ###############################################################*/
        public static bool Getboolean(int index)
        {
            return booleans[index];
        }

        /*################# Setboolean #######################################
        # Purpose: Sets a boolean at a specified index
        #          
        ###############################################################*/
        public static void Setboolean(int index, Boolean inpt)
        {
            booleans[index] = inpt;
        }                                           
    }
}
