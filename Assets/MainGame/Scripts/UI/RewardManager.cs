using System.Collections;
using TMPro;
using UnityEngine;
using YG;

public class RewardManager : MonoBehaviour
{
    [SerializeField] private TMP_Text emeraldTakeText;
    [SerializeField] private GameObject noRewardButton;
    [SerializeField] private int GiveEmerald = 10;
    private int _takeEmerald;
        
    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        _takeEmerald = GiveEmerald + StaticValue.EarnPower;
        StartCoroutine(ShowRewardButton());

    }

    public void TakeEmerald()
    {
        StaticValue.Emerald += _takeEmerald;
        PlayerPrefs.SetInt("Emerald", StaticValue.Emerald);
    }

    public void ShowReward()
    {
        YandexGame.RewVideoShow(0);
    }

    public void TakeReward()
    {
        StaticValue.Emerald += _takeEmerald * 2;
        PlayerPrefs.SetInt("Emerald", StaticValue.Emerald);
    }

    public IEnumerator ShowRewardButton()
    {
        yield return new WaitForSeconds(1f);
        noRewardButton.SetActive(true);
        emeraldTakeText.text = _takeEmerald.ToString();
    }

      
        
}