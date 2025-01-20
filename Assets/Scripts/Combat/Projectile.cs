using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private int damage = 35;

    private Transform target;
    public void SetTarget(GameObject closestEnemy)
    {
        target = closestEnemy.transform;
    }

    public float height = 5f;
    public float arrowSpeed = 15f;

    private Vector3 startPosition;
    private float journeyLength;
    private float startTime;

    private void Start()
    {
        startPosition = transform.position;
        startTime = Time.time;
    }

    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
        }
        Vector3 targetPosition = target.position;

        float distanceCovered = (Time.time - startTime) * arrowSpeed;

        journeyLength = Vector3.Distance(startPosition, targetPosition);

        float fractionOfJourney = distanceCovered / journeyLength;

        Vector3 currentPos = Vector3.Lerp(startPosition, targetPosition, fractionOfJourney);

        float heightOffset = Mathf.Sin(fractionOfJourney * Mathf.PI) * height;
        currentPos.y += heightOffset;

        transform.position = currentPos;

        transform.LookAt(targetPosition);

        if (fractionOfJourney >= 1f)
        {
            Destroy(gameObject);
        }

        if (fractionOfJourney >= 1f)
        {
            startPosition = transform.position;
            startTime = Time.time;
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }
}
