using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaking : MonoBehaviour
{
    [SerializeField]
    private float shakeTime;

    Vector3 cameraStart;

    // Start is called before the first frame update
    void Start()
    {
        cameraStart = transform.position;
        
    }

    IEnumerator isShaking()
    {
        
        float timeElapsed = 0f;
        shakeTime = 10f * Time.deltaTime + Time.deltaTime;

        while (timeElapsed < shakeTime)
        {
            timeElapsed += Time.deltaTime;
            transform.position = cameraStart + new Vector3(Random.Range(-.5f, .5f), Random.Range(-.5f, .5f), 0);

            yield return null;
        }

        transform.position = cameraStart;
        
    }

    public void CameraShake()
    {
        StartCoroutine(isShaking());
    }

}
