using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject impactEffect;
    private Transform target;
    public float explosionRadius = 0f;
    public float speed = 70f;
    public int damage = 50;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceFrame)
        //verifica daca lungimea vectorului dir este mai mica decat distanta pe care o parcurgem in timpul respectiv
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceFrame, Space.World);
        transform.LookAt(target);
    }

    void HitTarget()
    {
        GameObject effect = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effect, 5f);


        if(explosionRadius > 0f)
        {
            Explode();
        } else
        {
            Damage(target);
        }

        Destroy(gameObject);
    }


    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if( e != null) {
            e.TakeDamage(damage);
        }
        
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if(collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
            
        }

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
