using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public ItemType GetItemType { get { return Type; } }
    public string GetItemName { get { return Name; } }
    public Sprite GetItemSprite { get { return Sprite; } }

    public enum ItemType
    {
        Key
    }

    [SerializeField]
    private ItemType Type;
    [SerializeField]
    private string Name;
    [SerializeField]
    private Sprite Sprite;
}