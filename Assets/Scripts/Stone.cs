using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    
    // Board 저장
    public Board board;

    // 위치 index
    public Vector3 posIndex;

    // Animation 받기 위함
    Animator anim;


    // ID 지정
    public int stoneId;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // 이 stone 깜빡이기
    public void BlinkStone()
    {
        anim = this.GetComponent<Animator>();
        anim.SetTrigger("Blink");
    }

    public void BlinkOff()
    {
        anim = this.GetComponent<Animator>();
        anim.ResetTrigger("Blink");
    }

    public void SetupStone(Vector3 pos, Board theBoard)
    {
        posIndex = pos;
        board = theBoard;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RedrawStone()
    {
        transform.position = new Vector3(posIndex.x, posIndex.y, 1f);
    }
}
