using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed = 10f;
    private Transform target;
    private int wavpointIndex = 0;
    public int hp = 100;
    public int value = 1;
    // Start is called before the first frame update
    void Start()
    {
        target = waypoints.points[0];
    }

    public void TakeDamage(int amount)
    {
        hp -= amount;

        if (hp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        PlayerStats.Money += value;
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        
        if(Vector3.Distance(transform.position, target.position) <= 0.01f) 
        {
            GetNextWaypoint();
            if(hp<0){
                Destroy(gameObject);
            }
        }
    }

    void GetNextWaypoint()
    {
        if(wavpointIndex >= waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }

        wavpointIndex++;
        target = waypoints.points[wavpointIndex];
    }

    void EndPath ()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }
}
