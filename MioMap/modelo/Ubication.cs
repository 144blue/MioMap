using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modelo
{
    public class Ubication
    {
        string posx;
        string posy;

        public Ubication(string posx, string posy)
        {
            this.posx = posx;
            this.posy = posy;
        }

        public string Posx { get => posx; set => posx = value; }
        public string Posy { get => posy; set => posy = value; }
    }
}
