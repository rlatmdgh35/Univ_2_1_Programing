using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static void SaveTimeData(float score)
    {
        string scene = GameInfoData.nowScene;

        PlayerPrefs.SetFloat(scene + "_HighScore", score);
        PlayerPrefs.Save();
    }
}
