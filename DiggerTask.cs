using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digger
{
    public class Terrain : ICreature
    {

        string ICreature.GetImageFileName()
        {
            return "Terrain.png";
        }

        int ICreature.GetDrawingPriority()
        {
            return 100;
        }

        CreatureCommand ICreature.Act(int x, int y)
        {
            return new CreatureCommand();
        }

        bool ICreature.DeadInConflict(ICreature conflictedObject)
        {
            return true;
        }
    }

    public class Player : ICreature
    {
        private int[] GetXYdelta()
        {
            int[] result = new int[] { 0, 0 };
            switch (Game.KeyPressed)
            {
                case Keys.A:
                case Keys.Left:
                    result[0] = -1;
                    break;
                case Keys.W:
                case Keys.Up:
                    result[1] = -1;
                    break;
                case Keys.D:
                case Keys.Right:
                    result[0] = 1;
                    break;
                case Keys.S:
                case Keys.Down:
                    result[1] = 1;
                    break;
            }
            return result;
        }
        public CreatureCommand Act(int x, int y)
        {
            int[] delta = GetXYdelta();
            if ((x + delta[0] >= 0 && x + delta[0] < Game.MapWidth) &&
                (y + delta[1] >= 0 && y + delta[1] < Game.MapHeight))
                return new CreatureCommand()
                {
                    DeltaX = delta[0],
                    DeltaY = delta[1],
                    TransformTo = this
                };
            else return new CreatureCommand()
            {
                DeltaX = 0,
                DeltaY = 0,
                TransformTo = this
            };
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return false;
        }

        public int GetDrawingPriority()
        {
            return 90;
        }

        public string GetImageFileName()
        {
            return "Digger.png";
        }
    }
}
