
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    PlayerController playerController;
    [SerializeField] private float startingHealth;
    private float currentHealth;


    private void Start()
    {
        currentHealth = startingHealth;
    }

    internal void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        if (currentHealth > 0)
        {
            //player gets hurt //healthBarController things
        }
        else
        {
            //player dies
            playerController.KillPlayer();
        }
    }
}
