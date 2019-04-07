/*################# Program.cs #######################################
# Eklektik Design
# Micah Richards
# 12/28/2017
#           
# Purpose: Starting class for NextGen
#           
###############################################################*/

namespace NextGen
{

    /*################# Includes #####################################*/
    using System;
    using System.Windows.Forms;

    internal static class Program
    {
        [STAThread]


        /*################# Variables #####################################*/
        public static Form1 Wind;     /*## Allows control over the window form ##*/


        /*################# Functions #####################################*/

        /*################# Main #######################################
        # Purpose: Program starting point
        #          
        ###############################################################*/
        internal static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Wind = new Form1();
            Application.Run(Wind);
        }
        
    }
}
