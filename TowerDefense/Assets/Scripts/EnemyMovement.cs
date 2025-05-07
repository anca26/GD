using UnityEngine;



[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private int wavepointIndex = 0;

    private Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>();
        target = Waypoints.points[0];

    }

    void Update()
    {
        if (target == null || enemy == null)
        {
            return;
        }

        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);
        //asta i pentru viteza sa nu fluctueze

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }

        enemy.speed = enemy.startSpeed;

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
        WaveSpawner.enemiesAlive--;
        if (PlayerStats.lives <= 0)
        {
            Debug.Log("Game Over");
        }
    }

}
