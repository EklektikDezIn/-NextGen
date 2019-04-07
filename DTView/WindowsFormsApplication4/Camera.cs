/*################# Camera.cs #######################################
# Eklektik Design
# Micah Richards
# 12/28/2017
#           
# Purpose: Handles the user's view of the map
#           
###############################################################*/

namespace NextGen
{

    /*################# Includes #####################################*/
    using OpenTK;
    using System;

    internal class Camera
    {

        /*################# Variables #####################################*/
        public Vector3 Position;        /*## Stores the position of the camera object ##*/

        public Vector3 Orientation;     /*## Stores the orientation of the camera object ##*/

        public float Speed;             /*## Stores the sensitivity towards key presses ##*/

        public float Sensitivity;       /*## Stores the sensitivity of toward mouse movements ##*/

        public float Zoom;              /*## Stores the zoom of the camera object ##*/


        /*################# Functions #####################################*/

        /*################# GetViewMatrix #######################################
        # Purpose: Takes the information on the camera's perspective and
        #           outputs a view of the blocks
        #          
        ###############################################################*/
        public Matrix4 GetViewMatrix()
        {
            OpenTK.Vector3 lookat = new OpenTK.Vector3();

            lookat.X = (float)(Math.Sin((float)Orientation.X) * Math.Cos((float)Orientation.Y));
            lookat.Y = (float)Math.Sin((float)Orientation.Y);
            lookat.Z = (float)(Math.Cos((float)Orientation.X) * Math.Cos((float)Orientation.Y));

            return Matrix4.LookAt(Position, Position + lookat, OpenTK.Vector3.UnitY);
        }

        /*################# GetXAng #######################################
        # Purpose: Returns the X component of the rotation
        #          
        ###############################################################*/
        public float GetXAng()
        {
            return Orientation.X;
        }

        /*################# GetXPos #######################################
        # Purpose: Returns the X position
        #          
        ###############################################################*/
        public float GetXPos()
        {
            return Position.X;
        }

        /*################# GetYAng #######################################
        # Purpose: Returns the Y component of the rotation
        #          
        ###############################################################*/
        public float GetYAng()
        {
            return Orientation.Y;
        }

        /*################# GetYPos #######################################
        # Purpose: Returns the Y position
        #          
        ###############################################################*/
        public float GetYPos()
        {
            return Position.Y;
        }

        /*################# GetZAng #######################################
        # Purpose: Returns the Z component of the angle
        #          
        ###############################################################*/
        public float GetZAng()
        {
            return Orientation.Z;
        }

        /*################# GetZoom #######################################
        # Purpose: Returns the zoom property of the camera
        #          
        ###############################################################*/
        public float GetZoom()
        {
            return Zoom;
        }

        /*################# GetZPos #######################################
        # Purpose: Returns the Z position
        #          
        ###############################################################*/
        public float GetZPos()
        {
            return Position.Z;
        }

        /*################# Move #######################################
        # Purpose: Adjusts the position of the camera by a specified
        #           amount
        #          
        ###############################################################*/
        public void Move(float x, float y, float z)
        {
            OpenTK.Vector3 offset = new OpenTK.Vector3();

            OpenTK.Vector3 forward = new OpenTK.Vector3((float)Math.Sin((float)Orientation.X), 0, (float)Math.Cos((float)Orientation.X));
            OpenTK.Vector3 right = new OpenTK.Vector3(-forward.Z, 0, forward.X);

            offset += x * right;
            offset += y * forward;
            offset.Y += z;

            offset.NormalizeFast();
            offset = OpenTK.Vector3.Multiply(offset, Speed);

            Position += offset;
        }
        
        /*################# Rotate #######################################
        # Purpose: Adjust the rotation of the camera by a specified
        #           amount
        #          
        ###############################################################*/
        public void Rotate(float x, float y)
        {
            x = x * Sensitivity;
            y = y * Sensitivity;

            Orientation.X = (Orientation.X + x) % ((float)Math.PI * 2.0f);
            Orientation.Y = Math.Max(Math.Min(Orientation.Y + y, (float)Math.PI / 2.0f - 0.1f), (float)-Math.PI / 2.0f + 0.1f);
        }


        /*################# Constructors #####################################*/

        /*################# Camera #######################################
        # Purpose: Creates a new Camera object
        #          
        ###############################################################*/
        public Camera(float xPos, float yPos, float zPos, float xAng, float yAng, float zAng, float zoom, float MoveSpeed, float MouseSpeed)
        {
            Position = new Vector3(xPos, yPos, zPos);
            Orientation = new Vector3(xAng, yAng, zAng);
            Speed = MoveSpeed;
            Sensitivity = MouseSpeed;
            Zoom = zoom;
        }
    }
}
