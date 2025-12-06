using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ECommons.IPC.Subscribers.TextAdvance;

public class MoveData
{
    [Obfuscation] public Vector3 Position;
    [Obfuscation] public uint DataID;
    [Obfuscation] public bool NoInteract;
    [Obfuscation] public bool? Mount = null;
    [Obfuscation] public bool? Fly = null;
}

public class ExternalTerritoryConfig
{
    [Obfuscation] public bool? EnableQuestAccept = null;
    [Obfuscation] public bool? EnableQuestComplete = null;
    [Obfuscation] public bool? EnableRewardPick = null;
    [Obfuscation] public bool? EnableRequestHandin = null;
    [Obfuscation] public bool? EnableCutsceneEsc = null;
    [Obfuscation] public bool? EnableCutsceneSkipConfirm = null;
    [Obfuscation] public bool? EnableTalkSkip = null;
    [Obfuscation] public bool? EnableRequestFill = null;
    [Obfuscation] public bool? EnableAutoInteract = null;
}
