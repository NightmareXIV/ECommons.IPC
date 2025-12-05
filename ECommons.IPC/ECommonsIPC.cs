using ECommons.EzIpcManager;
using ECommons.IPC.Providers.LifestreamIPC;
using ECommons.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

namespace ECommons.IPC;

public static class ECommonsIPC
{
    public static LifestreamIPC Lifestream { get { field ??= new(); return field; } }
}