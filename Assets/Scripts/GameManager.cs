using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject spawner;
    [SerializeField] GameObject menuStart;
    [SerializeField] GameObject menuGameOver;
    [SerializeField] GameObject menuPowerButton;
    [SerializeField] TextMesh money;
    [SerializeField] TextMesh nbH;
    [SerializeField] TextMesh nbN;
    public enum State
    {
        Begining,
        InGame,
        GameOver,
    }
    public State gameState = State.Begining;

    public void StartGame()
    {
        gameState = State.InGame;
        spawner.SetActive(true);
        menuPowerButton.SetActive(true);
        menuStart.SetActive(false);

    }

    private void Update()
    {
        if(gameState == State.Begining)
        {
            money.text =PlayerPrefs.GetInt("£") + "£".ToString();
        }
        nbH.text = PlayerPrefs.GetInt("PH").ToString();
        nbN.text = PlayerPrefs.GetInt("PN").ToString();
    }

    public void GameOver()
    {
        gameState = State.GameOver;
        menuGameOver.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("GameLevel");
    }
}
