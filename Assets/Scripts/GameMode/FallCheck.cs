using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FallCheck : MonoBehaviour
{
    int boxCount;
    float bc_Time;
    bool gameOver;
    bool gameClear;

    public TextMeshProUGUI gameTime;
    string gameTimeText;

    public TextMeshProUGUI fallinBoxTMP;
    public GameObject finishBoxes;
    int finishBoxCount;

    public GameObject restart_ui;
    public GameObject success_ui;
    public GameObject endTime_ui;
    public GameObject newRecord_ui;

    PlayerController playerController;

    void Start()
    {
        restart_ui.SetActive(false); // SafeCode
        success_ui.SetActive(false); // SafeCode

        finishBoxCount = finishBoxes.transform.childCount;
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (!gameOver && Gamemode.sgtn.IsStart())
        {
            if (Gamemode.sgtn.IsEndGame() == false)
                bc_Time += Time.deltaTime;

            gameTimeText = bc_Time.ToString("F2"); // string foramt: "Fn" -> 0.00... (deciaml point * n)
            gameTime.text = "시간: " + gameTimeText;

            fallinBoxTMP.text = "상자: " + boxCount + " / " + finishBoxCount;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            boxCount++;
        }
        if ((other.CompareTag("Player") ||
            other.CompareTag("UniqueBox")) &
            gameClear == false)
        {
            GameOver();
        }
        else if (boxCount >= finishBoxCount & gameOver == false)
        {
            GameClear();

            float highScore = PlayerPrefs.GetFloat(GameInfoData.nowScene + "_HighScore", 0);
            if (bc_Time < highScore || highScore == 0)
            {
                endTime_ui.SetActive(false);
                GameInfoData.SaveTimeData(bc_Time);
                TextMeshProUGUI tmp = newRecord_ui.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
                tmp.text = "신기록: " + bc_Time.ToString("F2") + "초";
                newRecord_ui.SetActive(true);
            }
        }
    }

    void GameClear()
    {
        gameClear = true;
        success_ui.SetActive(true);
        endTime_ui.GetComponent<TextMeshProUGUI>().text = "걸린 시간: " + gameTimeText + "초";
        Gamemode.sgtn.GameEnd();

        playerController.GameClear();
    }

    void GameOver()
    {
        gameOver = true;
        restart_ui.SetActive(true);
        Gamemode.sgtn.GameEnd();

        playerController.GameOver();
    }
}
