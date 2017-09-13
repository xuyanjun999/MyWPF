using MahApps.Metro.Controls;
using MyWPF.Command;
using MyWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MyWPF
{
    /// <summary>
    /// LoginWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWindow : MetroWindow
    {
        public LoginViewModel LoginViewModel { get; set; }
        public LoginWindow()
        {
            InitializeComponent();
            Binding();
        }

        public void Binding()
        {
            LoginViewModel = new LoginViewModel();

            LoginViewModel.LoginCommand = new SimpleCommand()
            {
                CanExecuteDelegate = (o) => !string.IsNullOrWhiteSpace(txtUserName.Text),
                ExecuteDelegate = LoginExcute
            };

            this.DataContext = LoginViewModel;
        }


        public void LoginExcute(object obj)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            this.Close();
        }
    }
}
