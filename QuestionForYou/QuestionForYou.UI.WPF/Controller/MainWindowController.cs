using QuestionForYou.Data.Model;
using QuestionForYou.UI.WPF.Service;
using QuestionForYou.UI.WPF.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace QuestionForYou.UI.WPF.Controller
{
    public class MainWindowController : IMainWindowController
    {
        private readonly IQuestionService _service;

        public MainWindowViewModel ViewModel { get; set; }

        public MainWindowController(IQuestionService service)
        {
            _service = service;
        }

        public async void GetQuestion()
        {
            List<Question> list = ViewModel.Questions.ToList();
            Question q = await _service.GetRandomQuestionAsync();
            list.Add(q);
            ViewModel.Questions = list;
        }
    }
}