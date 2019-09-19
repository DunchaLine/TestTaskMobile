using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HopeItWork : MonoBehaviour
{
    public Transform _objToForw;
    public float _speed;
    
    void Update()
    {
        transform.position = Vector3.Slerp(transform.position, _objToForw.position, _speed * Time.deltaTime);
    }
}
