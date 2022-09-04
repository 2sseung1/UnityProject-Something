using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpMessage : MonoBehaviour
{
    [SerializeField]
    private UIManager _UIManager;
    [SerializeField]
    private string text;

    void OnTriggerEnter(Collider other)
    {
        _UIManager.StartPopUp(5, text);
    }
}