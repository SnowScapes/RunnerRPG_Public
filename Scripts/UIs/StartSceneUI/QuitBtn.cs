using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuitBtn : MonoBehaviour
{
    public Button quitButton;
    public Color targetColor = Color.red;

    private void Start()
    {
        quitButton.onClick.AddListener(ChangeTextColor);
    }

    private void ChangeTextColor()
    {
        StartCoroutine(ChangeTextColorCoroutine());
    }

    private IEnumerator ChangeTextColorCoroutine()
    {
        TextMeshProUGUI buttonText = quitButton.GetComponentInChildren<TextMeshProUGUI>();

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


    public void OApplicationQuit()
    {
        Application.Quit();
    }
}
