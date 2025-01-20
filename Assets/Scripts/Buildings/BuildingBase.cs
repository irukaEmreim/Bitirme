using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBase : MonoBehaviour
{
    public int health = 100;
    public int buildCost = 50;
    public string buildingName;

    public void TakeDamage(int damage)  // Enemy AI'de hasar verirken kullan�lacak.
    {
        health -= damage;
    }

    protected virtual void DestroyBuilding() 
    {
        print(buildingName+"yok edildi");
        Destroy(gameObject);
    }

    private void Update()
    {
        if (health <= 0)
        {
            DestroyBuilding();
        }
    }

}
