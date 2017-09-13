using MyWPF.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MyWPF.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {

        public ICommand LoginCommand { get; set; }

        private string userName;

        public string UserName
        {
            get => userName;
            set
            {
               userName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("UserName"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
