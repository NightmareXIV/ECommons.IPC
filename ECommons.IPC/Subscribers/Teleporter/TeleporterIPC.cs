using ECommons.EzIpcManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ECommons.IPC.Subscribers.Teleporter.TeleporterIPC.Delegates;

namespace ECommons.IPC.Subscribers.Teleporter;

public sealed class TeleporterIPC : IPCBase
{
    public TeleporterIPC()
    {
    }

    public TeleporterIPC(SafeWrapper wrapper) : base(wrapper)
    {
    }

    public override string IPCPrefix { get; } = null;
    public override string InternalName => "Teleporter";

    public static class Delegates
    {
        public delegate bool TeleportDelegate(uint aetheryteId, byte subAetheryteId);
    }

    [EzIPC("Teleport", false)] public TeleportDelegate Teleport{get; private set;}
}
