using ECommons.EzIpcManager;
using ECommons.IPC.Subscribers.Artisan;
using ECommons.IPC.Subscribers.AutoRetainer;
using ECommons.IPC.Subscribers.Dropbox;
using ECommons.IPC.Subscribers.LifestreamIPC;
using ECommons.IPC.Subscribers.Questionable;
using ECommons.IPC.Subscribers.Teleporter;
using ECommons.IPC.Subscribers.TextAdvance;
using ECommons.IPC.Subscribers.Vnavmesh;
using ECommons.IPC.Subscribers.Weatherman;
using ECommons.IPC.Subscribers.WrathCombo;
using ECommons.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

namespace ECommons.IPC;

public static class ECommonsIPC
{
    public static LifestreamIPC Lifestream { get { field ??= new(); return field; } }
    public static TeleporterIPC Teleporter { get { field ??= new(); return field; } }
    public static ArtisanIPC Artisan { get { field ??= new(); return field; } }
    public static AutoRetainerIPC AutoRetainer { get { field ??= new(); return field; } }
    public static DropboxIPC Dropbox { get { field ??= new(); return field; } }
    public static QuestionableIPC Questionable { get { field ??= new(); return field; } }
    public static TextAdvanceIPC TextAdvance { get { field ??= new(); return field; } }
    public static VnavmeshIPC Vnavmesh { get { field ??= new(); return field; } }
    public static WrathComboIPC WrathCombo { get { field ??= new(); return field; } }
    public static WeathermanIPC Weatherman { get { field ??= new(); return field; } }
}