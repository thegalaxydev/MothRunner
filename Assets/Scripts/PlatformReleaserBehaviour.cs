using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformReleaserBehaviour : MonoBehaviour
{
    [SerializeField] private PlatformPoolBehaviour _platformPool;

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("A collision/ Trigger event has occurred");
        if (collision.CompareTag("Platform"))
        {
            _platformPool.ReleasePlatform(collision.gameObject);
            _platformPool.SpawnPlatform();
        }
    }
}
