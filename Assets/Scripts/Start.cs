using UnityEngine;

public class StartZoneTrigger : MonoBehaviour
{
    public CountdownTimer countdownTimer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            countdownTimer.StartCountdown();
            gameObject.SetActive(false); 
        }
    }
}
