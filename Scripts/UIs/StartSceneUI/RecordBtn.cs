using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecordBtn : MonoBehaviour
{
    public Button recordButton;
    public GameObject recordPanel;
    public Color targetColor = Color.red;
    public TextMeshProUGUI recordTxt;

    private void Start()
    {
        recordButton.onClick.AddListener(ChangeTextColor);
        recordTxt = recordPanel.GetComponentInChildren<TextMeshProUGUI>();
    }

    private void ChangeTextColor()
    {
        StartCoroutine(ChangeTextColorCoroutine());
    }

    private IEnumerator ChangeTextColorCoroutine()
    {
        TextMeshProUGUI buttonText = recordButton.GetComponentInChildren<TextMeshProUGUI>();

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


    public void OnRecordPanel()
    {
        recordTxt.text = DataManager.Instance.bestScore.ToString();
        recordPanel.SetActive(true);
    }

    public void OffRecordPanel()
    {
        recordPanel.SetActive(false);
    }
}
