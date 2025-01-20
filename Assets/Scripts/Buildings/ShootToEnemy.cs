using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShootToEnemy : MonoBehaviour
{    
    private AudioSource audioSource;
    private bool canShoot = true;
    [SerializeField] float timer = 2;
    [SerializeField] GameObject weaponPrefab;
    [SerializeField] List<Transform> firePoints;
    IEnumerator shootTimer()
    {
        yield return new WaitForSeconds(timer);
        canShoot = true;

    }

    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    private Transform enYakin;
    public void fireArrowAtEnemy(GameObject closestEnemy)
    {
        if (canShoot)
        {
            float mesafe = Mathf.Infinity;
            foreach (Transform item in firePoints)
            {
                if (Vector3.Distance(item.position, closestEnemy.transform.position) <= mesafe)
                {
                    mesafe = Vector3.Distance(item.position, closestEnemy.transform.position);
                    enYakin = item;
                }
            }
            audioSource.Play();
            GameObject projectile = Instantiate(weaponPrefab, enYakin.position, Quaternion.identity);
            if (closestEnemy != null)
            {
                projectile.GetComponent<Projectile>().SetTarget(closestEnemy);
                canShoot = false;
                StartCoroutine(shootTimer());
            }
            else
            {
                Destroy(projectile);
            }
        }

    }



}
