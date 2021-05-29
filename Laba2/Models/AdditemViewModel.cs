using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2.Models
{
    class AdditemViewModel:BaseViewModel
    {
        private int selectIndex;
        public int SelectIndex
        {
            get { return selectIndex; }
            set { selectIndex = value; }
        }


    }
}
