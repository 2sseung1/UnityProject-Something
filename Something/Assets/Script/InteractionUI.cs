using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(ObjectChecker))]
public class InteractionUI : MonoBehaviour
{
    public InteractionData Data;
    public GameObject InteractionAimScreen;
    public GameObject InteractionMessageScreen;

    private ObjectChecker _checker;
    private Image _aim;
    private TextMeshProUGUI _interactionMessage;

    void Awake()
    {
        _checker = GetComponent<ObjectChecker>();
        _aim = InteractionAimScreen.GetComponent<Image>();
        _interactionMessage = InteractionMessageScreen.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        _aim.sprite = Data.GetIdleAim;
        _interactionMessage.text = "";

        if (_checker.ObjectCheck())
        {
            if (_checker.HitInfo.collider.tag == "Door")
            {
                _aim.sprite = Data.GetDoorAim;

                Door door = _checker.HitInfo.collider.GetComponent<Door>();

                switch (door.GetDoorState)
                {
                    case Door.State.Open:
                        _interactionMessage.text = Data.GetCloseDoorMessage;
                        break;

                    case Door.State.Close:
                        _interactionMessage.text = Data.GetOpenDoorMessage;
                        break;

                    case Door.State.Lock:
                        _interactionMessage.text = Data.GetLockDoorMessage;
                        break;
                }
            }
            else if (_checker.HitInfo.collider.tag == "Item")
            {
                _aim.sprite = Data.GetPickUpItemAim;
                _interactionMessage.text = Data.GetPickUpItemMessage;
            }
        }
    }
}