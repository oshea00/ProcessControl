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

namespace ProcessControl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RemoteControl _remote;

        public MainWindow()
        {
            InitializeComponent();
            _remote = new RemoteControl(this);
            _remote.Start();
        }

        public void btnAddText_Click(object sender, RoutedEventArgs e)
        {
            tbDoc.Text += txtText.Text;
        }

        public void btnReplace_Click(object sender, RoutedEventArgs e)
        {
            tbDoc.Text = txtText.Text;
        }

        public void btnClear_Click(object sender, RoutedEventArgs e)
        {
            tbDoc.Text = string.Empty;
        }
    }
}
