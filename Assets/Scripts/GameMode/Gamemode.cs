using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemode : MonoBehaviour
{
    public static Gamemode sgtn;

    bool isStart = false;
    bool isEndGame = false;

    void Awake()
    {
        if (sgtn == null)
            sgtn = this;
    }

    public bool IsStart()
    {
        return isStart;
    }

    public bool IsEndGame()
    {
        return isEndGame;
    }

    public void GameStart()
    {
        isStart = true;
    }

    public void GameEnd()
    {
        isEndGame = true;
    }

    public void ReStartScene()
    {
        Scene nowScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(nowScene.name);
    }

    public void Load_NextScene()
    {
        GameInfoData.Load_NextScene();
    }

}