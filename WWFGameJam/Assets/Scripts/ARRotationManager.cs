using System;
using UnityEngine;

public class ARRotationManager : MonoBehaviour
{

    public GameObject TestObject;
    public Transform ARObject;

    private Quaternion previousRotation;
    private Quaternion trota;

    void Update()
    {
        TestObject.transform.SetPositionAndRotation(TestObject.transform.position, new Quaternion(trota.x, trota.y, ARObject.transform.rotation.y, trota.w));
        previousRotation = ARObject.rotation;
    }

    private void Start()
    {
        trota = TestObject.transform.rotation;
        previousRotation = ARObject.rotation;
    }
}
