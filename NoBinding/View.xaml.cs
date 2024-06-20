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

namespace NoBinding;

public partial class View : Window, IDisposable
{
    private readonly ViewModel vm;

    public View(ViewModel viewModel)
    {
        InitializeComponent();
        vm = viewModel;
        vm.UpdateView ??= new Action(UpdateView);
    }

    private void CalculateButton_Click(object sender, RoutedEventArgs e)
    {
        SetParametersOnViewModel();
        vm.Calculate();
    }

    public void SetParametersOnViewModel()
    {
        vm.Para1 = int.Parse(Para1TextBox.Text);
        vm.Para2 = int.Parse(Para2TextBox.Text);
        vm.Result = int.Parse(ResultTextBox.Text);
    }

    public void UpdateView()
    {
        Para1TextBox.Text = vm.Para1.ToString();
        Para2TextBox.Text = vm.Para2.ToString();
        ResultTextBox.Text = vm.Result.ToString();
    }

    private void Window_Closed(object sender, EventArgs e)
    {
        Dispose();
    }

    private bool disposedValue;

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                vm.UpdateView = null;
                vm.Dispose();
            }
            disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}