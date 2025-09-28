using UnityEngine;

public class Finish : MonoBehaviour
{
    public UIManager uiManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (uiManager != null)
            {
                uiManager.SetGameOver(); 
            }
        }
    }
}
