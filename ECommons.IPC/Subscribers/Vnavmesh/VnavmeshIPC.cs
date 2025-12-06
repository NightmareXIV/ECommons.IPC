using ECommons.EzIpcManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static ECommons.IPC.Subscribers.Vnavmesh.VnavmeshIPC.Delegates;

namespace ECommons.IPC.Subscribers.Vnavmesh;

public sealed class VnavmeshIPC : IPCBase
{
    public VnavmeshIPC()
    {
    }

    public VnavmeshIPC(SafeWrapper wrapper) : base(wrapper)
    {
    }

    public override string IPCPrefix { get; } = "vnavmesh";

    public static class Delegates
    {
        public delegate Task<List<Vector3>> Pathfind(Vector3 from, Vector3 to, bool isFlying);
    }

    [EzIPC("Nav.IsReady")] public Func<bool> IsReady{get; private set;}
    [EzIPC("Nav.BuildProgress")] public Func<float> BuildProgress{get; private set;}
    [EzIPC("Nav.Reload")] public Func<bool> Reload{get; private set;}
    [EzIPC("Nav.Rebuild")] public Func<bool> Rebuild{get; private set;}
    /// <summary>
    /// Vector3 from, Vector3 to, bool fly
    /// </summary>
    [EzIPC("Nav.Pathfind")] public Pathfind Pathfind{get; private set;}

    [EzIPC("SimpleMove.PathfindAndMoveTo")] public Func<Vector3, bool, bool> PathfindAndMoveTo{get; private set;}
    [EzIPC("SimpleMove.PathfindInProgress")] public Func<bool> PathfindInProgress{get; private set;}

    [EzIPC("Path.Stop")] public Action Stop{get; private set;}
    [EzIPC("Path.IsRunning")] public Func<bool> IsRunning{get; private set;}

    /// <summary>
    /// Vector3 p, float halfExtentXZ, float halfExtentY
    /// </summary>
    [EzIPC("Query.Mesh.NearestPoint")] public Func<Vector3, float, float, Vector3?> NearestPoint{get; private set;}
    /// <summary>
    /// Vector3 p, bool allowUnlandable, float halfExtentXZ
    /// </summary>
    [EzIPC("Query.Mesh.PointOnFloor")] public Func<Vector3, bool, float, Vector3?> PointOnFloor{get; private set;}
}
