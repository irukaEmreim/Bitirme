using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractionController : MonoBehaviour
{

    public GameObject insaYeri;
    [SerializeField] private Transform playerHead;
    [SerializeField] private GameObject binaYerlestirmeSecenekleri;
    private PlayerController playerController;
    [SerializeField] private UIManager uIManager;
    
    void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    void FixedUpdate()
    {
        RaycastHit raycastHit;

        if (Physics.Raycast(playerHead.position,playerHead.forward,out raycastHit,0.2f) && Input.GetMouseButtonDown(0))
        {
            
            if (raycastHit.collider.gameObject.CompareTag("insaYeri"))
            {   
                uIManager.insaYeri = insaYeri;
                playerController.canMove = false;
                insaYeri = raycastHit.collider.gameObject;
                binaYerlestirmeSecenekleri.SetActive(true);
            }
        }

    }
}
