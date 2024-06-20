using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoBinding;

public class Model : IDisposable
{
    public int Para1 { get; set; }
    public int Para2 { get; set; }
    public int Result { get; set; }

    /// <summary>
    /// Actionは、Disposeの時にnullにしている。メモリーリークが発生するため。
    /// </summary>
    public Action? UpdateViewModel { get; set; }

    public Model()
    {
    }

    public void Calculate()
    {
        Result = Para1 + Para2;
        UpdateViewModel?.Invoke();
    }

    private bool disposedValue;

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                UpdateViewModel = null;
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