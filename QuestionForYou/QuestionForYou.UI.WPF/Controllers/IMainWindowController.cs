using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestionForYou.UI.WPF.ViewModels;

namespace QuestionForYou.UI.WPF.Controllers
{
    public interface IMainWindowController
    {
        MainWindowViewModel ViewModel { get; set; }

        void OnGetQuestions();
    }
}
