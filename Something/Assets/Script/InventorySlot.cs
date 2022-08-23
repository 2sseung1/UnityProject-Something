using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public bool IsActive { get; private set; }
    public Item Item { get; private set; }

    private Image _image;

    void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void Setting(Item item)
    {
        IsActive = true;
        Item = item;
        _image.sprite = item.GetItemSprite;
    }
}