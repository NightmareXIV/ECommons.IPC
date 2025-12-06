using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ECommons.IPC.Subscribers.LifestreamIPC;

public class HousePathData
{
    [Obfuscation] public int ResidentialDistrict;
    [Obfuscation] public int Ward;
    [Obfuscation] public int Plot;
    [Obfuscation] public List<Vector3> PathToEntrance = [];
    [Obfuscation] public List<Vector3> PathToWorkshop = [];
    [Obfuscation] public bool IsPrivate;
    [Obfuscation] public ulong CID;
    [Obfuscation] public bool EnableHouseEnterModeOverride = false;
    [Obfuscation] public int EnterModeOverride = 0;
}
