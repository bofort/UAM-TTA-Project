using Autofac;
using QuestionForYou.Data.Service;
using QuestionForYou.UI.WPF.Controller;
using QuestionForYou.UI.WPF.ViewModel;
using System.Windows;

namespace QuestionForYou.UI.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var builder = new ContainerBuilder();
            builder.RegisterType<MainWindowController>().As<IMainWindowController>();
            builder.RegisterType<MainWindowViewModel>().As<IMainWindowViewModel>();
            builder.RegisterType<QuestionService>().As<IQuestionService>();
            builder.RegisterType<MainWindow>();
            var container = builder.Build();
            MainWindow window = container.Resolve<MainWindow>();
            window.Show();
        }
    }
}