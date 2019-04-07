/*################# Texture.cs #######################################
# Eklektik Design
# Micah Richards
# 12/28/2017
#           
# Purpose: Handles the storage of Textures for NextGen Blocks
#           
###############################################################*/

namespace NextGen
{

    /*################# Includes #####################################*/
    using OpenTK.Graphics.OpenGL;
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;   // For BitmMapData type

    internal class Texture
    {

        /*################# Variables #####################################*/
        internal int[] skins = new int[6];        /*## Stores the six textures for a block ##*/


        /*################# Functions #####################################*/

        /*################# GetBack #######################################
        # Purpose: Returns the back texture
        #          
        ###############################################################*/
        public int GetBack()
        {
            return skins[3];
        }

        /*################# GetBottom #######################################
        # Purpose: Returns the bottom texture
        #          
        ###############################################################*/
        public int GetBottom()
        {
            return skins[1];
        }

        /*################# GetFront #######################################
        # Purpose: Returns the front texture
        #          
        ###############################################################*/
        public int GetFront()
        {
            return skins[2];
        }

        /*################# GetLeft #######################################
        # Purpose: Returns the left texture
        #          
        ###############################################################*/
        public int GetLeft()
        {
            return skins[4];
        }

        /*################# GetRight #######################################
        # Purpose: Returns the right texture
        #          
        ###############################################################*/
        public int GetRight()
        {
            return skins[5];
        }

        /*################# GetTop #######################################
        # Purpose: Returns the top texture
        #          
        ###############################################################*/
        public int GetTop()
        {
            return skins[0];
        }

        /*################# ToString #######################################
        # Purpose: Returns the string representation of the Texture
        #           object
        #          
        ###############################################################*/
        public override string ToString()
        {
            return "(" + skins[0] + "," + skins[1] + "," + skins[2] + "," + skins[3] + "," + skins[4] + "," + skins[5] + ")";
        }

        /*################# UploadTexture #######################################
        # Purpose: Takes an image file and makes it usable by the Texture
        #           object
        #          
        ###############################################################*/
        public static int UploadTexture(string pathname)
        {
            int id = GL.GenTexture();

            // Select the new texture
            GL.BindTexture(TextureTarget.Texture2D, id);

            // Load the image
            Bitmap bmp = new Bitmap(pathname);

            // Lock image data to allow direct access
            BitmapData bmp_data = bmp.LockBits(
                    new Rectangle(0, 0, bmp.Width, bmp.Height),
                    System.Drawing.Imaging.ImageLockMode.ReadOnly,
                    System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            // Import the image data into the OpenGL texture
            GL.TexImage2D(TextureTarget.Texture2D,
                          0,
                          PixelInternalFormat.Rgba,
                          bmp_data.Width,
                          bmp_data.Height,
                          0,
                          OpenTK.Graphics.OpenGL.PixelFormat.Bgra,
                          OpenTK.Graphics.OpenGL.PixelType.UnsignedByte,
                          bmp_data.Scan0);

            // Unlock the image data
            bmp.UnlockBits(bmp_data);

            // Configure minification and magnification filters
            GL.TexParameter(TextureTarget.Texture2D,
                    TextureParameterName.TextureMinFilter,
                    (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D,
                    TextureParameterName.TextureMagFilter,
                    (int)TextureMagFilter.Linear);

            // Return the OpenGL object ID for use
            return id;
        }


        /*################# Constructors #####################################*/

        /*################# Texture #######################################
        # Purpose: Creates a Texture object with six uniques sides
        #          
        ###############################################################*/
        public Texture(String Top, String Bottom, String Front, String Back, String Left, String Right, int quality)
        {
            //Multi Textured Object
            skins[0] = UploadTexture(Main.path[0] + "\\Resources\\" + quality.ToString() + "\\" + Top + ".png");
            skins[1] = UploadTexture(Main.path[0] + "\\Resources\\" + quality.ToString() + "\\" + Bottom + ".png");
            skins[2] = UploadTexture(Main.path[0] + "\\Resources\\" + quality.ToString() + "\\" + Front + ".png");
            skins[3] = UploadTexture(Main.path[0] + "\\Resources\\" + quality.ToString() + "\\" + Back + ".png");
            skins[4] = UploadTexture(Main.path[0] + "\\Resources\\" + quality.ToString() + "\\" + Left + ".png");
            skins[5] = UploadTexture(Main.path[0] + "\\Resources\\" + quality.ToString() + "\\" + Right + ".png");
        }

        /*################# Texture #######################################
        # Purpose: Creates a Texture object with six identical sides
        #          
        ###############################################################*/
        public Texture(String Image, int quality)
        {
            String temp = Main.path[0] + "\\Resources\\" + quality.ToString() + "\\" + Image + ".png";
            skins[0] = UploadTexture(temp);
            skins[1] = UploadTexture(temp);
            skins[2] = UploadTexture(temp);
            skins[3] = UploadTexture(temp);
            skins[4] = UploadTexture(temp);
            skins[5] = UploadTexture(temp);
        }
    }
}
