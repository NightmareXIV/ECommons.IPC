using System;
using System.Collections.Generic;
using System.Text;

namespace ECommons.IPC.Subscribers.Weatherman;

public class WeathermanWeather
{
    public byte Id;
    public bool Selected;
    public bool IsNormal;
    public WeathermanWeather(byte id, bool selected, bool normal)
    {
        Id = id;
        Selected = selected;
        IsNormal = normal;
    }
}

