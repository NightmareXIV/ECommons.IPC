using System;

namespace ECommons.IPC.Subscribers.YesAlready;

using EzIpcManager;

public sealed class YesAlreadyIPC : IPCBase
{
    public YesAlreadyIPC()
    {
    }

    public YesAlreadyIPC(SafeWrapper wrapper) : base(wrapper)
    {
    }

    public override string InternalName { get; } = "YesAlready";

    [EzIPC("SetPluginEnabled")] public Action<bool> SetPluginEnabled { get; private set; }
    [EzIPC("IsPluginEnabled")] public Func<bool> IsPluginEnabled { get; private set; }
}