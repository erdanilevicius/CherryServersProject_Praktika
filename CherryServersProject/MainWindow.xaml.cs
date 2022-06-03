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
using System.Security.Cryptography;
using System.Diagnostics;
using CherryServersProject.Views;
using CherryServersProject.API;

namespace CherryServersProject
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }


        private void Window_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }

        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (Email.Text == string.Empty || Password.Password == string.Empty)
            {
                string Head = "Message";
                string Msg = "Please fill all fields";
                MsgBox mess = new MsgBox(Head, Msg);
                mess.ShowDialog();


            }
            else if (Email.Text != string.Empty && Password.Password != String.Empty) {
                string email = Email.Text;
                string pass = Password.Password;
                string hash;

                using (SHA1 sha1Hash = SHA1.Create())
                {
                    byte[] sourceBytes = Encoding.UTF8.GetBytes(pass);
                    byte[] hashBytes = sha1Hash.ComputeHash(sourceBytes);
                    hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty).ToLower();
                }


                Login login = new Login();
                string log = login.Logon(email,hash);
                Interface next = new Interface();
                next.Show();
                this.Hide();
                

            }



        }

        private void OpenLink(object sender, RoutedEventArgs e)
        {
            string target = "https://portal.cherryservers.com/#/register";
            try
            {
                System.Diagnostics.Process.Start(target);
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MessageBox.Show(noBrowser.Message);
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }
    }

    

}
