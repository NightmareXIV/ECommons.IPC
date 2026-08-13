using System;
using System.Collections.Generic;
using ECommons.EzIpcManager;
using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.UI.Misc;

namespace ECommons.IPC.Subscribers.GlamourLog;

public sealed class GlamourLogIPC : IPCBase
{
    public GlamourLogIPC()
    {
    }

    public GlamourLogIPC(SafeWrapper wrapper) : base(wrapper)
    {
    }

    public override string InternalName { get; } = "GlamourLog";

    [EzIPC] public Func<List<uint>> GetArmoireItemIds { get; private set; }
    [EzIPC] public Func<List<uint>> GetDresserItemIds { get; private set; }
    [EzIPC] public Func<uint, List<uint>> GetItemsFromContent { get; private set; }
    [EzIPC] public Func<uint, bool> IsItemInArmoire { get; private set; }
    [EzIPC] public Func<uint, bool> IsItemInDresser { get; private set; }
    [EzIPC] public Func<uint, bool> IsItemOwned { get; private set; }
    [EzIPC] public Func<uint, bool> IsSetComplete { get; private set; }
    [EzIPC] public Func<uint, bool> IsContentComplete { get; private set; }
    [EzIPC] public Func<bool> EntrustAll { get; private set; }
    [EzIPC] public Func<bool> IsBusy { get; private set; }
}