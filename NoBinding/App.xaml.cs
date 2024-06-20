using System;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media.Imaging;

namespace NoBinding;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        var model = new Model();
        var viewModel = new ViewModel(model);
        var view = new View(viewModel);
        view.Show();
    }
}