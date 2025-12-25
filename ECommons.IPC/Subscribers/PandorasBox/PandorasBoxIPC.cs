using System;
using System.Collections.Generic;
using System.Text;

namespace ECommons.IPC.Subscribers.PandorasBox;

using EzIpcManager;

public sealed class PandorasBoxIPC : IPCBase
{
    public PandorasBoxIPC()
    {
    }

    public PandorasBoxIPC(SafeWrapper wrapper) : base(wrapper)
    {
    }

    public override string InternalName { get; } = "PandorasBox";

    [EzIPC] public Action<string, int> PauseFeature { get; private set; }
    [EzIPC] public Func<string, bool?> GetFeatureEnabled { get; private set; }
    [EzIPC] public Func<string, bool?> GetFeatureEnabledInternal { get; private set; }
    [EzIPC] public Action<string, bool> SetFeatureEnabled { get; private set; }
    [EzIPC] public Action SetFeatureEnabledInternal { get; private set; }
    [EzIPC] public Action<string, string, bool?> SetConfigEnabled { get; private set; }
}