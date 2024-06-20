using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoBinding;

public class ViewModel : IDisposable
{
    public Model Model { get; }
    public int Para1 { get; set; }
    public int Para2 { get; set; }
    public int Result { get; set; }
    public Action? UpdateView { get; set; }

    public ViewModel(Model model)
    {
        Model = model;
        Model.UpdateViewModel ??= new Action(UpdateViewModel);
    }

    public void Calculate()
    {
        SetParametersOnModel();
        Model.Calculate();
    }

    public void SetParametersOnModel()
    {
        Model.Para1 = Para1;
        Model.Para2 = Para2;
        Model.Result = Result;
    }

    public void UpdateViewModel()
    {
        Para1 = Model.Para1;
        Para2 = Model.Para2;
        Result = Model.Result;
        UpdateView?.Invoke();
    }

    private bool disposedValue;

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                UpdateView = null;
                Model.UpdateViewModel = null;
                Model.Dispose();
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