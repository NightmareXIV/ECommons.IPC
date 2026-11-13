using Dalamud.Game.ClientState.Objects.SubKinds;
using ECommons.EzIpcManager;
using System;
using System.Collections.Generic;
using System.Text;
using static ECommons.IPC.Subscribers.Splatoon.SplatoonIPC.Delegates;

namespace ECommons.IPC.Subscribers.Splatoon;

public class SplatoonIPC : IPCBase
{
    public SplatoonIPC()
    {
    }

    public SplatoonIPC(SafeWrapper wrapper) : base(wrapper)
    {
    }

    public static class Delegates
    {
        public delegate void DisplayAttentionWindowLineAction(string title, Action text);
        public delegate void DisplayAttentionWindowLineText(string title, string text);
    }

    public override string InternalName { get; } = "Splatoon";

    [EzIPC("GetRoleOf")] public Func<IPlayerCharacter, RolePosition> GetRoleOf;
    [EzIPC("DisplayAttentionWindowLineAction")] public DisplayAttentionWindowLineAction DisplayAttentionWindowLineAction;
    [EzIPC("DisplayAttentionWindowLineText")] public DisplayAttentionWindowLineText DisplayAttentionWindowLineText;
}
