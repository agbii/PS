using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class LevelManager : MonoBehaviour
{
    public Board board;
    public int currentLevel;
    public int lastLevel;
    
    // Start is called before the first frame update
    void Start()
    {
        currentLevel = PlayerPrefs.GetInt("saveLevel");
        if(currentLevel == 0)
        {
            currentLevel += 1;
        }
        lastLevel = 33;
        Debug.Log("Current Level : " + currentLevel.ToString());

        if(currentLevel == 1)
        {
            board.answerCount = 1;
            board.quizCount = 1;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 2;
        }
        else if (currentLevel == 2)
        {
            board.answerCount = 1;
            board.quizCount = 1;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 3;
        }
        else if (currentLevel == 3)
        {
            board.answerCount = 1;
            board.quizCount = 1;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 0;
        }
        else if (currentLevel == 4)
        {
            board.answerCount = 1;
            board.quizCount = 1;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 1;
        }
        
        else if (currentLevel == 5)
        {
            board.answerCount = 1;
            board.quizCount = 1;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 2;
        }
        else if (currentLevel == 6)
        {
            board.answerCount = 1;
            board.quizCount = 1;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 3;
        }
        else if (currentLevel == 7)
        {
            board.answerCount = 1;
            board.quizCount = 1;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 0;
        }
        else if (currentLevel == 8)
        {
            board.answerCount = 1;
            board.quizCount = 1;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 1;
        }
        else if (currentLevel == 9)
        {
            board.answerCount = 1;
            board.quizCount = 2;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 0;
            board.quizzes[1] = 3;
        }
        else if (currentLevel == 10)
        {
            board.answerCount = 1;
            board.quizCount = 2;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 1;
            board.quizzes[1] = 2;
        }
        else if (currentLevel == 11)
        {
            board.answerCount = 1;
            board.quizCount = 2;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 2;
            board.quizzes[1] = 0;
        }
        else if (currentLevel == 12)
        {
            board.answerCount = 1;
            board.quizCount = 2;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 3;
            board.quizzes[1] = 1;
        }
        else if (currentLevel == 13)
        {
            board.answerCount = 1;
            board.quizCount = 3;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 1;
            board.quizzes[1] = 2;
            board.quizzes[2] = 1;
        }
        else if (currentLevel == 14)
        {
            board.answerCount = 1;
            board.quizCount = 3;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 3;
            board.quizzes[1] = 0;
            board.quizzes[2] = 2;
        }
        else if (currentLevel == 15)
        {
            board.answerCount = 1;
            board.quizCount = 4;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 1;
            board.quizzes[1] = 3;
            board.quizzes[2] = 0;
            board.quizzes[3] = 2;
        }
        else if (currentLevel == 16)
        {
            board.answerCount = 1;
            board.quizCount = 4;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 3;
            board.quizzes[1] = 1;
            board.quizzes[2] = 2;
            board.quizzes[3] = 3;
        }
        else if (currentLevel == 17)
        {
            board.answerCount = 1;
            board.quizCount = 4;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 0;
            board.quizzes[1] = 2;
            board.quizzes[2] = 0;
            board.quizzes[3] = 3;
        }
        else if (currentLevel == 18)
        {
            board.answerCount = 2;
            board.quizCount = 1;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 2;
        }
        else if (currentLevel == 19)
        {
            board.answerCount = 2;
            board.quizCount = 1;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 3;
        }
        else if (currentLevel == 20)
        {
            board.answerCount = 2;
            board.quizCount = 1;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 0;
        }
        else if (currentLevel == 21)
        {
            board.answerCount = 2;
            board.quizCount = 1;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 1;
        }
        else if (currentLevel == 22)
        {
            board.answerCount = 2;
            board.quizCount = 2;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 0;
            board.quizzes[1] = 3;
        }
        else if (currentLevel == 23)
        {
            board.answerCount = 2;
            board.quizCount = 2;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 1;
            board.quizzes[1] = 2;
        }
        else if (currentLevel == 24)
        {
            board.answerCount = 2;
            board.quizCount = 2;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 2;
            board.quizzes[1] = 0;
        }
        else if (currentLevel == 25)
        {
            board.answerCount = 2;
            board.quizCount = 2;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 3;
            board.quizzes[1] = 1;
        }
        else if (currentLevel == 26)
        {
            board.answerCount = 2;
            board.quizCount = 3;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 1;
            board.quizzes[1] = 2;
            board.quizzes[2] = 1;
        }
        else if (currentLevel == 27)
        {
            board.answerCount = 2;
            board.quizCount = 3;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 3;
            board.quizzes[1] = 0;
            board.quizzes[2] = 2;
        }
        else if (currentLevel == 28)
        {
            board.answerCount = 2;
            board.quizCount = 4;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 1;
            board.quizzes[1] = 3;
            board.quizzes[2] = 0;
            board.quizzes[3] = 2;
        }
        else if (currentLevel == 29)
        {
            board.answerCount = 2;
            board.quizCount = 4;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 3;
            board.quizzes[1] = 1;
            board.quizzes[2] = 2;
            board.quizzes[3] = 3;
        }
        else if (currentLevel == 30)
        {
            board.answerCount = 2;
            board.quizCount = 4;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 0;
            board.quizzes[1] = 2;
            board.quizzes[2] = 0;
            board.quizzes[3] = 3;
        }
        else if (currentLevel == 31)
        {
            board.answerCount = 3;
            board.quizCount = 1;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 2;
        }
        else if (currentLevel == 32)
        {
            board.answerCount = 3;
            board.quizCount = 1;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 3;
        }
        else if (currentLevel == 33)
        {
            board.answerCount = 3;
            board.quizCount = 1;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 0;
        }
        else if (currentLevel == 34)
        {
            board.answerCount = 3;
            board.quizCount = 1;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 1;
        }
        else if (currentLevel == 35)
        {
            board.answerCount = 3;
            board.quizCount = 2;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 0;
            board.quizzes[1] = 3;
        }
        else if (currentLevel == 36)
        {
            board.answerCount = 3;
            board.quizCount = 2;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 1;
            board.quizzes[1] = 2;
        }
        else if (currentLevel == 37)
        {
            board.answerCount = 3;
            board.quizCount = 2;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 2;
            board.quizzes[1] = 0;
        }
        else if (currentLevel == 38)
        {
            board.answerCount = 3;
            board.quizCount = 2;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 3;
            board.quizzes[1] = 1;
        }
        else if (currentLevel == 39)
        {
            board.answerCount = 3;
            board.quizCount = 3;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 1;
            board.quizzes[1] = 2;
            board.quizzes[2] = 1;
        }
        else if (currentLevel == 40)
        {
            board.answerCount = 3;
            board.quizCount = 3;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 3;
            board.quizzes[1] = 0;
            board.quizzes[2] = 2;
        }
        else if (currentLevel == 41)
        {
            board.answerCount = 3;
            board.quizCount = 4;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 1;
            board.quizzes[1] = 3;
            board.quizzes[2] = 0;
            board.quizzes[3] = 2;
        }
        else if (currentLevel == 42)
        {
            board.answerCount = 3;
            board.quizCount = 4;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 3;
            board.quizzes[1] = 1;
            board.quizzes[2] = 2;
            board.quizzes[3] = 3;
        }
        else if (currentLevel == 43)
        {
            board.answerCount = 3;
            board.quizCount = 4;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 0;
            board.quizzes[1] = 2;
            board.quizzes[2] = 0;
            board.quizzes[3] = 3;
        }
        else if (currentLevel == 44)
        {
            board.answerCount = 4;
            board.quizCount = 1;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 2;
        }
        else if (currentLevel == 45)
        {
            board.answerCount = 4;
            board.quizCount = 1;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 3;
        }
        else if (currentLevel == 46)
        {
            board.answerCount = 4;
            board.quizCount = 1;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 0;
        }
        else if (currentLevel == 47)
        {
            board.answerCount = 4;
            board.quizCount = 1;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 1;
        }
        else if (currentLevel == 48)
        {
            board.answerCount = 4;
            board.quizCount = 2;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 0;
            board.quizzes[1] = 3;
        }
        else if (currentLevel == 49)
        {
            board.answerCount = 4;
            board.quizCount = 2;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 1;
            board.quizzes[1] = 2;
        }
        else if (currentLevel == 50)
        {
            board.answerCount = 4;
            board.quizCount = 2;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 2;
            board.quizzes[1] = 0;
        }
        else if (currentLevel == 51)
        {
            board.answerCount = 4;
            board.quizCount = 2;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 3;
            board.quizzes[1] = 1;
        }
        else if (currentLevel == 52)
        {
            board.answerCount = 4;
            board.quizCount = 3;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 1;
            board.quizzes[1] = 2;
            board.quizzes[2] = 1;
        }
        else if (currentLevel == 53)
        {
            board.answerCount = 4;
            board.quizCount = 3;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 3;
            board.quizzes[1] = 0;
            board.quizzes[2] = 2;
        }
        else if (currentLevel == 54)
        {
            board.answerCount = 4;
            board.quizCount = 4;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 1;
            board.quizzes[1] = 3;
            board.quizzes[2] = 0;
            board.quizzes[3] = 2;
        }
        else if (currentLevel == 55)
        {
            board.answerCount = 4;
            board.quizCount = 4;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 3;
            board.quizzes[1] = 1;
            board.quizzes[2] = 2;
            board.quizzes[3] = 3;
        }
        else if (currentLevel == 56)
        {
            board.answerCount = 4;
            board.quizCount = 4;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 0;
            board.quizzes[1] = 2;
            board.quizzes[2] = 0;
            board.quizzes[3] = 3;
        }
        else if (currentLevel == 57)
        {
            board.answerCount = 4;
            board.quizCount = 4;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 1;
            board.quizzes[1] = 3;
            board.quizzes[2] = 2;
            board.quizzes[3] = 1;
        }
        else if (currentLevel == 58)
        {
            board.answerCount = 4;
            board.quizCount = 4;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 2;
            board.quizzes[1] = 0;
            board.quizzes[2] = 2;
            board.quizzes[3] = 1;
        }
        else if (currentLevel == 59)
        {
            board.answerCount = 4;
            board.quizCount = 4;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 3;
            board.quizzes[1] = 1;
            board.quizzes[2] = 2;
            board.quizzes[3] = 3;
        }
        else if (currentLevel == 60)
        {
            board.answerCount = 4;
            board.quizCount = 4;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 1;
            board.quizzes[1] = 3;
            board.quizzes[2] = 1;
            board.quizzes[3] = 2;
        }
        else
        {
            Debug.Log("Level not defined");
        }
    }

    public void DeleteData()
    {
        PlayerPrefs.DeleteAll();
        gameManager.I.RestartLevel();
    }

    public void SaveLevel()
    {
        PlayerPrefs.SetInt("saveLevel", currentLevel);
    }

}
