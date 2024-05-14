using InvoiceApp.Service.Models;
using InvoiceApp.Service.Services.Interfaces;
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

        public MainWindow(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserLoginCredentials credentials = new UserLoginCredentials()
            {
                UserName = usernameMain.Text.ToString(),
                Password = passwordMain.Password.ToString()
            };

            var response = _authenticationService.Login(credentials);

            if(response.Success)
            {

            }
            else
            {
                loginErrorMain.Visibility = Visibility.Visible;
                loginErrorMain.Text = response.Message;
            }
        }
    }
}