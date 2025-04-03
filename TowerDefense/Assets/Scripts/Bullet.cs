using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject impactEffect;
    private Transform target;
    public float speed = 70f;
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
    }

    void HitTarget()
    {
        GameObject effect = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effect, 2f);

        Destroy(target.gameObject);
        Destroy(gameObject);
    }
}
