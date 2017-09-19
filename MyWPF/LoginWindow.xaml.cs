using AutoUpdaterDotNET;
using MahApps.Metro.Controls;
using MyWPF.Command;
using MyWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            CheckUpdate();
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

        public void CheckUpdate()
        {
            AutoUpdater.CurrentCulture = new CultureInfo("zh-CN");
            AutoUpdater.LetUserSelectRemindLater = true;
            AutoUpdater.RemindLaterTimeSpan = RemindLaterFormat.Minutes;
            AutoUpdater.RemindLaterAt = 1;
            AutoUpdater.ReportErrors = true;
            //System.Timers.Timer timer = new System.Timers.Timer { Interval = 2 * 60 * 1000 };
        
            //timer.Elapsed += delegate
            //{
                AutoUpdater.Start("http://localhost:10002/autoupdateTemplete.xml");
            //};
            //timer.Start();
        }


        public void LoginExcute(object obj)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            this.Close();
        }
    }
}
