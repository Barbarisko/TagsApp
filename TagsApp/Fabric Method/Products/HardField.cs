using System;
using System.Collections.Generic;
using System.Text;

namespace TagsApp.Fabric_Method
{
    public class HardField : Field
    {
        private uint Chance;
        public HardField(uint w, uint l, uint chanceOfRandomCancel) :base(w, l)
        {
            Name = "bckwrd";
            Tags[w-1, l-1] = new Tag();
            Chance = chanceOfRandomCancel;
            base.MoveTag(new FromToCoords(w - 1, l - 1, w - 1, l - 2));            
        }


        public override void MoveTag(FromToCoords fromTo)//overloaded func, can cancel users move
        {
            Random rnd = new Random();
            int randomInt = rnd.Next(1, 101);
            
            if (randomInt>Chance)
            {
                base.MoveTag(fromTo);
            }
            else
            {
                var core = Core.GetInstance();
                core.UndoCommand.Execute(); 
                MakeRandomMove();
            }
        }
        public void MakeRandomMove()
        {
            uint x = 0;
            uint y = 0;
            for(uint i = 0; i<Width; i++)
            {
                for(uint j = 0; j< Length; j++)
                {
                    if(Tags[i, j].Name ==  Tag.Empty)
                    {
                        x = i;
                        y = j;
                    }
                }
            }
            
            int counter = 0;
            while (counter < 2)
            {
                counter++;
                FromToCoords fromTo = new FromToCoords(x, y, x, y);
                Random r = new Random();
                int xory = r.Next(0, 2);
                int plusorminus = r.Next(0, 2);
                if (xory == 0)
                {
                    if (plusorminus == 0)
                    {
                        fromTo.toX++;
                        x++;
                    }
                    else
                    {
                        x--;
                        fromTo.toX--;
                    }
                }
                else
                {
                    if (plusorminus == 0)
                    {
                        y++;
                        fromTo.toY++;
                    }
                    else
                    {
                        y--;
                        fromTo.toY--;
                    }
                }

                try
                {
                    base.MoveTag(fromTo);
                }
                catch
                {
                    counter--;
                }
            }
        }
    }
}
