using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ComboCounter : MonoListener, IView
{
    [SerializeField]
    TMP_Text _valueField;
    [SerializeField]
    LikeCounter _likeCounter;

    private void Awake()
    {

        AddListener(Events.Turn, UpdateView);
    }

    public override void OnEnable()
    {
        base.OnEnable();
        UpdateView();
    }

    public void UpdateView()
    {
        _valueField.text = _likeCounter.Combo.ToString();
    }

}
