using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconChanger : MonoBehaviour
{
    [SerializeField]
    private Sprite[] _spriteSet;

    private bool _isActive = true;

    

    private Image _image;
    private void Awake()
    {


        _image = GetComponent<Image>();
        _image.sprite = _spriteSet[0];
    }

    public void ChangeIcon()
    {
        if (_isActive)
        {
            _image.sprite = _spriteSet[1];
            _isActive = false;
        }
        else
        {
            _image.sprite = _spriteSet[0];
            _isActive = true;
        }
    }
}
