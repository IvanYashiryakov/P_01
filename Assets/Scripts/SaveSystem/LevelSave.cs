using System;

[Serializable]
public struct LevelSave
{
    public int Id;
    public bool Star1;
    public bool Star2;
    public bool Star3;

    public LevelSave(int id, bool star1, bool star2, bool star3)
    {
        Id = id;
        Star1 = star1;
        Star2 = star2;
        Star3 = star3;
    }
}
