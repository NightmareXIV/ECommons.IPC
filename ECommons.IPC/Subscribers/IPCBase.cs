using ECommons.DalamudServices;
using ECommons.EzIpcManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommons.IPC.Subscribers;

public abstract class IPCBase
{
    public static SafeWrapper DefaultWrapper { get; set; } = SafeWrapper.None;
    public abstract string IPCPrefix { get; }
    public virtual string InternalName => IPCPrefix;
    public virtual SafeWrapper? Wrapper => null;
    public bool Available
    {
        get
        {
            return Svc.PluginInterface.InstalledPlugins.Any(x => x.InternalName == InternalName && x.IsLoaded);
        }
    }

    public IPCBase()
    {
        EzIPC.Init(this, IPCPrefix, Wrapper ?? DefaultWrapper);
    }

    public IPCBase(SafeWrapper wrapper)
    {
        EzIPC.Init(this, IPCPrefix, wrapper);
    }
}
