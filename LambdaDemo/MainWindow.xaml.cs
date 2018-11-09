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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LambdaDemo
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            afficher("Bienvenue dans ce monde de fous", devoyeller);
            afficher("Bienvenue dans ce monde de fous", (s) => s.Replace('e', 'z').Replace(' ', 's').Replace('n', 'o'));
            afficher("Bienvenue dans ce monde de fous", reverse);
        }
        public void afficher(String s, Func<String, String> fct) { MessageBox.Show(fct(s)); }
        private String devoyeller(String s)
        {
            String[] voyelles = { "a", "e", "i", "o", "u", "y" };
            foreach (String c in voyelles) { s = s.Replace(c, ""); }
            return s;
        }

        private String reverse(String s) { return String.Concat(s.ToArray().Reverse()); }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int[] tab = { 1, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31 };
            int n = tab.Count((x) => x > 15);
            MessageBox.Show(n.ToString());
            int[] tab2 = calculer(tab, (x) => x * 2);
            MessageBox.Show(tab2.Count((x) => x > 15).ToString());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Int32[] nbres = new Int32[1000];
            Random rnd = new Random();
            for (Int32 i = 0; i < nbres.Length; i++) { nbres[i] = rnd.Next(0, 100); }
            int n = nbres.Count((x) => x > 50);
            MessageBox.Show(n.ToString());
            int n2 = nbres.Count((x) => (x % 2) == 0);
            MessageBox.Show(n2.ToString());
        }

        private int[] calculer(int[] tab, Func<int, int> fct)
        {
            int[] tab2 = new int[tab.Length];
            for (int i = 0; i < tab.Length; i++) { tab2[i] = fct(tab[i]); }
            return tab2;
        }

        private List<String> extraire(List<String> list, Func<String, Boolean> fct)
        {
            List<String> list2 = new List<string>();
            foreach (String s in list)
            {
                if (fct(s)) { list2.Add(s); }
            }
            return list2;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            List<String> list = new List<string> { "un", "deux", "trois", "quatre", "cing" };
            List<String> list2 = extraire(list, (s) => s.Contains("u"));
            foreach (String s in list2) { MessageBox.Show(s); }
        }
    }
}
