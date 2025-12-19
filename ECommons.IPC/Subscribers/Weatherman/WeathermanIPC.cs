using ECommons.EzIpcManager;
using Lumina.Excel.Sheets;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommons.IPC.Subscribers.Weatherman;

public class WeathermanIPC : IPCBase
{
    public override string InternalName { get; } = "Weatherman";

    [EzIPC]
    public Func<bool> IsPluginEnabled;

    [EzIPC]
    public Func<bool> IsTimeCustom;

    [EzIPC]
    public Func<bool> IsWeatherCustom;

    [EzIPC]
    public Func<uint, bool> SetTime;

    [EzIPC]
    public Func<byte, bool> SetWeather;

    [EzIPC]
    public Func<uint[][]> DataGetZoneToWeatherIndexMap;

    [EzIPC]
    public Func<Dictionary<ushort, TerritoryType>> DataGetZones;

    [EzIPC]
    public Func<Dictionary<ushort, (List<byte> WeatherList, string EnvbFile)>> DataGetWeatherList;

    [EzIPC]
    public Func<HashSet<ushort>> DataGetWeatherAllowedZones;

    [EzIPC]
    public Func<HashSet<ushort>> DataGetTimeAllowedZones;

    [EzIPC]
    public Func<Dictionary<byte, string>> DataGetWeathers;

    [EzIPC]
    public Func<Dictionary<ushort, ZoneSettings>> DataGetZoneSettings;
}
