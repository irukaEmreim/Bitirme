using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetecEnemies : MonoBehaviour
{
    public float detectionRange = 15f;
    [SerializeField] ShootToEnemy shootToEnemy;



    private void Update()
    {
        GameObject closestEnemy = FindClosestEnemy();


        if (closestEnemy != null && Vector3.Distance(closestEnemy.transform.position, transform.position) <= detectionRange)
        {
            shootToEnemy.fireArrowAtEnemy(closestEnemy);

        }
    }

    private GameObject FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;

        float closestDistance = Mathf.Infinity;
        foreach (var enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            if (distance < closestDistance)
            {

                closestDistance = distance;
                closest = enemy;

            }
        }
        return closest;
    }
}
