using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCreated : MonoBehaviour
{
    [SerializeField] private GameObject altNokta;


    private void Start() {
        transform.position = new Vector3(transform.position.x,altNokta.transform.position.y,transform.position.z); 
        StartCoroutine(objeyiYerineTasi());
    }


    public float moveDuration = 2f;
    private IEnumerator objeyiYerineTasi()
    {
        Vector3 startPosition = transform.position;
        float yScale = transform.localScale.y;
        Vector3 targetPosition = new Vector3(transform.position.x,transform.position.y + yScale,transform.position.z);

        float elapsedTime = 0f;

        while (elapsedTime < moveDuration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime; // Geçen süreyi artır
            yield return null; // Bir frame bekle
        }
        transform.position = targetPosition;

    }

}
