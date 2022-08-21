using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractionObject
{
    public void Interacte()
    {
        Open();
        Close();
    }

    private void Open()
    {
        Debug.Log("문이 열립니다.");
    }

    private void Close()
    {
        Debug.Log("문이 닫힙니다.");
    }
}