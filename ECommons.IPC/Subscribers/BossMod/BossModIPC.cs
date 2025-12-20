using ECommons.EzIpcManager;
using System;
using System.Collections.Generic;

namespace ECommons.IPC.Subscribers.BossMod;

public sealed class BossModIPC : IPCBase
{
    public override string InternalName { get; } = "BossMod";

    public override string IPCPrefix => base.IPCPrefix;

    [EzIPC("Presets.Activate")] public Func<string, bool> Presets_Activate { get; private set; }
    [EzIPC("Presets.Deactivate")] public Func<string, bool> Presets_Deactivate { get; private set; }
    [EzIPC("Presets.GetActiveList")] public Func<List<string>> Presets_GetActiveList { get; private set; }
    [EzIPC("Presets.SetActiveList")] public Func<List<string>, bool> Presets_SetActiveList { get; private set; }
    [EzIPC("Presets.ClearActive")] public Func<bool> Presets_ClearActive { get; private set; }
}
