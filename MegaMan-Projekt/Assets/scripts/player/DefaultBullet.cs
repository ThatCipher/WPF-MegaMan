using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultBullet : MonoBehaviour
{
    [Header("Options")]
    [SerializeField] private float _bulletSpeed = 25f;
    [SerializeField] public bool isFlipped = false;

    private void Update()
    {
        Vector3 position = transform.position;

        if(isFlipped)
            position.x += _bulletSpeed * Time.deltaTime;
        else
            position.x -= _bulletSpeed * Time.deltaTime;

        transform.position = position;
    }

    private void OnBecameInvisible()
    {
        // Destroying the Game Object
        Destroy(gameObject);
    }
}
