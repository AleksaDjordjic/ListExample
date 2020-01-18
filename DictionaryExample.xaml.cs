using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace ListExample
{
    public partial class DictionaryExampleWindow : Window
    {
        Dictionary<int, string> dict;

        public DictionaryExampleWindow()
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

        private void WriteAtKey_Click(object sender, RoutedEventArgs e)
        {
            int res;
            if (CheckKeyInput(WriteAtKeyInput.Text, out res))
                return;

            try
            {
                OutputTextBox.Text += dict[res] + "\n";
                CodeRun.Text += $"         dictionary[{WriteAtKeyInput.Text}];\n";
            }
            catch (Exception ex)
            {
                OutputTextBox.Text += ex.ToString() + "\n";
            }

            WriteAtKeyInput.Text = "";
            SetupPreview();
        }

        private void ContainsKey_Click(object sender, RoutedEventArgs e)
        {
            int res;
            if (CheckKeyInput(ContainsKeyInput.Text, out res))
                return;

            CodeRun.Text += $"         Console.WriteLine(dictionary.ContainsKey({ContainsKeyInput.Text}));\n";
            OutputTextBox.Text += dict.ContainsKey(res) + "\n";

            ContainsKeyInput.Text = "";
            SetupPreview();
        }

        private void ContainsValue_Click(object sender, RoutedEventArgs e)
        {
            if (CheckInput(ContainsValueInput.Text))
                return;

            CodeRun.Text += $"         Console.WriteLine(dictionary.ContainsValue(\"{ContainsValueInput.Text}\"));\n";
            OutputTextBox.Text += dict.ContainsValue(ContainsValueInput.Text) + "\n";

            ContainsKeyInput.Text = "";
            SetupPreview();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            dict.Clear();
            CodeRun.Text += $"         dictionary.Clear();\n";
            SetupPreview();
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            int res;
            if (CheckKeyInput(RemoveKeyInput.Text, out res) == false)
                return;

            dict.Remove(res);
            CodeRun.Text += $"         dictionary.Remove(\"{res}\");\n";

            RemoveKeyInput.Text = "";
            SetupPreview();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            int res;
            if (CheckKeyInput(AddKeyInput.Text, out res) == false)
                return;

            if (CheckInput(AddInput.Text) == false)
                return;

            dict.Add(res, AddInput.Text);
            CodeRun.Text += $"         dictionary.Add({AddKeyInput.Text}, \"{AddInput.Text}\");\n";

            AddInput.Text = "";
            AddKeyInput.Text = "";
            SetupPreview();
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            OutputTextBox.Text += "-------------------\n";
            CodeRun.Text = "";
            dict = null;
            SetupPreview();
        }

        private void Generate_Click(object sender, RoutedEventArgs e)
        {
            dict = new Dictionary<int, string>();
            CodeRun.Text = "Dictionary<int, string> dictionary = new Dictionary<int, string>();\n";
            SetupPreview();
        }

        void SetupPreview()
        {
            GraphicalPreviewWrapPanel.Children.Clear();
            if(dict != null)
            {
                var list = dict.ToList();
                for (int i = 0; i < list.Count; i++)
                    GraphicalPreviewWrapPanel.Children.Add(new ListItem(list[i].Key, list[i].Value));
            }
        }

        bool CheckInput(string input)
        {
            if (dict == null)
            {
                OutputTextBox.Text += "Dictionary<string> \"dictionary\" nije definisan!\n";
                return false;
            }

            if(string.IsNullOrWhiteSpace(input) || string.IsNullOrEmpty(input))
            {
                OutputTextBox.Text += "Input ne moze da bude prazan...\n";
                return false;
            }

            return true;
        }

        bool CheckKeyInput(string input, out int res)
        {
            if (int.TryParse(input, out res) == false)
            {
                OutputTextBox.Text += "Input je key u dictionary, int, celobrojna vrezdnost, prvi tip u pravljenju dictionary-a oznacava tip kljuca, u ovom slucaju int (Dictionary<int, string>)\n";
                return false;
            }

            return true;
        }
    }
}