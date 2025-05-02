using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FallCheck : MonoBehaviour
{
    public int boxCount;
    public float bc_Time;
    bool gameOver;
    bool gameClear;

    public Text gameTime;
    string gameTimeText;

    public TextMeshProUGUI fallinBoxTMP;
    public GameObject finishBoxes;
    int finishBoxCount;

    public GameObject restart_ui;
    public GameObject success_ui;
    public GameObject endTime_ui;
    public GameObject newRecord_ui;

    void Start()
    {
        restart_ui.SetActive(false); // SafeCode
        success_ui.SetActive(false); // SafeCode

        finishBoxCount = finishBoxes.transform.childCount;

    }

    void Update()
    {
        if (endTime_ui == null)
            Debug.Log("Null");

        if (!gameOver & Gamemode.sgtn.IsStart() & Gamemode.sgtn.IsEndGame() == false)
        {
            bc_Time += Time.deltaTime;

            gameTimeText = bc_Time.ToString("F2"); // string foramt: "Fn" -> 0.00... (deciaml point * n)
            gameTime.text = "Time: " + gameTimeText;

            fallinBoxTMP.text = "»óÀÚ: " + boxCount + " / " + finishBoxCount;
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
                newRecord_ui.SetActive(true);
                GameInfoData.SaveTimeData(bc_Time);
                TextMeshProUGUI tmp = newRecord_ui.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
                tmp.text += bc_Time.ToString("F2");
                endTime_ui.SetActive(false);
            }
        }
    }

    void GameOver()
    {
        gameOver = true;
        restart_ui.SetActive(true);
        Gamemode.sgtn.GameEnd();
    }

    void GameClear()
    {
        gameClear = true;
        success_ui.SetActive(true);
        endTime_ui.GetComponent<TextMeshProUGUI>().text = gameTimeText;

        Gamemode.sgtn.GameEnd();
    }
}
