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
    DateTime _stopWatchStart;
    DispatcherTimer _timer = new DispatcherTimer();

    private void equalsLabel_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        if(e.ChangedButton == MouseButton.Left)
        {
            StartExercise();
        }
    }

    private void StartExercise()
    {
        resultTextBox.Clear();
        resultTextBox.Background = Brushes.Transparent;
        resultTextBox.IsEnabled = true;

        GetRandomNumbers(out int number1, out int number2);
        
        string operatorSign = GetRandomOperator();
        _expectedResult = CalculateResult(ref number1, ref number2, ref operatorSign);

        firstNumberLabel.Content = number1.ToString();
        operatorLabel.Content = operatorSign;
        secondNumberLabel.Content = number2.ToString();
        
        StartStopWatch();

        resultTextBox.Focus();
    }

    private void GetRandomNumbers(out int number1, out int number2)
    {
        number1 = _randomGenerator.Next(1, 101);
        number2 = _randomGenerator.Next(1, 101);
    }

    private string GetRandomOperator()
    {
        switch(_randomGenerator.Next(0, 2))
        {
            case 0:
                return "+";
            case 1:
                return "-";
        }
        return string.Empty;
    }

    private int CalculateResult(ref int number1, ref int number2, ref string operatorSign)
    {
        switch (operatorSign)
        {
            case "+":
                return number1 + number2;
            case "-":
                return number1 - number2;
        }
        return 0;
    }

    private void StartStopWatch()
    {
        _stopWatchStart = DateTime.Now;

        _timer.Interval = TimeSpan.FromMilliseconds(1);
        _timer.Tick += Timer_Tick;
        _timer.Start();
    }

    private void Timer_Tick(object? sender, EventArgs e)
    {
        TimeSpan timeElapsed = DateTime.Now - _stopWatchStart;
        timerLabel.Content = timeElapsed.ToString(@"mm\:ss\:fff");
    }

    private void resultTextBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            if (CheckResult())
            {
                _timer.Stop();
                resultTextBox.IsEnabled = false;
            }
            else
            {
                resultTextBox.SelectAll();
            }
        }
    }

    private bool CheckResult()
    {
        if (int.TryParse(resultTextBox.Text, out int result))
        {
            if (result == _expectedResult)
            {
                resultTextBox.Background = Brushes.LightGreen;
                return true;
            }
            else
            {
                resultTextBox.Background = Brushes.LightCoral;
                return false;
            }
        }
        else
        {
            resultTextBox.Background = Brushes.LightCoral;
            return false;
        }
    }
}