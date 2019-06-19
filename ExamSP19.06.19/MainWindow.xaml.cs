using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace ExamSP19._06._19
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _incrementedNumber = 0;
        private int[] _numbers;
        private object _locker = new object();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartButtonClick(object sender, RoutedEventArgs e)
        {
            int count;
            if (int.TryParse(numberTextBox.Text, out count))
            {
                _numbers = new int[count];
                for (int i = 0; i < count; i++)
                {
                    Thread thread = new Thread(AddNumber);
                    thread.Start(i + 1);
                    thread.Join();
                }
            }
            else { MessageBox.Show("Please enter number"); }
        }

        private void AddNumber(object number)
        {
            Thread.Sleep(100);
            _numbers[_incrementedNumber] = (int)number;
            Interlocked.Increment(ref _incrementedNumber);
        }

        private async void AddButtonClick(object sender, RoutedEventArgs e)
        {
            int price = 0;
            if (string.IsNullOrWhiteSpace(typeTextBox.Text)
                || int.TryParse(priceTextBox.Text, out price))
            {
                Clothes clothe = new Clothes()
                {
                    Type = typeTextBox.Text,
                    Gender = genderTextBox.Text,
                    Size = int.Parse(sizeTextBox.Text),
                    Country = countryTextBox.Text,
                    Price = int.Parse(priceTextBox.Text)
                };
                using (var context = new ClothesContext())
                {
                    context.Clothes.Add(clothe);
                    await context.SaveChangesAsync();
                }
            }
            else { MessageBox.Show("Not all fields are filled"); }
        }
    }
}