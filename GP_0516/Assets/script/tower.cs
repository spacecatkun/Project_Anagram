using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class tower : MonoBehaviour
{
    public Transform target;
    public float range = 5f;
    public string enemyTag = "Enemy";
    public Transform A_part;
    public float rotationSpeed = 200f;
    public float dps = 1f;
    private float fireCountdown = 0f;

    public GameObject bulletPrefab;
    public Transform firePoint;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);   
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanveToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanveToEnemy < shortestDistance)
            {
                shortestDistance = distanveToEnemy;
                nearestEnemy = enemy;
            }
        }
        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {return;}

        float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg - 90f;
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle);
        A_part.rotation = Quaternion.RotateTowards(A_part.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        if(fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f/dps;
        }
        fireCountdown -= Time.deltaTime;

    }

    private void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet bullet = bulletGO.GetComponent<bullet>();

        if(bullet != null)
        {
            bullet.Seek(target);
        }
    }

    private void OnDrawGizmosSelected() 
    {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, range);
    }
}