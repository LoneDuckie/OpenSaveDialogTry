using Microsoft.Win32;
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

namespace OpenSaveDialog
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        List<string> lines = new List<string>();
        List<Players> players = new List<Players>();
        int pocet { get; set; }

        private void OpenBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == true)
                    using (var sr = new StreamReader(openFileDialog.FileName))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            lines.Add(line);
                        }
                    }

                foreach (var item in lines)
                {
                    string[] arr = item.Split(';');
                    if (arr.Length > 4)
                    {
                        if (int.TryParse(arr[4], out int body))
                        {
                            Players hrac = new Players(arr[0], arr[1], arr[2], arr[3], body);
                            players.Add(hrac);
                        }
                    }
                }

                VypisLV.ItemsSource = players;

                Pocet.Content = players.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Filter()
        {
            List<Players> data = new List<Players>();

            foreach (var item in players)
            {
                if (item.Name.ToLower().Contains(Vyhledat.Text.ToLower()))
                {
                    data.Add(item);

                }
            }
            VypisLV.ItemsSource = data;

            Pocet.Content = $"{data.Count}/{players.Count}";
        }

        private void Vyhledat_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        //private void SaveBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    SaveFileDialog saveFileDialog = new SaveFileDialog();
        //    saveFileDialog.Filter = "Text files (*.txt)|*.txt|Logging files (*.log)|*.log|XAML files (*.xaml)|*.xaml";
        //    saveFileDialog.InitialDirectory = @"C:\Prace\Programy\OpenSaveDialog\OpenSaveDialog\bin\Debug";
        //    if (saveFileDialog.ShowDialog() == true)
        //        File.WriteAllText(saveFileDialog.FileName, VypisTX.Text);
        //}




    }
}
