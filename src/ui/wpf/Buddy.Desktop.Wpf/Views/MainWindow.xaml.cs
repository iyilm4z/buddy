using Buddy.Desktop.ViewModels;

namespace Buddy.Desktop.Views
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}