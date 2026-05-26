using ECommons.EzIpcManager;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommons.IPC.Subscribers.AetherBags;

public class AetherBagsIPC : IPCBase
{
    public AetherBagsIPC()
    {
    }

    public AetherBagsIPC(SafeWrapper wrapper) : base(wrapper)
    {
    }

    public override string InternalName { get; } = "AetherBags";


    [EzIPC("IsInventoryOpen")]
    public Func<bool> IsInventoryOpen { get; private set; }

    [EzIPC("GetVisibleItemIds")]
    public Func<List<uint>> GetVisibleItemIds { get; private set; }

    [EzIPC("GetItemsInCategory")]
    public Func<uint, List<uint>> GetItemsInCategory { get; private set; }

    [EzIPC("IsItemVisible")]
    public Func<uint, bool> IsItemVisible { get; private set; }

    [EzIPC("GetSearchFilter")]
    public Func<string> GetSearchFilter { get; private set; }

    [EzIPC("GetRegisteredSources")]
    public Func<List<string>> GetRegisteredSources { get; private set; }

    [EzIPC("GetConfigurationJson")]
    public Func<string> GetConfigurationJson { get; private set; }

    [EzIPC("SetConfigurationJson")]
    public Func<string, bool> SetConfigurationJson { get; private set; }

    [EzIPC("GetConfigProperty")]
    public Func<string, string> GetConfigProperty { get; private set; }

    [EzIPC("SetConfigProperty")]
    public Func<string, string, bool> SetConfigProperty { get; private set; }

    [EzIPC("AcquireVanillaInventoryBypass")]
    public Func<string, int, string> AcquireVanillaInventoryBypass { get; private set; }

    [EzIPC("ReleaseVanillaInventoryBypass")]
    public Func<string, bool> ReleaseVanillaInventoryBypass { get; private set; }

    [EzIPC("IsVanillaInventoryBypassActive")]
    public Func<bool> IsVanillaInventoryBypassActive { get; private set; }

    [EzIPC("GetVanillaInventoryBypassStatus")]
    public Func<string> GetVanillaInventoryBypassStatus { get; private set; }
}
