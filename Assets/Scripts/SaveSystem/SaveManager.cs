using UnityEngine;
using YG;

public class SaveManager : MonoBehaviour
{
    private SaveData _saveData;
    private readonly string _prefsID = "json";

    public bool Music => _saveData.Music;
    public bool Sound => _saveData.Sound;
    public float Gold => _saveData.Gold;
    public float MaxFuel => _saveData.MaxFuel;

    public static SaveManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey(_prefsID) == true)
        {
            _saveData = JsonUtility.FromJson<SaveData>(PlayerPrefs.GetString(_prefsID));
        }

        if (_saveData == null)
        {
            _saveData = new SaveData();
        }
    }

    public void SetMusic(bool value) => _saveData.Music = value;
    public void SetSound(bool value) => _saveData.Sound = value;

    public bool GetStarValue(int id, int starID)
    {
        foreach (var level in _saveData.Levels)
        {
            if (level.Id == id)
            {
                switch (starID)
                {
                    case 0: return level.Star1;
                    case 1: return level.Star2;
                    case 2: return level.Star3;
                }
            }
        }

        return false;
    }


    public void SaveLevel(int id, bool star1, bool star2, bool star3)
    {
        if (TrySaveInExistingRecord(id, star1, star2, star3) == false)
        {
            LevelSave newSave = new LevelSave( id, star1, star2, star3);
            _saveData.Levels.Add(newSave);

            if (star1 == true) _saveData.TotalStars++;
            if (star2 == true) _saveData.TotalStars++;
            if (star3 == true) _saveData.TotalStars++;
        }

        SaveToPrefs();
    }

    private bool TrySaveInExistingRecord(int id, bool star1, bool star2, bool star3)
    {
        for (int i = 0; i < _saveData.Levels.Count; i++)
        {
            if (_saveData.Levels[i].Id == id)
            {
                LevelSave newSave = new LevelSave(
                    id,
                    _saveData.Levels[i].Star1 == false ? star1 : true,
                    _saveData.Levels[i].Star2 == false ? star2 : true,
                    _saveData.Levels[i].Star3 == false ? star3 : true);

                if (_saveData.Levels[i].Star2 == false && star2 == true) _saveData.TotalStars++;
                if (_saveData.Levels[i].Star3 == false && star3 == true) _saveData.TotalStars++;

                _saveData.Levels.RemoveAt(i);
                _saveData.Levels.Add(newSave);

                return true;
            }
        }

        return false;
    }

    private void SaveToPrefs()
    {
        string json = JsonUtility.ToJson(_saveData);
        PlayerPrefs.SetString(_prefsID, json);

        YandexGame.savesData.SetNewLeaderboardScore(_saveData.TotalStars);
        YandexGame.savesData.json = json;
        YandexGame.SaveProgress();
    }
}
