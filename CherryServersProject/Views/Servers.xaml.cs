using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using CherryServerProject;
using CherryServersProject.API;

namespace CherryServersProject.Views
{
    /// <summary>
    /// Interaction logic for Servers.xaml
    /// </summary>
    public partial class Servers : UserControl
    {

        public string TeamID;
        public string ProjectID;
        public static string[] team;
        public static string[] project;
        public static string[] server;
        public Servers()
        {

            InitializeComponent();

            ObservableCollection<GridInfo> info = new ObservableCollection<GridInfo>();

            Teams teams = new Teams();
            team = teams.Team();

            Projects projects = new Projects();
            ProjectServers servers = new ProjectServers();

            var cnt = team.Count();
            int i = 1;
            while (i < cnt)
            {   
                TeamID = team[i - 1];
                project = projects.Project(TeamID);
                var cnt1 = project.Count();
                int j = 1;
                while (j < cnt1)
                {
                    ProjectID = project[j - 1];
                    server = servers.PServers(ProjectID);
                    var cnt2 = server.Count();
                    int k = 0;
                    while (k < cnt2)
                    {
                        info.Add(new GridInfo { id = server[k], Hostname = server[k+1], Configuration = server[k+2], OS = server[k+3], Price = server[k+4], Billing = server[k+5], Status = server[k+6] });
                        k += 7;
                    }
                    j +=2;
                }
                i += 2;
            }



            ServersDataGrid.ItemsSource = info;
        }

        private void ServersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;
            DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
            DataGridCell RowColumn = dataGrid.Columns[0].GetCellContent(row).Parent as DataGridCell;
            string CellValue = ((TextBlock)RowColumn.Content).Text;
            ServerInfo inf = new ServerInfo(CellValue);

            inf.Show();


        }
    }


    public class GridInfo { 
    
        public string id { get; set; }
        public string Hostname { get; set; }
        public string Configuration { get; set; }
        public string OS { get; set; }
        public string Price { get; set; }
        public string Billing { get; set; }
        public string Status { get; set; }



    }
}
