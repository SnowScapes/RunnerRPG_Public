using UnityEngine;

public class SoundSource : MonoBehaviour
{
    private AudioSource audioSource;
    private bool isPlaying = false;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        if (isPlaying)
        {
            Play(GameSceneSoundManager.instance.shotClip, GameSceneSoundManager.instance.soundEffectVolume, GameSceneSoundManager.instance.soundEffectPitchVariance);
        }
        else
        {
            isPlaying = true;
        }
    }

    public void Play(AudioClip clip, float soundEffectVolume, float soundEffectPitchVariance)
    {
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();

        CancelInvoke();
        audioSource.clip = clip;
        audioSource.volume = soundEffectVolume;
        audioSource.Play();
        audioSource.pitch = 1f + Random.Range(-soundEffectPitchVariance, soundEffectPitchVariance);
    }

    public void Disable()
    {
        audioSource.Stop();
        gameObject.SetActive(false);
    }
}
