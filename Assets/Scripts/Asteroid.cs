using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private float _zRot = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //rotate on z
        MovementAst();
    }

    private void MovementAst()
    {
       
        transform.Rotate(Vector3.forward * _zRot * Time.deltaTime);
    }
}
