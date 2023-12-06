using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CheatCode : MonoBehaviour
{
    public TextMeshProUGUI etx;
    public TMP_InputField cheat;
    public GameObject health;
    public ScoreScripts score;
    public TextMeshProUGUI coinText;

   
    public void SetCheat()
    {
        if(cheat.text == "giveheal")
        {
            health.SendMessage("AddHealthCheat");
        }
        if(cheat.text == "giveenergry")
        {
            health.SendMessage("AddEnergryCheat");
        }
        if(cheat.text == "givescore")
        {
            score.SendMessage("ScoreCheat");
        }
        if(cheat.text == "givedamage")
        {
            coinText.SendMessage("AddDamageCheat");
        }
    }
}
