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
    [Header("下一個俄羅斯方塊區域")]
    public Transform traNextArea;
    [Header("畫布")]
    public Transform traCanvas;

    /// <summary>
    /// 下一顆俄羅斯方塊編號
    /// </summary>
    private int indexNext;

    /// <summary>
    /// 目前俄羅斯方塊
    /// </summary>
    private RectTransform currentTetris;

    /// <summary>
    /// 計時器
    /// </summary>
    private float timer;

    #endregion

    #region 事件

    // 開始事件 : 開始時候執行一次
    private void Start()
    {
        RandomTetris();
    }

    //更新事件 : 一秒執行約60次
    public void Update()
    {
        ControlTertis();
    }
    #endregion


    #region 方法
    private void ControlTertis()
    {

        //如果 已經有 目前的俄羅斯方塊
        if (currentTetris)
        {
            timer += Time.deltaTime; // 計時器 累加 一偵的時間 - 累加時間

            if (timer >= timeFall)
            {
                timer = 0;
                currentTetris.anchoredPosition -= new Vector2(0, 50);
            }


            #region 控制俄羅斯方塊的左右、旋轉和加速
            //如果 X 座標 小於 350 才能往右移動
            if (currentTetris.anchoredPosition.x < 310)
            {
                //或者符號 : ||
                //按下 D 往右50
                if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                {
                    currentTetris.anchoredPosition += new Vector2(50, 0);
                }
            }
            //如果 X 座標 小於 350 才能往右移動
            if (currentTetris.anchoredPosition.x > -310)
            {
                //或者符號 : ||
                //按下 D 往右50
                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    currentTetris.anchoredPosition -= new Vector2(50, 0);
                }
            }

            //按下 W 逆時針轉90度
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                //屬性面板上面的 rotation 必須用eulerAngles控制
                currentTetris.eulerAngles += new Vector3(0, 0, 90);
            }
            //如果玩家 按住 S 就加速
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                timeFall = 0.2f;
            }
            //否則 就恢復速度
            else
            {
                timeFall = 1.5f;
            }
            #endregion

            //如果 目前的俄羅斯方塊 Y軸 等於 -300 就叫下一顆
            if (currentTetris.anchoredPosition.y == -300)
            {
                StartGame();
            }
        }
    }
    /// <summary>
    /// 生成俄羅斯方塊
    /// 1.隨機顯示一個下一顆俄羅斯方塊0-8
    /// </summary>
    private void RandomTetris()
    {
        //下一顆編號 = 隨機 的 範圍 (最小，最大) - 整數不會等於最大值
        indexNext = Random.Range(0, 9);
        //下一個俄羅斯方塊區域 . 取得子物件(子物件編號).轉為遊戲物件.啟動設定(顯示)
        traNextArea.GetChild(indexNext).gameObject.SetActive(true);
    }

    /// <summary>
    /// 開始遊戲
    /// 1.生成俄羅斯方塊要放在正確的位置
    /// 2.上一次俄羅斯方塊隱藏
    /// 3.隨機取得下一個
    /// </summary>
    public void StartGame()
    {
        //1.生成俄羅斯方塊要放在正確的位置
        //保持上一次的俄羅斯方塊
        GameObject tetris = traNextArea.GetChild(indexNext).gameObject;
        //目前俄羅斯方塊 = 生成物件(物件, 父物件)
        GameObject current = Instantiate(tetris, traCanvas);
        //GetComponent<任何元件>()
        //<T>泛型 - 指的是所有類型
        //目前俄羅斯方塊 . 取得元件<介面變形>().座標 = 二維向量
        current.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 400);

        // 2.上一次俄羅斯方塊隱藏
        tetris.SetActive(false);
        // 3.隨機取得下一個
        RandomTetris();
        //將生成的俄羅斯方塊 RectTransform 元件儲存
        currentTetris = current.GetComponent<RectTransform>();
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
