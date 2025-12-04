using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ECommons.IPC.Providers.Lifestream;

public enum PropertyType
{
    [Obfuscation] Auto,
    [Obfuscation] Home,
    [Obfuscation] FC,
    [Obfuscation] Apartment,
    [Obfuscation] Inn,
    [Obfuscation] Shared_Estate
}
