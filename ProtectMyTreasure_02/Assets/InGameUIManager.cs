using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using TMPro;

public class InGameUIManager : MonoBehaviour
{
    [SerializeField]
    private Sprite _emptyHearthSprite;

    [SerializeField]
    private List<Image> _hearth = new List<Image>();

    [SerializeField]
    private Spawner_Manager spawner_Manager = null;

    [SerializeField]
    private TextMeshProUGUI _textScore;

    public void SetScore(int score)
    {
        _textScore.text = score.ToString();
    }
    

    int _hearthRemaining;

    private void Start()
    {
        _hearthRemaining = 3;
        SetScore(0);
    }


    public void RemoveHearth()
    {
        _hearthRemaining--;

        _hearth[_hearthRemaining].sprite = _emptyHearthSprite;
    }
}
