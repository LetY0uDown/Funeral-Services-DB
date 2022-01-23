using Funeral_Services_DB.Core;
using Funeral_Services_DB.MVVM.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Funeral_Services_DB.MVVM.ViewModel
{
    public class ClientsViewModel
    {
        public ClientsViewModel()
        {
            AddClient = new RelayCommand(o => Clients.Add(new Client()));

            RemoveClient = new RelayCommand(o =>
            {
                if (SelectedClient == null)
                {
                    MessageBox.Show("Сначала выберете клиента, которого хотите удалить", "Ошибка: Клиент не выбран");
                    return;
                }

                if (MessageBox.Show("Действительно удалить выбранного клиента?", "Предупреждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Clients.Remove(SelectedClient);
                }
            });
        }

        public RelayCommand AddClient { get; set; }
        public RelayCommand RemoveClient { get; set; }

        public ObservableCollection<Client> Clients
        {
            get => Data.Clients;
            set => Data.Clients = value;
        }
        public ObservableCollection<Grave> Graves
        {
            get => Data.Graves;
            set => Data.Graves = value;
        }
        public ObservableCollection<Ceremony> Ceremonies
        {
            get => Data.Ceremonies;
            set => Data.Ceremonies = value;
        }

        private Client _selectedClient;
        public Client SelectedClient
        {
            get => _selectedClient;
            set
            {
                _selectedClient = value;
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
