using Microsoft.Practices.Prism.Commands;
using QuestionForYou.Data.Model;
using QuestionForYou.UI.WPF.Controller;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace QuestionForYou.UI.WPF.ViewModel
{
    public class MainWindowViewModel : IMainWindowViewModel, INotifyPropertyChanged
    {
        private IEnumerable<Question> _questions;

        public IEnumerable<Question> Questions
        {
            get { return _questions; }
            set
            {
                _questions = value;
                OnPropertyChanged();
            }
        }

        public ICommand GetQuestionCommand { get; }

        public MainWindowViewModel(IMainWindowController controller)
        {
            controller.ViewModel = this;

            Questions = new ObservableCollection<Question>();
            GetQuestionCommand = new DelegateCommand(controller.GetQuestion);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}