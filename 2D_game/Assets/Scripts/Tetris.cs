﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetris : MonoBehaviour
{
    [Header("角度為零，線條的長度")]
    public float length0;
    [Header("角度為九十度，線條的長度")]
    public float length90;
    [Header("旋轉位移左右")]
    public int offsetX;
    [Header("旋轉位移上下")]
    public int offsetY;
    [Header("偵測是否能旋轉")]
    public float lengthRotate0r;
    public float lengthRotate0l;
    public float lengthRotate90r;
    public float lengthRotate90l;

    /// <summary>
    /// 紀錄目前長度
    /// </summary>
    private float length;
    private float lengthDown;
    private float lengthRotateR;
    private float lengthRotateL;

    /// <summary>
    /// 是否碰到右邊牆壁
    /// </summary>
    public bool wallRight;
    /// <summary>
    /// 是否碰到左邊牆壁
    /// </summary>
    public bool wallLeft;
    /// <summary>
    /// 是否碰到下方地板
    /// </summary>
    public bool wallDown;

    public bool canRotate;
    private RectTransform rect;
    /// <summary>
    /// 繪製圖示
    /// </summary>
    private void OnDrawGizmos()
    {
        // 將浮點數角度 轉為 整數 - 去小數點
        int z = (int)transform.eulerAngles.z;

        if (z == 0 || z == 180)
        {
            // 儲存目前長度
            length = length0;
            // 圖示 的 繪製射線(起點，方向 * 長度)
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, Vector3.right * length0);
            Gizmos.color = Color.yellow;
            Gizmos.DrawRay(transform.position, -Vector3.right * length0);
            // 繪製向下線條
            lengthDown = length90;
            Gizmos.color = Color.magenta;
            Gizmos.DrawRay(transform.position, -Vector3.up * length90);
            //繪製旋轉射線
            lengthRotateR = lengthRotate0r;
            lengthRotateL = lengthRotate0l;
            Gizmos.color = Color.blue;
            Gizmos.DrawRay(transform.position, Vector3.right * lengthRotate0r);
            Gizmos.DrawRay(transform.position, -Vector3.right * lengthRotate0l);

        }
        else if (z == 90 || z == 270)
        {
            // 儲存目前長度
            length = length90;
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, Vector3.right * length90);
            Gizmos.color = Color.yellow;
            Gizmos.DrawRay(transform.position, -Vector3.right * length90);
            // 繪製向下線條
            lengthDown = length0;
            Gizmos.color = Color.magenta;
            Gizmos.DrawRay(transform.position, -Vector3.up * length0);
            //繪製旋轉射線
            lengthRotateR = lengthRotate90r;
            lengthRotateL = lengthRotate90l;
            Gizmos.color = Color.blue;
            Gizmos.DrawRay(transform.position, Vector3.right * lengthRotate90r);
            Gizmos.DrawRay(transform.position, -Vector3.right * lengthRotate90l);
        }
    }

    private void Start()
    {
        // 儲存遊戲開始的角度
        length = length0;

        rect = GetComponent<RectTransform>();
    }

    private void Update()
    {
        CheckWall();
    }

  

    /// <summary>
    /// 檢查射線是否碰到牆壁
    /// </summary>
    private void CheckWall()
    {
        // 2D 物理碰撞資訊 區域變數名稱 = 2D 物理.射線碰撞(起點，方向，長度，圖層)
        RaycastHit2D hitR = Physics2D.Raycast(transform.position, Vector3.right, length, 1 << 8);

        // 並且 &&
        // 如果 碰到東西 並且 名稱 為 牆壁：右邊
        if (hitR && hitR.transform.name == "牆壁：右邊")
        {
            wallRight = true;
        }
        else
        {
            wallRight = false;
        }

        //旋轉射線
        RaycastHit2D hitRotateR = Physics2D.Raycast(transform.position, Vector3.right, lengthRotateR, 1 << 8);
        RaycastHit2D hitRotateL = Physics2D.Raycast(transform.position, -Vector3.right, lengthRotateL, 1 << 8);

        if( hitRotateR  && hitRotateR.transform.name == "牆壁:右邊" || hitRotateL && hitRotateL.transform.name == "牆壁:左邊")
        {
            canRotate = false;
        }
        else
        {
            canRotate = true;
        }

        // 2D 物理碰撞資訊 區域變數名稱 = 2D 物理.射線碰撞(起點，方向，長度，圖層)
        RaycastHit2D hitL = Physics2D.Raycast(transform.position, -Vector3.right, length, 1 << 9);

        // 並且 &&
        // 如果 碰到東西 並且 名稱 為 牆壁：右邊
        if (hitL && hitL.transform.name == "牆壁：左邊")
        {
            wallLeft = true;
        }
        else
        {
            wallLeft = false;
        }

        // 2D 物理碰撞資訊 區域變數名稱 = 2D 物理.射線碰撞(起點，方向，長度，圖層)
        RaycastHit2D hitD = Physics2D.Raycast(transform.position, -Vector3.up, lengthDown, 1 << 9);

        // 並且 &&
        // 如果 碰到東西 並且 名稱 為 牆壁：右邊
        if (hitD && hitD.transform.name == "地板")
        {
            wallDown = true;
        }
        else
        {
            wallDown = false;
        }
    }

    /// <summary>
    /// 旋轉後位移處理
    /// </summary>
    public void Offset()
    {
        int z = (int)transform.eulerAngles.z;

        if(z == 90 || z == 270)
        {
            rect.anchoredPosition -= new Vector2(offsetX, offsetY);
        }
        else if(z == 0 || z == 180)
        {
            rect.anchoredPosition += new Vector2(offsetX, offsetY);
        }
    }
}

