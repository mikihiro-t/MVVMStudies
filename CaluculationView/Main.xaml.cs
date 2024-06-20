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
using System.Windows.Shapes;

namespace CaluculationView;

public partial class Main : Window
{
    public Main()
    {
        InitializeComponent();
    }


    private void Calculate100Button_Click(object sender, RoutedEventArgs e)
    {
        var view1 = new View();
        view1.Show();

        for (int i = 1; i <= 100; i++)
        {
            view1.Para1TextBox.Text = i.ToString();
            view1.Para2TextBox.Text = i.ToString();
            view1.Calculate();
            Result100TextBox.Text += view1.ResultTextBox.Text +"\r\n";
        }
    }
}