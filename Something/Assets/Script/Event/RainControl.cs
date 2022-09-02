using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.RainMaker;

public class RainControl : MonoBehaviour
{
    [SerializeField]
    private GameObject ControlTarget;

    void OnTriggerEnter(Collider other)
    {
        BaseRainScript rain = ControlTarget.GetComponent<BaseRainScript>();
        rain.RainIntensity = 0;
    }
}