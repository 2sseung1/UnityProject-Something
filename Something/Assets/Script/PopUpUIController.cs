using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpUIController : MonoBehaviour
{
    public ObjectChecker ObjectChecker;

    [SerializeField]
    private Image AimImage;
    [SerializeField]
    private Sprite IdleAimImage;

    void Update()
    {
        if (ObjectChecker.ObjectDetect)
        {
            if (ObjectChecker.HitInfo.collider.tag == "InteractionObject")
            {

            }
        }
    }
}