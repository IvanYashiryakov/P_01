using UnityEngine;

public class YandexInit : MonoBehaviour
{
    [SerializeField] private GameObject[] _toActivate;

    private void Start()
    {
        //while (YandexGame.SDKEnabled == false)
        //{
        //    yield return null;
        //}

        //YandexGame.LoadProgress();
        foreach (var item in _toActivate)
        {
            item.SetActive(true);
        }
        Game.Instance.CreateCurrentLevel();
    }
}
