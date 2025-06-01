using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInfoData : MonoBehaviour
{
    public static GameInfoData sgtn;

    public static string nowScene;

    void Awake()
    {
        if (sgtn == null)
        {
            sgtn = this;

            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

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

    public static void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
