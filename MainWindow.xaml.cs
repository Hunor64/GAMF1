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
        }
        private void CountButton_Click(object sender, RoutedEventArgs e)
        {
            int count = 0;
            long fixedNumber = 1310438493;
            try
            {
                foreach (var line in File.ReadAllLines("szamok.txt"))
                {
                    long number = long.Parse(line);
                    if (CalculateGCD(number, fixedNumber) == 1)
                    {
                        count++;
                    }
                }
                resultTextBlock.Text = $"Relatív prímek száma: {count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt: {ex.Message}");
            }
        }

        private long CalculateGCD(long a, long b)
        {
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }


        private void btnSzamol_Click(object sender, RoutedEventArgs e)
        {
            string referencia = "2354211341";
            int szamlalo = 0;
            string referenciaRendezett = String.Concat(referencia.OrderBy(c => c));

            try
            {
                foreach (string sor in File.ReadLines("szamok.txt"))
                {
                    if (String.Concat(sor.OrderBy(c => c)) == referenciaRendezett && sor != referencia)
                    {
                        szamlalo++;
                    }
                }

                txtEredmeny.Text = $"Anagrammák száma: {szamlalo}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt a fájl beolvasása közben: {ex.Message}");
            }
        }

    }
}
