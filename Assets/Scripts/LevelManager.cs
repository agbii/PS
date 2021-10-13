using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class LevelManager : MonoBehaviour
{
    public Board board;

    // Start is called before the first frame update
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name == "1")
        {
            board.answerCount = 1;
            board.quizCount = 1;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 0;
        }
        else if (scene.name == "2")
        {
            board.answerCount = 2;
            board.quizCount = 1;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 0;
        }
        else if (scene.name == "3")
        {
            board.answerCount = 1;
            board.quizCount = 2;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 0;
            board.quizzes[1] = 2;
        }
        else if (scene.name == "4")
        {
            board.answerCount = 2;
            board.quizCount = 2;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 1;
            board.quizzes[1] = 3;
        }
        else if (scene.name == "49")
        {
            board.answerCount = 4;
            board.quizCount = 2;
            board.quizzes = new int[board.quizCount];
            board.quizzes[0] = 1;
            board.quizzes[1] = 3;
        }
        else if (scene.name == "99")
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
}
