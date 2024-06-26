using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialUI : MonoBehaviour
{
    [SerializeField] private List<GameObject> tutorialPanels;
    [SerializeField] private Button next;
    [SerializeField] private Button prev;
    
    private int tutorialIndex = 0;

    private void OnEnable()
    {
        tutorialIndex = 0;
        tutorialPanels[tutorialIndex].SetActive(true);
        prev.gameObject.SetActive(false);
        next.gameObject.SetActive(true);
    }

    public void CloseButton()
    {
        gameObject.SetActive(false);
        tutorialPanels[tutorialIndex].SetActive(false);
    }

    public void NextButton()
    {
        tutorialIndex += 1;
        
        if (tutorialIndex+1 >= tutorialPanels.Count)
        {
            next.gameObject.SetActive(false);
        }
        else
        {
            next.gameObject.SetActive(true);
        }

        if (!prev.gameObject.activeInHierarchy)
        {
            prev.gameObject.SetActive(true);
        }
        
        tutorialPanels[tutorialIndex-1].SetActive(false);
        tutorialPanels[tutorialIndex].SetActive(true);
    }

    public void PrevButton()
    {
        tutorialIndex -= 1;
        
        if (tutorialIndex <= 0)
        {
            prev.gameObject.SetActive(false);
        }
        else
        {
            prev.gameObject.SetActive(true);
        }
        
        if (!next.gameObject.activeInHierarchy)
        {
            next.gameObject.SetActive(true);
        }

        tutorialPanels[tutorialIndex+1].SetActive(false);
        tutorialPanels[tutorialIndex].SetActive(true);
    }
}
