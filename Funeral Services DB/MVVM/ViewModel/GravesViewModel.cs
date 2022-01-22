using Funeral_Services_DB.Core;
using Funeral_Services_DB.MVVM.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Funeral_Services_DB.MVVM.ViewModel
{
    public class GravesViewModel : INotifyPropertyChanged
    {
        public GravesViewModel()
        {
            AddGrave = new RelayCommand(o => Graves.Add(new Grave()));

            RemoveGrave = new RelayCommand(o =>
            {
                if (SelectedGrave == null)
                {
                    MessageBox.Show("Сначала выберете могилу, которую хотите удалить", "Ошибка: Клиент не выбран");
                    return;
                }

                if (MessageBox.Show("Действительно удалить выбранную могилу?", "Предупреждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Graves.Remove(SelectedGrave);
                }
            });
        }

        public RelayCommand AddGrave { get; set; }
        public RelayCommand RemoveGrave { get; set; }

        public ObservableCollection<Grave> Graves
        {
            get => Data.Graves;
            set => Data.Graves = value;
        }
        public ObservableCollection<Client> Clients
        {
            get => Data.Clients;
            set => Data.Clients = value;
        }

        private Grave _selectedGrave;
        public Grave SelectedGrave
        {
            get => _selectedGrave;
            set
            {
                _selectedGrave = value;
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
