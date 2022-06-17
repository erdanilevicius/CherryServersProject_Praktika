using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CherryServersProject.Change;

namespace CherryServersProject.ViewClass
{
    internal class MainViewModel : ObservableObject
    {
        public static  Command HomeViewCommand { get; set; }

        public static Command ServersViewCommand { get; set; }

        public static HomeViewModel HomeVM { get; set; }

        public static ServersViewModel ServersVM { get; set; }

        public static object _currentView;
        public object CurrentView
        { 
            get { return _currentView; }
            set { _currentView = value; 
                OnPrepertyChanged();
                }
        
        }

        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            ServersVM = new ServersViewModel();
            CurrentView = HomeVM;

            HomeViewCommand = new Command(o =>
            {
                CurrentView = HomeVM;
            });
            ServersViewCommand = new Command(o =>
            {
                CurrentView = ServersVM;
            });


        }
        



    }
}
