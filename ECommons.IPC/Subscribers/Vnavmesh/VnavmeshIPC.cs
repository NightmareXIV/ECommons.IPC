using ECommons.EzIpcManager;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;

namespace ECommons.IPC.Subscribers.Vnavmesh;

using static VnavmeshIPC.Delegates;

public sealed class VnavmeshIPC : IPCBase
{
    public VnavmeshIPC()
    {
    }

    public VnavmeshIPC(SafeWrapper wrapper) : base(wrapper)
    {
    }

    public override string InternalName { get; } = "vnavmesh";

    public static class Delegates
    {
        public delegate Task<List<Vector3>> Pathfind(Vector3 from, Vector3 to, bool isFlying);
        public delegate bool PathfindAndMoveTo(Vector3 position, bool canFly);
        public delegate void PathMoveTo(List<Vector3> waypoints, bool fly);
    }

    [EzIPC("Nav.IsReady")] public Func<bool> IsReady { get; private set; }
    [EzIPC("Nav.BuildProgress")] public Func<float> BuildProgress { get; private set; }
    [EzIPC("Nav.Reload")] public Func<bool> Reload { get; private set; }
    [EzIPC("Nav.Rebuild")] public Func<bool> Rebuild { get; private set; }
    /// <summary>
    /// Vector3 from, Vector3 to, bool fly
    /// </summary>
    [EzIPC("Nav.Pathfind")] public Pathfind Pathfind { get; private set; }

    [EzIPC("SimpleMove.PathfindAndMoveTo")] public PathfindAndMoveTo PathfindAndMoveTo { get; private set; }
    [EzIPC("SimpleMove.PathfindInProgress")] public Func<bool> PathfindInProgress { get; private set; }

    [EzIPC("Path.Stop")] public Action Stop { get; private set; }
    [EzIPC("Path.IsRunning")] public Func<bool> IsRunning { get; private set; }

    /// <summary>
    /// Vector3 p, float halfExtentXZ, float halfExtentY
    /// </summary>
    [EzIPC("Query.Mesh.NearestPoint")] public Func<Vector3, float, float, Vector3?> NearestPoint { get; private set; }
    /// <summary>
    /// Vector3 p, bool allowUnlandable, float halfExtentXZ
    /// </summary>
    [EzIPC("Query.Mesh.PointOnFloor")] public Func<Vector3, bool, float, Vector3?> PointOnFloor { get; private set; }
    [EzIPC("Path.MoveTo")] public PathMoveTo MoveTo { get; private set; }

    [EzIPC("Path.NumWaypoints")] public Func<int> NumWaypoints { get; private set; }
    [EzIPC("Path.GetMovementAllowed")] public Func<bool> GetMovementAllowed { get; private set; }
    [EzIPC("Path.SetMovementAllowed")] public Action<bool> SetMovementAllowed { get; private set; }
    [EzIPC("Path.GetAlignCamera")] public Func<bool> GetAlignCamera { get; private set; }
    [EzIPC("Path.SetAlignCamera")] public Action<bool> SetAlignCamera { get; private set; }
    [EzIPC("Path.GetTolerance")] public Func<float> GetTolerance { get; private set; }
    [EzIPC("Path.SetTolerance")] public Action<float> SetTolerance { get; private set; }
}