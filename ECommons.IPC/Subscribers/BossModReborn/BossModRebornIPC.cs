using ECommons.EzIpcManager;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;

namespace ECommons.IPC.Subscribers.BossModReborn;

using static BossModRebornIPC.Delegates;

/// <summary>
/// IPC of BossMod Reborn. For the original BossMod (vbm), use <see cref="BossMod.BossModIPC"/>.<br></br>
/// Both plugins register their IPC under the same <c>BossMod.</c> prefix, so use <see cref="IPCBase.Available"/> to check which one is loaded.
/// Set up not inhereting from vbm to avoid cross-plugin references and to allow for further drifting from vbm.<br></br>
/// </summary>
public sealed class BossModRebornIPC : IPCBase
{
    public BossModRebornIPC()
    {
    }

    public BossModRebornIPC(SafeWrapper wrapper) : base(wrapper)
    {
    }

    public override string InternalName { get; } = "BossModReborn";

    public override string IPCPrefix { get; } = "BossMod";

    public static class Delegates
    {
        public delegate List<string> ConfigurationDelegate(List<string> args, bool save);
        public delegate List<string> ConfigurationSetTransientDelegate(List<string> args);
        public delegate bool PresetsCreateDelegate(string presetSerialized, bool overwrite);
        public delegate bool AddTransientStrategyDelegate(string presetName, string moduleTypeName, string trackName, string value);
        public delegate bool AddTransientStrategyTargetEnemyOIDDelegate(string presetName, string moduleTypeName, string trackName, string value, int oid);
        public delegate bool ClearTransientStrategyDelegate(string presetName, string moduleTypeName, string trackName);
        public delegate bool ClearTransientModuleStrategiesDelegate(string presetName, string moduleTypeName);
        public delegate bool IsDashSafeDelegate(Vector3 from, Vector3 to);
        public delegate bool IsFixedDashSafeDelegate(float range, bool backwards);
        public delegate bool IsBackdashSafeDelegate(Vector3 enemyPos, float range);
        public delegate bool ObstacleMapGenerateDelegate(Vector3 centerWorld, float radius, bool writeToFile);
    }

    /// <summary>Whether a boss module exists for the given enemy data ID (OID).</summary>
    [EzIPC] public Func<uint, bool> HasModuleByDataId { get; private set; }
    /// <summary>Whether a boss module is currently active.</summary>
    [EzIPC] public Func<bool> HasActiveModule { get; private set; }
    /// <summary>Name of the active module's primary actor, or null if no module is active.</summary>
    [EzIPC] public Func<string?> ActiveModuleName { get; private set; }
    /// <summary>Human-readable description of the active module's upcoming states, for debugging.</summary>
    [EzIPC("Debug.TimelineWalk")] public Func<string> Debug_TimelineWalk { get; private set; }

    // Timeline: seconds until the next state with the given hint in the active module's timeline, float.MaxValue if none
    [EzIPC("Timeline.NextRaidwideIn")] public Func<float> Timeline_NextRaidwideIn { get; private set; }
    [EzIPC("Timeline.NextTankbusterIn")] public Func<float> Timeline_NextTankbusterIn { get; private set; }
    [EzIPC("Timeline.NextKnockbackIn")] public Func<float> Timeline_NextKnockbackIn { get; private set; }
    [EzIPC("Timeline.NextDowntimeIn")] public Func<float> Timeline_NextDowntimeIn { get; private set; }
    [EzIPC("Timeline.NextDowntimeEndIn")] public Func<float> Timeline_NextDowntimeEndIn { get; private set; }
    [EzIPC("Timeline.NextVulnerableIn")] public Func<float> Timeline_NextVulnerableIn { get; private set; }
    [EzIPC("Timeline.NextVulnerableEndIn")] public Func<float> Timeline_NextVulnerableEndIn { get; private set; }

    /// <summary>Seconds until the next predicted damage, float.MaxValue if none.</summary>
    [EzIPC("Hints.NextDamageIn")] public Func<float> Hints_NextDamageIn { get; private set; }
    /// <summary>Type of the next predicted damage, cast to <see cref="PredictedDamageType"/>.</summary>
    [EzIPC("Hints.NextDamageType")] public Func<int> Hints_NextDamageType { get; private set; }
    /// <summary>Party slots hit by the next predicted damage, as a bitmask.</summary>
    [EzIPC("Hints.PredictedDamagePlayers")] public Func<ulong> Hints_PredictedDamagePlayers { get; private set; }
    /// <summary>Seconds until the next predicted raidwide, float.MaxValue if none.</summary>
    [EzIPC("Hints.NextRaidwideDamageIn")] public Func<float> Hints_NextRaidwideDamageIn { get; private set; }
    /// <summary>Seconds until the next predicted tankbuster, float.MaxValue if none.</summary>
    [EzIPC("Hints.NextTankbusterDamageIn")] public Func<float> Hints_NextTankbusterDamageIn { get; private set; }
    /// <summary>Longest time (in seconds) the player can spend casting before needing to move, float.MaxValue if unrestricted.</summary>
    [EzIPC("Hints.MaxCastTime")] public Func<float> Hints_MaxCastTime { get; private set; }
    [EzIPC("Hints.ForceCancelCastMechanic")] public Func<bool> Hints_ForceCancelCastMechanic { get; private set; }
    [EzIPC("Hints.ForceCancelCastOther")] public Func<bool> Hints_ForceCancelCastOther { get; private set; }
    [EzIPC("Hints.ForceCancelCastMechanicAI")] public Func<bool> Hints_ForceCancelCastMechanicAI { get; private set; }
    [EzIPC("Hints.ForceCancelCastOtherAI")] public Func<bool> Hints_ForceCancelCastOtherAI { get; private set; }
    [EzIPC("Hints.ForbiddenZonesCount")] public Func<int> Hints_ForbiddenZonesCount { get; private set; }
    /// <summary>Seconds until the first forbidden zone activates, float.MaxValue if none.</summary>
    [EzIPC("Hints.ForbiddenZonesNextActivation")] public Func<float> Hints_ForbiddenZonesNextActivation { get; private set; }
    [EzIPC("Hints.ForbiddenDirectionsCount")] public Func<int> Hints_ForbiddenDirectionsCount { get; private set; }
    /// <summary>Center of the arena; X and Y are the world X and Z coordinates.</summary>
    [EzIPC("Hints.ArenaCenter")] public Func<Vector2> Hints_ArenaCenter { get; private set; }
    [EzIPC("Hints.ArenaRadius")] public Func<float> Hints_ArenaRadius { get; private set; }
    /// <summary>Party slots that should be cleansed, as a bitmask.</summary>
    [EzIPC("Hints.ShouldCleansePlayers")] public Func<ulong> Hints_ShouldCleansePlayers { get; private set; }
    /// <summary>Game object ID of the object that should be interacted with, 0 if none.</summary>
    [EzIPC("Hints.InteractWithTargetOID")] public Func<ulong> Hints_InteractWithTargetOID { get; private set; }
    /// <summary>Recommended positional for the current target, cast to <see cref="Positional"/>.</summary>
    [EzIPC("Hints.RecommendedPositional")] public Func<int> Hints_RecommendedPositional { get; private set; }
    /// <summary>Seconds until the next special mode (pyretic, freezing, ...) activates, float.MaxValue if none.</summary>
    [EzIPC("Hints.SpecialModeIn")] public Func<float> Hints_SpecialModeIn { get; private set; }
    /// <summary>Type of the next special mode, cast to <see cref="SpecialMode"/>.</summary>
    [EzIPC("Hints.SpecialModeType")] public Func<int> Hints_SpecialModeType { get; private set; }
    /// <summary>Whether dashing from the player's position to the given position is safe (inside the arena, outside forbidden zones and obstacles).</summary>
    [EzIPC("Hints.IsPositionSafe")] public Func<Vector3, bool> Hints_IsPositionSafe { get; private set; }
    /// <summary>Same as <see cref="Hints_IsPositionSafe"/>, but from an explicit position.</summary>
    [EzIPC("Hints.IsDashSafe")] public IsDashSafeDelegate Hints_IsDashSafe { get; private set; }
    /// <summary>Whether dashing <c>range</c> yalms forward (or backward) from the player's current position and rotation is safe.</summary>
    [EzIPC("Hints.IsFixedDashSafe")] public IsFixedDashSafeDelegate Hints_IsFixedDashSafe { get; private set; }
    /// <summary>Whether backdashing <c>range</c> yalms directly away from <c>enemyPos</c> is safe.</summary>
    [EzIPC("Hints.IsBackdashSafe")] public IsBackdashSafeDelegate Hints_IsBackdashSafe { get; private set; }

    /// <summary>Whether BossMod is currently forcing the player to move.</summary>
    [EzIPC("Movement.IsMoving")] public Func<bool> Movement_IsMoving { get; private set; }
    /// <summary>Whether the user is currently pressing movement input.</summary>
    [EzIPC("Movement.IsMoveRequested")] public Func<bool> Movement_IsMoveRequested { get; private set; }

    /// <summary>Forbids (true) or allows (false) AI movement; returns the new value.</summary>
    [EzIPC("AI.PauseMovement")] public Func<bool, bool> AI_PauseMovement { get; private set; }
    /// <summary>Position the AI is navigating to (Y is always 0), or null if it isn't navigating.</summary>
    [EzIPC("AI.NaviTargetPos")] public Func<Vector3?> AI_NaviTargetPos { get; private set; }
    [EzIPC("AI.IsNavigating")] public Func<bool> AI_IsNavigating { get; private set; }
    [EzIPC("AI.PlayerSpeed")] public Func<float> AI_PlayerSpeed { get; private set; }
    /// <summary>Sets the AI preset by name (case-insensitive); an unknown name clears it.</summary>
    [EzIPC("AI.SetPreset")] public Action<string> AI_SetPreset { get; private set; }
    /// <summary>Name of the AI preset, empty if none.</summary>
    [EzIPC("AI.GetPreset")] public Func<string> AI_GetPreset { get; private set; }

    /// <summary>
    /// Equivalent of <c>/bmr cfg &lt;config-type&gt; &lt;field&gt; [value]</c>: gets or sets a config field. Returns the value or any error messages.<br></br>
    /// When <c>save</c> is false the change isn't saved immediately, but it is saved along with any later config change.
    /// </summary>
    [EzIPC] public ConfigurationDelegate Configuration { get; private set; }
    /// <summary>
    /// Same arguments as <see cref="Configuration"/>, but the change is temporary: it is never written to BossMod's config file,
    /// and <see cref="Configuration_ClearTransient"/> restores the user's own values. If the user changes the setting in the meantime, their new value is kept.
    /// Returns any error messages.
    /// </summary>
    [EzIPC("Configuration.SetTransient")] public ConfigurationSetTransientDelegate Configuration_SetTransient { get; private set; }
    /// <summary>Restores the user's own values of all settings changed by <see cref="Configuration_SetTransient"/>. Returns the number of settings restored.</summary>
    [EzIPC("Configuration.ClearTransient")] public Func<int> Configuration_ClearTransient { get; private set; }
    /// <summary>Time of the last config change.</summary>
    [EzIPC("Configuration.LastModified")] public Func<DateTime> Configuration_LastModified { get; private set; }

    /// <summary>Whether autorotation has queued any (non-manual) actions.</summary>
    [EzIPC("Rotation.ActionQueue.HasEntries")] public Func<bool> Rotation_ActionQueue_HasEntries { get; private set; }

    /// <summary>Serialized preset with the given name, or null if it doesn't exist.</summary>
    [EzIPC("Presets.Get")] public Func<string, string?> Presets_Get { get; private set; }
    /// <summary>Creates a user preset from its serialized form. Fails if it already exists, unless <c>overwrite</c> is set.</summary>
    [EzIPC("Presets.Create")] public PresetsCreateDelegate Presets_Create { get; private set; }
    [EzIPC("Presets.Delete")] public Func<string, bool> Presets_Delete { get; private set; }
    /// <summary>Name of the active autorotation preset, or null if none.</summary>
    [EzIPC("Presets.GetActive")] public Func<string?> Presets_GetActive { get; private set; }
    [EzIPC("Presets.SetActive")] public Func<string, bool> Presets_SetActive { get; private set; }
    [EzIPC("Presets.ClearActive")] public Func<bool> Presets_ClearActive { get; private set; }
    [EzIPC("Presets.GetForceDisabled")] public Func<bool> Presets_GetForceDisabled { get; private set; }
    [EzIPC("Presets.SetForceDisabled")] public Func<bool> Presets_SetForceDisabled { get; private set; }
    /// <summary>Temporarily overrides a strategy track of a preset's module. <c>moduleTypeName</c> is the full type name, e.g. <c>BossMod.Autorotation.MiscAI.StayCloseToTarget</c>.</summary>
    [EzIPC("Presets.AddTransientStrategy")] public AddTransientStrategyDelegate Presets_AddTransientStrategy { get; private set; }
    /// <summary>Same as <see cref="Presets_AddTransientStrategy"/>, targeting the enemy with the given OID.</summary>
    [EzIPC("Presets.AddTransientStrategyTargetEnemyOID")] public AddTransientStrategyTargetEnemyOIDDelegate Presets_AddTransientStrategyTargetEnemyOID { get; private set; }
    [EzIPC("Presets.ClearTransientStrategy")] public ClearTransientStrategyDelegate Presets_ClearTransientStrategy { get; private set; }
    [EzIPC("Presets.ClearTransientModuleStrategies")] public ClearTransientModuleStrategiesDelegate Presets_ClearTransientModuleStrategies { get; private set; }
    [EzIPC("Presets.ClearTransientPresetStrategies")] public Func<string, bool> Presets_ClearTransientPresetStrategies { get; private set; }

    /// <summary>Starts generating an obstacle map around the given position.</summary>
    [EzIPC("ObstacleMap.Generate")] public ObstacleMapGenerateDelegate ObstacleMap_Generate { get; private set; }
    [EzIPC("ObstacleMap.GetGenerationStatus")] public Func<TaskStatus> ObstacleMap_GetGenerationStatus { get; private set; }
    [EzIPC("ObstacleMap.HasTempMap")] public Func<bool> ObstacleMap_HasTempMap { get; private set; }
    [EzIPC("ObstacleMap.ClearTempMap")] public Func<bool> ObstacleMap_ClearTempMap { get; private set; }
    /// <summary>Quality metrics of the generated temporary obstacle map, or null if there is none.</summary>
    [EzIPC("ObstacleMap.EvaluateTempMapQuality")] public Func<BitmapQuality?> ObstacleMap_EvaluateTempMapQuality { get; private set; }

    /// <summary>JSON array of the actions planned by the active cooldown plan within the given number of seconds.</summary>
    [EzIPC("Plan.GetUpcomingActions")] public Func<float, string> Plan_GetUpcomingActions { get; private set; }
}
