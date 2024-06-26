using UnityEngine;

public class StartSceneSoundManager : MonoBehaviour
{
    public static StartSceneSoundManager instance;
    public VolumeSetting volumeSetting;
    public ObjectPool soundOP;

    [SerializeField][Range(0f, 1f)] private float soundEffectVolume;
    [SerializeField][Range(0f, 1f)] private float soundEffectPitchVariance;
    [SerializeField][Range(0f, 1f)] private float musicVolume;

    private AudioSource musicAudioSource;
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
        volumeSetting.MasterVol.value = DataManager.Instance.masterVolume;
        volumeSetting.BgmVol.value = DataManager.Instance.bgmVolume;
        volumeSetting.SFXVol.value = DataManager.Instance.sfxVolume;

        volumeSetting.SetMasterVolume(volumeSetting.MasterVol.value);
        volumeSetting.SetBgmVolume(volumeSetting.BgmVol.value);
        volumeSetting.SetSFXVolume(volumeSetting.SFXVol.value);

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
