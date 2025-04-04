using UnityEngine;

public class Gamemode : MonoBehaviour
{
    public int boxCount;
    public float bc_Time;
    bool gameover;

    void OnTriggerEnter(Collider obj)
    {
        if (obj.CompareTag("Box"))
        {
            boxCount++;
            Debug.Log("BoxCount: " + boxCount);
        }
        else if (obj.CompareTag("Player") | obj.CompareTag("UniqueBox"))
            GameOver();

        if (boxCount >= 3)
            GameOver();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameover)
            bc_Time += Time.deltaTime;
    }

    void GameOver()
    {
        gameover = true;
        Debug.Log("Game Over");
    }
}
