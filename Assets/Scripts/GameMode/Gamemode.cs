using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemode : MonoBehaviour
{
    public static Gamemode sgtn;

    bool isStart = false;

    void Awake()
    {
        if (sgtn == null)
            sgtn = this;
    }

    public bool IsStart()
    {
        return isStart;
    }

    public void GameStart()
    {
        isStart = true;
    }

    public void ReStartScene()
    {
        Scene nowScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(nowScene.name);
    }
}
