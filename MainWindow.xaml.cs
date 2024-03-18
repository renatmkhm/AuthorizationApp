using System.Windows;
using AuthorizationApp.ViewModels;

namespace AuthorizationApp
{
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _viewModel = new MainViewModel();

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Register_Click(object sender, RoutedEventArgs e)
        {
            string result = await _viewModel.Register(UsernameTextBox.Text, PasswordBox.Password);
            MessageBox.Show(result);
        }
        
        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            bool success = await _viewModel.Login(UsernameTextBox.Text, PasswordBox.Password);
            MessageBox.Show(success ? "Login successful" : "Login failed");
        }
    }
}