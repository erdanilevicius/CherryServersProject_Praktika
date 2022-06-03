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

namespace CherryServersProject.Views
{
    /// <summary>
    /// Interaction logic for Servers.xaml
    /// </summary>
    public partial class Servers : UserControl
    {

        public static string[] server;
        public Servers()
        {
            InitializeComponent();
            server = Home.server;
            var cnt = server.Count();

            int i = 1;
            while (i < cnt) {
                Serv.Items.Add(server[i]);

                i += 2;
            }



        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {

            string Head = "test";
            string Ms = "test";

            MsgBox msg = new MsgBox(Head,Ms);
            msg.Show();
        }
    }
}
