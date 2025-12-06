using ECommons.EzIpcManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ECommons.IPC.Subscribers.TextAdvance.TextAdvanceIPC.Delegates;

namespace ECommons.IPC.Subscribers.TextAdvance;

public sealed class TextAdvanceIPC : IPCBase
{
    public TextAdvanceIPC()
    {
    }

    public TextAdvanceIPC(SafeWrapper wrapper) : base(wrapper)
    {
    }

    public override string IPCPrefix { get; } = "TextAdvance";

    public static class Delegates
    {
        public delegate void EnqueueMoveToPoint(MoveData data, float stopRadius);
        public delegate bool EnableExternalControl(string requestingPluginName, ExternalTerritoryConfig config);
        public delegate bool DisableExternalControl(string requestingPluginName);
    }

    [EzIPC("EnqueueMoveTo2DPoint")] public EnqueueMoveToPoint EnqueueMoveTo2DPoint{get; private set;}
    [EzIPC("EnqueueMoveTo3DPoint")] public EnqueueMoveToPoint EnqueueMoveTo3DPoint{get; private set;}
    [EzIPC("Stop")] public Action Stop{get; private set;}
    [EzIPC("IsBusy")] public Func<bool> IsBusy{get; private set;}
    /// <summary>
    /// Enables external control of TextAdvance. 
    /// First argument = your plugin's name. 
    /// Second argument is options. Copy ExternalTerritoryConfig to your plugin. Configure it as you wish: set "null" values to features that you want to keep as configured by user. Set "true" or "false" to forcefully enable or disable feature. 
    /// Returns whether external control successfully enabled or not. When already in external control, it will succeed if called again if plugin name matches with one that already has control and new settings will take effect, otherwise it will fail.
    /// External control completely disables territory-specific settings.
    /// </summary>
    [EzIPC("EnableExternalControl")] public EnableExternalControl EnableExternalControl{get; private set;}
    /// <summary>
    /// Disables external control. Will fail if external control is obtained from other plugin.
    /// </summary>
    [EzIPC("DisableExternalControl")] public DisableExternalControl DisableExternalControl{get; private set;}
    /// <summary>
    /// Indicates whether external control is enabled.
    /// </summary>
    [EzIPC("IsInExternalControl")] public Func<bool> IsInExternalControl{get; private set;}

    /// <summary>
    /// Indicates whether user has plugin enabled. Respects territory configuration. If in external control, will return true.
    /// </summary>
    [EzIPC("IsEnabled")] public Func<bool> IsEnabled{get; private set;}
    /// <summary>
    /// Indicates whether plugin is paused by other plugin.
    /// </summary>
    [EzIPC("IsPaused")] public Func<bool> IsPaused{get; private set;}

    /// <summary>
    /// All the functions below return currently configured plugin state with respect for territory config and external control. 
    /// However, it does not includes IsEnabled or IsPaused check. A complete check whether TextAdvance is currently ready to process appropriate event will look like: <br></br>
    /// IsEnabled() &amp{get; private set;}&amp{get; private set;} !IsPaused() &amp{get; private set;}&amp{get; private set;} GetEnableQuestAccept()
    /// </summary>
    [EzIPC("GetEnableQuestAccept")] public Func<bool> GetEnableQuestAccept{get; private set;}
    /// <inheritdoc cref="TextAdvanceIPC.GetEnableQuestAccept"/>
    [EzIPC("GetEnableQuestComplete")] public Func<bool> GetEnableQuestComplete{get; private set;}
    /// <inheritdoc cref="TextAdvanceIPC.GetEnableQuestAccept"/>
    [EzIPC("GetEnableRewardPick")] public Func<bool> GetEnableRewardPick{get; private set;}
    /// <inheritdoc cref="TextAdvanceIPC.GetEnableQuestAccept"/>
    [EzIPC("GetEnableCutsceneEsc")] public Func<bool> GetEnableCutsceneEsc{get; private set;}
    /// <inheritdoc cref="TextAdvanceIPC.GetEnableQuestAccept"/>
    [EzIPC("GetEnableCutsceneSkipConfirm")] public Func<bool> GetEnableCutsceneSkipConfirm{get; private set;}
    /// <inheritdoc cref="TextAdvanceIPC.GetEnableQuestAccept"/>
    [EzIPC("GetEnableRequestHandin")] public Func<bool> GetEnableRequestHandin{get; private set;}
    /// <inheritdoc cref="TextAdvanceIPC.GetEnableQuestAccept"/>
    [EzIPC("GetEnableRequestFill")] public Func<bool> GetEnableRequestFill{get; private set;}
    /// <inheritdoc cref="TextAdvanceIPC.GetEnableQuestAccept"/>
    [EzIPC("GetEnableTalkSkip")] public Func<bool> GetEnableTalkSkip{get; private set;}
    /// <inheritdoc cref="TextAdvanceIPC.GetEnableQuestAccept"/>
    [EzIPC("GetEnableAutoInteract")] public Func<bool> GetEnableAutoInteract{get; private set;}
}
