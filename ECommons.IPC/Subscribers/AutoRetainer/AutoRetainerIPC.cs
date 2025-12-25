using ECommons.EzIpcManager;
using System;

namespace ECommons.IPC.Subscribers.AutoRetainer;

public sealed class AutoRetainerIPC : IPCBase
{
    public AutoRetainerIPC()
    {
    }

    public AutoRetainerIPC(SafeWrapper wrapper) : base(wrapper)
    {
    }

    public override string InternalName { get; } = "AutoRetainer";

    [EzIPC("AutoRetainer.GC.EnqueueInitiation", false)] public Action EnqueueInitiation { get; private set; }
    [EzIPC("PluginState.AbortAllTasks")] public Action AbortAllTasks { get; private set; }
    [EzIPC("PluginState.DisableAllFunctions")] public Action DisableAllFunctions { get; private set; }
    [EzIPC("PluginState.EnableMultiMode")] public Action EnableMultiMode { get; private set; }
    [EzIPC("PluginState.IsBusy")] public Func<bool> IsBusy { get; private set; }
    [EzIPC("PluginState.GetInventoryFreeSlotCount")] public Func<int> GetInventoryFreeSlotCount { get; private set; }
    [EzIPC("PluginState.EnqueueHET")] public Action<bool, bool> EnqueueHET { get; private set; }
    [EzIPC("PluginState.IsItemProtected")] public Func<uint, bool> IsItemProtected { get; private set; }
    [EzIPC("PluginState.GetMultiModeStatus")] public Func<bool> GetMultiModeStatus { get; private set; }
    [EzIPC("PluginState.GetClosestRetainerVentureSecondsRemaining")] public Func<ulong, long?> GetClosestRetainerVentureSecondsRemaining { get; private set; }
    [EzIPC("PluginState.AreAnyRetainersAvailableForCurrentChara")] public Func<bool> AreAnyRetainersAvailableForCurrentChara { get; private set; }
}