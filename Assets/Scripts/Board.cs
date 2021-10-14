using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class Board : MonoBehaviour
{
    // 정답보드 (stone 개수 n by n)
    public int boardWidth;
    public int boardHeight;

    // stone 프리팹 받기
    public Stone stonePrefab;

    // 모든 stone정보 저장 위함
    public static Stone[] allStones;
    public static int[] stoneIds;

    // 정답 확인 위한
    int[] tempAnswerArray;
    int[] answerArray;
    int[] userAnswer;
    bool checkCount;
    public int clickCount;

    // 외부에서 받는 레벨 전용 변수
    public int answerCount;
    public int quizCount;
    public int[] quizzes;

    // 임시 저장소
    public Stone tempStone;
    Quiz quiz;

    public LevelManager levelManager;

    SpriteRenderer sprite;


    // Start is called before the first frame update
    void Start()
    {
    }

    public void StartBoard()
    {
        // stone 개수에 따른 array 크기 지정
        allStones = new Stone[boardWidth * boardHeight];
        stoneIds = new int[boardWidth * boardHeight];
        tempAnswerArray = new int[boardWidth * boardHeight];
        userAnswer = new int[answerCount];


        // 보드판 생성, 순서 섞기
        SpawnStones();
        //ShuffleStoneOrder();
        MakeRandomQuestion(answerCount);

        // 순서에 따라 깜빡임, 퀴즈에 따라 위치 변경
        StartCoroutine("GamePlay");


    }

    // 보드판 생성 함수
    public void SpawnStones()
    {
        int id = 0;

        // 지정한 height과 width에 따라 stone 생성
        // x, y 포지션에 생성
        for (int x = 0; x < boardWidth; x++)
        {
            for (int y = 0; y < boardHeight; y++)
            {
                Vector3 pos = new Vector3(x, y, 0f);
                Stone stone = Instantiate(stonePrefab, pos, Quaternion.identity);
                stone.transform.parent = this.transform;

                // if(levelManager.currentLevel < 5)
                // {
                //     sprite = stone.GetComponent<SpriteRenderer>();
                //     if (id == 0)
                //     {
                //         sprite.material.color = new Color(62, 47, 99);    
                //     }
                //     else if(id == 1)
                //     {
                //         sprite.material.color = new Color(236, 84, 76);
                //     }
                //     else if (id == 2)
                //     {
                //         sprite.material.color = new Color(79, 83, 162);
                //     }
                // }

                // 생성한 stone을 allStones array에 저장
                allStones[id] = stone;

                // stone ID 저장, answer 배열 채우기
                stoneIds[id] = id;
                tempAnswerArray[id] = id;

                // 각 stone ID 번호 부여
                stone.GetComponent<Stone>().stoneId = id++;

                // stone에 position 정보 전달
                stone.SetupStone(pos, this);

                // 각 stone GameObject에 이름 부여
                stone.name = "stone - " + stone.GetComponent<Stone>().stoneId;
            }
        }
        if(levelManager.currentLevel < 5)
        {
            SetStoneColors();
        }
        DeactivateStoneCollider();
    }

    void SetStoneColors()
    {
        sprite = allStones[0].GetComponent<SpriteRenderer>();
        sprite.material.color = new Color(0.984f, 0.780f, 0.251f);
        sprite = allStones[1].GetComponent<SpriteRenderer>();
        sprite.material.color = new Color(0.027f, 0.733f, 0.612f);
        sprite = allStones[2].GetComponent<SpriteRenderer>();
        sprite.material.color = new Color(0.4f, 0.824f, 0.839f);
        sprite = allStones[3].GetComponent<SpriteRenderer>();
        sprite.material.color = new Color(0.741f, 0.592f, 0.796f);
        
    }

    // 정답 배열을 랜덤 순서로 변경
    void ShuffleStoneOrder()
    {
        for (int i = 0; i < tempAnswerArray.Length; i++)
        {
            int temp = tempAnswerArray[i];
            int rnd = UnityEngine.Random.Range(0, tempAnswerArray.Length);
            tempAnswerArray[i] = tempAnswerArray[rnd];
            tempAnswerArray[rnd] = temp;
        }
    }

    void MakeRandomQuestion(int n)
    {
        answerArray = new int[n];
        ShuffleStoneOrder();
        for (int i = 0; i < n; i++)
        {
            answerArray[i] = tempAnswerArray[i];
        }
    }

    IEnumerator GamePlay()
    {
        gameManager.I.ShowMsgRemember();
        for (int j = 0; j < answerArray.Length; j++)
        {
            int temp = Array.IndexOf(stoneIds, answerArray[j]);
            allStones[temp].BlinkStone();
            yield return new WaitForSecondsRealtime(0.5f);
            allStones[temp].BlinkOff();
        }

        yield return new WaitForSecondsRealtime(0.1f);
        
        StartCoroutine("ApplyQuiz");
        yield return new WaitForSecondsRealtime(0.1f);
               
    }

    // 시간차 두고 stoneIds[] 깜빡이기
    public IEnumerator ApplyQuiz()
    {
        // 퀴즈 배열받아서 for문 돌리고 실행
        for (int i = 0; i < quizCount; i++)
        {
            if (quizzes[i] == 0)
            {
                RotateRight();

                yield return new WaitForSecondsRealtime(0.5f);

                for (int j = 0; j < stoneIds.Length; j++)
                {
                    allStones[stoneIds[j]].RedrawStone();
                }

                yield return new WaitForSecondsRealtime(0.2f);
            }
            else if (quizzes[i] == 1)
            {
                RotateLeft();

                yield return new WaitForSecondsRealtime(0.5f);

                for (int j = 0; j < stoneIds.Length; j++)
                {
                    allStones[stoneIds[j]].RedrawStone();
                }

                yield return new WaitForSecondsRealtime(0.2f);
            }
            else if (quizzes[i] == 2)
            {
                FlipHorizontal();

                yield return new WaitForSecondsRealtime(0.5f);

                for (int j = 0; j < stoneIds.Length; j++)
                {
                    allStones[stoneIds[j]].RedrawStone();
                }

                yield return new WaitForSecondsRealtime(0.2f);
            }
            else if (quizzes[i] == 3)
            {
                FlipVertical();

                yield return new WaitForSecondsRealtime(0.5f);

                for (int j = 0; j < stoneIds.Length; j++)
                {
                    allStones[stoneIds[j]].RedrawStone();
                }

                yield return new WaitForSecondsRealtime(0.2f);
            }
            else
            {
                Debug.Log("ERROR!!");
            }
        }
        gameManager.I.ShowMsgClick();
        ActivateStoneCollider();
    }

    void RotateRight()
    {
        // 각 stone 위치 변경
        allStones[0].posIndex.y++;
        allStones[1].posIndex.x++;
        allStones[2].posIndex.x--;
        allStones[3].posIndex.y--;



        // allStones 배열 내 위치 조정
        tempStone = allStones[0];
        allStones[0] = allStones[2];
        allStones[2] = allStones[3];
        allStones[3] = allStones[1];
        allStones[1] = tempStone;


        int temp = stoneIds[0];
        stoneIds[0] = stoneIds[2];
        stoneIds[2] = stoneIds[3];
        stoneIds[3] = stoneIds[1];
        stoneIds[1] = temp;
    }

    void RotateLeft()
    {
        // 각 stone 위치 변경
        allStones[0].posIndex.x++;
        allStones[1].posIndex.y--;
        allStones[2].posIndex.y++;
        allStones[3].posIndex.x--;



        // allStones 배열 내 위치 조정
        tempStone = allStones[0];
        allStones[0] = allStones[1];
        allStones[1] = allStones[3];
        allStones[3] = allStones[2];
        allStones[2] = tempStone;

        int temp = stoneIds[0];
        stoneIds[0] = stoneIds[1];
        stoneIds[1] = stoneIds[3];
        stoneIds[3] = stoneIds[2];
        stoneIds[2] = temp;
    }

    void FlipHorizontal()
    {
        // 각 stone 위치 변경
        allStones[0].posIndex.x++;
        allStones[1].posIndex.x++;
        allStones[2].posIndex.x--;
        allStones[3].posIndex.x--;



        // allStones 배열 내 위치 조정
        tempStone = allStones[0];
        allStones[0] = allStones[2];
        allStones[2] = tempStone;
        tempStone = allStones[1];
        allStones[1] = allStones[3];
        allStones[3] = tempStone;

        int temp = stoneIds[0];
        stoneIds[0] = stoneIds[2];
        stoneIds[2] = temp;
        temp = stoneIds[1];
        stoneIds[1] = stoneIds[3];
        stoneIds[3] = temp;
    }

    void FlipVertical()
    {
        // 각 stone 위치 변경
        allStones[0].posIndex.y++;
        allStones[1].posIndex.y--;
        allStones[2].posIndex.y++;
        allStones[3].posIndex.y--;



        // allStones 배열 내 위치 조정
        tempStone = allStones[0];
        allStones[0] = allStones[1];
        allStones[1] = tempStone;
        tempStone = allStones[2];
        allStones[2] = allStones[3];
        allStones[3] = tempStone;

        int temp = stoneIds[0];
        stoneIds[0] = stoneIds[1];
        stoneIds[1] = temp;
        temp = stoneIds[2];
        stoneIds[2] = stoneIds[3];
        stoneIds[3] = temp;
    }

    public void GetClickedStone(Stone stoneClicked)
    {
        Debug.Log(stoneClicked.stoneId);
        userAnswer[clickCount] = stoneClicked.stoneId;
        clickCount += 1;
    }

    public bool CheckAnswer()
    {
        bool success = true;

        for (int i = 0; i < answerCount; i++)
        {
            Debug.Log("answer = " + answerArray[i] + ", userAnswer = " + userAnswer[i]);
            success = CheckCurrentAnswer(answerArray[i], userAnswer[i]);
            if (!success)
            {
                Debug.Log("WRONG!");
                return success;
            }
        }
        Debug.Log("SUCCESS!!");
        return success;
    }

    bool CheckCurrentAnswer(int answer, int userAnswer)
    {
        if (answer == userAnswer)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void DeactivateStoneCollider()
    {
        for (int i = 0; i < allStones.Length; i++)
        {   
            allStones[i].GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public void ActivateStoneCollider()
    {
        for (int i = 0; i < allStones.Length; i++)
        {
            allStones[i].GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    public void Reset()
    {
        DeactivateStoneCollider();
        DestroyStones();
        SpawnStones();
        StartCoroutine("GamePlay");
    }

    IEnumerator BlinkStones()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        Debug.Log("Blinking Stones");
        DeactivateStoneCollider();
        for (int j = 0; j < answerArray.Length; j++)
        {
            int temp = Array.IndexOf(stoneIds, answerArray[j]);
            allStones[temp].BlinkStone();
            yield return new WaitForSecondsRealtime(0.5f);
            allStones[temp].BlinkOff();
        }
    }

    public void DestroyStones()
    {
        for(int i = 0; i < allStones.Length; i++)
        {
            Destroy(allStones[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
