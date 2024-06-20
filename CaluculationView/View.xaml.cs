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

namespace CaluculationView;

public partial class View : Window
{
    public View()
    {
        InitializeComponent();
    }

    private void CalculateButton_Click(object sender, RoutedEventArgs e)
    {
        Calculate();
    }

    public void Calculate()
    {
        ResultTextBox.Text = (int.Parse(Para1TextBox.Text) + int.Parse(Para2TextBox.Text)).ToString();
    }
}