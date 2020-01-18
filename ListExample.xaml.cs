using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace ListExample
{
    public partial class ListExampleWindow : Window
    {
        List<string> list;

        public ListExampleWindow()
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
                OutputTextBox.Text += $"{list[res]}\n";
                CodeRun.Text += $"         Console.WriteLine(lista[{res}]);\n";
            }
            catch (Exception ex)
            {
                OutputTextBox.Text += ex.ToString() + "\n";
            }

            IndexInput.Text = "";
            SetupPreview();
        }

        private void RemoveAt_Click(object sender, RoutedEventArgs e)
        {
            int res;
            if (CheckIndexInput(RemoveAtInput.Text, out res) == false)
                return;

            try
            {
                list.RemoveAt(res);
                CodeRun.Text += $"         lista.RemoveAt({res});\n";
            }
            catch (Exception ex)
            {
                OutputTextBox.Text += ex.ToString() + "\n";
            }

            RemoveAtInput.Text = "";
            SetupPreview();
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            if (CheckInput(RemoveInput.Text) == false)
                return;

            list.Remove(RemoveInput.Text);
            CodeRun.Text += $"         lista.Remove(\"{RemoveInput.Text}\");\n";

            RemoveInput.Text = "";
            SetupPreview();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (CheckInput(AddInput.Text) == false)
                return;

            list.Add(AddInput.Text);
            CodeRun.Text += $"         lista.Add(\"{AddInput.Text}\");\n";

            AddInput.Text = "";
            SetupPreview();
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            OutputTextBox.Text += "-------------------\n";
            CodeRun.Text = "";
            list = null;
            SetupPreview();
        }

        private void Generate_Click(object sender, RoutedEventArgs e)
        {
            list = new List<string>();
            CodeRun.Text = "List<string> lista = new List<string>();\n";
            SetupPreview();
        }

        void SetupPreview()
        {
            GraphicalPreviewWrapPanel.Children.Clear();
            if(list != null)
                for (int i = 0; i < list.Count; i++)
                    GraphicalPreviewWrapPanel.Children.Add(new ListItem(i, list[i]));
        }

        bool CheckInput(string input)
        {
            if (list == null)
            {
                OutputTextBox.Text += "List<string> \"lista\" nije definisan!\n";
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
                OutputTextBox.Text += "Input je index u listi, celobrojna vrednost...\n";
                return false;
            }

            return true;
        }
    }
}