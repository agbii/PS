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

    public Text levelText;
    public Board board;
    public LevelManager levelManager;

    public static gameManager I;

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
        ShowStartPanel();
    }

    void ShowStartPanel()
    {
        startPanel.SetActive(true);
    }

    void LevelSuccess()
    {
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
            success = board.CheckAnswer();
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
        board.StartBoard();
    }

    public void StartNextLevel()
    {
        successPanel.SetActive(false);
        SceneManager.LoadScene(levelManager.currentLevel.ToString());
    }

    void ShowLevelText()
    {
        Scene scene = SceneManager.GetActiveScene();
        levelText.text = "LEVEL " + scene.name.ToString();
    }

    void WrongAnswer()
    {

    }

}
