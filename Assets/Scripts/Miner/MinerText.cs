using UnityEngine;
using TMPro;

public class MinerText : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private void Start()
    {
        _text.text = transform.parent.name;
    }
}
