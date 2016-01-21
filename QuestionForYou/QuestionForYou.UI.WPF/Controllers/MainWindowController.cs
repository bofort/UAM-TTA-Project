using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestionForYou.UI.WPF.ViewModels;
using QuestionForYou.UI.WPF.Service;


namespace QuestionForYou.UI.WPF.Controllers
{
    public class MainWindowController : IMainWindowController
    {
        private readonly IQuestionService _service;

        public MainWindowViewModel ViewModel { get; set; }

        public MainWindowController(IQuestionService service)
        {
            _service = service;
        }

        public async void OnGetQuestions()
        {
            ViewModel.Questions = await _service.GetRandomQuestionAsync();
        }
    }
}
