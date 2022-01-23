using Funeral_Services_DB.Core;
using Funeral_Services_DB.MVVM.View;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Windows;
using Funeral_Services_DB.MVVM.Model;
using System.Collections.ObjectModel;

namespace Funeral_Services_DB.MVVM.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            mainWindow = (MainWindow)Application.Current.MainWindow;

            ClientsView = new ClientsView();
            PlacesView = new PlacesView();
            CeremoniesView = new CeremoniesView();
            CurrentView = ClientsView;

            ClientsViewCommand = new RelayCommand(o =>
            {
                CurrentView = ClientsView;
                mainWindow.textPageName.Content = "Список клиентов";
            });
            GravesViewCommand = new RelayCommand(o =>
            {
                CurrentView = PlacesView;
                mainWindow.textPageName.Content = "Список могил";
            });
            CeremoniesViewCommand = new RelayCommand(o =>
            {
                CurrentView = CeremoniesView;
                mainWindow.textPageName.Content = "Список церемоний";
            }) ;

            ExitCommand = new RelayCommand(o =>
            {
                Application.Current.Shutdown();
            });

            MinimizeCommand = new RelayCommand(o =>
            {
                Application.Current.MainWindow.WindowState = WindowState.Minimized;
            });

            MaximizeCommand = new RelayCommand(o =>
            {
                if (Application.Current.MainWindow.WindowState == WindowState.Normal)
                    Application.Current.MainWindow.WindowState = WindowState.Maximized;
                else
                    Application.Current.MainWindow.WindowState = WindowState.Normal;
            });

            
        }

        MainWindow mainWindow;

        public RelayCommand ExitCommand { get; set; }
        public RelayCommand MinimizeCommand { get; set; }
        public RelayCommand MaximizeCommand { get; set; }

        public RelayCommand ClientsViewCommand { get; set; }
        public RelayCommand GravesViewCommand { get; set; }
        public RelayCommand CeremoniesViewCommand { get; set; }

        public ClientsView ClientsView { get; set; }
        public PlacesView PlacesView { get; set; }
        public CeremoniesView CeremoniesView { get; set; }

        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
