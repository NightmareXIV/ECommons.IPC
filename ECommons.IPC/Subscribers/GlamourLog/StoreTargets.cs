using System;

namespace ECommons.IPC.Subscribers.GlamourLog;

[Flags]
public enum StoreTargets
{
    None = 0,
    Armoire = 1 << 0,
    Dresser = 1 << 1,
    All = Armoire | Dresser,
}