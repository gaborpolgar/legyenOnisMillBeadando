using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace legyenOnisMillBeadando
{
    internal class Kerdes
    {
        private int szint;
        private string kerd;
        private string[] valasz;
        private int helyes;
        private string tema; 
        
        public Kerdes(string sor)
        {
            string[] temp=sor.Split(';');
            szint = Convert.ToInt32(temp[0]);
            kerd = temp[1];
            valasz = new string[] { temp[2], temp[3], temp[4], temp[5]};
            switch (temp[6])
            {
                case "A": helyes = 0;
                    break;
                case "B":
                    helyes = 1;
                    break;
                case "C":
                    helyes = 2;
                    break;
                case "D":
                    helyes = 3;
                    break;
                
            }
            tema=temp[7];

        }

        public int Szint { get => szint; set => szint = value; }
        public string Kerd { get => kerd; set => kerd = value; }
        public string[] Valasz { get => valasz; set => valasz = value; }
        public int Helyes { get => helyes; set => helyes = value; }
        public string Tema { get => tema; set => tema = value; }
    }

}
