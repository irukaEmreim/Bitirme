using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BinaKurmaYeri : MonoBehaviour
{
    public float speed = 2f;
    public float rotationSpeed = 100f;
    private bool hedefeGeldiMi = false;
    private void Update() {

        if (!hedefeGeldiMi)
        {
            transform.position = Vector3.Lerp(transform.position,new Vector3(transform.position.x,0.53f,transform.position.z),speed * Time.deltaTime);
            if (Vector3.Distance(transform.position,new Vector3(transform.position.x,0.53f,transform.position.z))<0.005f)
            {
                hedefeGeldiMi = true;
            }
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position,new Vector3(transform.position.x,0.5f,transform.position.z),speed * Time.deltaTime);   
            if (Vector3.Distance(transform.position,new Vector3(transform.position.x,0.5f,transform.position.z))<0.005f)
            {
                hedefeGeldiMi = false;
            }
        }

        transform.Rotate(0,rotationSpeed * Time.deltaTime,0);
    }
}
