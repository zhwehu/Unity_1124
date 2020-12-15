using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    /// <summary>
    /// 延遲呼叫，讓音樂播完
    /// </summary>
    public void DelayStartGame()
    {
        //語法 : 延遲呼叫("方法名稱",延遲秒數);
        Invoke("StartGame",0.9f);
    }

    public void DelayOuitGame()
    {
        Invoke("QuitGame", 0.9f);
    }

    /// <summary>
    /// 開始遊戲
    /// </summary>
    private void StartGame()
    {
        //載入指定場景
        //語法 : 場景管理器 的 載入音樂("場景名稱");
        //語法 : 場景管理器 的 載入音樂(1);
        SceneManager.LoadScene("game"); 
    }

    /// <summary>
    /// 離開遊戲
    /// </summary>
    private void QuitGame()
    {
        //退出遊戲
        //語法 : 應用程式 的 離開遊戲();
        Application.Quit();
    }
}
