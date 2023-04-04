using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUIManager : MonoBehaviour
{
    [SerializeField]
    private Sprite _emptyHearthSprite;

    [SerializeField]
    private List<Image> _hearth = new List<Image>();


    int _hearthRemaining;

    private void Start()
    {
        _hearthRemaining = 3;
    }


    public void RemoveHearth()
    {
        _hearthRemaining--;

        _hearth[_hearthRemaining].sprite = _emptyHearthSprite;
    }
}
