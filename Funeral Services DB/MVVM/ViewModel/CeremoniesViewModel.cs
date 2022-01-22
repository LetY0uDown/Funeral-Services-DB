using Funeral_Services_DB.Core;
using Funeral_Services_DB.MVVM.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Funeral_Services_DB.MVVM.ViewModel
{
    public class CeremoniesViewModel : INotifyPropertyChanged
    {
        public CeremoniesViewModel()
        {
            AddCeremony = new RelayCommand(o => Ceremonies.Add(new Ceremony()));

            RemoveCeremony = new RelayCommand(o =>
            {
                if (SelectedCeremony == null)
                {
                    MessageBox.Show("Сначала выберете могилу, которую хотите удалить", "Ошибка: Клиент не выбран");
                    return;
                }

                if (MessageBox.Show("Действительно удалить выбранную могилу?", "Предупреждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Ceremonies.Remove(SelectedCeremony);
                }
            });
        }

        public RelayCommand AddCeremony { get; set; }
        public RelayCommand RemoveCeremony { get; set; }

        private Ceremony _selectedCeremony;
        public Ceremony SelectedCeremony
        {
            get => _selectedCeremony;
            set
            {
                _selectedCeremony = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Ceremony> Ceremonies
        {
            get => Data.Ceremonies;
            set => Data.Ceremonies = value;
        }
        public ObservableCollection<Grave> Graves
        {
            get => Data.Graves;
            set => Data.Graves = value;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
