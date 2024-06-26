using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class StartSceneManager : MonoBehaviour
{

    // 클래스 분리

    public Button button;
    public Color targetColor = Color.red;

    public void LoadMainScene()
    {
        int num = Random.Range(1, 5);
        SceneManager.LoadScene(num);
    }

    private void Start()
    {
        button.onClick.AddListener(ChangeTextColor);
    }

    private void ChangeTextColor()
    {
        StartCoroutine(ChangeTextColorCoroutine());
    }

    private IEnumerator ChangeTextColorCoroutine()
    {
        TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();

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
    }

    // 클래스 분리
    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}
