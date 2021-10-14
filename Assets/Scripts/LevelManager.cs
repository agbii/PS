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

        //RR
        if(currentLevel == 1)
        {
            board.answerCount = 1;
            board.quizCount = 1;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 0;
        }
        //RL
        else if (currentLevel == 2)
        {
            board.answerCount = 1;
            board.quizCount = 1;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 1;
        }
        //FH
        else if (currentLevel == 3)
        {
            board.answerCount = 1;
            board.quizCount = 1;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 2;
        }
        //FV
        else if (currentLevel == 4)
        {
            board.answerCount = 1;
            board.quizCount = 1;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 3;
        }
        //RR
        else if (currentLevel == 5)
        {
            board.answerCount = 1;
            board.quizCount = 1;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 0;
        }
        //RL
        else if (currentLevel == 6)
        {
            board.answerCount = 1;
            board.quizCount = 1;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 1;
        }
        //FH
        else if (currentLevel == 7)
        {
            board.answerCount = 1;
            board.quizCount = 1;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 2;
        }
        //FV
        else if (currentLevel == 8)
        {
            board.answerCount = 1;
            board.quizCount = 1;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 3;
        }
        //RR, FV
        else if (currentLevel == 9)
        {
            board.answerCount = 1;
            board.quizCount = 2;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 0;
            board.quizzes[1] = 3;
        }
        //FH, RL
        else if (currentLevel == 10)
        {
            board.answerCount = 1;
            board.quizCount = 2;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 2;
            board.quizzes[1] = 1;
        }
        //FH, FV, RR
        else if (currentLevel == 11)
        {
            board.answerCount = 1;
            board.quizCount = 3;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 2;
            board.quizzes[1] = 3;
            board.quizzes[2] = 0;
        }
        //RR
        else if (currentLevel == 12)
        {
            board.answerCount = 2;
            board.quizCount = 1;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 0;
        }
        //RL
        else if (currentLevel == 13)
        {
            board.answerCount = 2;
            board.quizCount = 1;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 1;
        }
        //FH
        else if (currentLevel == 14)
        {
            board.answerCount = 2;
            board.quizCount = 1;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 2;
        }
        //FV
        else if (currentLevel == 15)
        {
            board.answerCount = 2;
            board.quizCount = 1;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 3;
        }
        //RL, FV
        else if (currentLevel == 16)
        {
            board.answerCount = 2;
            board.quizCount = 2;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 1;
            board.quizzes[1] = 3;
        }
        //FH, RR
        else if (currentLevel == 17)
        {
            board.answerCount = 2;
            board.quizCount = 2;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 2;
            board.quizzes[1] = 0;
        }
        //RL, FH, RL
        else if (currentLevel == 18)
        {
            board.answerCount = 2;
            board.quizCount = 3;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 1;
            board.quizzes[1] = 2;
            board.quizzes[2] = 1;
        }
        //RR
        else if (currentLevel == 19)
        {
            board.answerCount = 3;
            board.quizCount = 1;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 0;
        }
        //RL
        else if (currentLevel == 20)
        {
            board.answerCount = 3;
            board.quizCount = 1;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 1;
        }
        //FH
        else if (currentLevel == 21)
        {
            board.answerCount = 3;
            board.quizCount = 1;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 2;
        }
        //FV
        else if (currentLevel == 22)
        {
            board.answerCount = 3;
            board.quizCount = 1;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 3;
        }
        //RR, FH
        else if (currentLevel == 23)
        {
            board.answerCount = 3;
            board.quizCount = 2;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 0;
            board.quizzes[1] = 2;
        }
        //FV, RL
        else if (currentLevel == 24)
        {
            board.answerCount = 3;
            board.quizCount = 2;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 3;
            board.quizzes[1] = 1;
        }
        //FV, RR, FH
        else if (currentLevel == 25)
        {
            board.answerCount = 3;
            board.quizCount = 3;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 3;
            board.quizzes[1] = 0;
            board.quizzes[2] = 2;
        }
        //RR
        else if (currentLevel == 26)
        {
            board.answerCount = 4;
            board.quizCount = 1;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 0;
        }
        //RL
        else if (currentLevel == 27)
        {
            board.answerCount = 4;
            board.quizCount = 1;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 1;
        }
        //FH
        else if (currentLevel == 28)
        {
            board.answerCount = 4;
            board.quizCount = 1;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 2;
        }
        //FV
        else if (currentLevel == 29)
        {
            board.answerCount = 4;
            board.quizCount = 1;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 3;
        }
        //FH, RL
        else if (currentLevel == 30)
        {
            board.answerCount = 4;
            board.quizCount = 2;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 2;
            board.quizzes[1] = 1;
        }
        //RR, FV
        else if (currentLevel == 31)
        {
            board.answerCount = 4;
            board.quizCount = 2;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 0;
            board.quizzes[1] = 3;
        }
        //RL, FV, RL
        else if (currentLevel == 32)
        {
            board.answerCount = 4;
            board.quizCount = 3;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 1;
            board.quizzes[1] = 3;
            board.quizzes[2] = 1;
        }
        //FV, RR, FH
        else if (currentLevel == 33)
        {
            board.answerCount = 4;
            board.quizCount = 3;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 3;
            board.quizzes[1] = 0;
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
