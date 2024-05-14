using InvoiceApp.Service.Models;
using InvoiceApp.Service.Services.Interfaces;
using InvoiceApp.StartUpHelpers;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InvoiceApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly Dashboard _dashboard;

        public MainWindow(IAuthenticationService authenticationService, Dashboard dashboard)
        {
            _authenticationService = authenticationService;
            _dashboard = dashboard;
            InitializeComponent();
        }

        private void Login_Main(object sender, RoutedEventArgs e)
        {
            UserLoginCredentials credentials = new ()
            {
                UserName = usernameMain.Text.ToString(),
                Password = passwordMain.Password.ToString()
            };

            ServiceResponse response = _authenticationService.Login(credentials);

            if(response.Success)
            {
                _dashboard.Show();
                this.Close();
            }
            else
            {
                loginErrorMain.Visibility = Visibility.Visible;
                loginErrorMain.Text = response.Message;

            }
        }
    }
}