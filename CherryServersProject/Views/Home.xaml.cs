using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using CherryServersProject.API;
using CherryServerProject;
using System.Windows.Input;
using CherryServersProject.ViewClass;
using System;


namespace CherryServersProject.Views
{
    public partial class Home : UserControl
    {

        public Home()
        {
            InitializeComponent();
        }

        private void GetServ_Click(object sender, RoutedEventArgs e)
        {

            if (Server.Text != string.Empty)
            {
                GetServer srv = new GetServer();
                string srvId = Server.Text;
                string[] ats = srv.Gserv(srvId);

                if (ats == null)
                {
                    return;

                }
                else {
                    foreach (var atss in ats)
                    {
                        inform.Text += atss.ToString() + "\n";
                    }
                }
            }
            else if (Server.Text == string.Empty)
            {

                string head = "Error";
                string msg = "Please enter server id";

                MsgBox mm = new MsgBox(head,msg);
                mm.Show();
                return;                        
            }
        }
    }
}
