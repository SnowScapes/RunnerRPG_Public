using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSetting : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;

    [SerializeField] public Slider MasterVol;
    [SerializeField] public Slider BgmVol;
    [SerializeField] public Slider SFXVol;

    [SerializeField] private float muteThreshold = -40f;
    [SerializeField] private float muteVolume = -80f;

    private void Start()
    {
        MasterVol.onValueChanged.AddListener(SetMasterVolume);
        BgmVol.onValueChanged.AddListener(SetBgmVolume);
        SFXVol.onValueChanged.AddListener(SetSFXVolume);

    }

    public void SetMasterVolume(float volume)
    {
        if (volume <= muteThreshold)
        {
            _audioMixer.SetFloat("Master", muteVolume);

        }
        else
        {
            _audioMixer.SetFloat("Master", volume);
        }
    }

    public void SetBgmVolume(float volume)
    {
        if (volume <= muteThreshold)
        {
            _audioMixer.SetFloat("BGM", muteVolume);

        }
        else
        {
            _audioMixer.SetFloat("BGM", volume);
        }
    }

    public void SetSFXVolume(float volume)
    {
        if (volume <= muteThreshold)
        {
            _audioMixer.SetFloat("SFX", muteVolume);
        }
        else
        {
            _audioMixer.SetFloat("SFX", volume);
        }
    }
}