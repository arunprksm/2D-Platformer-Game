using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    PlayerController playerController;
    [SerializeField] private float startingHealth;
    public float currentHealth;

    public GameObject Health;
    public Image image;
    private void Start()
    {
        currentHealth = startingHealth;
        image.fillAmount = 1;
    }

    public void TakeDamage(float _damage)
    {
        currentHealth -= _damage;
        //currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        //if (currentHealth > 0)
        //{
        //    //player gets hurt //healthBarController things
        //    image.fillAmount = 1;
        //}
        //else
        //{
        //    //player dies
        //    playerController.KillPlayer();
        //}
    }
}
