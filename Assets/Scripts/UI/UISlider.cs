using UnityEngine;

public class UISlider : MonoBehaviour
{
    public GameObject leftButton;
    public GameObject rightButton;
    public GameObject gameStartButton;
    int maxPageCount;
    int count = 0;
    bool sawEndPage;

    void Start()
    {
        maxPageCount = transform.childCount;
        for (int i = 0; i < maxPageCount; i++)
            SetActive(i, false);

        SetActive(0, true);
        leftButton.SetActive(false);
        if (maxPageCount == 1)
            rightButton.SetActive(false);
        else
            gameStartButton.SetActive(false);
    }

    public void ChangePage(bool direction) // ( direction == 0 ): left, ( direction == 1 ): right,
    {
        SetActive(count, false);
        if (direction)
            SetActive(++count, true);
        else
            SetActive(--count, true);

        UpdateButton();
    }

    void UpdateButton()
    {
        if (count == 0)
        {
            leftButton.SetActive(false);
            rightButton.SetActive(true);
        }
        else if (count == maxPageCount - 1)
        {
            leftButton.SetActive(true);
            rightButton.SetActive(false);

            if (sawEndPage == false)
            {
                gameStartButton.SetActive(true);
                sawEndPage = true;
            }
        }
        else
        {
            leftButton.SetActive(true);
            rightButton.SetActive(true);
        }
    }

    void SetActive(int index, bool value)
    {
        transform.GetChild(index).gameObject.SetActive(value);
    }
}
