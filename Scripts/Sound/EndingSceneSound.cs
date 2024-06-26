using UnityEngine;

public class EndingSceneSound : MonoBehaviour
{
    public static EndingSceneSound instance;
    public VolumeSetting volumeSetting;

    [SerializeField][Range(0f, 1f)] public float soundEffectVolume;
    [SerializeField][Range(0f, 1f)] public float soundEffectPitchVariance;
    [SerializeField][Range(0f, 1f)] public float musicVolume;

    public AudioSource musicAudioSource;
    public AudioClip musicClip;

    private void Awake()
    {
        instance = this;
        volumeSetting = GetComponent<VolumeSetting>();
        musicAudioSource = GetComponent<AudioSource>();
        musicAudioSource.loop = true;
    }

    private void Start()
    {
        ChangeBackGroundMusic(musicClip);
    }

    private void ChangeBackGroundMusic(AudioClip musicClip)
    {
        instance.musicAudioSource.Stop();
        instance.musicAudioSource.clip = musicClip;
        instance.musicAudioSource.Play();
    }
}

