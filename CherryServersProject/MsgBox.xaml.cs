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

namespace CherryServersProject
{
    /// <summary>
    /// Interaction logic for MsgBox.xaml
    /// </summary>
    public partial class MsgBox : Window
    {
        public MsgBox(string Head, string Msg)
        {
            InitializeComponent();
            Alert.Text = Head;
            Message.Text = Msg;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Window_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }

        }

        public void Ok_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
