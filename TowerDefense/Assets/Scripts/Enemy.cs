using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int wavepointIndex = 0;

    public int HP = 100;
    public int value = 50;

    public GameObject deathEffect;

    void Start()
    {
        target = Waypoints.points[0];

    }

    public void TakeDamage(int amount)
    {
        HP -= amount;
        if (HP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        PlayerStats.money += value;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        //asta i pentru viteza sa nu fluctueze

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }

    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }


    void EndPath()
    {
        Destroy(gameObject);
        PlayerStats.lives--;
        if (PlayerStats.lives <= 0)
        {
            Debug.Log("Game Over");
        }
    }

}
