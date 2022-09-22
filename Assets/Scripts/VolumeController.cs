using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Updates the volume
/// </summary>
public class VolumeController : MonoBehaviour
{
    [SerializeField] Slider _volumeSlider;

    /// <summary>
    /// Adjusts volume based on the volume slider being dragged
    /// </summary>
    public void OnVolumeChanged()
    {
        AudioListener.volume = _volumeSlider.value;
    }
}
