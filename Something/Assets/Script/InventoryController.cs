using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public bool ViewActive { get; private set; }

    [SerializeField]
    private GameObject InventoryView;
    [SerializeField]
    private Image InventoryViewImage;
    [SerializeField]
    private GameObject Slots;

    private InventorySlot[] _slot;
    private int _slotCount;
    private int _nextSlotIndex;

    void Awake()
    {
        _slot = Slots.GetComponentsInChildren<InventorySlot>();
        _slotCount = 15;
        _nextSlotIndex = 0;
    }

    void Start()
    {
        ViewActive = true;
        ViewOnOff();
        InventoryViewImage.enabled = true;
    }

    public void ViewOnOff()
    {
        if (ViewActive)
        {
            InventoryView.SetActive(false);
        }
        else
        {
            InventoryView.SetActive(true);
        }

        ViewActive = !ViewActive;
    }

    public bool ToSlot(Item item)
    {
        if (_nextSlotIndex < _slotCount)
        {
            _slot[_nextSlotIndex].Setting(item);
            _nextSlotIndex++;

            return true;
        }
        else
        {
            Debug.Log("인벤토리가 가득 차서 아이템을 획득할 수 없습니다.");

            return false;
        }
    }
}