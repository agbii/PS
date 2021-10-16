using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{

    public GameObject startPanel;
    public GameObject successPanel;
    public GameObject msgPanel;
    public GameObject pausePanel;

    public Text levelText;
    public Text replayText;
    public Text msgText;

    public Board board;
    public LevelManager levelManager;

    bool showPause;

    

    public static gameManager I;

    public int replayTimes;

    bool success;

    void Awake()
    {
        I = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        ShowLevelText();
        InitializeGame();
        showPause = false;
    }

    private void InitializeGame()
    {
        Debug.Log("loaded once");
        ShowStartPanel();
    }

    void ShowStartPanel()
    {
        startPanel.SetActive(true);
    }

    void LevelSuccess()
    {
        if(levelManager.currentLevel != levelManager.lastLevel)
        {
            levelManager.currentLevel += 1;
            levelManager.SaveLevel();
            successPanel.SetActive(true);
        }
        else
        {
            ShowMsgCongrats();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("currentLevel = " + levelManager.currentLevel.ToString());
        if (board.clickCount == board.answerCount)
        {
            msgPanel.SetActive(false);
            success = board.CheckAnswer();
            board.DeactivateStoneCollider();
            if(success)
            {
                LevelSuccess();
            }
            else
            {
                LevelFail();
            }
            board.clickCount = 0;
        }
    }

    public void GameStart()
    {
        startPanel.SetActive(false);
        replayTimes = 1;
        board.StartBoard();
    }

    public void StartNextLevel()
    {
        SceneManager.LoadScene("Game");
        successPanel.SetActive(false);
    }

    public void Resume()
    {
        msgPanel.SetActive(false);
        board.ActivateStoneCollider();
    }

    void ShowLevelText()
    {
        levelText.text = "LEVEL " + levelManager.currentLevel;
    }

    public void UseReplay()
    {
        board.Reset();
        board.ActivateStoneCollider();
        if (replayTimes > 0)
        {
            replayTimes -= 1;
            Debug.Log("replayTimes = " + replayTimes.ToString());
            if(replayTimes != 0)
            {
                replayText.text = replayTimes.ToString();
            }
            else
            {
                replayText.text = "AD";
            }
            board.Reset();
            board.ActivateStoneCollider();
        }
    }

    public void ShowMsgRemember()
    {
        msgText.text = "REMEMBER!";
        msgPanel.SetActive(true);
        successPanel.SetActive(false);
    }

    public void ShowMsgClick()
    {
        msgText.text = "CLICK!";
        msgPanel.SetActive(true);
        successPanel.SetActive(false);
    }

    public void ShowMsgCongrats()
    {
        msgText.text = "YOU WON!";
        msgPanel.SetActive(true);
        successPanel.SetActive(false);
    }

    void LevelFail()
    {
        msgText.text = "WRONG!";
        board.ActivateStoneCollider();
        msgPanel.SetActive(true);
        successPanel.SetActive(false);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("Game");
    }
    
    public void TogglePausePanel()
    {
        if(showPause)
        {
            showPause = false;
            pausePanel.SetActive(true);
        }
        else
        {
            showPause = true;
            pausePanel.SetActive(false);
        }
    }

}
