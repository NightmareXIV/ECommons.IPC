using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ECommons.IPC.Subscribers.Questionable;

public sealed class StepData
{
    [Obfuscation] public string QuestId;
    [Obfuscation] public byte Sequence;
    [Obfuscation] public int Step;
    [Obfuscation] public string InteractionType;
    [Obfuscation] public Vector3? Position;
    [Obfuscation] public ushort TerritoryId;
}
