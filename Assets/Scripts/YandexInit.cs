using System.Collections;
using UnityEngine;
using YG;

public class YandexInit : MonoBehaviour
{
    [SerializeField] private GameObject[] _toActivate;

    private IEnumerator Start()
    {
        while (YandexGame.SDKEnabled == false)
        {
            yield return null;
        }

        YandexGame.savesData.LoadSaveToPrefs();

        foreach (var item in _toActivate)
        {
            item.SetActive(true);
        }

        //Game.Instance.CreateCurrentLevel();
    }
}
