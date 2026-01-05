using System;

namespace ECommons.IPC.Subscribers.Stylist;

using EzIpcManager;

public sealed class StylistIPC : IPCBase
{
    public StylistIPC()
    {
    }

    public StylistIPC(SafeWrapper wrapper) : base(wrapper)
    {
    }

    public override string InternalName { get; } = "Stylist";

    public static class Delegates
    {
        public delegate void UpdateCurrentGearsetExDelegate(bool? moveItemsFromInventory, bool? shouldEquip);
    }

    [EzIPC] public Delegates.UpdateCurrentGearsetExDelegate UpdateCurrentGearsetEx { get; private set; }
    [EzIPC] public Func<bool> IsBusy { get; private set; }
}