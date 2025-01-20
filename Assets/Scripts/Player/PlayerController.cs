using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody stickmanKingRb;
    public Transform orientation;
    private float verticalInput;
    public bool canMove = true;
    private AudioSource audioSource;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float walkSpeed = 0.5f;
    [SerializeField] private float runSpeed = 1f;
    [SerializeField] private float rotationSpeed = 100f;
    private float speed;

    private void Awake()
    {
        stickmanKingRb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // Hareket girdi kontrolü
        verticalInput = Input.GetAxis("Vertical");

        // Hız değişikliği
        speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

    }

    private void FixedUpdate()
    {
        MovePlayer();
        if (canMove)
        {
            RotateTowardsMouse();
        }
        stickmanKingRb.angularVelocity = Vector3.zero;
    }

    private bool isPlayingFootsteps = false;
    private void MovePlayer()
    {
        if (canMove)
        {
            Vector3 moveDirection = (orientation.forward * verticalInput).normalized;
            stickmanKingRb.velocity = moveDirection * speed;
            if (speed == runSpeed && !isPlayingFootsteps)
            {
                audioSource.Play();
                isPlayingFootsteps = true;
            }
            else if (speed != runSpeed && isPlayingFootsteps)
            {
                audioSource.Stop();
                isPlayingFootsteps = false;
            }
        }
        else
        {
            stickmanKingRb.velocity = Vector3.zero;
        }
    }


    private void RotateTowardsMouse()
    {
        Ray mouseRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(mouseRay, out RaycastHit hit))
        {
            Vector3 targetPoint = new Vector3(hit.point.x, transform.position.y, hit.point.z);

            Vector3 direction = (targetPoint - transform.position).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
