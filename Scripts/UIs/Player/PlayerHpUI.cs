using TMPro;
using UnityEngine;

public class PlayerHpUI : MonoBehaviour
{
    private TextMeshProUGUI hpText;

    private void Awake()
    {
        hpText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        HpTextUpdate();
    }

    public void HpTextUpdate()
    {
        hpText.text = GameManager.instance.PlayerStat.statDict[EStat.Hp].ToString();
    }
}
