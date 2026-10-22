using System;
using UnityEngine.UI;

[Serializable]
public class VolumeBinding
{
    public string MixerName;
    public Slider VolumeSlider;

    private VolumeToggle _volumeToggle;

    public void Subscribe(VolumeToggle volumeToggle)
    {
        _volumeToggle = volumeToggle;
        VolumeSlider.onValueChanged.AddListener(OnVolumeChanged);
    }

    public void Unsubscribe()
    {
        VolumeSlider.onValueChanged.RemoveListener(OnVolumeChanged);
    }

    private void OnVolumeChanged(float value)
    {
        _volumeToggle.SetVolume(MixerName, value);
    }
}
