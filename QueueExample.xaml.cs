using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace ListExample
{
    public partial class QueueExampleWindow : Window
    {
        Queue<string> queue;

        public QueueExampleWindow()
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

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            if (CheckNull() == false) return;

            queue.Clear();
            CodeRun.Text += $"         red.Clear();\n";
            SetupPreview();
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            if (CheckNull() == false) return;

            try
            {
                OutputTextBox.Text += queue.Dequeue() + "\n";
                CodeRun.Text += $"         Console.WriteLine(red.Dequeue());\n";
            }
            catch(Exception ex)
            {
                OutputTextBox.Text += ex.ToString() + "\n";
            }

            SetupPreview();
        }

        private void Peek_Click(object sender, RoutedEventArgs e)
        {
            if (CheckNull() == false) return;

            try
            {
                OutputTextBox.Text += queue.Peek() + "\n";
                CodeRun.Text += $"         Console.WriteLine(red.Peek())\n;";
            }
            catch (Exception ex)
            {
                OutputTextBox.Text += ex.ToString() + "\n";
            }
            
            SetupPreview();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (CheckInput(AddInput.Text) == false)
                return;

            queue.Enqueue(AddInput.Text);
            CodeRun.Text += $"         red.Enqueue(\"{AddInput.Text}\");\n";

            AddInput.Text = "";
            SetupPreview();
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            OutputTextBox.Text += "-------------------\n";
            CodeRun.Text = "";
            queue = null;
            SetupPreview();
        }

        private void Generate_Click(object sender, RoutedEventArgs e)
        {
            queue = new Queue<string>();
            CodeRun.Text = "Queue<string> red = new Queue<string>();\n";
            SetupPreview();
        }

        void SetupPreview()
        {
            GraphicalPreviewWrapPanel.Children.Clear();

            if(queue != null)
            {
                var array = queue.ToArray();
                for (int i = 0; i < array.Length; i++)
                    GraphicalPreviewWrapPanel.Children.Add(new ListItem(i, array[i]));
            }
        }

        bool CheckNull()
        {
            if(queue == null)
            {
                OutputTextBox.Text += "Queue<string> \"red\" nije definisan!\n";
                return false;
            }

            return true;
        }

        bool CheckInput(string input)
        {
            if (queue == null)
            {
                OutputTextBox.Text += "Queue<string> \"red\" nije definisan!\n";
                return false;
            }

            if(string.IsNullOrWhiteSpace(input) || string.IsNullOrEmpty(input))
            {
                OutputTextBox.Text += "Input ne moze da bude prazan...\n";
                return false;
            }

            return true;
        }
    }
}