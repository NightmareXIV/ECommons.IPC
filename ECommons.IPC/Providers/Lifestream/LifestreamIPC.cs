using ECommons.EzIpcManager;
using System;
using System.Collections.Generic;
using System.Numerics;
using static ECommons.IPC.Providers.LifestreamIPC.LifestreamIPC.Delegates;

namespace ECommons.IPC.Providers.LifestreamIPC;

public sealed class LifestreamIPC : ProviderBase
{
    public LifestreamIPC()
    {
    }

    public LifestreamIPC(SafeWrapper wrapper) : base(wrapper)
    {
    }

    public override string IPCPrefix { get; } = "Lifestream";

    public static class Delegates
    {
        public delegate bool TeleportDelegate(uint aetheryteId, byte subAetheryteId);
        public delegate void EnqueuePropertyShortcutDelegate(PropertyType propertyType, HouseEnterMode? houseEnterMode);
        public delegate void MoveToWorkshopDelegate();
    }

    [EzIPC("Teleport")]
    public TeleportDelegate Teleport { get; private set; }

    [EzIPC("TeleportToHome")]
    public Func<bool> TeleportToHome { get; private set; }

    [EzIPC("TeleportToFC")]
    public Func<bool> TeleportToFC { get; private set; }

    [EzIPC("TeleportToApartment")]
    public Func<bool> TeleportToApartment { get; private set; }

    [EzIPC("IsBusy")]
    public Func<bool> IsBusy { get; private set; }

    /// <summary>
    /// city aetheryte id
    /// </summary>
    [EzIPC("GetResidentialTerritory")]
    public Func<int, uint> GetResidentialTerritory { get; private set; }

    /// <summary>
    /// territory, plot
    /// </summary>
    [EzIPC("GetPlotEntrance")]
    public Func<uint, int, Vector3?> GetPlotEntrance { get; private set; }

    /// <summary>
    /// type(home=1, fc=2, apartment=3), mode(enter house=2)
    /// </summary>
    [EzIPC("EnqueuePropertyShortcut")]
    public EnqueuePropertyShortcutDelegate EnqueuePropertyShortcut { get; private set; }

    [EzIPC("GetCurrentPlotInfo")]
    public Func<(int Kind, int Ward, int Plot)?> GetCurrentPlotInfo { get; private set; }

    [EzIPC("EnqueueInnShortcut")]
    public Action<int?> EnqueueInnShortcut { get; private set; }

    [EzIPC("HasApartment")]
    public Func<bool?> HasApartment { get; private set; }

    [EzIPC("EnterApartment")]
    public Action<bool> EnterApartment { get; private set; }

    [EzIPC("HasPrivateHouse")]
    public Func<bool?> HasPrivateHouse { get; private set; }

    [EzIPC("HasFreeCompanyHouse")]
    public Func<bool?> HasFreeCompanyHouse { get; private set; }

    [EzIPC("AethernetTeleport")]
    public Func<string, bool> AethernetTeleport { get; private set; }

    [EzIPC("Move")]
    public Action<List<Vector3>> Move { get; private set; }

    [EzIPC("CanVisitSameDC")]
    public Func<string, bool> CanVisitSameDC { get; private set; }

    [EzIPC("CanVisitCrossDC")]
    public Func<string, bool> CanVisitCrossDC { get; private set; }

    /// <summary>
    /// (string w, bool isDcTransfer, string secondaryTeleport, bool noSecondaryTeleport, int? gateway, bool? doNotify, bool? returnToGateway)
    /// </summary>
    [EzIPC("TPAndChangeWorld")]
    public Action<string, bool, string, bool, WorldChangeAetheryte?, bool?, bool?> TPAndChangeWorld { get; private set; }

    [EzIPC("EnqueueLocalInnShortcut")]
    public Action<int?> EnqueueLocalInnShortcut { get; private set; }

    [EzIPC("GetHousePathData")]
    public Func<ulong, (HousePathData Private, HousePathData FC)> GetHousePathData { get; private set; }

    [EzIPC("GetSharedHousePathData")]
    public Func<HousePathData> GetSharedHousePathData { get; private set; }

    [EzIPC("HasSharedEstate")]
    public Func<bool?> HasSharedEstate { get; private set; }

    [EzIPC("CanMoveToWorkshop")]
    public Func<bool> CanMoveToWorkshop { get; private set; }

    [EzIPC("MoveToWorkshop")]
    public MoveToWorkshopDelegate MoveToWorkshop { get; private set; }

    [EzIPC("ExecuteCommand")]
    public Action<string> ExecuteCommand { get; private set; }
}
