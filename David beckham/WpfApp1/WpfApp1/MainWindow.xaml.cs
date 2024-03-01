using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace QuizApp
{
    public class Question
    {
        public string QuestionText { get; }
        public List<string> Options { get; }
        public List<int> CorrectAnswerIndices { get; }

        public Question(string questionText, List<string> options, List<int> correctAnswerIndices)
        {
            QuestionText = questionText;
            Options = options;
            CorrectAnswerIndices = correctAnswerIndices;
        }

        public bool IsAnswerCorrect(bool isOptionASelected, bool isOptionBSelected, bool isOptionCSelected, bool isOptionDSelected)
        {
            List<bool> selectedOptions = new List<bool> { isOptionASelected, isOptionBSelected, isOptionCSelected, isOptionDSelected };
            for (int i = 0; i < CorrectAnswerIndices.Count; i++)
            {
                int correctIndex = CorrectAnswerIndices[i];
                if (!selectedOptions[correctIndex])
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class QuestionViewModel : INotifyPropertyChanged
    {
        private List<Question> questions;
        private int currentQuestionIndex;
        private int correctAnswers;

        public event PropertyChangedEventHandler PropertyChanged;

        public string CurrentQuestion => questions[currentQuestionIndex].QuestionText;
        public string OptionA => questions[currentQuestionIndex].Options[0];
        public string OptionB => questions[currentQuestionIndex].Options[1];
        public string OptionC => questions[currentQuestionIndex].Options[2];
       

        public ICommand SubmitCommand { get; }

        public QuestionViewModel()
        {
            questions = new List<Question>
            {
    
                
    new Question("Mi az öröklődés az OOP-ban?",
                 new List<string>{"Ez az a folyamat, amelynek során egy osztály megszerzi egy másik osztály tulajdonságait (metódusokat és mezőket).",
                                  "Ez az a folyamat, amely során egy új osztályt hozunk létre egy meglévő osztályból.",
                                  "Ez az a folyamat, amelynek során elrejtjük a belső állapotot, és kötelezővé tesszük, hogy az összes interakció egy objektum metódusain keresztül történjen."},
                 new List<int>{0, 1}),

    new Question("Mi az a polimorfizmus az OOP-ban?",
                 new List<string>{"Ez az a képesség, hogy egy függvény különböző feladatokat végezzen el az objektumtól függően, amelyre hat.",
                                  "Ez az a folyamat, amely során egy új osztályt hozunk létre egy meglévő osztályból.",
                                  "Ez az a folyamat, amelynek során egy osztály megszerzi egy másik osztály tulajdonságait (metódusokat és mezőket)."},
                 new List<int>{0}),

    new Question("Mi az az inkapszuláció az OOP-ban?",
                 new List<string>{"Ez az a folyamat, amely során az adatokat és a módszereket, amelyek az adatokon dolgoznak, egyetlen egységbe vagy osztályba csoportosítjuk.",
                                  "Ez az a folyamat, amely során egy új osztályt hozunk létre egy meglévő osztályból.",
                                  "Ez az a folyamat, amelynek során elrejtjük a belső állapotot, és kötelezővé tesszük, hogy az összes interakció egy objektum metódusain keresztül történjen."},
                 new List<int>{0, 2}),

    new Question("Mi az egy osztály az OOP-ban?",
                 new List<string>{"Ez egy tervrajz az objektumok létrehozásához (egy adott adatstruktúra létrehozásához), kezdeti értékek biztosításával az állapot (tagváltozók vagy mezők) és a viselkedések (tagfüggvények vagy metódusok) végrehajtásának implementálásával.",
                                  "Ez egy osztály példánya.",
                                  "Ez egy speciális típusú függvény, amelyet az objektumok példányosítására használnak."},
                 new List<int>{0}),

    new Question("Mi az az objektum az OOP-ban?",
                 new List<string>{"Ez egy osztály példánya, amely tartalmazhat mind adatokat (tagváltozók vagy mezők), mind módszereket (tagfüggvények).",
                                  "Ez egy tervrajz az objektumok létrehozásához (egy adott adatstruktúra létrehozásához), kezdeti értékek biztosításával az állapot (tagváltozók vagy mezők) és a viselkedések (tagfüggvények vagy metódusok) végrehajtásának implementálásával.",
                                  "Ez egy speciális típusú függvény, amelyet az objektumok példányosítására használnak."},
                 new List<int>{0}),

    new Question("Mi az egy konstruktor az OOP-ban?",
                 new List<string>{"Ez egy speciális típusú függvény, amely automatikusan hívódik meg, amikor egy osztály objektuma létrejön.",
                                  "Ez egy függvény, amelyet egy meghatározott feladat elvégzésére használnak.",
                                  "Ez egy függvény, amelyet objektumok megsemmisítésére használnak."},
                 new List<int>{0}),

    new Question("Mi az a metódus felülírása az OOP-ban?",
                 new List<string>{"Ez az a folyamat, amelynek során a szülőosztályban már meglévő egy metódusnak az alosztályban új implementációt adunk.",
                                  "Ez az a folyamat, amely során egy új osztályt hozunk létre egy meglévő osztályból.",
                                  "Ez az a folyamat, amelynek során egy osztály megszerzi egy másik osztály tulajdonságait (metódusokat és mezőket)."},
                 new List<int>{0}),

    new Question("Mi az a metódus túlterhelése az OOP-ban?",
                 new List<string>{"Ez a képesség, hogy több metódust definiáljunk ugyanazzal a névvel, de különböző paraméterekkel.",
                                  "Ez az a folyamat, amely során egy új osztályt hozunk létre egy meglévő osztályból.",
                                  "Ez az a folyamat, amelynek során egy osztály megszerzi egy másik osztály tulajdonságait (metódusokat és mezőket)."},
                 new List<int>{0}),

    new Question("Mi az az egy statikus metódus az OOP-ban?",
                 new List<string>{"Ez egy olyan metódus, amely az osztályhoz tartozik, nem pedig az osztály egy adott példányához.",
                                  "Ez egy olyan metódus, amely automatikusan hívódik meg, amikor egy osztály objektuma létrejön.",
                                  "Ez egy olyan metódus, amelyet az objektumok példányosítására használnak."},
                 new List<int>{0}),

    new Question("Mi az az egy statikus változó az OOP-ban?",
                 new List<string>{"Ez egy olyan változó, amely az osztályhoz tartozik, nem pedig az osztály egy adott példányához.",
                                  "Ez egy változó, amely automatikusan hívódik meg, amikor egy osztály objektuma létrejön.",
                                  "Ez egy változó, amelyet az objektumok címének tárolására használnak."},
                 new List<int>{0}),

    new Question("Mi az az egy destruktor az OOP-ban?",
                 new List<string>{"Ez egy speciális típusú függvény, amely automatikusan hívódik meg, amikor egy osztály objektuma megsemmisül.",
                                  "Ez egy olyan függvény, amelyet egy meghatározott feladat elvégzésére használnak.",
                                  "Ez egy függvény, amelyet objektumok példányosítására használnak."},
                 new List<int>{0}),

    new Question("Mi az egy szülőosztály az OOP-ban?",
                 new List<string>{"Ez egy olyan osztály, amelyből egy másik osztály (alosztály) örökli a tulajdonságokat (metódusokat és mezőket).",
                                  "Ez egy osztály, amelynek az egyik alosztálya.",
                                  "Ez egy speciális típusú függvény, amelyet az objektumok példányosítására használnak."},
                 new List<int>{0}),

    new Question("Mi az az egy alosztály az OOP-ban?",
                 new List<string>{"Ez egy olyan osztály, amely örökli a tulajdonságokat (metódusokat és mezőket) egy másik osztályból (szülőosztály).",
                                  "Ez egy olyan osztály, amelyből egy másik osztály (szülőosztály) örökli a tulajdonságokat (metódusokat és mezőket).",
                                  "Ez egy speciális típusú függvény, amelyet az objektumok példányosítására használnak."},
                 new List<int>{0}),

    new Question("Mi az az egy virtuális metódus az OOP-ban?",
                 new List<string>{"Ez egy olyan metódus, amelyet felül lehet definiálni egy alosztályban.",
                                  "Ez egy olyan metódus, amelyet nem lehet felül definiálni egy alosztályban.",
                                  "Ez egy olyan metódus, amely automatikusan hívódik meg, amikor egy osztály objektuma létrejön."},
                 new List<int>{0})
};

    

            SubmitCommand = new RelayCommand(SubmitAnswer);
        }

        private void SubmitAnswer(object obj)
        {
            // Check if any checkboxes are checked
            if (questions[currentQuestionIndex].IsAnswerCorrect(IsOptionASelected, IsOptionBSelected, IsOptionCSelected, IsOptionDSelected))
            {
                correctAnswers++;
            }

            // Clear checkboxes
            IsOptionASelected = false;
            IsOptionBSelected = false;
            IsOptionCSelected = false;
            IsOptionDSelected = false;

            // Move to the next question
            currentQuestionIndex++;

            // Check if reached the end of the quiz
            if (currentQuestionIndex >= questions.Count)
            {
                // Display results
                string resultMessage = $"Ön {correctAnswers} kérdésből válaszolt helyesen az összesből.\n\n";
                for (int i = 0; i < questions.Count; i++)
                {
                    resultMessage += $"{i + 1}. kérdés: {questions[i].QuestionText}\n";
                    resultMessage += $"Helyes válasz(ok): {string.Join(", ", questions[i].CorrectAnswerIndices)}\n\n";
                }
                System.Windows.MessageBox.Show(resultMessage, "Quiz Eredmények");

                // Reset quiz
                currentQuestionIndex = 0;
                correctAnswers = 0;
            }

            OnPropertyChanged(nameof(CurrentQuestion));
            OnPropertyChanged(nameof(OptionA));
            OnPropertyChanged(nameof(OptionB));
            OnPropertyChanged(nameof(OptionC));
            
        }

        private bool _isOptionASelected;
        public bool IsOptionASelected
        {
            get => _isOptionASelected;
            set
            {
                if (_isOptionASelected != value)
                {
                    _isOptionASelected = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _isOptionBSelected;
        public bool IsOptionBSelected
        {
            get => _isOptionBSelected;
            set
            {
                if (_isOptionBSelected != value)
                {
                    _isOptionBSelected = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _isOptionCSelected;
        public bool IsOptionCSelected
        {
            get => _isOptionCSelected;
            set
            {
                if (_isOptionCSelected != value)
                {
                    _isOptionCSelected = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _isOptionDSelected;
        public bool IsOptionDSelected
        {
            get => _isOptionDSelected;
            set
            {
                if (_isOptionDSelected != value)
                {
                    _isOptionDSelected = value;
                    OnPropertyChanged();
                }
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<bool> _canExecute;

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public RelayCommand(Action<object> execute, Func<bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute();
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}

