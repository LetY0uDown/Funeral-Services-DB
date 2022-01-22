using System.Windows;

namespace Funeral_Services_DB
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void bClients_Click(object sender, RoutedEventArgs e)
        {
            textPageName.Content = "Список клиентов";
        }

        private void bGraves_Click(object sender, RoutedEventArgs e)
        {
            textPageName.Content = "Список могил";
        }

        private void bCeremonies_Click(object sender, RoutedEventArgs e)
        {
            textPageName.Content = "Список церемоний";
        }
    }
}
