using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject insaYeri;
    private InteractionController interactionController;
    [SerializeField] private GameObject UI_insa;

    public PlayerController playerController;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        interactionController = GameObject.Find("Player").GetComponent<InteractionController>();
    
    }
    public void CloseUI()
    {
        UI_insa.SetActive(false);
        playerController.canMove = true;

    }

    public void CreateTower(GameObject tower)
    {
        BuildingBase buildingBase = tower.GetComponent<BuildingBase>();
        if (insaYeri!=null && ResourceManager.Instance != null && tower != null && buildingBase!= null){
            if (ResourceManager.Instance.SpendResource(buildingBase.buildCost))
            {
                Instantiate(tower, insaYeri.transform.position, tower.transform.rotation);
                UI_insa.SetActive(false);
                insaYeri.SetActive(false);
                playerController.canMove = true;
                interactionController.insaYeri = null;    
            }
        } 
        else
        {
        print("Kaynak Yok");
        }   
    }

    public void ExitUI()
    {
        UI_insa.SetActive(false);
        playerController.canMove = true;
    }
}
