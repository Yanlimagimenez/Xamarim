using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Xamarin.Forms;
using System.Windows.Input;

namespace AppBindingCommands
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public ICommand ShowMessageCommand;

        private string name = string.Empty;
        public string Name
        { 
            get { return name; } //get => name
            set
            {
                if (name == null)
                    return;

                name = value;
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(DisplayName));
            }
        }

        private string displayMessage = string.Empty;

        public string DisplayMessage
        {
            get => displayMessage;
            set
            {
                if (displayMessage == null)
                    return;

                displayMessage = value;
                OnPropertyChanged(nameof(DisplayMessage));
            }
        }

        public void ShowMessage()
        {
            string dataProperty = Application.Current.Properties["dtAtual"].ToString();
            DisplayMessage = $"Boa noite {Name}. Hoje é {dataProperty}.";
        }

        public MainPageViewModel()
        {
            ShowMessageCommand = new Command(ShowMessage);
        }

        public string DisplayName => $"Nome digitado : {Name}";
    }

    
}
