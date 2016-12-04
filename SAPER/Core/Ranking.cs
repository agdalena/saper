using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPER.Core
{
    interface Ranking
    {
        void loadData();
        void saveData();
        void show();
        void saveNewScore(string player, int time);
    }
}
