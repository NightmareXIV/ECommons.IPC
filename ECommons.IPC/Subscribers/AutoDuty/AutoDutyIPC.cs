using System;

namespace ECommons.IPC.Subscribers.AutoDuty;

using EzIpcManager;
using static AutoDutyIPC.Delegates;

public sealed class AutoDutyIPC : IPCBase
{
    public AutoDutyIPC()
    {
    }

    public AutoDutyIPC(SafeWrapper wrapper) : base(wrapper)
    {
    }

    public override string InternalName { get; } = "AutoDuty";

    public static class Delegates
    {
        public delegate void RunDelegate(uint territoryType, int loops = 0, bool bareMode = false);
    }

    /**
     * @param config The name of the config to get.
     */
    [EzIPC("GetConfig")] public Func<string, string> GetConfig { get; private set; }

    [EzIPC("SetConfig")] private Action<string, object> SetConfig { get; set; }

    public void SetConfigValue(string config, string value) =>
        this.SetConfig(config, value);
    public void SetConfigValue(string config, string[] values) =>
        this.SetConfig(config, values);

    /**
     * @param territoryType The territory type ID to run the path in. 0 to use current territory.<br/>
     * @param loops Number of loops to run. Use 0 to use the current loops already set.<br/>
     * @param bareMode Only run the dungeon and skip any pre-, between-, and post-dungeon actions.
     */
    [EzIPC("Run")] public RunDelegate Run { get; private set; }
    /**
     * Starts navigating the current path.<br/>
     * @param startFromZero Whether to start the path from the beginning or stay at current index.
     */
    [EzIPC("Start")] public Action<bool> Start { get; private set; }
    [EzIPC("Stop")] public Action Stop { get; private set; }
    [EzIPC("IsNavigating")] public Func<bool> IsNavigating { get; private set; }
    [EzIPC("IsLooping")] public Func<bool> IsLooping { get; private set; }
    [EzIPC("IsStopped")] public Func<bool> IsStopped { get; private set; }
    /**
     * @param territoryType The territory type ID to check.
     */
    [EzIPC("ContentHasPath")] public Func<uint, bool> ContentHasPath { get; private set; }
}