using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{

    public GameObject startPanel;
    public GameObject successPanel;
    public GameObject failPanel;
    public GameObject msgPanel;

    public Text levelText;
    public Text replayText;
    public Text msgText;

    public Board board;
    public LevelManager levelManager;

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
    }

    private void InitializeGame()
    {
        levelManager.LoadLevel();
        ShowStartPanel();
    }

    void ShowStartPanel()
    {
        startPanel.SetActive(true);
    }

    void LevelSuccess()
    {
        levelManager.SaveLevel();
        levelManager.currentLevel += 1;
        successPanel.SetActive(true);
    }

    void LevelFail()
    {
        failPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
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
        Debug.Log("currentLevel = " + levelManager.currentLevel.ToString());
    }

    public void GameStart()
    {
        startPanel.SetActive(false);
        replayTimes = 2;
        board.StartBoard();
    }

    public void StartNextLevel()
    {
        successPanel.SetActive(false);
        SceneManager.LoadScene(levelManager.currentLevel.ToString());
    }

    public void Resume()
    {
        failPanel.SetActive(false);
        board.ActivateStoneCollider();
    }

    void ShowLevelText()
    {
        Scene scene = SceneManager.GetActiveScene();
        levelText.text = "LEVEL " + scene.name.ToString();
    }

    public void UseReplay()
    {
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
        failPanel.SetActive(false);
    }

    public void ShowMsgClick()
    {
        msgText.text = "CLICK!";
        msgPanel.SetActive(true);
        successPanel.SetActive(false);
        failPanel.SetActive(false);
    }

}
