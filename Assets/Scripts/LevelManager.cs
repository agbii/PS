using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class LevelManager : MonoBehaviour
{
    public Board board;
    public int currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        currentLevel = int.Parse(scene.name);
        Debug.Log("Current Level : " + currentLevel.ToString());

        if(currentLevel == 1)
        {
            board.answerCount = 1;
            board.quizCount = 1;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 0;
        }
        else if (currentLevel == 2)
        {
            board.answerCount = 2;
            board.quizCount = 1;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 0;
        }
        else if (currentLevel == 3)
        {
            board.answerCount = 1;
            board.quizCount = 2;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 0;
            board.quizzes[1] = 2;
        }
        else if (currentLevel == 4)
        {
            board.answerCount = 2;
            board.quizCount = 2;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 1;
            board.quizzes[1] = 3;
        }
        else if (currentLevel == 49)
        {
            board.answerCount = 4;
            board.quizCount = 2;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 1;
            board.quizzes[1] = 3;
        }
        else if (currentLevel == 99)
        {
            board.answerCount = 4;
            board.quizCount = 3;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 3;
            board.quizzes[1] = 1;
            board.quizzes[2] = 2;
        }
        else
        {
            Debug.Log("Level not defined");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveLevel()
    {
        PlayerPrefs.SetInt("levelSave", currentLevel+1);
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("levelSave", "LEVEL 1"));
    }

    public void DeleteStones()
    {
        
    }
}
