using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public int resource = 40;

    public static ResourceManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateUI();
        print(resource);
    }





    public void AddResource(int amount) 
    {
        resource += amount;
        UpdateUI();
    }

    public bool SpendResource(int amount) 
    {
        if (resource >= amount )
        {
            resource -= amount;
            UpdateUI();
            return true;
        }
        return false;
    }


    [SerializeField] private TextMeshProUGUI kaynakText;
    private void UpdateUI() 
    {
        kaynakText.text = resource.ToString();
    }


}
