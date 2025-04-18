using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInfoData : MonoBehaviour
{
    public static string nowScene;

    void Start()
    {
        nowScene = SceneManager.GetActiveScene().name;
    }
}
