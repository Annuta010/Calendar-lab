using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace ПР2
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                int Month = int.Parse(monthPlaceholder.Text);
                int Year = int.Parse(yearPlaceholder.Text);
                string[] MonthDaysAnswer = new string[35];
                int[] MonthDays = new int[]
                { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
                double StartDay = 3;
                int MonthSum = 0;
                string MonthString = " ";

                double Formyla = 0;
                if ((Year <= 2029) && (Year >= 1919) && (Month <= 12) && (Month >= 1))
                {
                    if ((Year - 1920) % 4 == 0)
                    {
                        MonthDays[1] = 29;
                    }
                    for (int c = 0; c < Month - 1; c++)
                    {
                        MonthSum += MonthDays[c];
                    }
                    Formyla = ((Year - 1916 - 1) / 4);
                    StartDay = StartDay + (((Year - 1919) + Math.Truncate(Formyla) + (MonthSum % 7)) % 7);
                    if (StartDay > 7)
                    {
                        StartDay = StartDay % 7;
                    }
                    for (int i = 0; i < MonthDays[Month - 1]; i++)
                    {

                        MonthDaysAnswer[Convert.ToInt32(StartDay)+i-1] = (i + 1).ToString();
                    }
                    switch (Month)
                    {
                        case 1:
                            MonthString = "ЯНВАРЬ";
                            break;
                        case 2:
                            MonthString = "ФЕВРАЛЬ";
                            break;
                        case 3:
                            MonthString = "МАРТ";
                            break;
                        case 4:
                            MonthString = "АПРЕЛЬ";
                            break;
                        case 5:
                            MonthString = "МАЙ";
                            break;
                        case 6:
                            MonthString = "ИЮНЬ";
                            break;
                        case 7:
                            MonthString = "ИЮЛЬ";
                            break;
                        case 8:
                            MonthString = "АВГУСТ";
                            break;
                        case 9:
                            MonthString = "СЕНТЯБРЬ";
                            break;
                        case 10:
                            MonthString = "ОКТЯБРЬ";
                            break;
                        case 11:
                            MonthString = "НОЯБРЬ";
                            break;
                        case 12:
                            MonthString = "ДЕКАБРЬ";
                            break;
                    }
                    layoutGrid.Visibility = Visibility.Visible;
                    yearOutput.Text = Year.ToString();
                    monthOutput.Text = MonthString;
                    int left = -270;
                    int top = -300;
                    int Day = 0;

                    while (Day < 42)
                    {

                        for (int j = 0; j < 7; j++)
                        {
                            TextBlock day = new TextBlock();
                            day.Width = 150;
                            day.Height = 50;
                            left += 100;
                            day.Margin = new Thickness(left, top, 0, 0);
                            if (MonthDaysAnswer[Day] == null)
                            {
                                MonthDaysAnswer[Day] = " ";

                            }
                            day.Text = MonthDaysAnswer[Day];
                            Day++;
                            layoutGrid.Children.Add(day);
                        }
                        left = -270;
                        top += 100;
                    }
                }
                else
                {
                    TextBlock err = new TextBlock();
                    err.Width = 200;
                    err.Height = 200;
                    err.Text = "Вы неправильно ввели данные";
                    errGrid.Children.Add(err);
                    errGrid.Visibility = Visibility.Visible;
                }

            }
            catch (Exception ex)
            {
                TextBlock err = new TextBlock();
                err.Width = 200;
                err.Height = 200;
                errGrid.Children.Add(err);
                errGrid.Visibility = Visibility.Visible;
            }

        }

        private void yearPlaceholder_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            IsInputBoxEmpty();
        }

        private void monthPlaceholder_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            IsInputBoxEmpty();
        }

        public void IsInputBoxEmpty()
        {
            if ((yearPlaceholder.Text != "") && (monthPlaceholder.Text != ""))
            {
                ShowBtn.IsEnabled = true;
            }
        }
    }
}
