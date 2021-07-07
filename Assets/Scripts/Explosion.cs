using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    [SerializeField]
    private AudioSource _explosionSound;

    // Start is called before the first frame update
    void Start()
    {
        _explosionSound.Play();
        Destroy(this.gameObject, 3.0f);
    }

}
