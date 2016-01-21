using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestionForYou.UI.WPF.Contracts;
using System.Windows.Input;

namespace QuestionForYou.UI.WPF.ViewModels
{
    public interface IMainWindowViewModel
    {
        Question Questions { get; set; }

        ICommand GetQuestionsCommand { get; }
    }
}
