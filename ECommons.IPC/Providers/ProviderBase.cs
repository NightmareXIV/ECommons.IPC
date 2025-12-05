using ECommons.DalamudServices;
using ECommons.EzIpcManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommons.IPC.Providers;

public abstract class ProviderBase
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

    public ProviderBase()
    {
        EzIPC.Init(this, IPCPrefix, Wrapper ?? DefaultWrapper);
    }

    public ProviderBase(SafeWrapper wrapper)
    {
        EzIPC.Init(this, IPCPrefix, wrapper);
    }
}
