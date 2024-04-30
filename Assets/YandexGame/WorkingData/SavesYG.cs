using UnityEngine;

namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        // "Технические сохранения" для работы плагина (Не удалять)
        public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;

        // Ваши сохранения
        public string json;

        public SavesYG()
        {
            ResetSave();
        }

        public void ResetSave()
        {
            json = "";
        }

        public void LoadSaveToPrefs()
        {
            if (json != "")
                PlayerPrefs.SetString(nameof(json), json);
        }

        public void SetNewLeaderboardScore(int score)
        {
            YandexGame.NewLeaderboardScores("Leaderboard", score);
        }
    }
}
