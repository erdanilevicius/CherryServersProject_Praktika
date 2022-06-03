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
using CherryServersProject.API;
using CherryServersProject.Views;

namespace CherryServersProject
{
    /// <summary>
    /// Interaction logic for Interface.xaml
    /// </summary>
    public partial class Interface : Window
    {

        public string Tok;
        public Interface()
        {
            InitializeComponent();





        }
        private void Window_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }

        }

        private void Close(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void Mini(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Array.Clear(Home.server, 0, Home.server.Length);
            Array.Clear(Home.team, 0, Home.team.Length);
            Array.Clear(Home.project, 0, Home.project.Length);
            Login.tok = null;

            string head = "Logged out";
            string ms = "You have logged out";

            
            MainWindow main = new MainWindow();
            this.Close();
            main.Show();
            MsgBox msg = new MsgBox(head, ms);
            msg.Show();


        }
    }




}
