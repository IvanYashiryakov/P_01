using System;
using System.Collections.Generic;

[Serializable]
public struct OreComponent
{
    public float Health;
    public List<OrePieceProvider> OrePieces;
    public int GoldAmount;
    public bool IsFree;
}
