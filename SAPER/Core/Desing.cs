using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPER.Core
{
    interface Desing
    {
        void setColorBackground(int color);
        void setColorCursor(int color);
        int getColorBackground();
        int getColorCursor();

        void show();
    }
}
