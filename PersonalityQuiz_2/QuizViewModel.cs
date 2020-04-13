using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace PersonalityQuiz_2
{
    public class QuizViewModel : INotifyPropertyChanged
    {
        public List<Question> Questions {  get;  set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public int QuestionIndex { get; set; }
        public int UserPoints;
        public string Character = string.Empty;
        bool buttonsAreVisible;
        public bool ButtonsAreVisible {
            get => buttonsAreVisible;
            private set
            {
                buttonsAreVisible = value;
                OnPropertyChanged();
                GoToNextQuestionTrue.ChangeCanExecute();
                GoToNextQuestionFalse.ChangeCanExecute();
            }

          }
      
        private Question CurrentQuestion;
       public string currentQuestionContent;
        public Command GoToNextQuestionTrue { get; }
        public Command GoToNextQuestionFalse { get; }

        public string CurrentQuestionContent
        {
            get => currentQuestionContent;
            set
            {
                if (currentQuestionContent == value)
                    return;

                currentQuestionContent = value;

                OnPropertyChanged();
                GoToNextQuestionTrue.ChangeCanExecute();
                GoToNextQuestionFalse.ChangeCanExecute();

            }
        }


        public QuizViewModel()
        {
            QuestionIndex = 0;
            buttonsAreVisible = true;
            UserPoints = 0;
            Questions = new List<Question>
            {
                new Question("Do you like ruining others people's lives?", 1),
                new Question("Do you like saving the galaxy?", 3),
                new Question("Have you ever accidentally kissed your sister on the lips?", 4),
                new Question("Are you awkward?", 20),
                new Question("Do you enjoy when the bad guys win?", 1)
            };

            CurrentQuestion = Questions[QuestionIndex];
            currentQuestionContent = CurrentQuestion.Content;

            GoToNextQuestionTrue = new Command(NextQuestionTrue);
            GoToNextQuestionFalse = new Command(NextQuestionFalse);

        }



        void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        void NextQuestionTrue()
        {

            if ((Questions.Count - 1) > QuestionIndex)

            {

                UserPoints += CurrentQuestion.PointValue;
                CurrentQuestion = Questions[++QuestionIndex];
                CurrentQuestionContent = CurrentQuestion.Content;
            }
            else
            {
                ButtonsAreVisible = false;
                SetCharacter();
                CurrentQuestionContent = Character;
            }
            
        }

        void NextQuestionFalse()
        {
            if ((Questions.Count - 1) > QuestionIndex)

            {
                CurrentQuestion = Questions[++QuestionIndex];
                CurrentQuestionContent = CurrentQuestion.Content;
            }
            else
            {
                ButtonsAreVisible = false;
                SetCharacter();
                CurrentQuestionContent = Character;
            }
        }

        void SetCharacter()
        {
            if (UserPoints <= 2 || UserPoints == 22)
            {
                Character = "You are Emporer Palpatine";

            }
            else if (UserPoints == 20)
            {
                Character = "You are Jar Jar Binks";

            }
            else if (UserPoints == 7 || UserPoints == 27)
            {
                Character = "You are Luke Skywalker";
            }
            else if (UserPoints == 3 || UserPoints == 23 )
            {
                Character = "You are Princess Leia";
            }
            else
            {
                Character = "You are Darth Vader";
            }
        }

 
    }


    public class Question
    {
        public string Content { get; set; }
        public int PointValue { get; set; }

        public Question(string content, int pointValue)
        {
            Content = content;
            PointValue = pointValue;
        }

    }
}

