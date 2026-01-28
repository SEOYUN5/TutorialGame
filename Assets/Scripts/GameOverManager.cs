using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
  public void OnPressPlayAgain()
  {
        SceneManager.LoadScene("GameScene");
  }

    public void OnpressMenu()
    {
        SceneManager.LoadScene("MainManuScene");
    }
}
