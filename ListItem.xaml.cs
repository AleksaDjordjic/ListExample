using System.Windows.Controls;

namespace ListExample
{
    public partial class ListItem : UserControl
    {
        public ListItem()
        {
            InitializeComponent();
        }

        public ListItem(int index, object content)
        {
            InitializeComponent();

            IndexText.Text = "#" + index.ToString();

            if (content == null)
                ContentText.Text = "NULL";
            else ContentText.Text = content.ToString();
        }
    }
}
