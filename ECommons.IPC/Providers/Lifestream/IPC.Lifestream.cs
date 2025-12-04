using ECommons.EzIpcManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ECommons.IPC.Providers.Lifestream;

public static partial class IPC
{
    public static class Lifestream
    {
        private static readonly string IPCPrefix = "Lifestream";

        [EzIPC("Teleport")] 
        public static Func<uint, byte, bool> Teleport;

        [EzIPC("TeleportToHome")] 
        public static Func<bool> TeleportToHome;

        [EzIPC("TeleportToFC")] 
        public static Func<bool> TeleportToFC;

        [EzIPC("TeleportToApartment")] 
        public static Func<bool> TeleportToApartment;

        [EzIPC("IsBusy")] 
        public static Func<bool> IsBusy;

        /// <summary>
        /// city aetheryte id
        /// </summary>
        [EzIPC("GetResidentialTerritory")] 
        public static Func<int, uint> GetResidentialTerritory;

        /// <summary>
        /// content id
        /// </summary>
        //[EzIPC("")] public Func<ulong, (HousePathData Private, HousePathData FC)> GetHousePathData;

        /// <summary>
        /// territory, plot
        /// </summary>
        [EzIPC("GetPlotEntrance")] 
        public static Func<uint, int, Vector3?> GetPlotEntrance;

        /// <summary>
        /// type(home=1, fc=2, apartment=3), mode(enter house=2)
        /// </summary>
        [EzIPC("EnqueuePropertyShortcut")] 
        public static Action<PropertyType, HouseEnterMode?> EnqueuePropertyShortcut;

        [EzIPC("GetCurrentPlotInfo")] 
        public static Func<(int Kind, int Ward, int Plot)?> GetCurrentPlotInfo;

        [EzIPC("EnqueueInnShortcut")] 
        public static Action<int?> EnqueueInnShortcut;

        [EzIPC("HasApartment")] 
        public static Func<bool?> HasApartment;

        [EzIPC("EnterApartment")] 
        public static Action<bool> EnterApartment;

        [EzIPC("HasPrivateHouse")] 
        public static Func<bool?> HasPrivateHouse;

        [EzIPC("HasFreeCompanyHouse")] 
        public static Func<bool?> HasFreeCompanyHouse;

        [EzIPC("AethernetTeleport")] 
        public static Func<string, bool> AethernetTeleport;

        [EzIPC("Move")] 
        public static Action<List<Vector3>> Move;

        [EzIPC("CanVisitSameDC")] 
        public static Func<string, bool> CanVisitSameDC;

        [EzIPC("CanVisitCrossDC")] 
        public static Func<string, bool> CanVisitCrossDC;

        /// <summary>
        /// (string w, bool isDcTransfer, string secondaryTeleport, bool noSecondaryTeleport, int? gateway, bool? doNotify, bool? returnToGateway)
        /// </summary>
        [EzIPC("TPAndChangeWorld")] 
        public static Action<string, bool, string, bool, WorldChangeAetheryte?, bool?, bool?> TPAndChangeWorld;

        [EzIPC("EnqueueLocalInnShortcut")] 
        public static Action<int?> EnqueueLocalInnShortcut;

        [EzIPC("GetHousePathData")] 
        public static Func<ulong, (HousePathData Private, HousePathData FC)> GetHousePathData;

        [EzIPC("GetSharedHousePathData")] 
        public static Func<HousePathData> GetSharedHousePathData;

        [EzIPC("HasSharedEstate")] 
        public static Func<bool?> HasSharedEstate;

        [EzIPC("CanMoveToWorkshop")] 
        public static Func<bool> CanMoveToWorkshop;

        [EzIPC("MoveToWorkshop")] 
        public static Action MoveToWorkshop;

        [EzIPC("ExecuteCommand")] 
        public static Action<string> ExecuteCommand;
    }
}