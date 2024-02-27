using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GAMF1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Int64> szamok = new();
        public MainWindow()
        {
            InitializeComponent();
            RelativPrimSzamok();
        }
        public void RelativPrimSzamok()
        {
            int szam = 1310438493;
            List<int> oszthatoVele = new();
            foreach (var sor in File.ReadAllLines("szamok.txt"))
            {
                szamok.Add(Convert.ToInt64(sor));
            }
            for (int i = 2; i < szam; i++)
            {
                if (szam % i == 0)
                {
                    oszthatoVele.Add(i);
                }
            }
            MessageBox.Show(szamok[1].ToString());
        }
    }
}
