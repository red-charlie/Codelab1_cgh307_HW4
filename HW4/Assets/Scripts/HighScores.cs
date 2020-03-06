using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScores : MonoBehaviour
{
    #region variables
    public Text highScores; //the text object where i fill the scores
    public string textTemplate = "HIGH SCORES :" +
                                 "\n\n" + "1. <highscores>"; //the text template to fill them
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        
        string highScoreString = "";
        
        

        List<string> hsNames = GameManager.instance.highScoreNames; //get the names
        List<float>  hsScore = GameManager.instance.highScoreScores; //get the scores!

        for (int i = 0; i < hsNames.Count; i++) //okay for loops -- go thru the names
        {
            highScoreString += hsNames[i] + "       "; // split with several spaces
            if (i < (hsNames.Count -1))
            {
                highScoreString += hsScore[i] + "\n" + (i + 2) + ". ";    // and a line break and a number
            }
            else
            {
                highScoreString += hsScore[i] + "\n";    // and a line break no number
            }

        }

        string displayText = textTemplate.Replace("<highscores>", highScoreString); //replace what you got with what I made
        highScores.text = displayText; //put it in the text stuff

    }

    
}
