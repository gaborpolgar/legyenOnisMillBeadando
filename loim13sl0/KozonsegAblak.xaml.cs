using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace legyenOnisMillBeadando

{
    public partial class KozonsegAblak : Window
    {
        public int[] szamok = new int[4];
        public KozonsegAblak()
        {
            InitializeComponent();
        }

        public void vetit(List<int> lista)
        {
            a.Height = lista[0];
            b.Height = lista[1];
            c.Height = lista[2];
            d.Height = lista[3];
        }
    }
}
