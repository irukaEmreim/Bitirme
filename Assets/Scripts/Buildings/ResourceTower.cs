using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceTower : BuildingBase
{
    public int resourcePerWave = 40;
    
    public void GenerateResource() 
    {
        ResourceManager.Instance.AddResource(resourcePerWave);
    }


}
