using System;
using System.Collections.Generic;
using System.Text;

namespace TagsApp
{
    public  class UserInputController
    {
        public uint ChooseFieldType(string fieldType)
        {
            if (!Utils.IsDigit(fieldType))
            {
                throw new InvalidInputException("Only digits!");
            }          
            int ft = Convert.ToInt32(fieldType) - 1;

            if ( ft < 0 || ft > 2)
            {
                throw new InvalidInputException("No field type at this index. Try again");
            }
            return Convert.ToUInt32(ft);
        }
        public uint[] ChooseFieldSize(string width, string length)
        {
            if (!Utils.IsDigit(width))
            {
                throw new InvalidInputException("not a digit"); 
            }
            if (Convert.ToUInt32(width) <= 2)
            {
                throw new InvalidInputException("width too small");
            }


            if (!Utils.IsDigit(length))
            {
                throw new InvalidInputException("not a digit");
            }
            if (Convert.ToUInt32(length) <= 2)
            {
                throw new InvalidInputException("width too small");
            }
            uint[] FieldSize = new uint[2] { Convert.ToUInt32 (width), Convert.ToUInt32(length) };
            return FieldSize;
        }
        public uint GetNumOfSwaps(string numOfSwaps)
        {
            if (!Utils.IsDigit(numOfSwaps))
            {
                throw new InvalidInputException("not a digit");
            }
            if (Convert.ToUInt32(numOfSwaps) <= 0)
            {
                throw new InvalidInputException("Need at least 1");
            }
            return Convert.ToUInt32(numOfSwaps);
        }

        public uint GetChanceOfRndCancel(string chanceOfRndCancel)
        {
            if (!Utils.IsDigit(chanceOfRndCancel))
            {
                throw new InvalidInputException("not a digit");
            }
            if (Convert.ToUInt32(chanceOfRndCancel) > 100)
            {
                throw new InvalidInputException("Chance more than 100%?");
            }
            if (Convert.ToUInt32(chanceOfRndCancel)<0)
            {
                throw new InvalidInputException("Chance less than 0%?");
            }
            return Convert.ToUInt32(chanceOfRndCancel);
        }

        public FromToCoords ParseMove(string ans)
        {
            uint[] coords = new uint[4] { 0,0,0,0};

            int counter = 0;

            char[] mas = ans.ToUpper().ToCharArray();    

            foreach (char h in mas)
            {                
                if (h == ' ')
                {   
                    counter+=2;
                    if (counter >2)
                    {
                        break;
                    }
                }
                else if (char.IsDigit(h))
                {
                    coords[counter+1] = coords[counter+1] * 10 + Convert.ToUInt32(h.ToString());
                }
                else
                {
                    coords[counter] = coords[counter] * 10 + Utils.CharToIndex(h);
                }
            }
            return new FromToCoords(coords[0], coords[1]-1, coords[2], coords[3]-1);
        }

        public bool CancelMove(string ans)
        {
            if (ans == "cancel")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool GiveUp(string ans)
        {
            if (ans == "give up")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}
