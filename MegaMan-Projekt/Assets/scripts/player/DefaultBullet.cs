using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultBullet : MonoBehaviour
{

    [Header("Options")] 
    [SerializeField] private float _bulletSpeed = 25f;
    
    private void Update()
    {
        Vector3 position = transform.position;
        position.x += _bulletSpeed;
        transform.position = position;
    }
}
