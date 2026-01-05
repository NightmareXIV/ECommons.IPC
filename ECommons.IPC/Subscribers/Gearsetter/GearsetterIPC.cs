using System;
using System.Collections.Generic;

namespace ECommons.IPC.Subscribers.Gearsetter
{
    using EzIpcManager;
    using FFXIVClientStructs.FFXIV.Client.Game;
    using FFXIVClientStructs.FFXIV.Client.UI.Misc;

    public sealed class GearsetterIPC : IPCBase
    {
        public GearsetterIPC()
        {
        }

        public GearsetterIPC(SafeWrapper wrapper) : base(wrapper)
        {
        }

        public override string InternalName { get; } = "Gearsetter";

        [EzIPC] public Func<byte, List<(uint ItemId, InventoryType? SourceInventory, byte? SourceInventorySlot, RaptureGearsetModule.GearsetItemIndex TargetSlot)>> GetRecommendationsForGearset { get; private set; }
    }
}
