using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    private const string MasterName = "Master";
    private const string MusicName = "MusicVolume";
    private const string EffectName = "SFXVolume";

    private const float _volumeToDbFactor = 20;

    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private Toggle _muteToggle;

    [SerializeField] private Button _button1;
    [SerializeField] private Button _button2;
    [SerializeField] private Button _button3;

    [SerializeField] private AudioSource _sound1;
    [SerializeField] private AudioSource _sound2;
    [SerializeField] private AudioSource _sound3;

    [SerializeField] private Slider _sliderMaster;
    [SerializeField] private Slider _sliderMusic;
    [SerializeField] private Slider _sliderEffects;

    private float _minVolumeDB = -80;
    private float _maxVolumeDB = 0;

    private void OnEnable()
    {
        _muteToggle.onValueChanged.AddListener(OnMuteToogle);

        _button1.onClick.AddListener(() => PlaySound(_sound1));
        _button2.onClick.AddListener(() => PlaySound(_sound2));
        _button3.onClick.AddListener(() => PlaySound(_sound3));

        _sliderMaster.onValueChanged.AddListener(value => SetVolume(MasterName, value));
        _sliderMusic.onValueChanged.AddListener(value => SetVolume(MusicName, value));
        _sliderEffects.onValueChanged.AddListener(value => SetVolume(EffectName, value));
    }

    private void OnDisable()
    {
        _muteToggle.onValueChanged.RemoveAllListeners();

        _button1.onClick.RemoveAllListeners();
        _button2.onClick.RemoveAllListeners();
        _button3.onClick.RemoveAllListeners();

        _sliderMaster.onValueChanged.RemoveAllListeners();
        _sliderMusic.onValueChanged.RemoveAllListeners();
        _sliderEffects.onValueChanged.RemoveAllListeners();
    }

    public void PlaySound(AudioSource audioSource)
    {
        audioSource.Play();
    }

    public void OnMuteToogle(bool isOn)
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