using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theater_App.Models;

namespace Theater_App.Repositories
{
    public class Plays_Presented
    {
        private List<Play> Plays { get; set; }
        public Plays_Presented()
        {
            this.Plays = new List<Play>
            {
                new Play{Id = "hamlet", Name = "Hamlet", Type = "tragedy"},
                new Play{Id = "as-like", Name = "As You Like It", Type = "comedy"},
                new Play{Id = "othello", Name = "Othello", Type = "tragedy"},
                //Newly added
                new Play{Id = "ghosts", Name = "Ghost Stories", Type = "horror"}
            };
        }
        public List<Play> GetPlays()
        {
            return this.Plays;
        }
    }
}
