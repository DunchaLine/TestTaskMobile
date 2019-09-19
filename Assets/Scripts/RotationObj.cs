using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationObj : MonoBehaviour
{
    float dx, dz;
    public Transform _cube;
    public float _sensitivityX, _sensitivityZ;
    public float speed;
    private int _counterX, _counterY;
    private Vector3 targetDir;
    public float _speedCube;
    void FixedUpdate()
    {
        if ((Input.GetMouseButton(0)) || (Input.touchCount > 0))
        {
            dz = Input.GetAxis("Mouse X") * speed * _sensitivityX;
            dx =  Input.GetAxis("Mouse Y") * speed * _sensitivityZ;
            Vector3 _SomeVector = new Vector3(dx, -20f, -dz);
                
            Debug.Log("DX: " + dx + " DZ: " + dz + " CountX: " + _counterX + " CountY: " +_counterY);
            Physics.gravity = _SomeVector;
            if (dx > 0)
            {
                Vector3 _godPls = new Vector3(_cube.rotation.x, _cube.rotation.y, _counterX / 2);
                targetDir = _godPls - _cube.rotation.eulerAngles;
                Debug.Log("targetDir in dx > 0: " + targetDir);
                _speedCube *= Time.deltaTime;
                _cube.rotation = Quaternion.Lerp(_cube.rotation, Quaternion.Euler(targetDir), .5f);
            }

            if (dx < 0)
            {
                _counterX++;
                Vector3 _godPls = new Vector3(_cube.rotation.x, _cube.rotation.y, _counterX / 2);
                targetDir = _godPls - _cube.rotation.eulerAngles;
                Debug.Log("targetDir in dx < 0: " + targetDir);
                _speedCube *= Time.deltaTime;
                _cube.rotation = Quaternion.Lerp(_cube.rotation, Quaternion.Euler(targetDir), .5f);
            }

            if (dz > 0)
            {
                _counterY--;
                Vector3 _godPls = new Vector3(_counterY / 2, _cube.rotation.y, _cube.rotation.z);
                targetDir = _godPls - _cube.rotation.eulerAngles;
                    Debug.Log("targetDir in dz > 0: " + targetDir);
                _speedCube *= Time.deltaTime;
                _cube.rotation = Quaternion.Lerp(_cube.rotation, Quaternion.Euler(targetDir), .5f);
            }

            if (dz < 0)
            {
                _counterY++;
                Vector3 _godPls = new Vector3(_counterY / 2, _cube.rotation.y, _cube.rotation.z);
                targetDir = _godPls - _cube.rotation.eulerAngles;
                Debug.Log("targetDir in dz < 0: " + targetDir);
                _speedCube *= Time.deltaTime;
                _cube.rotation = Quaternion.Lerp(_cube.rotation, Quaternion.Euler(targetDir), .5f);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            Physics.gravity = new Vector3(0f, -20f, 0f);
            _cube.eulerAngles = new Vector3(0f, 0f, 0f);
            _counterX = 0;
            _counterY = 0;
            Debug.Log("DX: " + dx + " DZ: " + dz + " CountX: " + _counterX + " CountY: " +_counterY);
        }
        //СДЕЛАТЬ ПЛАВНЫЙ ПОВОРОТ КАМЕРЫ (??УБРАТЬ СИНЕМАШИНУ??), ДОБАВИТЬ ТЕЛЕПОРТ И КНОПКУ РЕСТАРТА ИГРЫ, 
        //ПЕРЕДЕЛАТЬ ИГРУ ПОД АНДРОИД
    }
}
