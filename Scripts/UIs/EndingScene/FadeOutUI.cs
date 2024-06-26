using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeOutUI : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI text;

    private void Start()
    {
        GameManager.instance.Player.DieEvent += StartCo;
        gameObject.SetActive(false);
    }

    public void StartCo()
    {
        gameObject.SetActive(true);
        StartCoroutine(FadeOutCo());
    }

    IEnumerator FadeOutCo()
    {
        Color imageColor = image.color;
        Color textColor = text.color;
        float a = 0f;

        while (a < 1f)
        {
            a += Time.deltaTime;
            imageColor.a = a;
            textColor.a = a;
            image.color = imageColor;
            text.color = textColor;
            yield return null;
        }

        SceneManager.LoadScene(5);
    }
    
}
