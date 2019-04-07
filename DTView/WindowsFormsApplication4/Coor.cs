/*################# Coor.cs #######################################
# Eklektik Design
# Micah Richards
# 12/28/2017
#           
# Purpose: Extends Vector3 and Vector2 objects for use with
#           NextGen
#           
###############################################################*/

namespace NextGen
{

    /*################# Includes #####################################*/
    using OpenTK;
    using System;
    using System.Collections.Generic;

    public static class Coor
    {

        /*################# Vector3 Functions #####################################*/

        /*################# Clone #######################################
        # Purpose: Makes a unique copy of a Coor object
        #           (Extends Vector3)
        #
        # Inputs:  None 
        #     
        # Outputs: Vector3:copy
        #          
        ###############################################################*/
        public static Vector3 Clone(this Vector3 vec)
        {
            return new Vector3(vec.X, vec.Y, vec.Z);
        }

        /*################# DistanceTo #######################################
        # Purpose: Returns the distance between each part of two vectors
        #           (Extends Vector3)
        #
        # Inputs:  Vector3:target
        #     
        # Outputs: Vector3:distances
        #          
        ###############################################################*/
        public static Vector3 DistanceTo(this Vector3 vec, Vector3 target)
        {
            return new Vector3(target.X - vec.X, target.Y - vec.Y, target.Z - vec.Z);
        }

        /*################# Lowest #######################################
        # Purpose: Returns the lowest of each part of two vectors
        #          
        # Inputs:  Vector3:V1,V2
        #     
        # Outputs: Vector3:minimums
        #          
        ###############################################################*/
        public static Vector3 Lowest(Vector3 V1, Vector3 V2)
        {
            return new Vector3(Math.Min(V1.X, V2.X), Math.Min(V1.Y, V2.Y), Math.Min(V1.Z, V2.Z));
        }

        /*################# OffSet #######################################
        # Purpose: Returns a new vector offset by the given quantities
        #           (Extends Vector3)
        #
        # Inputs:  float:offset x,offset y,offset z
        #     
        # Outputs: Vector3: offset Vector
        #          
        ###############################################################*/
        public static Vector3 OffSet(this Vector3 vec, float x, float y, float z)
        {
            return new Vector3(vec.X + x, vec.Y + y, vec.Z + z);
        }

        /*################# OffSet #######################################
        # Purpose: Returns a new vector offset by the vector
        #           (Extends Vector3)
        #          
        ###############################################################*/
        public static Vector3 OffSet(this Vector3 vec, Vector3 tar)
        {
            return new Vector3(vec.X + tar.X, vec.Y + tar.Y, vec.Z + tar.Z);
        }

        /*################# OffSetS #######################################
        # Purpose: Returns a new vector offset by the given quantities
        #           Offsets matched to sign of direction before addition
        #           (Extends Vector3)
        #          
        ###############################################################*/
        public static Vector3 OffSetS(this Vector3 vec, float x, float y, float z)
        {
            int sX;
            int sY;
            int sZ;
            if (vec.X / x == 0)
            {
                sX = 1;
            }
            else
            {
                sX = (int)(vec.X / Math.Abs(vec.X));
            }

            if (vec.Y == 0)
            {
                sY = 1;
            }
            else
            {
                sY = (int)(vec.Y / Math.Abs(vec.Y));
            }

            if (vec.Z == 0)
            {
                sZ = 1;
            }
            else
            {
                sZ = (int)(vec.Z / Math.Abs(vec.Z));
            }

            return new Vector3(vec.X + x * sX, vec.Y + y * sY, vec.Z + z * sZ);
        }

        /*################# OffSetX #######################################
        # Purpose: Returns a new vector multiplied by the given quantities
        #           (Extends Vector3)
        #
        #          
        ###############################################################*/
        public static Vector3 OffSetX(this Vector3 vec, float x, float y, float z)
        {
            return new Vector3(vec.X * x, vec.Y * y, vec.Z * z);
        }

        /*################# OrderCoor #######################################
        # Purpose: Creates a list of three Vector2 Objects of the format
        #           (Coordinate, ID) where 0=x,1=y,2=z.  This allows one
        #           to sort the coordinates without losing track of what
        #           was what
        #           (Extends Vector3)
        #          
        ###############################################################*/
        public static List<Vector2> OrderCoor(this Vector3 vec)
        {
            List<int> order = new List<int>();
            List<Vector2> report = new List<Vector2>();
            order.Add((int)Math.Abs(vec.X));
            order.Add((int)Math.Abs(vec.Y));
            order.Add((int)Math.Abs(vec.Z));
            order.Sort();
            if (order[0] == (int)Math.Abs(vec.X))
            {
                report.Add(new Vector2(vec.X, 0));
                if (order[1] == (int)Math.Abs(vec.Y))
                {
                    report.Add(new Vector2(vec.Y, 1));
                    report.Add(new Vector2(vec.Z, 2));
                }
                else
                {
                    report.Add(new Vector2(vec.Z, 2));
                    report.Add(new Vector2(vec.Y, 1));
                }
            }
            else if (order[0] == (int)Math.Abs(vec.Y))
            {
                report.Add(new Vector2(vec.Y, 1));
                if (order[1] == (int)Math.Abs(vec.X))
                {
                    report.Add(new Vector2(vec.X, 0));
                    report.Add(new Vector2(vec.Z, 2));
                }
                else
                {
                    report.Add(new Vector2(vec.Z, 2));
                    report.Add(new Vector2(vec.X, 0));
                }
            }
            else if (order[0] == (int)Math.Abs(vec.Z))
            {
                report.Add(new Vector2(vec.Z, 2));
                if (order[1] == (int)Math.Abs(vec.Y))
                {
                    report.Add(new Vector2(vec.Y, 1));
                    report.Add(new Vector2(vec.X, 0));
                }
                else
                {
                    report.Add(new Vector2(vec.X, 0));
                    report.Add(new Vector2(vec.Y, 1));
                }
            }

            return report;
        }

        /*################# Round #######################################
        # Purpose: Rounds the given vector coordinates down to the
        #           nearest integers
        #           (Extends Vector3)
        #          
        ###############################################################*/
        public static Vector3 Round(this Vector3 vec)
        {
            vec.X = (float)Math.Floor(vec.X);
            vec.Y = (float)Math.Floor(vec.Y);
            vec.Z = (float)Math.Floor(vec.Z);
            return vec;
        }

        /*################# SetXYZ #######################################
        # Purpose: Changes the values of a vector's coordinate from int
        #           values
        #           (Extends Vector3)
        #          
        ###############################################################*/
        public static Vector3 SetXYZ(this Vector3 vec, int x, int y, int z)
        {
            vec.X = x;
            vec.Y = y;
            vec.Z = z;
            return vec;
        }

        /*################# SetXYZ #######################################
        # Purpose: Changes the values of a vector's coordinate from a 
        #           string
        #           (Extends Vector3)
        #          
        ###############################################################*/
        public static Vector3 SetXYZ(this Vector3 vec, string xyz)
        {
            xyz = xyz.Substring(xyz.IndexOf('(') + 1, xyz.IndexOf(')'));
            vec.X = Int32.Parse(xyz.Substring(0, xyz.IndexOf(',')));

            xyz = xyz.Substring(xyz.IndexOf(',') + 2);
            vec.Y = Int32.Parse(xyz.Substring(0, xyz.IndexOf(',')));

            xyz = xyz.Substring(xyz.IndexOf(',') + 2);
            vec.Z = Int32.Parse(xyz.Substring(0, xyz.IndexOf(')')));

            return vec;
        }

        /*################# SumD #######################################
        # Purpose: Returns the sum of all three coordinates
        #           (Extends Vector3)
        #          
        ###############################################################*/
        public static float SumD(this Vector3 vec)
        {
            return vec.X + vec.Y + vec.Z;
        }

        /*################# SwitchXY #######################################
        # Purpose: Swaps the x and y coordinates
        #           (Extends Vector3)
        #          
        ###############################################################*/
        public static Vector3 SwitchXY(this Vector3 vec)
        {
            float temp = vec.X;
            vec.X = vec.Y;
            vec.Y = temp;
            return vec;
        }

        /*################# SwitchXZ #######################################
        # Purpose: Swaps the x and z coordinates
        #           (Extends Vector3)
        #          
        ###############################################################*/
        public static Vector3 SwitchXZ(this Vector3 vec)
        {
            float temp = vec.Z;
            vec.Z = vec.X;
            vec.X = temp;
            return vec;
        }

        /*################# SwitchZY #######################################
        # Purpose: Swaps the z and y coordinates
        #           (Extends Vector3)
        #          
        ###############################################################*/
        public static Vector3 SwitchZY(this Vector3 vec)
        {
            float temp = vec.Y;
            vec.Y = vec.Z;
            vec.Z = temp;
            return vec;
        }

        /*################# ToPositive #######################################
        # Purpose: Changes each coordinate to its absolute value
        #           (Extends Vector3)
        #          
        ###############################################################*/
        public static Vector3 ToPositive(this Vector3 vec)
        {
            vec.X = (float)Math.Abs(vec.X);
            vec.Y = (float)Math.Abs(vec.Y);
            vec.Z = (float)Math.Abs(vec.Z);
            return vec;
        }

        /*################# ToStringS #######################################
        # Purpose: Returns the string representation of the vector
        #           (Extends Vector3)
        #          
        ###############################################################*/
        public static String ToStringS(this Vector3 vec)
        {
            return ("(" + vec.X + ", " + vec.Y + ", " + vec.Z + ")");
        }


        /*################# Vector2 Functions #####################################*/

        /*################# OffSet #######################################
        # Purpose: Returns a new vector offset by the given quantities
        #           (Extends Vector2)
        #          
        ###############################################################*/
        public static Vector2 OffSet(this Vector2 vec, float x, float y)
        {
            return new Vector2(vec.X + x, vec.Y + y);
        }

        /*################# OffSet #######################################
        # Purpose: Returns a new vector offset by the given vector
        #           (Extends Vector2)
        #          
        ###############################################################*/
        public static Vector2 OffSet(this Vector2 vec, Vector2 tar)
        {
            return new Vector2(vec.X + tar.X, vec.Y + tar.Y);
        }
        
        /*################# SetX #######################################
        # Purpose: Sets the X value of a Vector2 object
        #           (Extends Vector2)
        #          
        ###############################################################*/
        public static Vector2 SetX(this Vector2 vec, float x)
        {
            return new Vector2(x, vec.Y);
        }

        /*################# SetY #######################################
        # Purpose: Sets the Y value of a Vector2 object
        #           (Extends Vector2)
        #          
        ###############################################################*/
        public static Vector2 SetY(this Vector2 vec, float y)
        {
            return new Vector2(vec.X, y);
        }

        /*################# Random Functions #####################################*/

        /*################# NextDouble #######################################
        # Purpose: Returns a random double between given numbers
        #           (Extends Random)
        #          
        ###############################################################*/
        public static double NextDouble(this Random random, double minValue, double maxValue)
        {
            return random.NextDouble() * (maxValue - minValue) + minValue;
        }
    }
}
