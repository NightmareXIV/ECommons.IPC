using ECommons.EzIpcManager;
using static ECommons.IPC.Subscribers.AllaganTools.AllaganToolsIPC.Delegates;

namespace ECommons.IPC.Subscribers.AllaganTools;

using System.Collections.Generic;

public class AllaganToolsIPC : IPCBase
{
    public AllaganToolsIPC()
    {
    }

    public AllaganToolsIPC(SafeWrapper wrapper) : base(wrapper)
    {
    }

    public override string InternalName { get; } = "InventoryTools";

    public static class Delegates
    {
        public delegate uint           InventoryCountByType(uint       inventoryType,  ulong? characterId);
        public delegate uint           InventoryCountByTypes(uint[]    inventoryTypes, ulong? characterId);
        public delegate uint           ItemCount(uint                  itemId,         ulong  characterId,          int    inventoryType);
        public delegate uint           ItemCountOwned(uint             itemId,         bool   currentCharacterOnly, uint[] inventoryTypes);
        public delegate HashSet<ulong> GetCharactersOwnedByActive(bool includeOwner);
    }

    [EzIPC("AllaganTools.InventoryCountByType", false)]
    public InventoryCountByType InventoryCountByType;

    [EzIPC("AllaganTools.InventoryCountByTypes", false)]
    public InventoryCountByTypes InventoryCountByTypes;

    [EzIPC("AllaganTools.ItemCount", false)]
    public ItemCount ItemCount;

    [EzIPC("AllaganTools.ItemCountHQ", false)]
    public ItemCount ItemCountHQ;

    [EzIPC("AllaganTools.ItemCountOwned", false)]
    public ItemCountOwned ItemCountOwned;

    [EzIPC("AllaganTools.GetCharactersOwnedByActive", false)]
    public GetCharactersOwnedByActive GetCharactersOwnedByActive;
}
