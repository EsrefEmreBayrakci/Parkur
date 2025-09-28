using UnityEngine;
using UnityEngine.UI;

public class HealtController : MonoBehaviour
{
    public int maxHealth = 100; 
    private int currentHealth; 

    public Slider healthBar; 

    public Image backgroundImage; 

    public UIManager uiManager;

    private void Start()
    {
        currentHealth = maxHealth; 
        healthBar.value = currentHealth;
    }

    public void hasarAl(int damage)
    {

        currentHealth -= damage; 
        healthBar.value = currentHealth; 
        UpdateBackgroundVisibility(); 
        if (currentHealth <= 0)
        {
            if (uiManager != null)
            {
                uiManager.SetGameOver();
            }
        }
    }


    public void iyiles(int healAmount)
    {
        currentHealth += healAmount; 
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth; 
        }
        healthBar.value = currentHealth; 
        UpdateBackgroundVisibility(); 
    }


    void UpdateBackgroundVisibility()
    {

        backgroundImage.enabled = (currentHealth < maxHealth);


    }
}
