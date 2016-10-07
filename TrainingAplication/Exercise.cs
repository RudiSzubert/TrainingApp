using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingAplication
{
    class Exercise
    {
        public string name;
        public int time;
        public string comment;
        public Track track = null;
    }

    class Training
    {
        public int RestTime;
        public int ExerciseTime;
        public int Series = 1;


    }
}
