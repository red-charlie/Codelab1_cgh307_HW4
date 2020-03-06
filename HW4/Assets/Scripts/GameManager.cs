using System.Collections;
using System.IO; //literally forgot this and spend a long time trying to figure out why "File" did not exist in the current context
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //hw4 game manager script

    #region variables
    public static GameManager instance;

    public int timerAmt = 30;
    public int timer = 30; //the timer for the game
    Text timerText;

    Text scoreText;



    
    bool isPlaying = false; //whether or not we are playing the game

    public string playerName = "Greg"; //the player name

    private const string FILE_HS_LIST = "/CodeLab1-s2020-HighScores-shopping.txt"; //the txt file that stores the highscore lists

    public List<string> highScoreNames; //the lists containing the different names and scores that are at the top
    public List<float> highScoreScores;

    #endregion

    #region Property stuff - score highscores etc

    private int score = 1;
    public int Score
    {
        get
        {
            return score; //this thing is the current score
        }

        set
        {
            score = value; //set score to whatever value you passed through it from elsewhere
            if (score > 0)
            {
                scoreText.text = "" + score;
            }
        }
    }


    #endregion

    private void Awake()
    {
        if (instance == null)//if there isn't one
        {
            instance = this; //set instance to me
            DontDestroyOnLoad(gameObject); //keep it around
        }
        else
        { //there can only be ONE
            Destroy(gameObject);
        }
    }

    void Start()
    {
        highScoreNames = new List<string>(); //the list of names I'm makin'
        highScoreScores = new List<float>();  //the list of scores I'm makin'

        if (File.Exists(Application.dataPath + FILE_HS_LIST)) // if the file has already been made
        {
            string fileContents = File.ReadAllText(Application.dataPath + FILE_HS_LIST); //read the text in the file
            string[] scorePairs = fileContents.Split('\n'); //split it on the new line

            for (int i = 0; i < scorePairs.Length; i++) //go through each one
            {
                string[] nameScores = scorePairs[i].Split(' '); //split on the space
                highScoreNames.Add(nameScores[0]); //add the names
                Debug.Log("Igot this far");
                highScoreScores.Add(float.Parse(nameScores[1])); //parse and add the scores
            }
        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                highScoreNames.Add("Frank");
                highScoreScores.Add(100 - i * 10);
            }
        }


       
    }

    private void Update()
    {
        if(timerAmt <= 0)
        {
            timerAmt = 0;
            gameEnd();

           
        }
    }
    public void UpdateHighScores()
    {
        bool newScore = false; //create a new score variable to test against

        for (int i = 0; i < highScoreScores.Count; i++)
        {
            if (highScoreScores[i] < Score)
            {
                highScoreScores.Insert(i, Score); //use the score
                highScoreNames.Insert(i, playerName); //use the player name
                newScore = true;
                break;
            }

            if (newScore)
            {
                highScoreScores.RemoveAt(highScoreScores.Count - 1); //remove the last score
                highScoreNames.RemoveAt(highScoreNames.Count - 1); //remove the last name


            }


        }
        string fileContents = "";

        for (int i = 0; i < highScoreNames.Count; i++) //
        {
            if (i < highScoreNames.Count - 1) {
                fileContents += highScoreNames[i] + " " + highScoreScores[i] + "\n";
                    }
            else
            {
                fileContents += highScoreNames[i] + " " + highScoreScores[i];
            }
        }

        File.WriteAllText(Application.dataPath + FILE_HS_LIST, fileContents);

    }

    public void Reset() //reset the game 
    {
        timerAmt = timer;
        score = 0;


    }

    public void gameStart()
    {
        Invoke("findText", .5f);

        if (timerAmt >= 0) {
            InvokeRepeating("timerTick", 1, 1);
                }
    }

    public void findText()
    {
        GameObject timerTextOBJ = GameObject.Find("Timer");
        timerText = timerTextOBJ.GetComponent<Text>();

        GameObject scoreTextOBJ = GameObject.Find("Current score");
        scoreText = scoreTextOBJ.GetComponent<Text>();
    }
    public void timerTick()
    {
        timerAmt--;
        Debug.Log("Current timer amount: " + timerAmt);
        timerText.text = "" + timerAmt;
    }

    public void gameEnd()
    {
        
        Debug.Log("I have recalculated the highscores");
        SceneManager.LoadScene("EndScoreScreen");
        timerAmt = 30;

    }

    public void playerNameChange(string nameInput)
    {
        playerName = nameInput;
        Debug.Log("The New player name is " + playerName);
    }
}