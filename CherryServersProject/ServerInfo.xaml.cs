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
using CherryServerProject.API;
using CherryServersProject;
using CherryServersProject.API;
using CherryServersProject.Views;

namespace CherryServerProject
{
    
    public partial class ServerInfo : Window
    {
        string srvID;
        string usl;

        public ServerInfo(string id)
        {
           
            InitializeComponent();
            srvID = id;

            GetServer srv = new GetServer();
            string[] ats = srv.Gserv(id);

            var element = ats.Count();

            Name.Text = ats[0].Trim();
            int i = 1;
            while (i < element) {
                Res.Text += ats[i] + "\n";
                i++;
            }


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

        private void Action_Click(object sender, RoutedEventArgs e)
        {
            Perform prf = new Perform();


            if (Act.SelectionBoxItem.ToString() == "Power On")
            {
                usl = prf.Perf("power-on", srvID);


                string head = "Success";
                string ms = "Action in progress";

                MsgBox msg = new MsgBox(head, ms);
                msg.Show();
            }
            else if (Act.SelectionBoxItem.ToString() == "Power Off")
            {
                usl = prf.Perf("power-off", srvID);


                string head = "Success";
                string ms = "Action in progress";

                MsgBox msg = new MsgBox(head, ms);
                msg.Show();
            }
            else if (Act.SelectionBoxItem.ToString() == "Reboot")
            {
                usl = prf.Perf("reboot", srvID);

                string head = "Success";
                string ms = "Action in progress";

                MsgBox msg = new MsgBox(head, ms);
                msg.Show();

            }
            else if (Act.SelectionBoxItem == null) {
                string head = "Failed";
                string ms = "Please select action to perform";

                MsgBox msg = new MsgBox(head,ms);
                msg.Show();
            
            }

        }
    }
}
