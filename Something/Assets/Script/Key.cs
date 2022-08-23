using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Item
{
    public int GetValue { get { return Value; } }

    [SerializeField]
    private int Value;
}