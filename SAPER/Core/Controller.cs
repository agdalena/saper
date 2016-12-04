using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAPER.Core;

namespace SAPER.View
{
    interface Controller
    {
        int control(Board board);
        int getX();
        int getY();
}
}
