using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpriteType
{
    Gold,
    Fuel
}

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private FloatingText _prefab;
    [SerializeField] private Sprite _goldSprite;
    [SerializeField] private Sprite _fuelSprite;

    private List<FloatingText> _list;
    private int _objectsCount = 20;

    public static ObjectPool Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        _list = new List<FloatingText>(_objectsCount);

        for (int i = 0; i < _objectsCount; i++)
            CreateObject();
    }

    private FloatingText CreateObject()
    {
        FloatingText floatingText = Instantiate(_prefab);
        floatingText.gameObject.SetActive(false);
        _list.Add(floatingText);

        return floatingText;
    }

    private Sprite GetSprite(SpriteType spriteType)
    {
        switch (spriteType)
        {
            case SpriteType.Gold: return _goldSprite;
            case SpriteType.Fuel: return _fuelSprite;
            default: return _goldSprite;
        }
    }

    public void Spawn(float value, SpriteType spriteType, Vector3 position)
    {
        foreach (var item in _list)
        {
            if (item.gameObject.activeSelf == false)
            {
                item.Init(value, GetSprite(spriteType), position);
                return;
            }
        }

        CreateObject().Init(value, GetSprite(spriteType), position);
    }
}
