/*################# File.cs #######################################
# Eklektik Design
# Micah Richards
# 12/28/2017
#           
# Purpose: Handles IO for General Usage
#           
###############################################################*/

namespace NextGen
{

    /*################# Includes #####################################*/
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    internal class File
    {

        /*################# Functions #####################################*/

        /*################# Clear #######################################
        # Purpose: Clears a given file
        #
        ###############################################################*/
        public static void Clear(String file)
        {
            try
            {
                //Open the File
                StreamWriter sw = new StreamWriter(file, false, Encoding.ASCII);

                //Write the text
                sw.Write("");
                //Close the file
                sw.Close();
            }
            catch (Exception e)
            {
                if (Main.Error)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
            }
        }

        /*################# Read #######################################
        # Purpose: Returns the a list of the String contents for a given
        #           file
        #          
        ###############################################################*/
        public static List<String> Read(String file)
        {
            List<String> Paragraph = new List<String>();
            String line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(file);

                //Read the first line of text
                line = sr.ReadLine();

                //Continue to read until you reach end of file
                while (line != null)
                {
                    //Add the line to the list
                    Paragraph.Add(line);
                    //Read the next line
                    line = sr.ReadLine();
                }

                //Close the file
                sr.Close();
            }
            catch (Exception e)
            {
                if (Main.Error)
                {
                    Console.WriteLine("Exception at readFile: " + e.Message);
                }
            }
            return Paragraph;
        }

        /*################# Write #######################################
        # Purpose: Writes multiple lines to the end of a specified file
        #          
        ###############################################################*/
        public static void Write(String file, List<String> inpt)
        {
            try
            {
                //Open the File
                StreamWriter sw = new StreamWriter(file, true, Encoding.ASCII);

                //Write the text
                foreach (string i in inpt)
                {
                    sw.Write(i);
                }
                //Close the file
                sw.Close();
            }
            catch (Exception e)
            {
                if (Main.Error)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
            }
        }

        /*################# Write #######################################
        # Purpose: Writes a single line to the end of a specified file
        #          
        ###############################################################*/
        public static void Write(String file, String inpt)
        {
            try
            {
                //Open the File
                StreamWriter sw = new StreamWriter(file, true, Encoding.ASCII);

                //Write the text
                sw.Write(inpt);
                //Close the file
                sw.Close();
            }
            catch (Exception e)
            {
                if (Main.Error)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
            }
        }
    }
}
