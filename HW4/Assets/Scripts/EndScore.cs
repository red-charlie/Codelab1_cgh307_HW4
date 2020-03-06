using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScore : MonoBehaviour
{
    string playerName;
    int playerScore;
    string scoreTemplate = "CONGRATS <playerName>" + "\n\n"+
                            "YOUR SCORE IS:\n" +"<playerScore>";
    public Text endMessage;
    // Start is called before the first frame update
    void Start()
    {
        playerName = GameManager.instance.playerName;
        playerScore = GameManager.instance.Score;
        string comboString = scoreTemplate.Replace("<playerName>", playerName);
        comboString = comboString.Replace("<playerScore>" , playerScore +"");

        endMessage.text = comboString;
        GameManager.instance.UpdateHighScores();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
