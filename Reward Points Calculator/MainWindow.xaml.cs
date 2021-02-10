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

namespace Reward_Points_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const String REWARD_POINTS_ZERO = "0";
        const String REWARD_POINTS_AVERAGE = "5";
        const String REWARD_POINTS_ABOVE_AVERAGE = "15";
        const String REWARD_POINTS_MEDIUM = "30";
        const String REWARD_POINTS_HIGHEST = "60";

        const byte BOOKS_COUNT_ZERO     = 0;
        const byte BOOKS_COUNT_ONE      = 1;
        const byte BOOKS_COUNT_TWO      = 2;
        const byte BOOKS_COUNT_THREE    = 3;
        const byte BOOKS_COUNT_FOUR     = 4;

        int booksCountValue;

        const String ERROR_TIP_MESSAGE          = "Please enter the valid input.";
        const String MAXREWARD_GREETING_MESSAGE = "Congrats!! You've earned max points.";

        const String ERROR_COLOR_CODE       = "#EF7C8E";
        const String GREETING_COLOR_CODE    = "#18A558";

        public MainWindow()
        {
            InitializeComponent();
            booksCountValue = 0;
        }

        private void Calculate_Reward_Points(object sender, RoutedEventArgs e)
        {
            try
            {
                booksCountValue = byte.Parse(booksCount.Text);
                errorTip.Visibility = Visibility.Hidden;
                if (booksCountValue == BOOKS_COUNT_ZERO)
                {
                    rewardsLabel.Content = REWARD_POINTS_ZERO;
                }
                else if (booksCountValue == BOOKS_COUNT_ONE)
                {
                    rewardsLabel.Content = REWARD_POINTS_AVERAGE;
                }
                else if (booksCountValue == BOOKS_COUNT_TWO)
                {
                    rewardsLabel.Content = REWARD_POINTS_ABOVE_AVERAGE;
                }
                else if (booksCountValue == BOOKS_COUNT_THREE)
                {
                    rewardsLabel.Content = REWARD_POINTS_MEDIUM;
                }
                else if (booksCountValue >= BOOKS_COUNT_FOUR)
                {
                    rewardsLabel.Content = REWARD_POINTS_HIGHEST;
                    showGreetingOrErrorMessage(MAXREWARD_GREETING_MESSAGE, GREETING_COLOR_CODE);
                }
            }
            catch(FormatException)
            {
                showGreetingOrErrorMessage(ERROR_TIP_MESSAGE, ERROR_COLOR_CODE);
            }
            catch(OverflowException)
            {
                showGreetingOrErrorMessage(ERROR_TIP_MESSAGE, ERROR_COLOR_CODE);
            }
        }

        private void Clear_Values(object sender, RoutedEventArgs e)
        {
            rewardsLabel.Content = REWARD_POINTS_ZERO;
            booksCount.Text = BOOKS_COUNT_ZERO.ToString();
            errorTip.Visibility = Visibility.Hidden;
        }

        private void showGreetingOrErrorMessage(String message, String colorCode)
        {
            errorTip.Content = message;
            rewardsLabel.Content = message.Equals(ERROR_TIP_MESSAGE) ? REWARD_POINTS_ZERO : rewardsLabel.Content;
            errorTip.Foreground = (Brush)new BrushConverter().ConvertFrom(colorCode);
            errorTip.Visibility = Visibility.Visible;
        }
    }
}
