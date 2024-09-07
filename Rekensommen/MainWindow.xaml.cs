using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Rekensommen;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    Random _randomGenerator = new Random();
    int _expectedResult;



    private void StartExercise()
    {
        resultTextBox.Clear();
        resultTextBox.Background = Brushes.White;
        resultTextBox.IsEnabled = true;

        int number1 = 0;
        int number2 = 0;

        //TODO 1: call GetRandomNumbers

        //TODO 2: call CalculateResult and store the result in _expectedResult

        firstNumberLabel.Content = number1.ToString();
        operatorLabel.Content = "+";
        secondNumberLabel.Content = number2.ToString();

        //TODO 3: call InitStopWatch

        resultTextBox.Focus();
    }

    private void GetRandomNumbers(out int number1, out int number2)
    {
        number1 = _randomGenerator.Next(1, 101);
        number2 = _randomGenerator.Next(1, 101);
    }


    private int CalculateResult(ref int number1, ref int number2)
    {
        return number1 + number2;
    }

    private bool CheckResult(TextBox textBox)
    {
        //TODO:
        //check if the input from resultTextBox is a number
        //check if the input is equal to _expectedResult
        //change the backgroundcolor to lightgreen or lightcoral
        //TIP: use TryParse

        throw new NotImplementedException(); //Remove this line
    }
}