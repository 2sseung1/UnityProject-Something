using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Door Data", menuName = "Data/Door Data")]
public class DoorData : ScriptableObject
{
    public Sprite Image;
    public AudioClip OpenSound;
    public AudioClip CloseSound;
    public AudioClip LockSound;
    public AudioClip UnlockSound;
}