using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class AIManager : MonoBehaviour
{
    public int attackPower = 9;
    private Rigidbody enemyRb;
    private Enemy enemy;
    private Animator animator;
    private float rotationSpeed = 100;
    private NavMeshAgent agent;
    void Start()
    {
        enemy = GetComponent<Enemy>();
        animator = GetComponent<Animator>();
        enemyRb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        //agent.SetDestination(FindClosestEnemy().transform.position);
        StartCoroutine(HedefBelirle());
        StartCoroutine(SaldiriSekliniDegis());
    }

    
    public bool kuleyeGeldi = false;
    private int[] saldiriTuru = {0,1,2};
    public int sonSaldiriSekli = 0;
    public float yaklasmaMesafesi = 0.5f;
    void Update()
    {
        print(agent.speed);
        if (enemy.health<=0)
        {
            agent.speed = 0;
            animator.SetTrigger("isDead"); 
            Destroy(gameObject,2.8f);  
        }
        else
        {
            if (Vector3.Distance(transform.position,FindClosestTower().transform.position + HedeflenecekTarafBelirle())<yaklasmaMesafesi)
            {
                kuleyeGeldi = true;
            }
            if (kuleyeGeldi)
            {
                LookClosestTower();
                agent.speed = 0f;
                animator.SetFloat("Speed",agent.speed);
                animator.SetInteger("Attack",sonSaldiriSekli);
                if (!isAttacking)
                {
                    StartCoroutine(Attack(FindClosestTower()));                   
                }
                
            }
            if (kuleyeGeldi && agent.speed>0.5f)
            {
                print("BURASI ÇALIŞYIOR MU");
                HedefeGit(FindClosestTower().transform);
                kuleyeGeldi = false;
            }
            if(Vector3.Distance(transform.position,FindClosestTower().transform.position + HedeflenecekTarafBelirle())>=yaklasmaMesafesi)
            {
                kuleyeGeldi = false;
            }
            if(!kuleyeGeldi)
            {
                agent.speed = 1.6f;
                animator.SetFloat("Speed",agent.speed);
            }

           
            
        }
    }

    private bool isAttacking = false;
     private IEnumerator Attack(GameObject target)
    {
        isAttacking = true;
        agent.isStopped = true; // Hareketi durdur

        // Saldırı animasyonu başlat
        if (animator != null)
        {
            animator.SetInteger("Attack",sonSaldiriSekli);
        }

        // Hedefe hasar ver
        yield return new WaitForSeconds(4.4f); // Saldırı animasyonunun süresine göre zamanlayın
        if (target != null)
        {
            target.GetComponent<BuildingBase>()?.TakeDamage(attackPower);
        }
        else
        {
            agent.isStopped = false;
        }

        isAttacking = false; // Saldırı tamamlandı
    }

    private IEnumerator SaldiriSekliniDegis()
    {
        while (true)
        {
            print("ALOO");
            sonSaldiriSekli = saldiriTuru[Random.Range(0,3)];
            yield return new WaitForSeconds(6);
        }
    }

    private GameObject FindClosestTower()
    {
        print("CLOSEST TOWER BULUNDU");
        GameObject[] towers = GameObject.FindGameObjectsWithTag("Kule");
        GameObject closest = null;

        float closestDistance = Mathf.Infinity;
        foreach (var tower in towers)
        {
            float distance = Vector3.Distance(transform.position, tower.transform.position);

            if (distance < closestDistance)
            {

                closestDistance = distance;
                closest = tower;

            }
        }
        return closest;
    }

   public void HedefeGit(Transform transform)
   {
    agent.SetDestination(transform.position+HedeflenecekTarafBelirle());
   }

    private IEnumerator HedefBelirle()
    {
        while(true){
        HedefeGit(FindClosestTower().transform);
        yield return new WaitForSeconds(5f);
        } 
    }

private Vector3 HedeflenecekTarafBelirle()
    {
        Transform target = FindClosestTower().transform;
        Vector3 offset;
        if (target.position.x > transform.position.x)
        {
            if (target.position.z > transform.position.z)
            {
                offset = new Vector3(-0.05f, 0, -0.05f);
            }
            else
            {
                offset = new Vector3(-0.05f, 0,-0.05f);
            }
        }
        else
        {
            if (target.position.z > transform.position.z)
            {
                offset = new Vector3(-0.05f, 0, -0.05f);
            }
            else
            {
                offset = new Vector3(-0.05f, 0, -0.05f);
            }
        }

        return offset;
    }

    private void LookClosestTower()
    {
        Vector3 direction = (FindClosestTower().transform.position-transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }




}
