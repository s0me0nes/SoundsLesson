using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    [SerializeField] private PlayBinding[] _playBindings;
    [SerializeField] private VolumeBinding[] _volumeBindings;
    [SerializeField] private VolumeToggle _volumeController;
    [SerializeField] private Toggle _muteToggle;

    private void OnEnable()
    {
        _volumeController.SubscribeMute(_muteToggle);

        for (int i = 0; i < _playBindings.Length; i++)
        {
            _playBindings[i].Subscribe();
        }

        for (int i = 0; i < _volumeBindings.Length; i++)
        {
            _volumeBindings[i].Subscribe(_volumeController);
        }
    }

    private void OnDisable()
    {
        _volumeController.UnsubscribeMute(_muteToggle);

        for (int i = 0; i < _playBindings.Length; i++)
        {
            _playBindings[i].Unsubscribe();
        }

        for (int i = 0; i < _volumeBindings.Length; i++)
        {
            _volumeBindings[i].Unsubscribe();
        }
    }
}
