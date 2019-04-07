/*################# Room #######################################
# Eklektik Design
# Micah Richards
# 05/26/2015
#           
# Purpose: 
#           
###############################################################*/


/*################# Imports #####################################*/

namespace NextGen
{
    using OpenTK;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="Room" />
    /// </summary>
    internal class Room
    {
        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public void AddArea(Vector3 coor1, Vector3 coor2, char ent)
        {
            if (Contains(coor1) && Contains(coor2))
            {
                Vector3 distance = coor1.DistanceTo(coor2);
                Vector3 target = new Vector3(0, 0, 0);
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

                for (int x = (int)coor1.X; x != coor2.X + xcount; x += xcount)
                {
                    for (int y = (int)coor1.Y; y != coor2.Y + ycount; y += ycount)
                    {
                        for (int z = (int)coor1.Z; z != coor2.Z + zcount; z += zcount)
                        {
                            SetObject(target.SetXYZ(x, y, z), ent);
                        }
                    }
                }
            }
            else
            {
                if (Main.Error)
                {
                    System.Console.WriteLine("addArea: Either " + coor1.ToString() + " or " + coor2.ToString() + "does not exist");
                }
            }
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        private void AddLand()
        {
            for (int r = 0; r < height.GetLength(0); r++)
            {
                for (int c = 0; c < height.GetLength(1); c++)
                {
                    for (int h = 0; h <= height[r, c]; h++)
                    {
                        alpha = alpha.SetXYZ(r, h, c);
                        SetObject(alpha, ']');

                    }
                }
            }
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public void AddLava(int height)
        {
            for (int r = 0; r < GetXDim(); r++)
            {
                for (int c = 0; c < GetZDim(); c++)
                {
                    for (int h = 0; h < height; h++)
                    {
                        alpha = alpha.SetXYZ(r, h, c);
                        if (GetObjectAt(alpha).Equals('#'))
                        {
                            SetObject(alpha, '!');
                            if (GetObjectAt(alpha.OffSet(1, 0, 0)).Equals('S')) { SetObject(alpha.OffSet(1, 0, 0), 'D'); }
                            if (GetObjectAt(alpha.OffSet(-1, 0, 0)).Equals('S')) { SetObject(alpha.OffSet(-1, 0, 0), 'D'); }
                            if (GetObjectAt(alpha.OffSet(0, 1, 0)).Equals('S')) { SetObject(alpha.OffSet(0, 1, 0), 'D'); }
                            if (GetObjectAt(alpha.OffSet(0, -1, 0)).Equals('S')) { SetObject(alpha.OffSet(0, -1, 0), 'D'); }
                            if (GetObjectAt(alpha.OffSet(0, 0, 1)).Equals('S')) { SetObject(alpha.OffSet(0, 0, 1), 'D'); }
                            if (GetObjectAt(alpha.OffSet(0, 0, -1)).Equals('S')) { SetObject(alpha.OffSet(0, 0, -1), 'D'); }
                        }
                    }
                }
            }
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public void AddLevel(char sym, int height)
        {
            for (int r = 0; r < GetXDim(); r++)
            {
                for (int c = 0; c < GetZDim(); c++)
                {
                    for (int h = 0; h < height; h++)
                    {
                        alpha = alpha.SetXYZ(r, h, c);
                        SetObject(alpha, sym);
                    }
                }
            }
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public void AddRadius(Vector3 coor, int Rad, char ent)
        {
            Vector3 obtar = new Vector3(0, 0, 0);
            for (int ydim = -Rad; ydim <= Rad; ydim++)
            {
                for (int xdim = -Rad; xdim <= Rad; xdim++)
                {
                    for (int zdim = -Rad; zdim <= Rad; zdim++)
                    {
                        if (Math.Abs(xdim) + Math.Abs(zdim) + Math.Abs(ydim) <= Rad)
                        {
                            obtar = obtar.SetXYZ((int)coor.X + xdim, (int)coor.Y + ydim, (int)coor.Z + zdim);
                            if (Contains(obtar))
                            {
                                SetObject(obtar, ent);
                            }
                        }
                    }
                }
            }
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public void AddRadiusI(Vector3 coor, int Rad, char ent)
        {
            Vector3 obtar = new Vector3(0, 0, 0);
            for (int ydim = -Rad; ydim <= Rad; ydim++)
            {
                for (int xdim = -Rad; xdim <= Rad; xdim++)
                {
                    for (int zdim = -Rad; zdim <= Rad; zdim++)
                    {
                        if (Math.Abs(xdim) + Math.Abs(zdim) + Math.Abs(ydim) >= Rad)
                        {
                            obtar = obtar.SetXYZ((int)coor.X + xdim, (int)coor.Y + ydim, (int)coor.Z + zdim);
                            if (Contains(obtar))
                            {
                                SetObject(obtar, ent);
                            }
                        }
                    }
                }
            }
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public void AddScene(Room obj, Vector3 target)
        {
            for (int y = 0; y < obj.GetYDim(); y++)
            {
                for (int x = 0; x < obj.GetXDim(); x++)
                {
                    for (int z = 0; z < obj.GetZDim(); z++)
                    {
                        alpha = alpha.SetXYZ(x, y, z);
                        SetObject(alpha.OffSet(target), obj.GetObjectAt(alpha));
                    }
                }
            }
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public void AddSceneB(Room obj, Vector3 target, char ent)
        {
            for (int y = 0; y < obj.GetYDim(); y++)
            {
                for (int x = 0; x < obj.GetXDim(); x++)
                {
                    for (int z = 0; z < obj.GetZDim(); z++)
                    {
                        alpha = alpha.SetXYZ(x, y, z);
                        if (!obj.GetObjectAt(alpha).Equals('#'))
                        {
                            SetObject(alpha.OffSet(target), ent);
                        }
                        else
                        {
                            SetObject(alpha.OffSet(target), '#');
                        }
                    }
                }
            }
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public void AddSceneI(Room obj, Vector3 target, char ent)
        {
            for (int y = 0; y < obj.GetYDim(); y++)
            {
                for (int x = 0; x < obj.GetXDim(); x++)
                {
                    for (int z = 0; z < obj.GetZDim(); z++)
                    {
                        alpha = alpha.SetXYZ(x, y, z);
                        if (obj.GetObjectAt(alpha).Equals('#'))
                        {
                            SetObject(alpha.OffSet(target), ent);
                        }
                    }
                }
            }
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public void AddToArea(Vector3 coor1, Vector3 coor2, char ent)
        {
            if (Contains(coor1) && Contains(coor2))
            {
                Vector3 distance = coor1.DistanceTo(coor2);
                Vector3 target = new Vector3(0, 0, 0);
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

                for (int x = (int)coor1.X; x != coor2.X + xcount; x += xcount)
                {
                    for (int y = (int)coor1.Y; y != coor2.Y + ycount; y += ycount)
                    {
                        for (int z = (int)coor1.Z; z != coor2.Z + zcount; z += zcount)
                        {
                            target = target.SetXYZ(x, y, z);
                            if (GetObjectAt(target).Equals('#'))
                            {
                                SetObject(target, ent);
                            }
                        }
                    }
                }
            }
            else
            {
                if (Main.Error)
                {
                    System.Console.WriteLine("addArea: Either " + coor1.ToString() + " or " + coor2.ToString() + "does not exist");
                }
            }
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public void AddToRadius(Vector3 coor, int Rad, char ent)
        {
            Vector3 obtar = new Vector3(0, 0, 0);
            for (int ydim = -Rad; ydim <= Rad; ydim++)
            {
                for (int xdim = -Rad; xdim <= Rad; xdim++)
                {
                    for (int zdim = -Rad; zdim <= Rad; zdim++)
                    {
                        if (Math.Abs(xdim) + Math.Abs(zdim) + Math.Abs(ydim) <= Rad)
                        {
                            obtar = obtar.SetXYZ((int)coor.X + xdim, (int)coor.Y + ydim, (int)coor.Z + zdim);
                            if (Contains(obtar) && GetObjectAt(obtar).Equals('#'))
                            {
                                SetObject(obtar, ent);
                            }
                        }
                    }
                }
            }
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public void AddToRadiusI(Vector3 coor, int Rad, char ent)
        {
            Vector3 obtar = new Vector3(0, 0, 0);
            for (int ydim = -Rad; ydim <= Rad; ydim++)
            {
                for (int xdim = -Rad; xdim <= Rad; xdim++)
                {
                    for (int zdim = -Rad; zdim <= Rad; zdim++)
                    {
                        if (Math.Abs(xdim) + Math.Abs(zdim) + Math.Abs(ydim) >= Rad)
                        {
                            obtar = obtar.SetXYZ((int)coor.X + xdim, (int)coor.Y + ydim, (int)coor.Z + zdim);
                            if (Contains(obtar) && GetObjectAt(obtar).Equals('#'))
                            {
                                SetObject(obtar, ent);
                            }
                        }
                    }
                }
            }
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public void AddToScene(Room obj, Vector3 target)
        {
            for (int y = 0; y < obj.GetYDim(); y++)
            {
                for (int x = 0; x < obj.GetXDim(); x++)
                {
                    for (int z = 0; z < obj.GetZDim(); z++)
                    {
                        alpha = alpha.SetXYZ(x, y, z);
                        if (GetObjectAt(alpha.OffSet(target)).Equals('#'))
                        {
                            SetObject(alpha.OffSet(target), obj.GetObjectAt(alpha));
                        }
                    }
                }
            }
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public void AddToSceneB(Room obj, Vector3 target, char ent)
        {
            for (int y = 0; y < obj.GetYDim(); y++)
            {
                for (int x = 0; x < obj.GetXDim(); x++)
                {
                    for (int z = 0; z < obj.GetZDim(); z++)
                    {
                        alpha = alpha.SetXYZ(x, y, z);
                        if (GetObjectAt(target.OffSet(alpha)).Equals('#') && !obj.GetObjectAt(alpha).Equals('#'))
                        {
                            SetObject(alpha.OffSet(target), ent);
                        }
                    }
                }
            }
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public void AddToSceneI(Room obj, Vector3 target, char ent)
        {
            for (int y = 0; y < obj.GetYDim(); y++)
            {
                for (int x = 0; x < obj.GetXDim(); x++)
                {
                    for (int z = 0; z < obj.GetZDim(); z++)
                    {
                        alpha = alpha.SetXYZ(x, y, z);
                        if (obj.GetObjectAt(alpha).Equals('#') && GetObjectAt(target.OffSet(alpha)).Equals('#'))
                        {
                            SetObject(alpha.OffSet(target), ent);
                        }
                    }
                }
            }
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public void Cave(int depth, Vector3 coor, double chance, char ent)
        {

            alpha = alpha.SetXYZ((int)coor.X, (int)coor.Y, (int)coor.Z);
            if (Contains(alpha)) { SetObject(alpha, ent); }
            if (Contains(alpha.OffSet(1, 0, 0)) && GetObjectAt(alpha.OffSet(1, 0, 0)).Equals(']') && GetObjectAt(alpha.OffSet(1, 0, 0)).Equals('#')) { SetObject(alpha.OffSet(1, 0, 0), ent); }
            if (Contains(alpha.OffSet(-1, 0, 0)) && GetObjectAt(alpha.OffSet(-1, 0, 0)).Equals(']') && !GetObjectAt(alpha.OffSet(-1, 0, 0)).Equals('#')) { SetObject(alpha.OffSet(-1, 0, 0), ent); }
            if (Contains(alpha.OffSet(0, 1, 0)) && GetObjectAt(alpha.OffSet(0, 1, 0)).Equals(']') && !GetObjectAt(alpha.OffSet(0, 1, 0)).Equals('#')) { SetObject(alpha.OffSet(0, 1, 0), ent); }
            if (Contains(alpha.OffSet(0, -1, 0)) && GetObjectAt(alpha.OffSet(0, -1, 0)).Equals(']') && !GetObjectAt(alpha.OffSet(0, -1, 0)).Equals('#')) { SetObject(alpha.OffSet(0, -1, 0), ent); }
            if (Contains(alpha.OffSet(0, 0, 1)) && GetObjectAt(alpha.OffSet(0, 0, 1)).Equals(']') && !GetObjectAt(alpha.OffSet(0, 0, 1)).Equals('#')) { SetObject(alpha.OffSet(0, 0, 1), ent); }
            if (Contains(alpha.OffSet(0, 0, -1)) && GetObjectAt(alpha.OffSet(0, 0, -1)).Equals(']') && !GetObjectAt(alpha.OffSet(0, 0, -1)).Equals('#')) { SetObject(alpha.OffSet(0, 0, -1), ent); }
            double prob = Math.Pow(chance, 2);
            alpha = alpha.SetXYZ((int)coor.X + 1, (int)coor.Y, (int)coor.Z);
            if
            (Contains(alpha) /*&& inpt[coor.X + 1, coor.Y, coor.Z].Equals(']'*/ && Rand.NextDouble() < prob)
            {
                Cave(depth + 1, alpha, prob, ent);
            }
            alpha = alpha.SetXYZ((int)coor.X - 1, (int)coor.Y, (int)coor.Z);
            if
            (Contains(alpha) /*&& inpt[(int)coor.X - 1, (int)coor.Y, (int)coor.Z].Equals(']')*/&& Rand.NextDouble() < prob)
            {
                Cave(depth + 1, alpha, prob, ent);
            }
            alpha = alpha.SetXYZ((int)coor.X, (int)coor.Y + 1, (int)coor.Z);
            if
            (Contains(alpha) /*&& inpt[(int)coor.X , (int)coor.Y+1, (int)coor.Z].Equals(']'*/ && Rand.NextDouble() < prob)
            {
                Cave(depth + 1, alpha, prob, ent);
            }
            alpha = alpha.SetXYZ((int)coor.X, (int)coor.Y - 1, (int)coor.Z);
            if
            (Contains(alpha) /*&& inpt[(int)coor.X , (int)coor.Y-1, (int)coor.Z].Equals(']'*/ && Rand.NextDouble() < prob)
            {
                Cave(depth + 1, alpha, prob, ent);
            }
            alpha = alpha.SetXYZ((int)coor.X, (int)coor.Y, (int)coor.Z + 1);
            if
            (Contains(alpha) /*&& inpt[(int)coor.X + 1, (int)coor.Y, (int)coor.Z+1].Equals(']'*/ && Rand.NextDouble() < prob)
            {
                Cave(depth + 1, alpha, prob, ent);
            }
            alpha = alpha.SetXYZ((int)coor.X, (int)coor.Y, (int)coor.Z - 1);
            if
            (Contains(alpha) /*&& inpt[(int)coor.X , (int)coor.Y, (int)coor.Z-1].Equals(']'*/ && Rand.NextDouble() < prob)
            {
                Cave(depth + 1, alpha, prob, ent);
            }
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public Room ChangeSize(int x, int y, int z)
        {
            Room CS = new Room(x, y, z);
            CS.Name = Name;
            CS.SetEmpty();
            for (int xi = 0; xi < GetXDim(); xi++)
            {
                for (int yi = 0; yi < GetYDim(); yi++)
                {
                    for (int zi = 0; zi < GetZDim(); zi++)
                    {
                        alpha = alpha.SetXYZ(xi, yi, zi);
                        CS.SetObject(alpha, GetObjectAt(alpha));
                    }
                }
            }
            return CS;
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public static Block CharToEnt(char inpt, Vector3 target)
        {
            foreach (BlockType data in Main.Archives)
            {
                if (data.Symbol.Equals(inpt))
                {
                    return new Block(target, data.Clone());
                }
            }
            return null;
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public Room Clone()
        {
            Room clone = new Room(GetRoomSize());

            for (int x = 0; x < GetXDim(); x++)
            {
                for (int y = 0; y < GetYDim(); y++)
                {
                    for (int z = 0; z < GetZDim(); z++)
                    {
                        alpha = alpha.SetXYZ(x, y, z);
                        clone.SetObject(alpha, GetObjectAt(alpha));
                    }
                }
            }
            return clone;
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public bool Contains(char ent)
        {
            Vector3 obtar = new Vector3(0, 0, 0);
            for (int y = 0; y < GetYDim(); y++)
            {
                for (int x = 0; x < GetXDim(); x++)
                {
                    for (int z = 0; z < GetZDim(); z++)
                    {
                        obtar = obtar.SetXYZ(x, y, z);
                        if (GetObjectAt(obtar) == ent)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public bool Contains(Vector3 coor)
        {
            return (coor.X >= 0 && coor.Y >= 0 && coor.Z >= 0 && coor.X < GetXDim() && coor.Y < GetYDim() && coor.Z < GetZDim());
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public void Divide(int xbeg, int zbeg, int xfin, int zfin)
        {
            int halfx = xbeg + ((xfin - xbeg) / 2);
            int halfz = zbeg + ((zfin - zbeg) / 2);
            double scale = (Main.roughness / 10) * (xfin - xbeg);
            height[xbeg, halfz] = (height[xbeg, zbeg] + height[xbeg, zfin]) / 2;
            height[xfin, halfz] = (height[xfin, zbeg] + height[xfin, zfin]) / 2;
            height[halfx, zbeg] = (height[xbeg, zbeg] + height[xfin, zbeg]) / 2;
            height[halfx, zfin] = (height[xbeg, zfin] + height[xfin, zfin]) / 2;
            height[halfx, halfz] = ((height[xbeg, zbeg] + height[xfin, zbeg] + height[xbeg, zfin] + height[xfin, zfin]) / 4) + (Rand.NextDouble(-1, 1) * scale);

            if (xfin - xbeg <= 3)
            {
                return;
            }
            else
            {
                Divide(xbeg, zbeg, halfx, halfz);
                Divide(halfx, halfz, xfin, zfin);
                Divide(xbeg, halfz, halfx, zfin);
                Divide(halfx, zbeg, xfin, halfz);
            }
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public List<Vector3> FindObjects(char ent)
        {
            List<Vector3> datapoints = new List<Vector3>();
            Vector3 obtar = new Vector3(0, 0, 0);
            for (int y = 0; y < GetYDim(); y++)
            {
                for (int x = 0; x < GetXDim(); x++)
                {
                    for (int z = 0; z < GetZDim(); z++)
                    {
                        obtar = obtar.SetXYZ(x, y, z);
                        if (GetObjectAt(obtar) == ent)
                        {
                            datapoints.Add(obtar);
                        }
                    }
                }
            }
            return datapoints;
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public List<Vector3> FindObjects(int ent)
        {
            List<Vector3> datapoints = new List<Vector3>();
            Vector3 obtar = new Vector3(0, 0, 0);
            for (int y = 0; y < GetYDim(); y++)
            {
                for (int x = 0; x < GetXDim(); x++)
                {
                    for (int z = 0; z < GetZDim(); z++)
                    {
                        obtar = obtar.SetXYZ(x, y, z);
                        if (Type(obtar, 'D') == ent)
                        {
                            datapoints.Add(obtar);
                        }
                    }
                }
            }
            return datapoints;
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public List<Vector3> GetEdges()
        {
            List<Vector3> Edges = new List<Vector3>();
            for (int x = 0; x < GetXDim(); x++)
            {
                for (int y = 0; y < GetYDim(); y++)
                {
                    for (int z = 0; z < GetZDim(); z++)
                    {
                        if (x == 0 || x == GetXDim() - 1 || y == 0 || y == GetYDim() - 1 || z == 0 || z == GetZDim() - 1)
                        {
                            Edges.Add(new Vector3(x, y, z));
                        }
                    }
                }
            }
            return Edges;
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public char GetObjectAt(Vector3 coor)
        {
            if (Contains(coor))
            {
                return Cube[(int)coor.X, (int)coor.Y, (int)coor.Z];
            }
            else
            {
                if (Main.Error)
                {
                    System.Console.WriteLine("getObjectAt:  " + coor.ToString() + " does not exist.");
                }
                return '#';
            }
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public Room GetObjectsAt(Vector3 coor1, Vector3 coor2)
        {


            Vector3 distance = coor1.DistanceTo(coor2);
            Vector3 target = new Vector3(0, 0, 0);
            Vector3 obtar = new Vector3(0, 0, 0);
            Room area = new Room(distance.ToPositive().OffSetS(1, 1, 1));
            area.SetEmpty();

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

            for (int x = (int)coor1.X; x != coor2.X + xcount; x += xcount)
            {
                for (int y = (int)coor1.Y; y != coor2.Y + ycount; y += ycount)
                {
                    for (int z = (int)coor1.Z; z != coor2.Z + zcount; z += zcount)
                    {
                        area.SetObject(target.SetXYZ(x - GL((int)coor1.X, (int)coor2.X), y - GL((int)coor1.Y, (int)coor2.Y), z - GL((int)coor1.Z, (int)coor2.Z)), GetObjectAt(obtar.SetXYZ(x, y, z)));
                    }
                }
            }
            return area;
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public Room GetObjectsInRadius(Vector3 coor, int Rad)
        {
            Vector3 target = new Vector3(0, 0, 0);
            Vector3 obtar = new Vector3(0, 0, 0);
            Room area = new Room(2 * Rad + 1, 2 * Rad + 1, 2 * Rad + 1);
            area.offset = coor.OffSet(-Rad, -Rad, -Rad);
            area.SetEmpty();
            for (int ydim = -Rad; ydim <= Rad; ydim++)
            {
                for (int xdim = -Rad; xdim <= Rad; xdim++)
                {
                    for (int zdim = -Rad; zdim <= Rad; zdim++)
                    {
                        if (Math.Abs(xdim) + Math.Abs(zdim) + Math.Abs(ydim) <= Rad)
                        {
                            target = target.SetXYZ(xdim + Rad, ydim + Rad, zdim + Rad);
                            obtar = obtar.SetXYZ((int)coor.X + xdim, (int)coor.Y + ydim, (int)coor.Z + zdim);
                            if (Contains(target) && Contains(obtar))
                            {
                                char temp = GetObjectAt(obtar);
                                area.SetObject(target, GetObjectAt(obtar));
                            }
                        }
                    }
                }
            }
            return area;
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public char[,,] GetRoom()
        {
            return Cube;
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public Vector3 GetRoomSize()
        {
            return new Vector3(GetXDim(), GetYDim(), GetZDim());
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public int GetXDim()
        {
            return Cube.GetLength(0);
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public int GetYDim()
        {
            return Cube.GetLength(1);
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public int GetZDim()
        {
            return Cube.GetLength(2);
        }

        //}
        //else
        //{
        //    if (Main.Error)
        //    {
        //        System.Console.WriteLine("Vision: " + Home.ToString() + "does not exist");
        //    }
        //    return null;
        //}

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public static int GL(int alpha, int beta)
        {
            if (alpha < beta)
            {
                return alpha;
            }
            else
            {
                return beta;
            }
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public Room Hollow()
        {
            Room comp = new Room(GetXDim(), GetYDim(), GetZDim());
            comp.offset = offset;
            comp.Name = Name;
            bool Norm = true;
            for (int x = 0; x < GetXDim(); x++)
            {
                for (int y = 0; y < GetYDim(); y++)
                {
                    for (int z = 0; z < GetZDim(); z++)
                    {
                        alpha = alpha.SetXYZ(x, y, z);
                        for (int i = 0; i <= 9; i++)
                        {
                            if ((Type(alpha, 'D') == i) &&
                                (Type(alpha.OffSet(1, 0, 0), 'D') == i) &&
                                (Type(alpha.OffSet(-1, 0, 0), 'D') == i) &&
                                (Type(alpha.OffSet(0, 1, 0), 'D') == i) &&
                                (Type(alpha.OffSet(0, -1, 0), 'D') == i) &&
                                (Type(alpha.OffSet(0, 0, 1), 'D') == i) &&
                                (Type(alpha.OffSet(0, 0, -1), 'D') == i))
                            {
                                comp.SetObject(alpha, '#');
                                Norm = false;
                            }
                        }
                        if (Norm)
                        {
                            comp.SetObject(alpha, GetObjectAt(alpha));
                        }
                        Norm = true;
                    }
                }
            }
            return comp;
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public Room InvertFB(Vector3 coor1, int dis)
        {
            Room rot = new Room(dis, dis, dis);
            rot.offset = coor1;
            rot.offset = rot.offset.OffSet(offset);
            rot.SetEmpty();
            Vector3 temp = new Vector3(0, 0, 0);
            for (int x = 0; x < dis; x++)
            {
                for (int y = 0; y < dis; y++)
                {
                    for (int z = 0; z < dis; z++)
                    {
                        alpha = alpha.SetXYZ(x, y, z);
                        temp = alpha.OffSetX(1, -1, 1).OffSet(0, dis - 1, 0);
                        rot.SetObject(temp, GetObjectAt(alpha.OffSet(coor1)));
                    }
                }

            }
            return rot;
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public Room InvertLR(Vector3 coor1, int dis)
        {
            Room rot = new Room(dis, dis, dis);
            rot.offset = coor1;
            rot.offset = rot.offset.OffSet(offset);
            rot.SetEmpty();
            Vector3 temp = new Vector3(0, 0, 0);
            for (int x = 0; x < dis; x++)
            {
                for (int y = 0; y < dis; y++)
                {
                    for (int z = 0; z < dis; z++)
                    {
                        alpha = alpha.SetXYZ(x, y, z);
                        temp = alpha.OffSetX(-1, 1, 1).OffSet(dis - 1, 0, 0);
                        rot.SetObject(temp, GetObjectAt(alpha.OffSet(coor1)));
                    }
                }

            }
            return rot;
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public Room InvertUD(Vector3 coor1, int dis)
        {
            Room rot = new Room(dis, dis, dis);
            rot.offset = coor1;
            rot.offset = rot.offset.OffSet(offset);
            rot.SetEmpty();
            Vector3 temp = new Vector3(0, 0, 0);
            for (int x = 0; x < dis; x++)
            {
                for (int y = 0; y < dis; y++)
                {
                    for (int z = 0; z < dis; z++)
                    {
                        alpha = alpha.SetXYZ(x, y, z);
                        temp = alpha.OffSetX(1, 1, -1).OffSet(0, 0, dis - 1);
                        rot.SetObject(temp, GetObjectAt(alpha.OffSet(coor1)));
                    }
                }

            }
            return rot;
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public List<Vector3> Line(Vector3 Home, Vector3 walls, int range)
        {
            //if (Contains(Home))
            //{
            List<Vector3> points = new List<Vector3>();
            Vector3 distance = new Vector3(walls.X - Home.X, walls.Y - Home.Y, walls.Z - Home.Z);
            int xVal = (int)distance.X;
            int yVal = (int)distance.Y;
            int zVal = (int)distance.Z;

            int wallX = (int)walls.X;
            int wallY = (int)walls.Y;
            int wallZ = (int)walls.Z;

            int xmov;
            if (xVal != 0)
            {
                xmov = (xVal / Math.Abs(xVal));
            }
            else
            {
                xmov = 0;
            }
            int ymov;
            if (yVal != 0)
            {
                ymov = (yVal / Math.Abs(yVal));
            }
            else
            {
                ymov = 0;
            }
            int zmov;
            if (zVal != 0)
            {
                zmov = (zVal / Math.Abs(zVal));
            }
            else
            {
                zmov = 0;
            }

            int xLoc = wallX, yLoc = wallY, zLoc = wallZ;
            Vector3 target = new Vector3(wallX + xmov, wallY + ymov, wallZ + zmov);
            while (Math.Abs(distance.X) + Math.Abs(distance.Y) + Math.Abs(distance.Z) < range)
            {
                xVal = (int)distance.X;
                yVal = (int)distance.Y;
                zVal = (int)distance.Z;
                while (xVal != 0 || yVal != 0 || zVal != 0)
                {
                    if (xVal != 0)
                    {
                        xLoc += xmov;
                        xVal -= xmov;
                    }
                    if (yVal != 0)
                    {
                        yLoc += ymov;
                        yVal -= ymov;
                    }
                    if (zVal != 0)
                    {
                        zLoc += zmov;
                        zVal -= zmov;
                    }

                    target = target.SetXYZ(xLoc, yLoc, zLoc);
                    points.Add(target);
                    distance = distance.SetXYZ((int)(walls.X - Home.X), (int)(walls.Y - Home.Y), (int)(walls.Z - Home.Z));
                }
            }
            return points;
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public void LoadBlanks()
        {
            for (int r = 0; r < height.GetLength(0); r++)
            {
                for (int c = 0; c < height.GetLength(1); c++)
                {
                    height[r, c] = 0;
                }
            }
            if (Main.Error)
            {
                System.Console.WriteLine(height);
            }
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public Room ModTerrain()
        {
            Room comp = new Room(GetXDim(), GetYDim(), GetZDim());
            comp.Name = Name;
            //comp.setEmpty();
            //for (int x = 0; x < getXDim(); x++)
            //{
            //    for (int y = 0; y < getYDim(); y++)
            //    {
            //        for (int z = 0; z < getZDim(); z++)
            //        {
            //            alpha = alpha.setXYZ(x, y, z);
            //            comp.setObject(alpha.offSet(1, 1, 1), getObjectAt(alpha));
            //            setObject(alpha, getObjectAt(alpha));
            //        }
            //    }
            //}
            //for (int x = 0; x < comp.getXDim(); x++)
            //{
            //    for (int y = 0; y < comp.getYDim(); y++)
            //    {
            //        for (int z = 0; z < comp.getZDim(); z++)
            //        {
            //            alpha = alpha.setXYZ(x, y, z);
            //            if (comp.getObjectAt(alpha).Equals('#'))
            //            {
            //                comp.setObject(alpha, '`');
            //            }
            //        }
            //    }
            //}
            bool Norm = true;
            for (int x = 0; x < GetXDim(); x++)
            {
                for (int y = 0; y < GetYDim(); y++)
                {
                    for (int z = 0; z < GetZDim(); z++)
                    {
                        alpha = alpha.SetXYZ(x, y, z);
                        if (y + 3 < GetYDim())
                        {
                            if (Rand.NextDouble() > .5)
                            {
                                if
                               (GetObjectAt(alpha.OffSet(0, 2, 0)).Equals(']') && GetObjectAt(alpha.OffSet(0, 1, 0)).Equals(']'))
                                {
                                    comp.SetObject(alpha, 'S');
                                    Norm = false;
                                }
                            }
                            else if
                              (GetObjectAt(alpha.OffSet(0, 3, 0)).Equals(']') && GetObjectAt(alpha.OffSet(0, 2, 0)).Equals(']') && GetObjectAt(alpha.OffSet(0, 1, 0)).Equals(']'))
                            {
                                comp.SetObject(alpha, 'S');
                                Norm = false;
                            }

                        }


                        if
                          (GetObjectAt(alpha).Equals(']') &&
                          GetObjectAt(alpha.OffSet(0, 1, 0)).Equals('#'))
                        {
                            comp.SetObject(alpha, '[');
                            Norm = false;

                            if (Rand.NextDouble() < Main.TreeProb / 1000)
                            {
                                comp.AddToScene(Main.convertToRoom(File.Read(Main.path[0] + "\\parts\\Tree.ngs")), alpha.OffSet(-5, 0, -5));
                            }
                            else if (Rand.NextDouble() < Main.BushProb / 1000)
                            {
                                SetObject(alpha.OffSet(0, 1, 0), 'L');
                            }
                        }


                        if (alpha.Y > Main.corners[1] + 10 && alpha.Y < Main.corners[1] + 50 && Rand.NextDouble() < Main.CloudProb / 10000)
                        {

                            comp.Cave(1, alpha.SetXYZ(x, y, z), Rand.NextDouble(.5, .999), 'C');
                        }

                        if (alpha.Y > Main.corners[1] - 50 && alpha.Y < Main.corners[1] - 10 && Rand.NextDouble() < Main.CaveProb / 10000)
                        {
                            comp.Cave(1, alpha.SetXYZ(x, y, z), Rand.NextDouble(.5, .999), '#');
                        }


                        if
                         ((Type(alpha, 'D') == 9) &&
                         (GetObjectsInRadius(alpha, Main.BeachWidth).Contains('~')))
                        {
                            comp.SetObject(alpha, ':');
                            Norm = false;
                        }

                        if (Norm)
                        {
                            comp.SetObject(alpha, GetObjectAt(alpha));
                        }
                        Norm = true;
                    }
                }
            }
            return comp;
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public void MoveObject(Vector3 from, Vector3 to)
        {
            char temp = GetObjectAt(from);
            SetObject(from, '#');
            SetObject(to, temp);
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public List<Vector3>[] PathFinder(Vector3 alpha, Vector3 omega)
        {
            // alpha = new Vector3(3, -10, 11);
            //omega = new Vector3(-14, 20, 1);
            List<Vector3>[] Paths = new List<Vector3>[6];
            Paths[0] = new List<Vector3>();
            Paths[1] = new List<Vector3>();
            Paths[2] = new List<Vector3>();
            Paths[3] = new List<Vector3>();
            Paths[4] = new List<Vector3>();
            Paths[5] = new List<Vector3>();
            int xcount;
            int ycount;
            int zcount;
            for (int i = 0; i < 6; i++)
            {
                Paths[i].Add(alpha);
            }
            //Vector3 home = alpha.Clone();
            Vector3 voids = new Vector3(0, 0, 0);
            int j = 0;
            while (!alpha.Equals(omega))
            {
                j++;
                Vector3 distance = alpha.DistanceTo(omega);
                List<Vector2> data = distance.OrderCoor();
                int min;
                if (data[0].X == 0)
                {
                    if (data[1].X == 0)
                    {
                        min = (int)Math.Abs(data[2].X);
                    }
                    else
                    {
                        min = (int)Math.Abs(data[1].X);
                    }
                }
                else
                {
                    min = (int)Math.Abs(data[0].X);
                }
                Vector3 jump = new Vector3((float)Math.Truncate(distance.X / min), (float)Math.Truncate(distance.Y / min), (float)Math.Truncate(distance.Z / min));


                //"Don't do it wrong"-Prim
                for (int i = 0; i < min; i++)
                {
                    Vector3 home = alpha.Clone();
                    distance = alpha.DistanceTo(home.OffSet(jump));
                    while (!distance.Equals(voids) && !alpha.Equals(omega))
                    {
                        if (distance.X == 0)
                        {
                            xcount = 0;
                        }
                        else
                        {
                            xcount = (int)(distance.X / Math.Abs(distance.X));
                        }

                        if (distance.Y == 0)
                        {
                            ycount = 0;
                        }
                        else
                        {
                            ycount = (int)(distance.Y / Math.Abs(distance.Y));
                        }

                        if (distance.Z == 0)
                        {
                            zcount = 0;
                        }
                        else
                        {
                            zcount = (int)(distance.Z / Math.Abs(distance.Z));
                        }
                        Paths[0].Add(alpha.OffSet(xcount, 0, 0));
                        Paths[0].Add(alpha.OffSet(xcount, ycount, 0));
                        Paths[0].Add(alpha.OffSet(xcount, ycount, zcount));

                        Paths[1].Add(alpha.OffSet(xcount, 0, 0));
                        Paths[1].Add(alpha.OffSet(xcount, 0, zcount));
                        Paths[1].Add(alpha.OffSet(xcount, ycount, zcount));

                        Paths[2].Add(alpha.OffSet(0, ycount, 0));
                        Paths[2].Add(alpha.OffSet(xcount, ycount, 0));
                        Paths[2].Add(alpha.OffSet(xcount, ycount, zcount));

                        Paths[3].Add(alpha.OffSet(0, ycount, 0));
                        Paths[3].Add(alpha.OffSet(0, ycount, zcount));
                        Paths[3].Add(alpha.OffSet(xcount, ycount, zcount));

                        Paths[4].Add(alpha.OffSet(0, 0, zcount));
                        Paths[4].Add(alpha.OffSet(xcount, 0, zcount));
                        Paths[4].Add(alpha.OffSet(xcount, ycount, zcount));

                        Paths[5].Add(alpha.OffSet(0, 0, zcount));
                        Paths[5].Add(alpha.OffSet(0, ycount, zcount));
                        Paths[5].Add(alpha.OffSet(xcount, ycount, zcount));


                        alpha = alpha.OffSet(xcount, ycount, zcount);
                        distance = alpha.DistanceTo(home.OffSet(jump));
                    }
                }
            }
            return Paths;
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public void PrintHeight()
        {
            for (int r = 0; r < height.GetLength(0); r++)
            {
                for (int c = 0; c < height.GetLength(1); c++)
                {
                    System.Console.Write(height[r, c] + ",");
                }
            }
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public void RemoveObject(Vector3 coor)
        {

            /*
             Removes an Object to the Map.  
             List How far left, high and deep from origin.
             */
            if (Contains(coor))
            {
                Cube[(int)coor.X, (int)coor.Y, (int)coor.Z] = '#';
            }
            else
            {
                if (Main.Error)
                {
                    System.Console.WriteLine("removeObject: " + coor.ToString() + "does not exist");
                }
            }
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public void ReplaceArea(Vector3 coor1, Vector3 coor2, char ent)
        {
            if (Contains(coor1) && Contains(coor2))
            {
                Vector3 distance = coor1.DistanceTo(coor2);
                Vector3 target = new Vector3(0, 0, 0);
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

                for (int x = (int)coor1.X; x != coor2.X + xcount; x += xcount)
                {
                    for (int y = (int)coor1.Y; y != coor2.Y + ycount; y += ycount)
                    {
                        for (int z = (int)coor1.Z; z != coor2.Z + zcount; z += zcount)
                        {
                            target = target.SetXYZ(x, y, z);
                            if (!GetObjectAt(target).Equals('#'))
                            {
                                SetObject(target, ent);
                            }
                        }
                    }
                }
            }
            else
            {
                if (Main.Error)
                {
                    System.Console.WriteLine("addArea: Either " + coor1.ToString() + " or " + coor2.ToString() + "does not exist");
                }
            }
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public void ReplaceRadius(Vector3 coor, int Rad, char ent)
        {
            Vector3 obtar = new Vector3(0, 0, 0);
            for (int ydim = -Rad; ydim <= Rad; ydim++)
            {
                for (int xdim = -Rad; xdim <= Rad; xdim++)
                {
                    for (int zdim = -Rad; zdim <= Rad; zdim++)
                    {
                        if (Math.Abs(xdim) + Math.Abs(zdim) + Math.Abs(ydim) <= Rad)
                        {
                            obtar = obtar.SetXYZ((int)coor.X + xdim, (int)coor.Y + ydim, (int)coor.Z + zdim);
                            if (Contains(obtar) && !GetObjectAt(obtar).Equals('#'))
                            {
                                SetObject(obtar, ent);
                            }
                        }
                    }
                }
            }
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public void ReplaceRadiusI(Vector3 coor, int Rad, char ent)
        {
            Vector3 obtar = new Vector3(0, 0, 0);
            for (int ydim = -Rad; ydim <= Rad; ydim++)
            {
                for (int xdim = -Rad; xdim <= Rad; xdim++)
                {
                    for (int zdim = -Rad; zdim <= Rad; zdim++)
                    {
                        if (Math.Abs(xdim) + Math.Abs(zdim) + Math.Abs(ydim) >= Rad)
                        {
                            obtar = obtar.SetXYZ((int)coor.X + xdim, (int)coor.Y + ydim, (int)coor.Z + zdim);
                            if (Contains(obtar) && !GetObjectAt(obtar).Equals('#'))
                            {
                                SetObject(obtar, ent);
                            }
                        }
                    }
                }
            }
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public Room RotD(Vector3 coor1, int dis)
        {
            Room rot = new Room(dis, dis, dis);
            rot.offset = coor1;
            rot.offset = rot.offset.OffSet(offset);
            rot.SetEmpty();
            Vector3 temp = new Vector3(0, 0, 0);
            for (int x = 0; x < dis; x++)
            {
                for (int y = 0; y < dis; y++)
                {
                    for (int z = 0; z < dis; z++)
                    {
                        alpha = alpha.SetXYZ(x, y, z);
                        temp = alpha.SwitchZY().OffSetX(1, 1, -1).OffSet(0, 0, dis - 1);
                        rot.SetObject(temp, GetObjectAt(alpha.OffSet(coor1)));
                    }
                }

            }
            return rot;
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public Room RotL(Vector3 coor1, int dis)
        {
            Room rot = new Room(dis, dis, dis);
            rot.offset = coor1;
            rot.offset = rot.offset.OffSet(offset);
            rot.SetEmpty();
            Vector3 temp = new Vector3(0, 0, 0);
            for (int x = 0; x < dis; x++)
            {
                for (int y = 0; y < dis; y++)
                {
                    for (int z = 0; z < dis; z++)
                    {
                        alpha = alpha.SetXYZ(x, y, z);
                        temp = alpha.SwitchXY().OffSetX(1, -1, 1).OffSet(0, dis - 1, 0);
                        rot.SetObject(temp, GetObjectAt(alpha.OffSet(coor1)));
                    }
                }

            }
            return rot;
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public Room RotR(Vector3 coor1, int dis)
        {
            Room rot = new Room(dis, dis, dis);
            rot.offset = coor1;
            rot.offset = rot.offset.OffSet(offset);
            rot.SetEmpty();
            Vector3 temp = new Vector3(0, 0, 0);
            for (int x = 0; x < dis; x++)
            {
                for (int y = 0; y < dis; y++)
                {
                    for (int z = 0; z < dis; z++)
                    {
                        alpha = alpha.SetXYZ(x, y, z);
                        temp = alpha.SwitchXY().OffSetX(-1, 1, 1).OffSet(dis - 1, 0, 0);
                        rot.SetObject(temp, GetObjectAt(alpha.OffSet(coor1)));
                    }
                }

            }
            return rot;
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public Room RotS(Vector3 coor1, int dis)
        {
            Room rot = new Room(dis, dis, dis);
            rot.offset = coor1;
            rot.offset = rot.offset.OffSet(offset);
            rot.SetEmpty();
            Vector3 temp = new Vector3(0, 0, 0);
            for (int x = 0; x < dis; x++)
            {
                for (int y = 0; y < dis; y++)
                {
                    for (int z = 0; z < dis; z++)
                    {
                        alpha = alpha.SetXYZ(x, y, z);
                        temp = alpha.SwitchXZ().OffSetX(-1, 1, 1).OffSet(dis - 1, 0, 0);
                        rot.SetObject(temp, GetObjectAt(alpha.OffSet(coor1)));
                    }
                }

            }
            return rot;
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public Room RotSI(Vector3 coor1, int dis)
        {
            Room rot = new Room(dis, dis, dis);
            rot.offset = coor1;
            rot.offset = rot.offset.OffSet(offset);
            rot.SetEmpty();
            Vector3 temp = new Vector3(0, 0, 0);
            for (int x = 0; x < dis; x++)
            {
                for (int y = 0; y < dis; y++)
                {
                    for (int z = 0; z < dis; z++)
                    {
                        alpha = alpha.SetXYZ(x, y, z);
                        temp = alpha.SwitchXZ().OffSetX(1, 1, -1).OffSet(0, 0, dis - 1);
                        rot.SetObject(temp, GetObjectAt(alpha.OffSet(coor1)));
                    }
                }

            }
            return rot;
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public Room RotU(Vector3 coor1, int dis)
        {
            Room rot = new Room(dis, dis, dis);
            rot.offset = coor1;
            rot.offset = rot.offset.OffSet(offset);
            rot.SetEmpty();
            Vector3 temp = new Vector3(0, 0, 0);
            for (int x = 0; x < dis; x++)
            {
                for (int y = 0; y < dis; y++)
                {
                    for (int z = 0; z < dis; z++)
                    {
                        alpha = alpha.SetXYZ(x, y, z);
                        temp = alpha.SwitchZY().OffSetX(1, -1, 1).OffSet(0, dis - 1, 0);
                        rot.SetObject(temp, GetObjectAt(alpha.OffSet(coor1)));
                    }
                }

            }
            return rot;
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public Room RoundAbout(Room place)
        {
            Vector3 obtar = new Vector3(0, 0, 0);
            for (int y = 0; y < GetYDim(); y++)
            {
                for (int x = 0; x < GetXDim(); x++)
                {
                    for (int z = 0; z < GetZDim(); z++)
                    {
                        obtar = obtar.SetXYZ(x, y, z);
                        if (!GetObjectAt(obtar).Equals('#'))
                        {
                            SetObject(obtar, place.GetObjectAt(obtar));
                        }
                    }
                }

            }
            return this;
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public Room Scent(Vector3 coor, int minScent)
        {
            Room area = new Room(GetXDim(), GetYDim(), GetZDim());
            area.SetEmpty();
            area.offset = offset;
            for (int x = 0; x < GetXDim(); x++)
            {
                for (int y = 0; y < GetYDim(); y++)
                {
                    for (int z = 0; z < GetZDim(); z++)
                    {
                        Vector3 target = new Vector3(x, y, z);
                        char temp = GetObjectAt(target);
                        if (Type(target, 'N') - target.DistanceTo(coor).ToPositive().SumD() >= minScent)
                        {
                            area.SetObject(target, GetObjectAt(target));
                        }
                    }
                }
            }
            return area;
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public Room Senses(Vector3 coor)
        {
            int SightRadius = 20;
            int minScent = 1;
            int minAudio = 1;

            Room World = new Room(GetXDim(), GetYDim(), GetZDim());
            World.SetEmpty();
            World.offset = offset;

            Room Eye = GetObjectsInRadius(coor, SightRadius).Vision(alpha.SetXYZ(SightRadius, SightRadius, SightRadius));
            Room Skin = GetObjectsInRadius(coor, 1);
            Room Nose;
            Room Ear;

            //check all dim for max
            if (GetXDim() > Main.MaxScent && GetXDim() > Main.MaxSound)
            {
                Nose = GetObjectsInRadius(coor, Main.MaxScent).Scent(alpha.SetXYZ(Main.MaxScent, Main.MaxScent, Main.MaxScent), minScent);
                Ear = GetObjectsInRadius(coor, Main.MaxSound).Sound(alpha.SetXYZ(Main.MaxSound, Main.MaxSound, Main.MaxSound), minAudio);
            }
            else
            {
                Nose = Scent(coor, minScent);
                Ear = Sound(coor, minAudio);
            }

            World.AddToScene(Eye, Eye.offset);
            World.AddToScene(Nose, Nose.offset);
            World.AddToScene(Skin, Skin.offset);
            World.AddToScene(Ear, Ear.offset);

            return World;
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public void SetEmpty()
        {
            Vector3 target = new Vector3(0, 0, 0);
            for (int x = 0; x < GetXDim(); x++)
            {
                for (int y = 0; y < GetYDim(); y++)
                {
                    for (int z = 0; z < GetZDim(); z++)
                    {

                        SetObject(target.SetXYZ(x, y, z), '#');
                    }
                }
            }
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public void SetObject(Vector3 coor, char ent)
        {
            /*
             Adds an Object to the Map.  
             List How far left, high and deep from origin.
             Followed by the Object to be added
             (x,y,z,object)
             */
            if (Contains(coor))
            {
                Cube[(int)coor.X, (int)coor.Y, (int)coor.Z] = ent;
            }
            else
            {
                if (Main.Error)
                {
                    System.Console.WriteLine("setObject: " + coor.ToString() + " does not exist");
                }
            }
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public Room Sound(Vector3 coor, int minAudio)
        {
            Room area = new Room(GetXDim(), GetYDim(), GetZDim());
            area.SetEmpty();
            area.offset = offset;
            for (int x = 0; x < GetXDim(); x++)
            {
                for (int y = 0; y < GetYDim(); y++)
                {
                    for (int z = 0; z < GetZDim(); z++)
                    {
                        Vector3 target = new Vector3(x, y, z);
                        char temp = GetObjectAt(target);
                        if (Type(target, 'A') - target.DistanceTo(coor).ToPositive().SumD() >= minAudio)
                        {
                            area.SetObject(target, GetObjectAt(target));
                        }
                    }
                }
            }
            return area;
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public void SwapArea(Vector3 coor1, Vector3 coor2, char ent, char ent2)
        {
            if (Contains(coor1) && Contains(coor2))
            {
                Vector3 distance = coor1.DistanceTo(coor2);
                Vector3 target = new Vector3(0, 0, 0);
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

                for (int x = (int)coor1.X; x != coor2.X + xcount; x += xcount)
                {
                    for (int y = (int)coor1.Y; y != coor2.Y + ycount; y += ycount)
                    {
                        for (int z = (int)coor1.Z; z != coor2.Z + zcount; z += zcount)
                        {
                            target = target.SetXYZ(x, y, z);
                            if (GetObjectAt(target).Equals(ent))
                                SetObject(target, ent2);
                        }
                    }
                }
            }
            else
            {
                if (Main.Error)
                {
                    System.Console.WriteLine("addArea: Either " + coor1.ToString() + " or " + coor2.ToString() + "does not exist");
                }
            }
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public String SymToText(Vector3 coor)
        {
            char sym = GetObjectAt(coor);
            BlockType comp = Main.Archives[1];

            foreach (BlockType data in Main.Archives)
            {
                if (data.Symbol.Equals(sym))
                {
                    return data.Name;
                }
            }
            return "null";
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public void TerrainGen(int size, int[] seed)
        {
            size = (int)Math.Pow(2, size);
            height[0, 0] = seed[0];
            height[0, height.GetLength(1) - 1] = seed[1];
            height[height.GetLength(0) - 1, 0] = seed[2];
            height[height.GetLength(0) - 1, height.GetLength(1) - 1] = seed[3];
            Divide(0, 0, size, size);
            AddLand();
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public List<Block> ToDisplay()
        {
            List<Block> temp = new List<Block>();
            char car;
            for (int y = 0; y < GetYDim(); y++)
            {
                for (int x = 0; x < GetXDim(); x++)
                {
                    for (int z = 0; z < GetZDim(); z++)
                    {
                        alpha = alpha.SetXYZ(x, y, z);
                        car = GetObjectAt(alpha);
                        if (!car.Equals('#'))
                        {
                            temp.Add(CharToEnt(car, alpha.OffSet(offset)));
                        }
                    }
                }
            }
            return temp;
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public override String ToString()
        {
            Vector3 obtar = new Vector3(0, 0, 0);
            String map = "";
            for (int y = 0; y < GetYDim(); y++)
            {
                for (int x = 0; x < GetXDim(); x++)
                {
                    for (int z = 0; z < GetZDim(); z++)
                    {
                        map += GetObjectAt(obtar.SetXYZ(x, y, z));
                    }
                    map += "|";
                }
                map += " \n";
            }
            return map;
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public int Type(Vector3 coor, char sense)
        {
            char sym = GetObjectAt(coor);

            foreach (BlockType data in Main.Archives)
            {
                if (data.Symbol.Equals(sym))
                {
                    switch (sense)
                    {
                        case 'D'://Density
                            return data.CharSees[0];
                        case 'T'://Transparency
                            return data.CharSees[1];
                        case 'N'://Scent
                            return data.CharSees[2];
                        case 'A'://Audio
                            return data.CharSees[3];
                    }
                }
            }
            return -1;
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public Room Vision(Vector3 coor)
        {
            Room area = new Room(GetXDim(), GetYDim(), GetZDim());
            area.offset = offset;
            area.SetEmpty();
            foreach (Vector3 point in area.GetEdges())
            {
                List<Vector3>[] Paths = PathFinder(coor, point);
                for (int i = 0; i < 6; i++)
                {
                    foreach (Vector3 target in Paths[i])
                    {
                        char temp = GetObjectAt(target);
                        if (!temp.Equals('#'))
                        {

                        }
                        area.SetObject(target, GetObjectAt(target));
                        if ((Type(target, 'T') <= 3) && !target.Equals(coor))
                        {
                            break;
                        }
                    }
                }
            }
            return area;
        }

        /*################# Static Variables #####################################*/
        internal static Random Rand = new Random();//Random Number Generator

        internal static double[,] height;//Corner Heights

        /*################# Public Variables #####################################*/
        public Vector3 offset = new Vector3(0, 0, 0);//Offset Vector

        public string Name = "Map1";

        /*################# Private Variables #####################################*/
        private char[,,] Cube;//3D array of characters for Room

        /*################# Variables #####################################*/
        internal Vector3 alpha = new Vector3(0, 0, 0);//Class Vector

        /*################# Public Functions #####################################*/

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public Room(int x, int y, int z)
        {
            if (x > 0 && y > 0 && z > 0)
            {
                Cube = new char[x, y, z];
                height = new double[x, z];
            }
            else
            {
                if (Main.Error)
                {
                    System.Console.WriteLine("Room: Nonexistent Room: " + x + ", " + y + ", " + z);
                }
                Cube = new char[0, 0, 0];

            }
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public Room(Vector3 vec)
        {
            if (vec.X > 0 && vec.Y > 0 && vec.Z > 0)
            {
                Cube = new char[(int)vec.X, (int)vec.Y, (int)vec.Z];
                height = new double[(int)vec.X, (int)vec.Z];
            }
            else
            {
                if (Main.Error)
                {
                    System.Console.WriteLine("Room: Nonexistent Room: " + vec.X + ", " + vec.Y + ", " + vec.Z);
                }
                Cube = new char[0, 0, 0];

            }
        }

        /*################# Title #######################################
        # Purpose: 
        #          
        # Inputs:  
        # 	   
        # Outputs: 
        #          
        ###############################################################*/
        public Room(char[,,] inpt)
        {
            Cube = inpt;
        }
    }
}
