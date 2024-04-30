using System;
using System.Collections.Generic;

[Serializable]
public class SaveData
{
    public bool Sound, Music;
    public int TotalStars;
    public float Gold;
    public float MaxFuel;
    public List<LevelSave> Levels;

    public SaveData()
    {
        Sound = true;
        Music = true;
        TotalStars = 0;
        Gold = -1;
        MaxFuel = -1;
        Levels = new List<LevelSave>();
    }
}
