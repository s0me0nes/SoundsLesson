using UnityEngine;
using UnityEngine.Audio;

public class VolumeController : MonoBehaviour
{
    private const float _volumeToDbFactor = 20;
    private const string _masterName = "Master";

    [SerializeField] private AudioMixerGroup _mixer;

    private float _minVolumeDB = -80;
    private float _maxVolumeDB = 0;

    public void OnMuteToggle(bool isOn)
    {
        if (isOn)
        {
            _mixer.audioMixer.SetFloat(_masterName, _maxVolumeDB);
        }
        else
        {
            _mixer.audioMixer.SetFloat(_masterName, _minVolumeDB);
        }
    }

    public void SetVolume(string label, float volume)
    {
        _mixer.audioMixer.SetFloat(label, Mathf.Log10(volume) * _volumeToDbFactor);
    }
}