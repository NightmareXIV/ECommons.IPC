using ECommons.EzIpcManager;
using System;
using System.Collections.Generic;

namespace ECommons.IPC.Subscribers.Skippy
{
    public class SkippyIPC : IPCBase
    {
        public override string InternalName => "Skippy";


        public enum SkippedCategory
        {
            IsEnabled,
            AutoEnable4Man,
            SkipMSQRoulette,
            ExemptPrae,
            ExemptCastrum,
            ExemptPorta,
            SkipMassivePC,
            SkipGoldSaucer,
            ExemptChocoboRacing,
            ExemptVerminion,
            ExemptTripleTriad,
            ExemptFallGuys,
            ExemptAirForceOne,
            ExemptMahjong,
            SkipCustomTalk,
            SkipNormalCutscenes,
            SkipFeedBuddy,
            SkipOceanFishing,
            SkipCrystallineConflict,
            SkipInn,
        }


        /** @return Whether Skippy is enabled or not.*/
        [EzIPC("IsEnabled")] public Func<bool> IsEnabled { get; private set; }

        /** Returns the names of all the categories of skips that are currently active. */
        [EzIPC("GetSkippedCategories")] public Func<SkippedCategory[]> GetSkippedCategories { get; private set; }

        /** Returns the full configuration information of Skippy as a key/value map.*/
        [EzIPC("GetConfig")] public Func<Dictionary<string, bool>> GetConfig { get; private set; }

    }
}
