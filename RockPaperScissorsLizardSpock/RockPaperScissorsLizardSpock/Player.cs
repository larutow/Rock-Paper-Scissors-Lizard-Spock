using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpock
{
    class Player
    {
        public Gesture gesture;
        public string name;

        public Player()
        {

        }

        public virtual Gesture ChooseGesture(List<Gesture> gestures)
        {
            // choose gesture codeblock
        }
    } 
}
