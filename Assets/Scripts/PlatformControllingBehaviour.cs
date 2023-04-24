using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformControllingBehaviour : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    [SerializeField] private Rigidbody _rigidBody;

    // Update is called once per frame
    void Update()
    {
        _rigidBody.velocity = new Vector3( -1 * speed, 0, 0);   
    }
}
