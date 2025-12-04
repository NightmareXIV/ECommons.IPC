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
    public static void Init(IEnumerable<IPCProvider> providers, SafeWrapper wrapper = SafeWrapper.None)
    {
        PluginLog.Information($"Initializing IPC: {providers.Print()}");
        if(providers.Contains(IPCProvider.Lifestream))
        {
            EzIPC.Init(typeof(Lifestream), "Lifestream", wrapper);
            PluginLog.Information("Initialized Lifestream");
        }
    }

    public static void Init(SafeWrapper wrapper = SafeWrapper.None)
    {
        PluginLog.Information($"Called global init: {Enum.GetValues<IPCProvider>().Print()}");
        Init(Enum.GetValues<IPCProvider>(), wrapper);
    }
}