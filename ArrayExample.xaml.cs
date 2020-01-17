using System;
using System.Windows;
using System.Windows.Input;

namespace ListExample
{
    public partial class ArrayExampleWindow : Window
    {
        string[] array;

        public ArrayExampleWindow()
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

        private void WriteAtIndex_Click(object sender, RoutedEventArgs e)
        {
            int res;
            if (CheckIndexInput(IndexInput.Text, out res) == false)
                return;

            try 
            {
                if (string.IsNullOrEmpty(array[res]))
                    OutputTextBox.Text += $"Element sa indexom {res} je prazan text, da je ovo skup nekih drugih elemenata bilo bi NULL i program bi se ovde crash-ovao!";
                else OutputTextBox.Text += $"{array[res]}\n";
                CodeRun.Text += $"         Console.WriteLine(skup[{res}]);\n";
            }
            catch (Exception ex)
            {
                OutputTextBox.Text += ex.ToString() + "\n";
            }

            IndexInput.Text = "";
            SetupPreview();
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            OutputTextBox.Text += "-------------------\n";
            CodeRun.Text = "";
            array = null;
            SetupPreview();
        }

        private void Generate_Click(object sender, RoutedEventArgs e)
        {
            int res;
            if (CheckIndexInput(GenerateSizeInput.Text, out res) == false)
                return;

            array = new string[res];
            CodeRun.Text = $"string[] skup = new string[{res}];\n";
            SetupPreview();
        }

        private void Set_Click(object sender, RoutedEventArgs e)
        {
            int res;
            if (CheckIndexInput(SetIndexInput.Text, out res) == false)
                return;

            //TODO: FINISH
        }

        private void SetNull_Click(object sender, RoutedEventArgs e)
        {
            int res;
            if (CheckIndexInput(SetNullIndexInput.Text, out res) == false)
                return;

            //TODO: FINISH
        }

        void SetupPreview()
        {
            GraphicalPreviewWrapPanel.Children.Clear();
            for (int i = 0; i < array.Length; i++)
                GraphicalPreviewWrapPanel.Children.Add(new ListItem(i, array[i]));
        }

        bool CheckInput(string input)
        {
            if (array == null)
            {
                OutputTextBox.Text += "string[] \"skup\" nije definisana!\n";
                return false;
            }

            if(string.IsNullOrWhiteSpace(input) || string.IsNullOrEmpty(input))
            {
                OutputTextBox.Text += "Input ne moze da bude prazan...\n";
                return false;
            }

            return true;
        }

        bool CheckIndexInput(string input, out int res)
        {
            res = 0;

            if(int.TryParse(input, out res) == false)
            {
                OutputTextBox.Text += "Input je index u skupu, celobrojna vrednost...\n";
                return false;
            }

            return true;
        }
    }
}