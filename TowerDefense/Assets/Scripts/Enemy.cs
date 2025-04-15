using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;

    public float HP = 100;
    public int worth = 50;

    public GameObject deathEffect;

    void Start()
    {
        speed = startSpeed;
    }

    public void TakeDamage(float amount)
    {
        HP -= amount;
        if (HP <= 0)
        {
            Die();
        }
    }

    public void Slow(float amount)
    {
        speed = startSpeed * (1f - amount);
    }

    void Die()
    {
        PlayerStats.money += worth;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
    }

   

}
