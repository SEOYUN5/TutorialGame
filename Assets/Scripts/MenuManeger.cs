using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManeger: MonoBehaviour
{
   
    public void OnPressGameStart()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void OnPressExit()
    {
        Application.Quit();
    }
}
