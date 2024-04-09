using TMPro;
using UnityEngine;
using YG;

namespace UI
{
    public class RewardManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text emeraldTakeText;
        [SerializeField] private int GiveEmerald = 10;
        private int _takeEmerald;
        private void Start()
        {
          
            _takeEmerald = GiveEmerald + StaticValue.EarnPower;
            emeraldTakeText.text = _takeEmerald.ToString();
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
    }
}
