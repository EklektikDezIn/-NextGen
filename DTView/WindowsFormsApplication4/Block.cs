/*################# Block.cs #######################################
# Eklektik Design
# Micah Richards
# 12/28/2017
#           
# Purpose: Extends the Block object to include a position
#           reference
#           
###############################################################*/

namespace NextGen
{

    /*################# Includes #####################################*/
    using OpenTK;

    internal class Block: BlockType
    {

        /*################# Variables #####################################*/
        public Vector3 Pos;       /*## Tracks the Entity's position ##*/


        /*################# Functions #####################################*/

        /*################# Clone #######################################
        # Purpose: Creates a unique copy of the Block
        #          
        ###############################################################*/
        public new Block Clone()
        {
            return new Block(Pos.Clone(), base.Clone());
        }

        /*################# GetBlockType #######################################
        # Purpose: Returns this Block's BlockType parent
        #          
        ###############################################################*/
        public BlockType GetBlockType()
        {
            return base.Self();
        }

        /*################# Self #######################################
        # Purpose: Returns this Block object
        #          
        ###############################################################*/
        public new Block Self()
        {
            return this;
        }

        /*################# SetPos #######################################
        # Purpose: Set the position of the Block
        #          
        ###############################################################*/
        public Block SetPos(Vector3 coor)
        {
            Pos = coor;
            return this;
        }

        /*################# ToString #######################################
        # Purpose: Returns a string representation of the Block object
        #          
        ###############################################################*/
        public override string ToString()
        {
            return "<" + Pos.ToStringS() + " " + base.ToString() + ">";
        }


        /*################# Constructors #####################################*/

        /*################# Block #######################################
        # Purpose: Creates an Block Object
        #          
        ###############################################################*/
        public Block(Vector3 coor, BlockType dat)
        {
            Pos = coor;
            base.CopyBlockType(dat);
        }
    }
}
