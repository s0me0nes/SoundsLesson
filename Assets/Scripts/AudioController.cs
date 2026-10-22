using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    [SerializeField] private PlayBinding[] _playBindings;
    [SerializeField] private VolumeBinding[] _volumeBindings;
    [SerializeField] private VolumeController _volumeController;
    [SerializeField] private Toggle _muteToggle;

    private void OnEnable()
    {
        _muteToggle.onValueChanged.AddListener(_volumeController.OnMuteToggle);

        SubscribeAll();
    }

    private void OnDisable()
    {
        _muteToggle.onValueChanged.RemoveAllListeners();

        UnSubscribeAll();
    }

    private void SubscribeAll()
    {
        for (int i = 0; i < _playBindings.Length; i++)
        {
            Button button = _playBindings[i].PlayButton;
            AudioSource audio = _playBindings[i].AudioSource;


            button.onClick.AddListener(() => PlaySound(audio));
        }

        for (int i = 0; i < _volumeBindings.Length; i++)
        {
            Slider volumeSlider = _volumeBindings[i].VolumeSlider;
            string name = _volumeBindings[i].MixerName;

            volumeSlider.onValueChanged.AddListener(value => _volumeController.SetVolume(name, value));
        }
    }

    private void UnSubscribeAll()
    {
        for (int i = 0; i < _playBindings.Length; i++)
        {
            _playBindings[i].PlayButton.onClick.RemoveAllListeners();
        }

        for (int i = 0; i < _volumeBindings.Length; i++)
        {
            _volumeBindings[i].VolumeSlider.onValueChanged.RemoveAllListeners();
        }
    }

    public void PlaySound(AudioSource audioSource)
    {
        audioSource.Play();
    }
}