using ECommons.EzIpcManager;
using System;
using System.Collections.Generic;

namespace ECommons.IPC.Subscribers.BossMod;

using static BossModIPC.Delegates;

public sealed class BossModIPC : IPCBase
{
    public override string InternalName { get; } = "BossMod";

    public BossModIPC()
    {
    }

    public BossModIPC(SafeWrapper wrapper) : base(wrapper)
    {
    }


    public static class Delegates
    {
        public delegate bool AddTransientStrategyDelegate(string presetName, string moduleTypeName, string trackName, string value);
    }

    [EzIPC] public Func<uint, bool> HasModuleByDataId { get; private set; }
    [EzIPC("Presets.Get")] public Func<string, string?> Presets_Get { get; private set; }
    [EzIPC("Presets.Create")] public Func<string, bool, bool> Presets_Create { get; private set; }
    [EzIPC("Presets.Delete")] public Func<string, bool> Presets_Delete { get; private set; }
    [EzIPC("Presets.Activate")] public Func<string, bool> Presets_Activate { get; private set; }
    [EzIPC("Presets.Deactivate")] public Func<string, bool> Presets_Deactivate { get; private set; }
    [EzIPC("Presets.GetActive")] public Func<string> Presets_GetActive { get; private set; }
    [EzIPC("Presets.GetActiveList")] public Func<List<string>> Presets_GetActiveList { get; private set; }
    [EzIPC("Presets.SetActive")] public Func<string, bool> Presets_SetActive { get; private set; }
    [EzIPC("Presets.SetActiveList")] public Func<List<string>, bool> Presets_SetActiveList { get; private set; }
    [EzIPC("Presets.ClearActive")] public Func<bool> Presets_ClearActive { get; private set; }
    [EzIPC("Presets.GetForceDisabled")] public Func<bool> Presets_GetForceDisabled { get; private set; }
    [EzIPC("Presets.SetForceDisabled")] public Func<bool> Presets_SetForceDisabled { get; private set; }
    [EzIPC("Presets.AddTransientStrategy")] public Delegates.AddTransientStrategyDelegate Presets_AddTransientStrategy { get; private set; }
}