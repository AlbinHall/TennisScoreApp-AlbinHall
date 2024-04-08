using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisScoreApp_AlbinHall.Models
{
    public class TennisScore
    {
        public int Score { get; set; }
        public int Set {  get; set; }
        public int Gem { get; set; }
    
        public TennisScore() 
        {
            Score = 0;
            Set = 0;
            Gem = 0;
        }
    }
}
