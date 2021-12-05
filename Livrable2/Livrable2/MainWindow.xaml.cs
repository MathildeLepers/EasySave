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

namespace Livrable2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public Software software;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (FR.IsChecked == true & EN.IsChecked == true)
            {
                MessageBox.Show("Please choose only one language");
            }
            else if (FR.IsChecked == true)
            {
                MessageBox.Show("Français choisi");
                this.software = new Software(Languages.FRANCAIS);
                this.software.launch();
            }
            else if (EN.IsChecked == true)
            {
                MessageBox.Show("English choosen");
                this.software = new Software(Languages.ENGLISH);
                software.launch();
            }
            Test.Text = this.software.nbBackup;
            this.software.nbBackup = Select.Text;
        }
    }
}
