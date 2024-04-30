using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILevelsPanel : MonoBehaviour
{
    [SerializeField] private UILevelView[] _levelViews;
    [SerializeField] private Button _prev, _next;

    private int _startLevelID = 0;
    private int _levelsCount = 0;
    private int _levelsCountOnScreen = 10;

    private void RefreshList(int startLevelID)
    {
        for (int i = 0; i < _levelViews.Length; i++)
        {
            if (startLevelID < _levelsCount)
            {
                _levelViews[i].Init(true, _startLevelID + i);
                startLevelID++;
            }
            else
            {
                _levelViews[i].Init(false);
            }
        }

        UpdateNextPrevButtons();
    }

    private void UpdateNextPrevButtons()
    {
        _prev.interactable = _startLevelID != 0;
        _next.interactable = (_levelsCount - _startLevelID - 1) / _levelsCountOnScreen != 0;
    }

    public void Init(int levelsCount, int currentLevel = 0)
    {
        _levelsCount = levelsCount;
        _startLevelID = currentLevel / _levelsCountOnScreen;
        RefreshList(_startLevelID);
    }

    public void OnPressNext()
    {
        _startLevelID += _levelsCountOnScreen;
        RefreshList(_startLevelID);
    }

    public void OnPressPrev()
    {
        _startLevelID -= _levelsCountOnScreen;
        RefreshList(_startLevelID);
    }
}
