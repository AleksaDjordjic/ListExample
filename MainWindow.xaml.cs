using System.Windows;
using System.Windows.Input;

namespace ListExample
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TopBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Maximize_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
                WindowState = WindowState.Normal;
            else WindowState = WindowState.Maximized;
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Array_Click(object sender, RoutedEventArgs e)
        {
            new ArrayExampleWindow().Show();
            Close();
        }

        private void List_Click(object sender, RoutedEventArgs e)
        {
            new ListExampleWindow().Show();
            Close();
        }

        private void Queue_Click(object sender, RoutedEventArgs e)
        {
            new QueueExampleWindow().Show();
            Close();
        }

        private void Dictionary_Click(object sender, RoutedEventArgs e)
        {
            new DictionaryExampleWindow().Show();
            Close();
        }
    }
}