using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionBtn : MonoBehaviour
{
    public Button optionButton;
    public GameObject optionPanel;
    public Color targetColor = Color.red;

    public Slider masterVol;
    public Slider bgmVol;
    public Slider sfxVol;

    private void Start()
    {
        optionButton.onClick.AddListener(ChangeTextColor);

        masterVol.value = DataManager.Instance.playerData.masterVolume;
        bgmVol.value = DataManager.Instance.playerData.bgmVolume;
        sfxVol.value = DataManager.Instance.playerData.sfxVolume;
    }

    private void ChangeTextColor()
    {
        StartCoroutine(ChangeTextColorCoroutine());
    }

    private IEnumerator ChangeTextColorCoroutine()
    {
        TextMeshProUGUI buttonText = optionButton.GetComponentInChildren<TextMeshProUGUI>();

        Color baseColor = buttonText.color;

        if (buttonText != null)
        {
            buttonText.color = targetColor;
        }

        yield return new WaitForSeconds(0.1f);

        if (buttonText != null)
        {
            buttonText.color = baseColor;
        }

        yield return null;
    }


    public void OnOptionPanel()
    {
        optionPanel.SetActive(true);
    }

    public void OffOptionPanel()
    {
        optionPanel.SetActive(false);

        DataManager.Instance.masterVolume = masterVol.value;
        DataManager.Instance.bgmVolume = bgmVol.value;
        DataManager.Instance.sfxVolume = sfxVol.value;

        DataManager.Instance.OnSaveData();
    }
}
