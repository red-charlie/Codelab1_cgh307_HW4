using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public Text playerNameInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitGame()
    {
        //this quits the game
        Application.Quit();
    }

    public void startGame ()
    {
        //this starts the game
        SceneManager.LoadScene("Game");
        GameManager.instance.gameStart();
    }

    public void mainMenu()
    {
        //this loads the main menu
        SceneManager.LoadScene("MainMenu");
        GameManager.instance.Reset();
    }

    public void changePlayerName()
    {
        string newName = "Greg";
        if (playerNameInput.text != "")
        {
            newName = playerNameInput.text;
        }
        
        
        GameManager.instance.playerNameChange(newName);
    }
   
}
