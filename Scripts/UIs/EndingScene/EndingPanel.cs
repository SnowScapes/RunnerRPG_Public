using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingPanel : MonoBehaviour
{
    public TextMeshProUGUI curScore;
    public TextMeshProUGUI bestScore;

    public Animator anim;

    public void Retry()
    {
        int num = Random.Range(1, 5);
        SceneManager.LoadScene(num);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void OnEnable()
    {
        curScore.text = DataManager.Instance.curScore.ToString();
        bestScore.text = DataManager.Instance.bestScore.ToString();

        if (DataManager.Instance.curScore == DataManager.Instance.bestScore)
            anim.SetTrigger("IsNewRecord");
    }

}
