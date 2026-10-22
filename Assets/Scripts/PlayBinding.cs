using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class PlayBinding
{
    public Button PlayButton;
    public AudioSource AudioSource;

    public void Subscribe()
    {
        PlayButton.onClick.AddListener(Play);
    }

    public void Unsubscribe()
    {
        PlayButton.onClick.RemoveListener(Play);
    }

    private void Play()
    {
        AudioSource.Play();
    }
}
