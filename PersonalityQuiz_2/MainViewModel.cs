using System;
using System.ComponentModel;

namespace PersonalityQuiz_2
{
    public class MainViewModel : INotifyPropertyChanged
    {

        string name = string.Empty;

        public string Name
        {
            get => name;

            set
            {
                if (name == value)
                    return;

                    name = value;
                OnPropertyChanged(nameof(Name));

                    
                
            }
        }
        public MainViewModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
