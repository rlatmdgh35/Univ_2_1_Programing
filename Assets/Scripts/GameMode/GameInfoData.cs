using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInfoData : MonoBehaviour
{
    public static string nowScene;

    void Start()
    {
        nowScene = SceneManager.GetActiveScene().name;
    }

    public static void Load_NextScene()
    {
        int nowSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(nowSceneIndex + 1);
    }

    public static void SaveTimeData(float score)
    {
        PlayerPrefs.SetFloat(nowScene + "_HighScore", score);
        PlayerPrefs.Save();
    }

    public static void ResetTimeData()
    {
        PlayerPrefs.DeleteKey(nowScene + "_HighScore");
    }
}
