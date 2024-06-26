using UnityEngine;

public class GameSceneSoundManager : MonoBehaviour
{
    public static GameSceneSoundManager instance;
    public VolumeSetting volumeSetting;
    public ObjectPool soundOP;

    [SerializeField][Range(0f, 1f)] public float soundEffectVolume;
    [SerializeField][Range(0f, 1f)] public float soundEffectPitchVariance;
    [SerializeField][Range(0f, 1f)] public float musicVolume;

    public AudioSource musicAudioSource;
    public AudioClip musicClip;
    public AudioClip shotClip;

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

    public static void PlayClip(AudioClip musicClip)
    {
        GameObject obj = instance.soundOP.SpawnFromPool("SoundSource");
        SoundSource soundSource = obj.GetComponent<SoundSource>();
        soundSource.Play(musicClip, instance.soundEffectVolume, instance.soundEffectPitchVariance);
    }


    public void SetVolume(float volume)
    {
        musicAudioSource.volume = volume;          // 오디오 소스의 볼륨을 슬라이더의 값으로 설정
    }
}
