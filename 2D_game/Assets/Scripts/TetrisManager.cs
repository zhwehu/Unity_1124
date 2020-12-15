using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisManager : MonoBehaviour
{
    #region 欄位
    [Header("掉落時間"), Range(0.1f, 3)]
    public float timeFall = 1.5f;
    [Header("目前分數")]
    public int score;
    [Header("最高分數")]
    public int scoreHight;
    [Header("等級")]
    public int lv = 1;
    [Header("結束畫面")]
    public GameObject objFinal;
    [Header("音效：地落、移動、消除與結束")]
    public AudioClip soundFall;
    public AudioClip soundMove;
    public AudioClip soundClear;
    public AudioClip soundLose;
    #endregion

    #region 事件

    //private void Start()
    //{
    //Generate_Tetris();
    // int add = addScore();
    // print("傳回整數: "+ add);
    //time();
    //over();
    //reture();
    //exit();

    //}
    #endregion

    #region 方法

    private void SpawnTetris()
    {
        
    }

    public void addScore(int add)
    {
        
    }

    private void GameTime()
    {
       
    }

    private void GmaeOver()
    {
        
    }

    public void ReplyGame()
    {
        
    }

    public void QuitGame()
    {
        
    }

    #endregion
}
