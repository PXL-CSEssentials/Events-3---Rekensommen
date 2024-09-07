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
    DispatcherTimer _stopWatch = new DispatcherTimer();

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
        resultTextBox.Background = Brushes.White;
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

        _stopWatch.Interval = TimeSpan.FromMilliseconds(1);
        _stopWatch.Tick += Timer_Tick;
        _stopWatch.Start();
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
            if (CheckResult((TextBox)sender))
            {
                _stopWatch.Stop();
                resultTextBox.IsEnabled = false;
            }
            else
            {
                resultTextBox.SelectAll();
            }
        }
    }

    private bool CheckResult(TextBox textBox)
    {
        //TODO:
        //check if the input from resultTextBox is a number
        //check if the input is equal to _expectedResult

        if (int.TryParse(textBox.Text, out int result))
        {
            if (result == _expectedResult)
            {
                textBox.Background = Brushes.LightGreen;
                return true;
            }
            else
            {
                textBox.Background = Brushes.LightCoral;
                return false;
            }
        }
        else
        {
            textBox.Background = Brushes.LightCoral;
            return false;
        }
    }

    private void Range_TextChanged(object sender, TextChangedEventArgs e)
    {
        TextBox textBox = (TextBox)sender;
        //TextBox textBox = sender as TextBox;

        //By default the background is white
        textBox.Background = Brushes.White;

        if (int.TryParse(textBox.Text, out int number))
        {
            if (number < 0 || number > 100)
            {
                //If the number is out of range, the background will be lightcoral
                textBox.Background = Brushes.LightCoral;
            }
        }
        else
        {
            //If the input is not a number, the background will be lightcoral
            textBox.Background = Brushes.LightCoral;
        }

        //If no condition is met, the background will still be white
    }

    private void Range_KeyDown(object sender, KeyEventArgs e)
    {
        if(e.Key >= Key.D0 && e.Key <= Key.D9 && e.KeyboardDevice.Modifiers == ModifierKeys.Shift)
        {
            e.Handled = false;
        }
        else if (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
        {
            e.Handled = false;
        }
        else
        {
            e.Handled = true;
        }
    }

    private void showTimeButton_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show(DateTime.Now.ToString("ddd dd MMMM yyyy HH:mm"), "Datum en tijd", MessageBoxButton.OK, MessageBoxImage.Information);
    }
}