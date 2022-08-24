using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public bool IsActive { get; private set; }
    public Item Item { get; private set; }

    private Image _image;
    private Color _newColor;

    void Awake()
    {
        _image = GetComponent<Image>();
        _newColor = _image.color;
    }

    public void Setting(Item item)
    {
        IsActive = true;
        Item = item;
        _image.sprite = item.GetItemSprite;
        _newColor.a = 255;
        _image.color = _newColor;
    }
}