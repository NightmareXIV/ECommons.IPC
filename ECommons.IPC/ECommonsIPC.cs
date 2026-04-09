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

using ECommons.IPC.Subscribers.AllaganTools;
using ECommons.IPC.Subscribers.CashFlow;
using Subscribers.AutoDuty;
using Subscribers.Gearsetter;
using Subscribers.PandorasBox;
using Subscribers.RotationSolverReborn;
using Subscribers.Stylist;
using Subscribers.YesAlready;

public static class ECommonsIPC
{
    public static LifestreamIPC Lifestream => field ??= new();
    public static TeleporterIPC Teleporter => field ??= new();
    public static ArtisanIPC Artisan => field ??= new();
    public static AutoRetainerIPC AutoRetainer => field ??= new();
    public static DropboxIPC Dropbox => field ??= new();
    public static QuestionableIPC Questionable => field ??= new();
    public static TextAdvanceIPC TextAdvance => field ??= new();
    public static VnavmeshIPC Vnavmesh => field ??= new();
    public static WrathComboIPC WrathCombo => field ??= new();
    public static WeathermanIPC Weatherman => field ??= new();
    public static BossModIPC BossMod => field ??= new();
    public static AutoDutyIPC AutoDuty => field ??= new();
    public static YesAlreadyIPC YesAlready => field ??= new();
    public static StylistIPC Stylist => field ??= new();
    public static PandorasBoxIPC PandorasBox => field ??= new();
    public static GearsetterIPC Gearsetter => field ??= new();
    public static RotationSolverRebornIPC RotationSolverReborn => field ??= new();
    public static CashFlowIPC CashFlow => field ??= new();
    public static AllaganToolsIPC AllaganTools => field ??= new();
}