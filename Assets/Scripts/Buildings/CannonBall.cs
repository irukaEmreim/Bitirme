using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    
    public float rotationSpeed = 10f;
    private void Update() {
        if (FindClosestEnemy()!=null)
        {
            Vector3 direction = (FindClosestEnemy().transform.position-transform.position).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
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
