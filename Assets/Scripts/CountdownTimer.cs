using TMPro;
using UnityEngine;


public class CountdownTimer : MonoBehaviour
{
    public float countdownDuration = 10f;
    private float currentTime;
    private bool isCounting = false;
    public TextMeshProUGUI countdownText;
    public UIManager uiManager;


    public void StartCountdown()
    {
        currentTime = countdownDuration;
        isCounting = true;
    }

    void Update()
    {
        if (isCounting)
        {
            currentTime -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(currentTime / 60f);
            int seconds = Mathf.FloorToInt(currentTime % 60f);

            countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            if (currentTime <= 0)
            {
                isCounting = false;

                if (uiManager != null)
                {
                    uiManager.SetGameOver(); 
                }
            }
        }
    }


}

