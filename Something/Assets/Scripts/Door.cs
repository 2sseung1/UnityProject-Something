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
        Debug.Log("���� �����ϴ�.");
    }

    private void Close()
    {
        Debug.Log("���� �����ϴ�.");
    }
}