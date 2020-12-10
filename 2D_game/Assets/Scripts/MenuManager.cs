using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private void Start()
    {
        start();
        exit();
    }

    public void start()
    {
        print("開始遊戲");
    }

    public void exit()
    {
        print("離開遊戲");
    }
}
