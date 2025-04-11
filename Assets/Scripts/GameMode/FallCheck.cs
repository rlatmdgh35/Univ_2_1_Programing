using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FallCheck : MonoBehaviour
{
    public int boxCount;
    public float bc_Time;
    bool gameover;
    bool gameClear;

    public Text gameTime;
    string gameTimeText;

    public TextMeshProUGUI fallinBox;
    public int finishBox = 36;

    public GameObject restart_ui;
    public GameObject success_ui;

    void Start()
    {
        restart_ui.SetActive(false); // SafeCode
        success_ui.SetActive(false); // SafeCode
    }

    void Update()
    {
        if (!gameover & Gamemode.sgtn.IsStart())
        {
            bc_Time += Time.deltaTime;

            gameTimeText = bc_Time.ToString("F2"); // string foramt: "Fn" -> 0.00... (deciaml point * n)
            gameTime.text = "Time: " + gameTimeText;

            fallinBox.text = "»óÀÚ: " + boxCount + " / " + finishBox;
        }
    }

    void OnTriggerEnter(Collider obj)
    {
        if (obj.CompareTag("Box"))
        {
            boxCount++;
            Debug.Log("BoxCount: " + boxCount);
        }
        if ((obj.CompareTag("Player") ||
            obj.CompareTag("UniqueBox")) &
            gameClear == false)
        {
            GameOver();
        }
        else if (boxCount >= finishBox & gameover == false)
        {
            GameClear();
        }
    }

    void GameOver()
    {
        gameover = true;
        restart_ui.SetActive(true);
    }

    void GameClear()
    {
        gameClear = true;
        success_ui.SetActive(true);
    }
}
