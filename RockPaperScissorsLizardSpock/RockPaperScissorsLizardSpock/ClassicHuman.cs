using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpock
{
    class ClassicHuman : Human
    {
        public ClassicHuman(string name)
            : base(name)
        {
            availableGestures.RemoveRange(3, 2);
        }
    }
}

