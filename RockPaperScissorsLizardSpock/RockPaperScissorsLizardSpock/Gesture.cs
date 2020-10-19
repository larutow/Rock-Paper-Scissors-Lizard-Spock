using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpock
{
    class Gesture
    {
        public string gestureType;
        public List<string> defeats;
        
        public Gesture(String gestureType)
        {
            this.gestureType = gestureType;
            defeats = new List<string>();
            PopulateDefeats();
        }


        public void PopulateDefeats()
        {
            if(gestureType == "rock")
            {
                defeats.Add("scissors");
                defeats.Add("lizard");
            }else
            if (gestureType == "paper")
            {
                defeats.Add("rock");
                defeats.Add("spock");
            }else
            if (gestureType == "scissors")
            {
                defeats.Add("paper");
                defeats.Add("lizard");
            }else
            if (gestureType == "lizard")
            {
                defeats.Add("paper");
                defeats.Add("spock");
            }else
            if (gestureType == "spock")
            {
                defeats.Add("scissors");
                defeats.Add("rock");
            }
        }
    }
}
