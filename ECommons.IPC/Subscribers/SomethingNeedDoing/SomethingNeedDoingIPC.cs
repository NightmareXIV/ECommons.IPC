using System;

namespace ECommons.IPC.Subscribers.SomethingNeedDoing;

using EzIpcManager;

public sealed class SomethingNeedDoingIPC : IPCBase
{
    public SomethingNeedDoingIPC()
    {
    }

    public SomethingNeedDoingIPC(SafeWrapper wrapper) : base(wrapper)
    {
    }

    public override string InternalName { get; } = "SomethingNeedDoing";

    [EzIPC] public Func<bool> IsAnyMacroRunning { get; private set; }
}