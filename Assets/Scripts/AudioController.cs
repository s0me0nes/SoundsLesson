using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{

    private readonly string[] _mixerNames =
    {
    VolumeController.MasterName,
    VolumeController.MusicName,
    VolumeController.EffectName
    };

    [SerializeField] private VolumeController _volumeController;
    [SerializeField] private Toggle _muteToggle;
    [SerializeField] private Button[] _buttons;
    [SerializeField] private AudioSource[] _sounds;
    [SerializeField] private Slider[] _sliders;


    private void OnEnable()
    {
        _muteToggle.onValueChanged.AddListener(_volumeController.OnMuteToggle);

        SubscribeButtons();
        SubscribeSliders();
    }

    private void OnDisable()
    {
        _muteToggle.onValueChanged.RemoveAllListeners();

        UnSubscribeButtons();
        UnSubscribeSliders();
    }

    private void SubscribeButtons()
    {
        if (_buttons.Length != _sounds.Length)
        {
            Debug.LogError("Забыл добавить в массив кнопку или звук");
            return;
        }

        for (int i = 0; i < _buttons.Length; i++)
        {
            int index = i;
            AudioSource sound = _sounds[index];
            _buttons[i].onClick.AddListener(() => PlaySound(sound));
        }
    }

    private void UnSubscribeButtons()
    {
        for (int i = 0; i < _buttons.Length; i++)
        {
            _buttons[i].onClick.RemoveAllListeners();
        }
    }

    private void SubscribeSliders()
    {
        if (_sliders.Length != _mixerNames.Length)
        {
            Debug.LogError("Забыл добавить в массив Слайдер или Имя микшера");
            return;
        }

        for (int i = 0; i < _sliders.Length; i++)
        {
            string name = _mixerNames[i];
            _sliders[i].onValueChanged.AddListener(value => _volumeController.SetVolume(name, value));
        }
    }

    private void UnSubscribeSliders()
    {
        for (int i = 0; i < _sliders.Length; i++)
        {
            _sliders[i].onValueChanged.RemoveAllListeners();
        }
    }

    public void PlaySound(AudioSource audioSource)
    {
        audioSource.Play();
    }
}