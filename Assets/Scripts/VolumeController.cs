using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController : MonoBehaviour
{
    public void OnVolumeChanged()
    {
        Debug.Log("volume slider changed");
    }
}
