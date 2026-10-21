using UnityEngine;
using UnityEngine.Audio;

public class VolumeController : MonoBehaviour
{
    public const string MasterName = "Master";
    public const string MusicName = "MusicVolume";
    public const string EffectName = "SFXVolume";

    private const float _volumeToDbFactor = 20;

    [SerializeField] private AudioMixerGroup _mixer;

    private float _minVolumeDB = -80;
    private float _maxVolumeDB = 0;

    public void OnMuteToggle(bool isOn)
    {
        if (isOn)
        {
            _mixer.audioMixer.SetFloat(MasterName, _maxVolumeDB);
        }
        else
        {
            _mixer.audioMixer.SetFloat(MasterName, _minVolumeDB);
        }
    }

    public void SetVolume(string label, float volume)
    {
        _mixer.audioMixer.SetFloat(label, Mathf.Log10(volume) * _volumeToDbFactor);
    }
}
