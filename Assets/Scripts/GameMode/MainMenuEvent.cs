using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuEvent : MonoBehaviour
{
    public string sceneName;

    public void Load_Scene()
    {
        SceneManager.LoadScene(sceneName);
    }

}
