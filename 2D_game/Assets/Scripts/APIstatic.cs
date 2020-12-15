using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 認識靜態的 API
/// 靜態 static
/// </summary>
public class APIstatic : MonoBehaviour
{
    private void Start()
    {
        //★★★靜態屬性★★★
        //【取得】
        //語法 : 類別名稱.靜態屬性名稱
        print(Mathf.PI);

        //【設定】
        //*如果有 Read Only 代表不能設定
        //語法 : 類別名稱.靜態屬性名稱 = 相同類別的值
        Time.timeScale = 0.5f;

        //【練習】
        print("攝影機數量:"+ Camera.allCamerasCount);  //取得的範例
        Cursor.visible = false; // 設定的範例

        //★★★靜態方法 Static Methods★★★
        //【使用】
        //語法 : 類別名稱.靜態方法名稱(對應的參數)
        int number = Mathf.Abs(-999);
        print("取得絕對值的結果" + number);
        //print("取得絕對值的結果" + Mathf.Abs(-999)); // -->與30.31結果相同

        print("隨機範圍3-20.5:" + Random.Range(3.0f, 20.5f));

        //【練習】
        //Application.OpenURL("http://unity3d.com/");
        print("去小數點:" + Mathf.Floor(8.5f));
        

    }

    /// <summary>
    /// 更新事件 : 一秒執行60次 (60FPS)  --> 就是數量會一直跑的
    /// </summary>
    private void Update()
    {
        //【練習】
        //print("是否按任意建:"+Input.anyKey);
        //print("遊戲時間:"+Time.time);
        //print("是否按下空白鍵"+Input.GetKeyDown("space"));
    }


}
