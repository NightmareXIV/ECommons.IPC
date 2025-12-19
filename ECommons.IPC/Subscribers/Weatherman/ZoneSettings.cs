using Lumina.Excel.Sheets;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommons.IPC.Subscribers.Weatherman;

public class ZoneSettings
{
    public ushort ZoneId;
    public string ZoneName;
    public List<WeathermanWeather> SupportedWeathers;
    public bool WeatherControl = false;
    public int TimeFlow = 0;
    public int FixedTime = 0;
    public TerritoryType terr;
    public int Music = 0;
}
