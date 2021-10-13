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
    int clickCount;

    // 외부에서 받는 레벨 전용 변수
    public int answerCount;
    public int quizCount;
    public int[] quizzes;

    // 임시 저장소
    public Stone tempStone;

    // 모든 퀴즈종류 정보 저장
    public Quiz[] quizTypes;
    Quiz quiz;

    Animator anim;
    SpriteRenderer sprite;


    // Start is called before the first frame update
    void Start()
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
        StartCoroutine("BlinkAndApplyQuiz");
    }

    // 보드판 생성 함수
    void SpawnStones()
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

                // transform 시각적 확인 위해 임시로 임의 색상 씌우기
                // float rnd1 = UnityEngine.Random.Range(0f, 1f);
                // float rnd2 = UnityEngine.Random.Range(0f, 1f);
                // float rnd3 = UnityEngine.Random.Range(0f, 1f);
                // sprite = stone.GetComponent<SpriteRenderer>();
                // sprite.material.color = new Color(rnd1, rnd2, rnd3);

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

    // 시간차 두고 stoneIds[] 깜빡이기
    IEnumerator BlinkAndApplyQuiz()
    {
        for (int j = 0; j < answerArray.Length; j++)
        {
            int temp = Array.IndexOf(stoneIds, answerArray[j]);
            allStones[temp].BlinkStone();
            yield return new WaitForSecondsRealtime(1);
            allStones[temp].BlinkOff();
        }

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

                yield return new WaitForSecondsRealtime(0.5f);
            }
            else if (quizzes[i] == 1)
            {
                RotateLeft();

                yield return new WaitForSecondsRealtime(0.5f);

                for (int j = 0; j < stoneIds.Length; j++)
                {
                    allStones[stoneIds[j]].RedrawStone();
                }

                yield return new WaitForSecondsRealtime(0.5f);
            }
            else if (quizzes[i] == 2)
            {
                FlipHorizontal();

                yield return new WaitForSecondsRealtime(0.5f);

                for (int j = 0; j < stoneIds.Length; j++)
                {
                    allStones[stoneIds[j]].RedrawStone();
                }

                yield return new WaitForSecondsRealtime(0.5f);
            }
            else if (quizzes[i] == 3)
            {
                FlipVertical();

                yield return new WaitForSecondsRealtime(0.5f);

                for (int j = 0; j < stoneIds.Length; j++)
                {
                    allStones[stoneIds[j]].RedrawStone();
                }

                yield return new WaitForSecondsRealtime(0.5f);
            }
            else
            {
                Debug.Log("ERROR!!");
            }
        }

        // yield return new WaitForSecondsRealtime(0.5f);

        // for (int i = 0; i < stoneIds.Length; i++)
        // {
        //     allStones[stoneIds[i]].RedrawStone();
        // }

        // yield return new WaitForSecondsRealtime(0.5f);

        // for (int i = 0; i < answerArray.Length; i++)
        // {
        //     int temp = Array.IndexOf(stoneIds, answerArray[i]);
        //     allStones[temp].BlinkStone();
        //     yield return new WaitForSecondsRealtime(1);
        //     allStones[temp].BlinkOff();
        // }

        // yield return new WaitForSecondsRealtime(0.5f);

        // FlipVertical();

        // yield return new WaitForSecondsRealtime(0.5f);

        // for (int i = 0; i < stoneIds.Length; i++)
        // {
        //     allStones[stoneIds[i]].RedrawStone();
        // }

        // yield return new WaitForSecondsRealtime(0.5f);

        // for (int i = 0; i < answerArray.Length; i++)
        // {
        //     int temp = Array.IndexOf(stoneIds, answerArray[i]);
        //     allStones[temp].BlinkStone();
        //     yield return new WaitForSecondsRealtime(1);
        //     allStones[temp].BlinkOff();
        // }
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

        userAnswer[clickCount] = stoneClicked.stoneId;
        clickCount += 1;
    }

    public void CheckAnswer()
    {
        bool success;

        for (int i = 0; i < answerCount; i++)
        {
            Debug.Log("answer = " + answerArray[i] + ", userAnswer = " + userAnswer[i]);
            success = CheckCurrentAnswer(answerArray[i], userAnswer[i]);
            if (!success)
            {
                Debug.Log("WRONG!");
                return;
            }
        }
        Debug.Log("SUCCESS!!");
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

    IEnumerator StoneBlinkAndReset()
    {
        for (int i = 0; i < stoneIds.Length; i++)
        {
            allStones[stoneIds[i]].RedrawStone();
        }

        yield return new WaitForSecondsRealtime(0.5f);

        for (int i = 0; i < answerArray.Length; i++)
        {
            int temp = Array.IndexOf(stoneIds, answerArray[i]);
            allStones[temp].BlinkStone();
            yield return new WaitForSecondsRealtime(1);
            allStones[temp].BlinkOff();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (clickCount == answerCount)
        {
            CheckAnswer();
            clickCount = 0;
        }
    }
}
