using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpock
{
    class ClassicAI : AI
    {
        public ClassicAI(string name, Random rng)
            :base(name, rng)
        {
            availableGestures.RemoveRange(3, 2);
        }
    }
}
