using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using QuestionForYou.UI.WPF.Contracts;
using QuestionForYou.UI.WPF.Controllers;


namespace QuestionForYou.UI.WPF.ViewModels
{
    public class MainWindowViewModel : IMainWindowViewModel, INotifyPropertyChanged
    {
        private Question _questions;

        public Question Questions
        {
            get { return _questions; }
            set
            {
                _questions = value;
                OnPropertyChanged();
            }
        }

        public ICommand GetQuestionsCommand { get; }

        public MainWindowViewModel(IMainWindowController controller)
        {
            controller.ViewModel = this;

            Questions = new Question();
            GetQuestionsCommand = new DelegateCommand(controller.OnGetQuestions);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
