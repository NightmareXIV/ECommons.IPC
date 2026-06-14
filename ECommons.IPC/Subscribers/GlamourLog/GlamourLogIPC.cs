using System;
using System.Collections.Generic;

namespace ECommons.IPC.Subscribers.GlamourLog
{
    using EzIpcManager;
    using FFXIVClientStructs.FFXIV.Client.Game;
    using FFXIVClientStructs.FFXIV.Client.UI.Misc;

    public sealed class GlamourLogIPC : IPCBase
    {
        public GlamourLogIPC()
        {
        }

        public GlamourLogIPC(SafeWrapper wrapper) : base(wrapper)
        {
        }

        public override string InternalName { get; } = "GlamourLog";

        [EzIPC] public Func<List<uint>>       GetArmoireItemIds   { get; private set; }
        [EzIPC] public Func<List<uint>>       GetDresserItemIds   { get; private set; }
        [EzIPC] public Func<uint, List<uint>> GetItemsFromContent { get; private set; }
        [EzIPC] public Func<uint, bool>       IsItemInArmoire     { get; private set; }
        [EzIPC] public Func<uint, bool>       IsItemInDresser     { get; private set; }
        [EzIPC] public Func<uint, bool>       IsItemOwned         { get; private set; }
        [EzIPC] public Func<uint, bool>       IsSetComplete       { get; private set; }
    }
}