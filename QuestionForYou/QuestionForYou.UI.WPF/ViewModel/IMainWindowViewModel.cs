using QuestionForYou.Data.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace QuestionForYou.UI.WPF.ViewModel
{
    public interface IMainWindowViewModel
    {
        IEnumerable<Question> Questions { get; set; }
        ICommand GetQuestionCommand { get; }

        event PropertyChangedEventHandler PropertyChanged;
    }
}