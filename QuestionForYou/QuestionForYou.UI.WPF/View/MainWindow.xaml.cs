using QuestionForYou.Data.Model;
using QuestionForYou.Data.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using QuestionForYou.UI.WPF.ViewModels;


namespace QuestionForYou.UI.WPF.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //QuestionForYouContext db = new QuestionForYouContext("IntegrationTestsConnectionString");

        //private int rightAnswer = -1; // it keep the number of answer which is right in current question
        public MainWindow(IMainWindowViewModel viewModel)
        {
            InitializeComponent();


        }

        private void putQuestionButton_Click(object sender, RoutedEventArgs e)
        {
           

            //List<Answer> allAnswers = new List<Answer>();
            //if (firstAnswerTextBox.Text != "" && firstAnswerTextBox.Text != "Put here right answer..." &&
            //    secondAnswerTextBox.Text != "" && secondAnswerTextBox.Text != "Put here wrong answer..." &&
            //    thirdAnswerTextBox.Text != "" && thirdAnswerTextBox.Text != "Put here wrong answer..." &&
            //    fourthAnswerTextBox.Text != "" && fourthAnswerTextBox.Text != "Put here wrong answer..." &&
            //    questionTextTextBox.Text !="" && questionTextTextBox.Text != "Put here new text for question..."
            //    )
            //{
            //    var newQuestion = new Question { Text = questionTextTextBox.Text };
            //    allAnswers.Add(new Answer { Text = firstAnswerTextBox.Text, IsCorrect = true });
            //    allAnswers.Add(new Answer { Text = secondAnswerTextBox.Text, IsCorrect = false });
            //    allAnswers.Add(new Answer { Text = thirdAnswerTextBox.Text, IsCorrect = false });
            //    allAnswers.Add(new Answer { Text = fourthAnswerTextBox.Text, IsCorrect = false });
            //    db.Questions.Add(new Question { Id = null, Text = questionTextTextBox.Text, Answers = allAnswers, Category = new Category { Name = "Sport" } });
            //    db.SaveChanges();
            //    MessageBox.Show("Inserted");
            //}
            //else MessageBox.Show("Put data to all boxes");

        }

        private void getQuestionButton_Click(object sender, RoutedEventArgs e) //get random question
        {
            /*Random rnd1 = new Random();
            List<Question> allQuestion = db.Questions.ToList();
            int randomNumber = rnd1.Next(0, allQuestion.Count - 1);
            
            Question choosedQuestion = allQuestion.ElementAt(randomNumber);

            questionTextButton.Content = choosedQuestion.Text;

            var answersQuery = from cust in db.Answers
                                       where cust.Question.Id == choosedQuestion.Id
                                       select cust;


            Console.Write("Count of answers:"+ answersQuery.ToList().Count.ToString());
            List<Answer> answersOoChoosedQuestion = answersQuery.ToList();

            Console.Write(rnd1.Next(0, allQuestion.Count).ToString());
            answersOoChoosedQuestion = shuffleList(answersOoChoosedQuestion);

            firstAnswerButton.Content = answersOoChoosedQuestion.ElementAt(0).Text;
            secondAnswerButton.Content = answersOoChoosedQuestion.ElementAt(1).Text;
            thirdAnswerButton.Content = answersOoChoosedQuestion.ElementAt(2).Text;
            fourthAnswerButton.Content = answersOoChoosedQuestion.ElementAt(3).Text;

            rightAnswer = findRightAnswer(answersOoChoosedQuestion);

            Console.Write("Answer right:" + rightAnswer.ToString());
            */

        }

        private List<E> shuffleList<E>(List<E> inputList)
        {
            List<E> randomList = new List<E>();

            Random r = new Random();
            int randomIndex = 0;
            while (inputList.Count > 0)
            {
                randomIndex = r.Next(0, inputList.Count);
                randomList.Add(inputList[randomIndex]);
                inputList.RemoveAt(randomIndex);
            }

            return randomList;
        }

        private int findRightAnswer(List<Answer> answers) //return -1 if there is no correct answer or other numerb which represent number (from the left side in wpf app) which answer is correct
        {
            int i = 0;
            foreach (Answer answer in answers)
            {
                if (answer.IsCorrect == true)
                    return i;

            }
            return -1;

        }

        //private void firstAnswerTextBox_GotFocus(object sender, RoutedEventArgs e)
        //{
        //    if (firstAnswerTextBox.Text == "Put here right answer...")
        //        firstAnswerTextBox.Text = "";
        //}

        //private void secondAnswerTextBox_GotFocus(object sender, RoutedEventArgs e)
        //{
        //    if (secondAnswerTextBox.Text == "Put here wrong answer...")
        //        secondAnswerTextBox.Text = "";

        //}

        //private void thirdAnswerTextBox_GotFocus(object sender, RoutedEventArgs e)
        //{
        //    if (thirdAnswerTextBox.Text == "Put here wrong answer...")
        //        thirdAnswerTextBox.Text = "";

        //}

        //private void fourthAnswerTextBox_GotFocus(object sender, RoutedEventArgs e)
        //{
        //    if (fourthAnswerTextBox.Text == "Put here wrong answer...")
        //        fourthAnswerTextBox.Text = "";

        //}

        //private void fourthAnswerTextBox_LostFocus(object sender, RoutedEventArgs e)
        //{
        //    if (fourthAnswerTextBox.Text == "")
        //        fourthAnswerTextBox.Text = "Put here wrong answer...";

        //}

        //private void thirdAnswerTextBox_LostFocus(object sender, RoutedEventArgs e)
        //{
        //    if (thirdAnswerTextBox.Text == "")
        //        thirdAnswerTextBox.Text = "Put here wrong answer...";
        //}

        //private void secondAnswerTextBox_LostFocus(object sender, RoutedEventArgs e)
        //{
        //    if (secondAnswerTextBox.Text == "")
        //        secondAnswerTextBox.Text = "Put here wrong answer...";

        //}

        //private void firstAnswerTextBox_LostFocus(object sender, RoutedEventArgs e)
        //{
        //    if (firstAnswerTextBox.Text == "")
        //        firstAnswerTextBox.Text = "Put here right answer...";
        //}

        //private void questionTextTextBox_LostFocus(object sender, RoutedEventArgs e)
        //{
        //    if (questionTextTextBox.Text == "")
        //        questionTextTextBox.Text = "Put here new text for question...";
        //}

        //private void questionTextTextBox_GotFocus(object sender, RoutedEventArgs e)
        //{
        //    if (questionTextTextBox.Text == "Put here new text for question...")
        //        questionTextTextBox.Text = "";
                   

        //}
    }
}

