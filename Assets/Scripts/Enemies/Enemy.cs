using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   
    public int health = 100;


    public void TakeDamage(int damage)
    {
        health -= damage;
    }




    

}
