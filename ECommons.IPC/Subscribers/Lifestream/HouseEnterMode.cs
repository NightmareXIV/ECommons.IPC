using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ECommons.IPC.Subscribers.LifestreamIPC;

public enum HouseEnterMode
{
    [Obfuscation] None,
    [Obfuscation] Walk_to_door,
    [Obfuscation] Enter_house
}
