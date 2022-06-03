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
using WpfApp1.API;
using WpfApp1;

namespace WpfApp1.Views
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    /// 
    
    public partial class Home : UserControl
    {
        public string TeamID;
        public string ProjectID;
        public static string[] team;
        public static string[] project;
        public static string[] server;

        public Home()
        {
            InitializeComponent();
            var converter = new System.Windows.Media.BrushConverter();
            var brush = (Brush)converter.ConvertFromString("AliceBlue");


            Teams teams = new Teams();
            team = teams.Team();

            Projects projects = new Projects();
            ProjectServers servers = new ProjectServers();

            var cnt = team.Count();
            int i = 1;
            while (i < cnt)
            {
                var item = new TreeViewItem(){Header ="Team: "+ team[i], Foreground= brush, Focusable= false };
                User.Items.Add(item);

                TeamID = team[i-1];
                project = projects.Project(TeamID);
                var cnt1 = project.Count();
                int j = 1;
                while (j< cnt1)
                {
                    var subitm = new TreeViewItem () {Header="Project: "+ project[j], Foreground= brush, Focusable = false };
                    item.Items.Add(subitm);

                    ProjectID = project[j-1];
                    server = servers.PServers(ProjectID);
                    var cnt2 = server.Count();
                    int k = 1;
                    while (k < cnt2)
                    {
                        var subsrv = new TreeViewItem() { Header ="Server: " + server[k], Foreground = brush, Focusable = false };
                        subitm.Items.Add(subsrv);
                        k += 2;
                    }
                    j += 2;
                }
                i += 2;
            }
        }




    }
}
