using System.Collections.ObjectModel;

namespace Funeral_Services_DB.MVVM.Model
{
    public static class Data
    {
        public static ObservableCollection<Client> Clients { get; set; } = new ObservableCollection<Client>();
        public static ObservableCollection<Grave> Graves { get; set; } = new ObservableCollection<Grave>();
        public static ObservableCollection<Ceremony> Ceremonies { get; set; } = new ObservableCollection<Ceremony>();
    }
}
