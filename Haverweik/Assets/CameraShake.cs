using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private void Start()
    {
        var mouseRay = gameObject.GetComponent<mouseRaycast>();
        mouseRay.takeDMG += StartCameraShake;
    }

    IEnumerator shake(float duration, float magnitude)
    {
        Vector3 origin = transform.localPosition;

        float elapsedTime = 0.0f;
       
        while(elapsedTime < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, origin.z);

            elapsedTime += Time.deltaTime;

            yield return null;
        }
        transform.position = origin;
    }

    private void StartCameraShake()
    {
        StartCoroutine(shake(0.3f, 0.2f));
    }
}
