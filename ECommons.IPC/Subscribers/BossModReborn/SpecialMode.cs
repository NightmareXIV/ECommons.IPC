namespace ECommons.IPC.Subscribers.BossModReborn;

public enum SpecialMode
{
    Normal,
    /// <summary>No movement, actions or casting allowed at activation time (pyretic, acceleration bomb).</summary>
    Pyretic,
    /// <summary>No movement allowed.</summary>
    NoMovement,
    /// <summary>Should be moving at activation time.</summary>
    Freezing,
    /// <summary>Movement direction is temporarily misdirected.</summary>
    Misdirection,
}
