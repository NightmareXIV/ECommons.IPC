using ECommons.EzIpcManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommons.IPC.Subscribers.Dropbox;

public sealed class DropboxIPC : IPCBase
{
    public DropboxIPC()
    {
    }

    public DropboxIPC(SafeWrapper wrapper) : base(wrapper)
    {
    }

    public override string IPCPrefix { get; } = "Dropbox";
    [EzIPC("IsBusy")] public Func<bool> IsBusy { get; private set;  }
}
