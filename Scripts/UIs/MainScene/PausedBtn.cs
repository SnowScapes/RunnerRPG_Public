using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PausedBtn : MonoBehaviour
{
    public GameObject pausedPanel;
    public Slider masterSlider;
    public Slider bgmSlider;
    public Slider sfxSlider;

    private void Start()
    {
        masterSlider.value = DataManager.Instance.masterVolume;
        bgmSlider.value = DataManager.Instance.bgmVolume;
        sfxSlider.value = DataManager.Instance.sfxVolume;
    }

    public void PausedButton()
    {
        Time.timeScale = 0f;
        pausedPanel.SetActive(true);
    }

    public void ResumeButton()
    {
        Time.timeScale = 1f;
        pausedPanel.SetActive(false);

        DataManager.Instance.masterVolume = masterSlider.value;
        DataManager.Instance.bgmVolume = bgmSlider.value;
        DataManager.Instance.sfxVolume = sfxSlider.value;

        DataManager.Instance.OnSaveData();
    }

    public void LobbyButton()
    {
        DataManager.Instance.masterVolume = masterSlider.value;
        DataManager.Instance.bgmVolume = bgmSlider.value;
        DataManager.Instance.sfxVolume = sfxSlider.value;

        DataManager.Instance.OnSaveData();

        // 게임 시작 화면으로 이동
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

}
