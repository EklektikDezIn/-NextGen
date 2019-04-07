/*################# Transparency.cs #######################################
# Eklektik Design
# Micah Richards
# 12/28/2017
#           
# Purpose: Object for tracking the transparency on the facets 
#           of a cube for NextGen
#
###############################################################*/

namespace NextGen
{
    internal class Transparency
    {
        /*################# Functions #####################################*/

        /*################# GetBack #######################################
        # Purpose: Returns the back transparency
        #          
        # Inputs:  None
        #     
        # Outputs: float: transparency
        #          
        ###############################################################*/
        public float GetBack()
        {
            return SWrap[3];
        }

        /*################# GetBottom #######################################
        # Purpose: Returns the bottom transparency
        #          
        # Inputs:  None
        #     
        # Outputs: float: transparency
        #          
        ###############################################################*/
        public float GetBottom()
        {
            return SWrap[1];
        }

        /*################# GetFront #######################################
        # Purpose: Returns the front transparency
        #          
        # Inputs:  None
        #     
        # Outputs: float: transparency
        #          
        ###############################################################*/
        public float GetFront()
        {
            return SWrap[2];
        }

        /*################# GetLeft #######################################
        # Purpose: Returns the left transparency
        #          
        # Inputs:  None
        #     
        # Outputs: float: transparency
        #          
        ###############################################################*/
        public float GetLeft()
        {
            return SWrap[4];
        }

        /*################# GetRight #######################################
        # Purpose: Returns the right transparency
        #          
        # Inputs:  None
        #     
        # Outputs: float: transparency
        #          
        ###############################################################*/
        public float GetRight()
        {
            return SWrap[5];
        }

        /*################# GetTop #######################################
        # Purpose: Returns the top transparency
        #          
        # Inputs:  None
        #     
        # Outputs: float: transparency
        #          
        ###############################################################*/
        public float GetTop()
        {
            return SWrap[0];
        }

        /*################# ToString #######################################
        # Purpose: Returns a string representation of the transparency
        #          
        # Inputs:  None
        #     
        # Outputs: String: description
        #          
        ###############################################################*/
        public override string ToString()
        {
            return "(" + SWrap[0] + "," + SWrap[1] + "," + SWrap[2] + "," + SWrap[3] + "," + SWrap[4] + "," + SWrap[5] + ")";
        }

        /*################# Variables #####################################*/
        internal float[] SWrap = new float[6];/*## List of transparency values ##*/

        /*################# Constructors #####################################*/

        /*################# Transparency #######################################
        # Purpose: Creates a transparency with six unique values
        #          
        # Inputs:  float(s): Six transparency values
        #     
        # Outputs: Transparency Object: this
        #          
        ###############################################################*/
        public Transparency(float top, float bottom, float front, float back, float left, float right)
        {
            SWrap[0] = top;
            SWrap[1] = bottom;
            SWrap[2] = front;
            SWrap[3] = back;
            SWrap[4] = left;
            SWrap[5] = right;
        }

        /*################# Transparency #######################################
        # Purpose: Creates a transparency with constant values
        #          
        # Inputs:  float: Transparency value
        #     
        # Outputs: Transparency Object: this
        #          
        ###############################################################*/
        public Transparency(float alpha)
        {
            SWrap[0] = alpha;
            SWrap[1] = alpha;
            SWrap[2] = alpha;
            SWrap[3] = alpha;
            SWrap[4] = alpha;
            SWrap[5] = alpha;
        }
    }
}
