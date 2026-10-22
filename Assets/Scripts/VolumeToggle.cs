using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeToggle : MonoBehaviour
{
    private const float VolumeToDbFactor = 20f;
    private const string MasterName = "Master";

    [SerializeField] private AudioMixerGroup _mixer;

    private float _minVolumeDB = -80f;
    private float _maxVolumeDB = 0f;

    public void SubscribeMute(Toggle muteToggle)
    {
        muteToggle.onValueChanged.AddListener(ToggleMute);
    }

    public void UnsubscribeMute(Toggle muteToggle)
    {
        muteToggle.onValueChanged.RemoveListener(ToggleMute);
    }

    public void ToggleMute(bool isOn)
    {
        float volumeDb = isOn ? _maxVolumeDB : _minVolumeDB;
        _mixer.audioMixer.SetFloat(MasterName, volumeDb);
    }

    public void SetVolume(string label, float volume)
    {
        float volumeDb = Mathf.Log10(Mathf.Clamp(volume, 0.0001f, 1f)) * VolumeToDbFactor;
        _mixer.audioMixer.SetFloat(label, volumeDb);
    }
}
