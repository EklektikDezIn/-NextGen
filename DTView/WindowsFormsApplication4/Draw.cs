/*################# Draw.cs #######################################
# Eklektik Design
# Micah Richards
# 12/28/2017
#           
# Purpose: 
#           
###############################################################*/

namespace NextGen
{
    using OpenTK;
    using OpenTK.Graphics.OpenGL;
    using System;
    using System.Drawing;

    internal class Draw
    {
        /*################# Title #######################################
        # Purpose: 
        #          
        ###############################################################*/
        public static void BoxScene(int it, OpenTK.Vector3 coor1, OpenTK.Vector3 coor2, int scheme)
        {
            float rotSpeed = 0; //sets the angle of Rotation
            OpenTK.Vector3 rotAxis = Main.rotAxis;
            float[] TP = new float[6] { 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f };
            Texture texture = new Texture("Wood", 64);
            Tint Basic = Main.Colors[scheme];
            OpenTK.Vector3 distance = coor1.DistanceTo(coor2);
            int xcount;
            int ycount;
            int zcount;
            if (distance.X == 0)
            {
                xcount = 1;
            }
            else
            {
                xcount = (int)(distance.X / Math.Abs(distance.X));
            }

            if (distance.Y == 0)
            {
                ycount = 1;
            }
            else
            {
                ycount = (int)(distance.Y / Math.Abs(distance.Y));
            }

            if (distance.Z == 0)
            {
                zcount = 1;
            }
            else
            {
                zcount = (int)(distance.Z / Math.Abs(distance.Z));
            }



            //Base
            DrawRect(it,
              -(coor1.X - .6f * xcount), (coor1.Y - .6f * ycount), (coor1.Z - .6f * zcount),
                -distance.X - xcount * 1.2f, 0.1f, 0.1f,
                rotSpeed, rotAxis,
                texture, Basic, TP);
            DrawRect(it,
                -(coor1.X - .6f * xcount), (coor1.Y - .6f * ycount), (coor1.Z - .6f * zcount),
                0.1f, 0.1f, distance.Z + zcount * 1.2f,
                rotSpeed, rotAxis,
                texture, Basic, TP);
            DrawRect(it,
               -(coor1.X + distance.X + .6f * xcount), (coor1.Y - .6f * ycount), (coor1.Z + distance.Z + .6f * zcount),
                distance.X + xcount * 1.2f, 0.1f, 0.1f,
                rotSpeed, rotAxis,
                texture, Basic, TP);
            DrawRect(it,
                 -(coor1.X + distance.X + .6f * xcount), (coor1.Y - .6f * ycount), (coor1.Z + distance.Z + .6f * zcount),
                0.1f, 0.1f, -distance.Z - zcount * 1.2f,
                rotSpeed, rotAxis,
                texture, Basic, TP);

            //Walls
            DrawRect(it,
                -(coor1.X - .6f * xcount), (coor1.Y + distance.Y + .6f * ycount), (coor1.Z - .6f * zcount),
                0.1f, -(distance.Y + ycount * 1.2f), 0.1f,
                rotSpeed, rotAxis,
                texture, Basic, TP);
            DrawRect(it,
               -(coor1.X + distance.X + .6f * xcount), (coor1.Y + distance.Y + .6f * ycount), (coor1.Z + distance.Z + .6f * zcount),
                0.1f, -(distance.Y + ycount * 1.2f), 0.1f,
                rotSpeed, rotAxis,
                texture, Basic, TP);
            DrawRect(it,
               -(coor1.X - .6f * xcount), (coor1.Y + distance.Y + .6f * ycount), (coor1.Z + distance.Z + .6f * zcount),
               0.1f, -(distance.Y + ycount * 1.2f), 0.1f,
               rotSpeed, rotAxis,
               texture, Basic, TP);
            DrawRect(it,
               -(coor1.X + distance.X + .6f * xcount), (coor1.Y + distance.Y + .6f * ycount), (coor1.Z - .6f * zcount),
                0.1f, -(distance.Y + ycount * 1.2f), 0.1f,
                rotSpeed, rotAxis,
                texture, Basic, TP);
            //Top
            DrawRect(it,
              -(coor1.X - .6f * xcount), (coor1.Y + distance.Y + .6f * ycount), (coor1.Z - .6f * zcount),
                -distance.X - xcount * 1.2f, 0.1f, 0.1f,
                rotSpeed, rotAxis,
                texture, Basic, TP);
            DrawRect(it,
                -(coor1.X - .6f * xcount), (coor1.Y + distance.Y + .6f * ycount), (coor1.Z - .6f * zcount),
                0.1f, 0.1f, distance.Z + zcount * 1.2f,
                rotSpeed, rotAxis,
                texture, Basic, TP);
            DrawRect(it,
               -(coor1.X + distance.X + .6f * xcount), (coor1.Y + distance.Y + .6f * ycount), (coor1.Z + distance.Z + .6f * zcount),
                distance.X + xcount * 1.2f, 0.1f, 0.1f,
                rotSpeed, rotAxis,
                texture, Basic, TP);
            DrawRect(it,
                 -(coor1.X + distance.X + .6f * xcount), (coor1.Y + distance.Y + .6f * ycount), (coor1.Z + distance.Z + .6f * zcount),
                0.1f, 0.1f, -distance.Z - zcount * 1.2f,
                rotSpeed, rotAxis,
                texture, Basic, TP);
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        ###############################################################*/
        public static void Cube(int it, Block ent)
        {
            BlockType data = ent.GetBlockType();
            //Adjusts object position for centering
            double x = ent.Pos.X + data.UserSees[1] / -2;
            double y = ent.Pos.X + data.UserSees[1] / 2;
            double z = ent.Pos.X + data.UserSees[1] / 2;

            double rotA = 0;// (data.UserSees[0] * it) % 360;//sets rotation angle

            GL.PushMatrix();
            GL.Translate(ent.Pos);//Moves object
            GL.Rotate(rotA, data.RotAxis.X, data.RotAxis.Y, data.RotAxis.Z);//Rotates object

            //Top
            GL.BindTexture(TextureTarget.Texture2D, data.Textr.GetTop()); //Get texture
            GL.Begin(PrimitiveType.Quads);
            GL.Color4(Main.Colors[(int)data.UserSees[3]].GetTop().R, Main.Colors[(int)data.UserSees[3]].GetTop().G, Main.Colors[(int)data.UserSees[3]].GetTop().B, data.UserSees[2]);//Set color and transparancy
            GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(-data.UserSees[1] / 2, data.UserSees[1] / 2, data.UserSees[1] / 2);//Create Plane
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(data.UserSees[1] / 2, data.UserSees[1] / 2, data.UserSees[1] / 2);
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(data.UserSees[1] / 2, data.UserSees[1] / 2, -data.UserSees[1] / 2);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(-data.UserSees[1] / 2, data.UserSees[1] / 2, -data.UserSees[1] / 2);
            GL.End();

            //Bottom
            GL.BindTexture(TextureTarget.Texture2D, data.Textr.GetBottom());
            GL.Begin(PrimitiveType.Quads);
            GL.Color4(Main.Colors[(int)data.UserSees[3]].GetBottom().R, Main.Colors[(int)data.UserSees[3]].GetBottom().G, Main.Colors[(int)data.UserSees[3]].GetBottom().B, data.UserSees[2]);
            GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(-data.UserSees[1] / 2, -data.UserSees[1] / 2, data.UserSees[1] / 2);
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(-data.UserSees[1] / 2, -data.UserSees[1] / 2, -data.UserSees[1] / 2);
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(data.UserSees[1] / 2, -data.UserSees[1] / 2, -data.UserSees[1] / 2);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(data.UserSees[1] / 2, -data.UserSees[1] / 2, data.UserSees[1] / 2);
            GL.End();

            //Front
            GL.BindTexture(TextureTarget.Texture2D, data.Textr.GetFront());
            GL.Begin(PrimitiveType.Quads);
            GL.Color4(Main.Colors[(int)data.UserSees[3]].GetFront().R, Main.Colors[(int)data.UserSees[3]].GetFront().G, Main.Colors[(int)data.UserSees[3]].GetFront().B, data.UserSees[2]);
            GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(-data.UserSees[1] / 2, -data.UserSees[1] / 2, data.UserSees[1] / 2);
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(data.UserSees[1] / 2, -data.UserSees[1] / 2, data.UserSees[1] / 2);
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(data.UserSees[1] / 2, data.UserSees[1] / 2, data.UserSees[1] / 2);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(-data.UserSees[1] / 2, data.UserSees[1] / 2, data.UserSees[1] / 2);
            GL.End();

            //Back
            GL.BindTexture(TextureTarget.Texture2D, data.Textr.GetBack());
            GL.Begin(PrimitiveType.Quads);
            GL.Color4(Main.Colors[(int)data.UserSees[3]].GetBack().R, Main.Colors[(int)data.UserSees[3]].GetBack().G, Main.Colors[(int)data.UserSees[3]].GetBack().B, data.UserSees[2]);
            GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(data.UserSees[1] / 2, -data.UserSees[1] / 2, -data.UserSees[1] / 2);
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(-data.UserSees[1] / 2, -data.UserSees[1] / 2, -data.UserSees[1] / 2);
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(-data.UserSees[1] / 2, data.UserSees[1] / 2, -data.UserSees[1] / 2);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(data.UserSees[1] / 2, data.UserSees[1] / 2, -data.UserSees[1] / 2);
            GL.End();

            //Left
            GL.BindTexture(TextureTarget.Texture2D, data.Textr.GetLeft());
            GL.Begin(PrimitiveType.Quads);
            GL.Color4(Main.Colors[(int)data.UserSees[3]].GetLeft().R, Main.Colors[(int)data.UserSees[3]].GetLeft().G, Main.Colors[(int)data.UserSees[3]].GetLeft().B, data.UserSees[2]);
            GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(-data.UserSees[1] / 2, -data.UserSees[1] / 2, -data.UserSees[1] / 2);
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(-data.UserSees[1] / 2, -data.UserSees[1] / 2, data.UserSees[1] / 2);
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(-data.UserSees[1] / 2, data.UserSees[1] / 2, data.UserSees[1] / 2);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(-data.UserSees[1] / 2, data.UserSees[1] / 2, -data.UserSees[1] / 2);
            GL.End();

            //Right
            GL.BindTexture(TextureTarget.Texture2D, data.Textr.GetRight());
            GL.Begin(PrimitiveType.Quads);
            GL.Color4(Main.Colors[(int)data.UserSees[3]].GetRight().R, Main.Colors[(int)data.UserSees[3]].GetRight().G, Main.Colors[(int)data.UserSees[3]].GetRight().B, data.UserSees[2]);
            GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(data.UserSees[1] / 2, -data.UserSees[1] / 2, data.UserSees[1] / 2);
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(data.UserSees[1] / 2, -data.UserSees[1] / 2, -data.UserSees[1] / 2);
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(data.UserSees[1] / 2, data.UserSees[1] / 2, -data.UserSees[1] / 2);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(data.UserSees[1] / 2, data.UserSees[1] / 2, data.UserSees[1] / 2);
            GL.End();


            GL.PopMatrix();
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        ###############################################################*/
        public static void DrawRect(int it, float x, float y, float z, float sizex, float sizey, float sizez, float rotAngle, OpenTK.Vector3 rotAxis, Texture tRef, Tint Tint, float[] transparancy)
        {
            //Adjusts object position for centering
            x += sizex / 2;
            x *= -1;
            y += sizey / 2;
            z += sizez / 2;

            rotAngle *= it;//sets rotation angle

            GL.PushMatrix();
            GL.Translate(x, y, z);//Moves object
            GL.Rotate(-rotAngle, rotAxis.X, rotAxis.Y, rotAxis.Z);//Rotates object

            //Top
            GL.BindTexture(TextureTarget.Texture2D, tRef.GetTop()); //Get texture
            GL.Begin(PrimitiveType.Quads);
            GL.Color4(Tint.GetTop().R, Tint.GetTop().G, Tint.GetTop().B, transparancy[0]);//Set color and transparancy
            GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(-sizex / 2, sizey / 2, sizez / 2);//Create Plane
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(sizex / 2, sizey / 2, sizez / 2);
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(sizex / 2, sizey / 2, -sizez / 2);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(-sizex / 2, sizey / 2, -sizez / 2);
            GL.End();

            //Bottom
            GL.BindTexture(TextureTarget.Texture2D, tRef.GetBottom());
            GL.Begin(PrimitiveType.Quads);
            GL.Color4(Tint.GetBottom().R, Tint.GetBottom().G, Tint.GetBottom().B, transparancy[1]);
            GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(-sizex / 2, -sizey / 2, sizez / 2);
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(-sizex / 2, -sizey / 2, -sizez / 2);
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(sizex / 2, -sizey / 2, -sizez / 2);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(sizex / 2, -sizey / 2, sizez / 2);
            GL.End();

            //Front
            GL.BindTexture(TextureTarget.Texture2D, tRef.GetFront());
            GL.Begin(PrimitiveType.Quads);
            GL.Color4(Tint.GetFront().R, Tint.GetFront().G, Tint.GetFront().B, transparancy[2]);
            GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(-sizex / 2, -sizey / 2, sizez / 2);
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(sizex / 2, -sizey / 2, sizez / 2);
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(sizex / 2, sizey / 2, sizez / 2);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(-sizex / 2, sizey / 2, sizez / 2);
            GL.End();

            //Back
            GL.BindTexture(TextureTarget.Texture2D, tRef.GetBack());
            GL.Begin(PrimitiveType.Quads);
            GL.Color4(Tint.GetBack().R, Tint.GetBack().G, Tint.GetBack().B, transparancy[3]);
            GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(sizex / 2, -sizey / 2, -sizez / 2);
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(-sizex / 2, -sizey / 2, -sizez / 2);
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(-sizex / 2, sizey / 2, -sizez / 2);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(sizex / 2, sizey / 2, -sizez / 2);
            GL.End();

            //Left
            GL.BindTexture(TextureTarget.Texture2D, tRef.GetLeft());
            GL.Begin(PrimitiveType.Quads);
            GL.Color4(Tint.GetLeft().R, Tint.GetLeft().G, Tint.GetLeft().B, transparancy[4]);
            GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(-sizex / 2, -sizey / 2, -sizez / 2);
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(-sizex / 2, -sizey / 2, sizez / 2);
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(-sizex / 2, sizey / 2, sizez / 2);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(-sizex / 2, sizey / 2, -sizez / 2);
            GL.End();

            //Right
            GL.BindTexture(TextureTarget.Texture2D, tRef.GetRight());
            GL.Begin(PrimitiveType.Quads);
            GL.Color4(Tint.GetRight().R, Tint.GetRight().G, Tint.GetRight().B, transparancy[5]);
            GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(sizex / 2, -sizey / 2, sizez / 2);
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(sizex / 2, -sizey / 2, -sizez / 2);
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(sizex / 2, sizey / 2, -sizez / 2);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(sizex / 2, sizey / 2, sizez / 2);
            GL.End();

            GL.PopMatrix();
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        ###############################################################*/
        public static void Load()
        {
            // Setup OpenGL capabilities
            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.CullFace);
            GL.Enable(EnableCap.Texture2D);
            // Setup background color
            GL.ClearColor(Color.Black);
            Main.loadVar();
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        ###############################################################*/
        public static void Pyramid(int it, float x, float y, float z, float size, float rotAngle, OpenTK.Vector3 rotAxis, Texture tRef, Tint Tint, Transparency transparancy)
        {
            //Adjusts object position for centering
            x += size / 2;
            x *= -1;
            y += size / 2;
            z += size / 2;

            rotAngle *= it;//sets rotation angle

            GL.PushMatrix();
            GL.Translate(x, y, z);//Moves object

            GL.Rotate(-rotAngle, rotAxis.X, rotAxis.Y, rotAxis.Z);//Rotates object
            //Bottom
            GL.BindTexture(TextureTarget.Texture2D, tRef.GetBottom()); //Get texture
            GL.Begin(PrimitiveType.Quads);
            GL.Color4(Tint.GetBottom().R, Tint.GetBottom().G, Tint.GetBottom().B, transparancy.GetBottom()); //Set color and transparancy
            GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(-size / 2, -size / 2, size / 2);//Create Plane
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(-size / 2, -size / 2, -size / 2);
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(size / 2, -size / 2, -size / 2);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(size / 2, -size / 2, size / 2);
            GL.End();

            //Front
            GL.BindTexture(TextureTarget.Texture2D, tRef.GetFront());
            GL.Begin(PrimitiveType.Triangles);
            GL.Color4(Tint.GetFront().R, Tint.GetFront().G, Tint.GetFront().B, transparancy.GetFront());
            GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(-size / 2, -size / 2, size / 2);
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(size / 2, -size / 2, size / 2);
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(0, size / 2, 0);
            GL.End();

            //Back
            GL.BindTexture(TextureTarget.Texture2D, tRef.GetBack());
            GL.Begin(PrimitiveType.Triangles);
            GL.Color4(Tint.GetBack().R, Tint.GetBack().G, Tint.GetBack().B, transparancy.GetBack());
            GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(size / 2, -size / 2, -size / 2);
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(-size / 2, -size / 2, -size / 2);
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(0, size / 2, 0);
            GL.End();

            //Left
            GL.BindTexture(TextureTarget.Texture2D, tRef.GetLeft());
            GL.Begin(PrimitiveType.Triangles);
            GL.Color4(Tint.GetLeft().R, Tint.GetLeft().G, Tint.GetLeft().B, transparancy.GetLeft());
            GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(-size / 2, -size / 2, -size / 2);
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(-size / 2, -size / 2, size / 2);
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(0, size / 2, 0);
            GL.End();

            //Right
            GL.BindTexture(TextureTarget.Texture2D, tRef.GetRight());
            GL.Begin(PrimitiveType.Triangles);
            GL.Color4(Tint.GetRight().R, Tint.GetRight().G, Tint.GetRight().B, transparancy.GetRight());
            GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(size / 2, -size / 2, size / 2);
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(size / 2, -size / 2, -size / 2);
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(0, size / 2, 0);
            GL.End();






            GL.PopMatrix();
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        ###############################################################*/
        public static void Render()
        {
            // Clear the screen
            if (!loaded) { return; }
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            // Initialise the model view matrix
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            GL.Enable(EnableCap.Blend);
            // Draw the scene
            Main.DrawScene();

            GL.Disable(EnableCap.Blend);
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        ###############################################################*/
        public static void SetLoaded(bool inpt)
        {
            loaded = inpt;
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        ###############################################################*/
        public static void UpdateImage(int w, int h)
        {

            if (!loaded) { return; }

            float aspect = 1;
            // Calculate aspect ratio, checking for divide by zero
            if (h > 0)
            {
                aspect = (float)w / (float)h;
            }

            // Initialise the projection view matrix
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            // Setup a perspective view

            float FOVradians = MathHelper.DegreesToRadians(Main.cam.GetZoom());
            Matrix4 perspective = Main.cam.GetViewMatrix() * Matrix4.CreatePerspectiveFieldOfView(FOVradians, aspect, 1.0f, 4000.0f);
            GL.MultMatrix(ref perspective);

            // Set the viewport to the whole window
            GL.Viewport(0, 0, w, h);
        }

        public static bool loaded = false;//Checks if OpenGL Window is active
    }
}
