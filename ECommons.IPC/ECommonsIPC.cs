using ECommons.IPC.Subscribers.Artisan;
using ECommons.IPC.Subscribers.AutoRetainer;
using ECommons.IPC.Subscribers.BossMod;
using ECommons.IPC.Subscribers.Dropbox;
using ECommons.IPC.Subscribers.LifestreamIPC;
using ECommons.IPC.Subscribers.Questionable;
using ECommons.IPC.Subscribers.Teleporter;
using ECommons.IPC.Subscribers.TextAdvance;
using ECommons.IPC.Subscribers.Vnavmesh;
using ECommons.IPC.Subscribers.Weatherman;
using ECommons.IPC.Subscribers.WrathCombo;

namespace ECommons.IPC;

using Subscribers.AutoDuty;
using Subscribers.Gearsetter;
using Subscribers.PandorasBox;
using Subscribers.Stylist;
using Subscribers.YesAlready;

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
    public static BossModIPC BossMod { get { field ??= new(); return field; } }
    public static AutoDutyIPC AutoDuty { get { field ??= new(); return field; } }
    public static YesAlreadyIPC YesAlready { get { field ??= new(); return field; } }
    public static StylistIPC Stylist { get { field ??= new(); return field; } }
    public static PandorasBoxIPC PandorasBox { get { field ??= new(); return field; } }
    public static GearsetterIPC Gearsetter { get { field ??= new(); return field; } }
}