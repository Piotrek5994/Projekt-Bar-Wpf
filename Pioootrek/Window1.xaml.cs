using System.Windows;

namespace Pioootrek
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow powrot = new MainWindow();
            this.Visibility = Visibility.Hidden;
            powrot.Show();
        }
    }
}
