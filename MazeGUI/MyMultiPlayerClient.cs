using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGUI
{
    class MyMultiPlayerClient : AbstractMultiPlayerClient
    {
        private static MyMultiPlayerClient instance;
        private MyMultiPlayerClient() { }
        public static MyMultiPlayerClient Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MyMultiPlayerClient();
                }
                return instance;
            }
        }
    }
}
