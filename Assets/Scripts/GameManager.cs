using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool restartingGame = false;

    public float restartDelay = 3f;

    public void EndGame()
    {
        if (restartingGame == false)
        {
            restartingGame = true;
            Invoke("Restart", restartDelay);
        }
        
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
