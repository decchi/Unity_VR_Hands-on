using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ApplicationManager : MonoBehaviour {


    public void RetryGame()
    {
        SceneManager.LoadScene("VR_OniGokko_Hands-on"); //VR_OniGokko_Hands-onのシーンを再生する。

    }

    public void QuitGame()
    {
        Application.Quit(); //アプリケーションを終了する。
    }

}
