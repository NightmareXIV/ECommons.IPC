using ECommons.EzIpcManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommons.IPC.Subscribers.Artisan;

public sealed class ArtisanIPC : IPCBase
{
    public ArtisanIPC()
    {
    }

    public ArtisanIPC(SafeWrapper wrapper) : base(wrapper)
    {
    }

    public override string IPCPrefix { get; } = "Artisan";

    [EzIPC("GetEnduranceStatus")] public  Func<bool> GetEnduranceStatus{get; private set;}
    [EzIPC("SetEnduranceStatus")] public  Action<bool> SetEnduranceStatus{get; private set;}

    [EzIPC("IsListRunning")] public  Func<bool> IsListRunning{get; private set;}
    [EzIPC("IsListPaused")] public  Func<bool> IsListPaused{get; private set;}
    [EzIPC("SetListPause")] public  Action<bool> SetListPause{get; private set;}

    [EzIPC("GetStopRequest")] public  Func<bool> GetStopRequest{get; private set;}
    [EzIPC("SetStopRequest")] public  Action<bool> SetStopRequest{get; private set;}
}
