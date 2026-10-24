using System.Reflection;

namespace ECommons.IPC.Subscribers.BossModReborn;

public sealed class BitmapQuality
{
    /// <summary>Fraction of blocked cells (higher = less navigable).</summary>
    [Obfuscation] public float BlockedFraction;
    /// <summary>Fraction of passable cells in the largest connected area (higher = more navigable).</summary>
    [Obfuscation] public float LargestPassableComponentFraction;
    /// <summary>Fraction of passable cells in tiny clusters (higher = more fragmented).</summary>
    [Obfuscation] public float TinyPassableComponentFraction;
    /// <summary>Fraction of isolated cells with no neighbors of the same type (higher = noisier).</summary>
    [Obfuscation] public float SpeckleFraction;
    /// <summary>Number of separate passable areas (higher = more fragmented).</summary>
    [Obfuscation] public int PassableComponents;
}
