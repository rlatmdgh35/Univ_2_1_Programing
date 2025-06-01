using UnityEngine;
using TMPro;

public class LastGamemode : MonoBehaviour
{
    public GameObject gameSuccessUI;
    public GameObject gameOverUI;
    public GameObject newRecordUI;
    public TextMeshProUGUI curtTimeText;
    public TextMeshProUGUI curtCoinText;
    public TextMeshProUGUI resultTime;

    PlayerController playerController;
    bool isStart;
    bool isEndGame;
    int curtPoint = 0;
    int maxPoint = 30;
    float dt;

    void Start()
    {
        gameSuccessUI.SetActive(false);
        gameOverUI.SetActive(false);
        playerController = FindAnyObjectByType<PlayerController>();
    }

    void Update()
    {
        if (isStart)
        {
            if (isEndGame == false)
            dt += Time.deltaTime;

            curtCoinText.text = "���� ����: " + (maxPoint - curtPoint).ToString();
            curtTimeText.text = "���� �ð�: " + dt.ToString("F2");
        }
    }

    public void StartGame()
    {
        isStart = true;
    }

    public void AddPoint(int value)
    {
        curtPoint += value;
        CheckCurrentPoint();
    }

    void CheckCurrentPoint()
    {
        curtPoint = Mathf.Clamp(curtPoint, 0, maxPoint);
        if (curtPoint == maxPoint)
        {
            isEndGame = true;
            gameSuccessUI.SetActive(true);

            float highScore = PlayerPrefs.GetFloat(GameInfoData.nowScene + "_HighScore", 0);
            if (dt < highScore || highScore == 0)
            {
                resultTime.gameObject.SetActive(false);
                GameInfoData.SaveTimeData(dt);
                TextMeshProUGUI tmp = newRecordUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
                tmp.text = "�ű��: " + dt.ToString("F2") + "��";
                newRecordUI.SetActive(true);
            }
            else
            {
                gameSuccessUI.SetActive(true);
                resultTime.text = "�ɸ� �ð�: " + dt.ToString("F2") + "��";
                Gamemode.sgtn.GameEnd();

                playerController.GameClear();
            }

            Gamemode.sgtn.GameEnd();
        }
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
        isEndGame = true;
        playerController.GameOver();
        Gamemode.sgtn.GameEnd();
    }

    public void LoadMainMenu()
    {
        GameInfoData.LoadMainMenu();
    }
}
