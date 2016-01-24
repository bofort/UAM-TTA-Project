using QuestionForYou.UI.WPF.ViewModel;

namespace QuestionForYou.UI.WPF.Controller
{
    public interface IMainWindowController
    {
        MainWindowViewModel ViewModel { get; set; }

        void GetQuestion();
    }
}