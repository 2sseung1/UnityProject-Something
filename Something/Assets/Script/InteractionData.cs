using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InteractionData", menuName = "Data/Interaction")]
public class InteractionData : ScriptableObject
{
    public Sprite GetIdleAim { get { return IdleAim; } }
    public Sprite GetDoorAim { get { return DoorAim; } }
    public Sprite GetPickUpItemAim { get { return PickUpItemAim; } }

    public string GetOpenDoorMessage { get { return OpenDoorMessage; } }
    public string GetCloseDoorMessage { get { return CloseDoorMessage; } }
    public string GetPickUpItemMessage { get { return PickUpItemMessage; } }

    [SerializeField]
    private Sprite IdleAim;
    [SerializeField]
    private Sprite DoorAim;
    [SerializeField]
    private Sprite PickUpItemAim;

    [SerializeField]
    private string OpenDoorMessage;
    [SerializeField]
    private string CloseDoorMessage;
    [SerializeField]
    private string PickUpItemMessage;
}