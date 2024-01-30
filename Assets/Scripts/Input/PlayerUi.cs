using UnityEngine;
using TMPro;

public class PlayerUi : MonoBehaviour
{
  [SerializeField]  private TextMeshProUGUI text;

    

    public void TextUpdate(string mes)
    {
        text.text = mes;
    }
}
