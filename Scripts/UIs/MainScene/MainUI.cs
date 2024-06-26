using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    private PlayerStat Player;

    [Header("UtilUI")]
    [SerializeField] private GameObject buffSelectUI;
    [SerializeField] private Image leftBuffImage;
    [SerializeField] private Image rightBuffImge;
    [SerializeField] private TextMeshProUGUI leftBuffDescription;
    [SerializeField] private TextMeshProUGUI rightBuffDescription;
    [SerializeField] private Sprite[] buffImageContainer;
    [SerializeField] private string[] buffDescriptionContainer;

    [Header("InGameUI")]
    [SerializeField] private Slider distanceSlider;

    public TextMeshProUGUI ATKText;

    private EStat leftBuff;
    private EStat rightBuff;

    private int leftValue;
    private int rightValue;

    private int distanceCount;
    private int BuffCount;

    private void Start()
    {
        Player = GameManager.instance.PlayerStat;
        GameManager.instance.UpgradeEvent += AddBuffCount;
        GameManager.instance.UpgradeEvent += RandomBuff;
        GameManager.instance.SpawnMonsterEvent += UpdateSlider;
        ATKTextUpdate();

        distanceCount = -2;
    }

    private void ATKTextUpdate()
    {
        ATKText.text = Player.statDict[EStat.Atk].ToString();
    }

    private void AddBuffCount()
    {
        BuffCount++;
    }

    public void LeftStatModifier()
    {
        Player.AddStat(leftBuff, leftValue);

        if (leftBuff == EStat.Atk)
            ATKTextUpdate();

        buffSelectUI.SetActive(false);
        Time.timeScale = 1.0f;
        BuffCount--;

        if (BuffCount > 0)
            RandomBuff();

    }

    public void RightStatModifier()
    {
        Player.AddStat(rightBuff, rightValue);

        if (rightBuff == EStat.Atk)
            ATKTextUpdate();

        buffSelectUI.SetActive(false);
        Time.timeScale = 1.0f;
        BuffCount--;
        if (BuffCount > 0)
            RandomBuff();

    }

    public void RandomBuff()
    {
        List<int> stats = new List<int> { 0, 1, 2, 3, 4, 5 };
        int idx1 = Random.Range(0, stats.Count);
        leftBuff = (EStat)stats[idx1];
        stats.RemoveAt(idx1);
        int idx2 = Random.Range(0, stats.Count);
        rightBuff = (EStat)stats[idx2];


        RandomBuffValue(leftBuff, ref leftValue);
        RandomBuffValue(rightBuff, ref rightValue);

        leftBuffDescription.text = $"{buffDescriptionContainer[(int)leftBuff]} +{leftValue}";
        rightBuffDescription.text = $"{buffDescriptionContainer[(int)rightBuff]} +{rightValue}";

        leftBuffImage.sprite = buffImageContainer[(int)leftBuff];
        rightBuffImge.sprite = buffImageContainer[(int)rightBuff];

        buffSelectUI.SetActive(true);

        Time.timeScale = 0f;
    }

    private void RandomBuffValue(EStat stat, ref int value)
    {
        switch (stat)
        {
            case EStat.Hp:
                value = HPAtk();
                break;
            case EStat.Atk:
                value = HPAtk();
                break;
            case EStat.ProjectileDistance:
                value = DistanceSpeedDelay();
                break;
            case EStat.ProjectileSpeed:
                value = DistanceSpeedDelay();
                break;
            case EStat.ProjectileAmount:
                value = AmountBuff();
                break;
            case EStat.ProjectileDelay:
                value = DistanceSpeedDelay();
                break;
        }
    }

    private int HPAtk()
    {
        return Random.Range(50, 100);
    }

    private int DistanceSpeedDelay()
    {
        return Random.Range(1, 4);
    }

    private int AmountBuff()
    {
        return 1;
    }

    private void UpdateSlider()
    {
        distanceCount++;
        if (distanceCount >= 0)
            distanceSlider.value = (float)(distanceCount / 30f);

        if (distanceSlider.value == 1)
        {
            distanceCount = 0;
            distanceSlider.value = 0;
        }
    }
}