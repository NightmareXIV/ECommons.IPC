using ECommons.EzIpcManager;
using System;
using System.Collections.Generic;
using System.Numerics;
using static ECommons.IPC.Providers.LifestreamIPC.Lifestream.Delegates;

namespace ECommons.IPC.Providers.LifestreamIPC;

public static class Lifestream
{
    public static class Delegates
    {
        public delegate bool TeleportDelegate(uint aetheryteId, byte subAetheryteId);
        public delegate void EnqueuePropertyShortcutDelegate(PropertyType propertyType, HouseEnterMode? houseEnterMode);
        public delegate void MoveToWorkshopDelegate();
    }

    [EzIPC("Teleport")]
    public static TeleportDelegate Teleport { get; private set; }

    [EzIPC("TeleportToHome")]
    public static Func<bool> TeleportToHome { get; private set; }

    [EzIPC("TeleportToFC")]
    public static Func<bool> TeleportToFC { get; private set; }

    [EzIPC("TeleportToApartment")]
    public static Func<bool> TeleportToApartment { get; private set; }

    [EzIPC("IsBusy")]
    public static Func<bool> IsBusy { get; private set; }

    /// <summary>
    /// city aetheryte id
    /// </summary>
    [EzIPC("GetResidentialTerritory")]
    public static Func<int, uint> GetResidentialTerritory { get; private set; }

    /// <summary>
    /// territory, plot
    /// </summary>
    [EzIPC("GetPlotEntrance")]
    public static Func<uint, int, Vector3?> GetPlotEntrance { get; private set; }

    /// <summary>
    /// type(home=1, fc=2, apartment=3), mode(enter house=2)
    /// </summary>
    [EzIPC("EnqueuePropertyShortcut")]
    public static EnqueuePropertyShortcutDelegate EnqueuePropertyShortcut { get; private set; }

    [EzIPC("GetCurrentPlotInfo")]
    public static Func<(int Kind, int Ward, int Plot)?> GetCurrentPlotInfo { get; private set; }

    [EzIPC("EnqueueInnShortcut")]
    public static Action<int?> EnqueueInnShortcut { get; private set; }

    [EzIPC("HasApartment")]
    public static Func<bool?> HasApartment { get; private set; }

    [EzIPC("EnterApartment")]
    public static Action<bool> EnterApartment { get; private set; }

    [EzIPC("HasPrivateHouse")]
    public static Func<bool?> HasPrivateHouse { get; private set; }

    [EzIPC("HasFreeCompanyHouse")]
    public static Func<bool?> HasFreeCompanyHouse { get; private set; }

    [EzIPC("AethernetTeleport")]
    public static Func<string, bool> AethernetTeleport { get; private set; }

    [EzIPC("Move")]
    public static Action<List<Vector3>> Move { get; private set; }

    [EzIPC("CanVisitSameDC")]
    public static Func<string, bool> CanVisitSameDC { get; private set; }

    [EzIPC("CanVisitCrossDC")]
    public static Func<string, bool> CanVisitCrossDC { get; private set; }

    /// <summary>
    /// (string w, bool isDcTransfer, string secondaryTeleport, bool noSecondaryTeleport, int? gateway, bool? doNotify, bool? returnToGateway)
    /// </summary>
    [EzIPC("TPAndChangeWorld")]
    public static Action<string, bool, string, bool, WorldChangeAetheryte?, bool?, bool?> TPAndChangeWorld { get; private set; }

    [EzIPC("EnqueueLocalInnShortcut")]
    public static Action<int?> EnqueueLocalInnShortcut { get; private set; }

    [EzIPC("GetHousePathData")]
    public static Func<ulong, (HousePathData Private, HousePathData FC)> GetHousePathData { get; private set; }

    [EzIPC("GetSharedHousePathData")]
    public static Func<HousePathData> GetSharedHousePathData { get; private set; }

    [EzIPC("HasSharedEstate")]
    public static Func<bool?> HasSharedEstate { get; private set; }

    [EzIPC("CanMoveToWorkshop")]
    public static Func<bool> CanMoveToWorkshop { get; private set; }

    [EzIPC("MoveToWorkshop")]
    public static MoveToWorkshopDelegate MoveToWorkshop { get; private set; }

    [EzIPC("ExecuteCommand")]
    public static Action<string> ExecuteCommand { get; private set; }
}