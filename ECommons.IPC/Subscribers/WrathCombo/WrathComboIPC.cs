using ECommons.EzIpcManager;
using FFXIVClientStructs.FFXIV.Client.Game;
using System;
using static ECommons.IPC.Subscribers.WrathCombo.WrathComboIPC.Delegates;

namespace ECommons.IPC.Subscribers.WrathCombo;

[Obsolete("All WrathCombo's IPC functions are available via WrathCombo.IPC library now. Install from https://github.com/PunishXIV/WrathCombo.API")]
public sealed class WrathComboIPC : IPCBase
{
    public WrathComboIPC()
    {
    }

    public WrathComboIPC(SafeWrapper wrapper) : base(wrapper)
    {
    }

    public override string InternalName { get; } = "WrathCombo";

    public static class Delegates
    {
        public delegate void RequestBlacklist(ActionType actionType, uint actionId, int timeMsFromNow);
        public delegate void ResetBlacklist(ActionType actionType, uint actionId);
        public delegate float GetArtificialCooldown(ActionType actionType, uint actionId);
        public delegate void RequestActionUse(ActionType actionType, uint actionId, int timeMsFromNow, bool? isGcd);
        public delegate void ResetRequest(ActionType actionType, uint actionId);
        public delegate bool CanWeave(float? estimatedWeaveTime);
        public delegate bool CanDelayedWeave(float? weaveStart, float? weaveEnd);
        public delegate bool ActionReady(uint actionId, bool? recastCheck, bool? castCheck);
    }

    /// <summary>
    /// ActionType,<br />
    /// action ID<br />
    /// time in miliseconds for how long to blacklist
    /// </summary>
    [EzIPC("ActionRequest.RequestBlacklist")] public RequestBlacklist RequestBlacklist { get; private set; }
    /// <summary>
    /// ActionType,<br />
    /// action ID
    /// </summary>
    [EzIPC("ActionRequest.ResetBlacklist")] public ResetBlacklist ResetBlacklist { get; private set; }
    [EzIPC("ActionRequest.ResetAllBlacklist")] public Action ResetAllBlacklist { get; private set; }
    /// <summary>
    /// ActionType, <br />
    /// action ID, <br />
    /// remaining cooldown
    /// </summary>
    [EzIPC("ActionRequest.GetArtificialCooldown")] public GetArtificialCooldown GetArtificialCooldown { get; private set; }
    /// <summary>
    /// ActionType, <br />
    /// action ID, <br />
    /// time in miliseconds for how long request is valid, <br />
    /// whether to use action as gcd, where true is use only at GCD time, false use only at OGCD time (no clipping), and null - use asap (with clipping)
    /// </summary>
    [EzIPC("ActionRequest.RequestActionUse")] public RequestActionUse RequestActionUse { get; private set; }
    /// <summary>
    /// ActionType,<br />
    /// action ID
    /// </summary>
    [EzIPC("ActionRequest.ResetRequest")] public ResetRequest ResetRequest { get; private set; }
    [EzIPC("ActionRequest.ResetAllRequests")] public Action ResetAllRequests { get; private set; }

    [EzIPC("CanWeave")] public CanWeave CanWeave { get; private set; }
    [EzIPC("CanDelayedWeave")] public CanDelayedWeave CanDelayedWeave { get; private set; }
    [EzIPC("ActionReady")] public ActionReady ActionReady { get; private set; }
}
