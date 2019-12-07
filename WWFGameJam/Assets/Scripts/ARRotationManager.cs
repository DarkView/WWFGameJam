
using UnityEngine;

public class ARRotationManager : MonoBehaviour
{

    public GameObject TestObject;

    private Gyroscope gyro;

    void Update()
    {
        //TestObject.transform.rotation = gyro.attitude * rot;
        TestObject.transform.rotation = Quaternion.Euler(0, gyro.attitude.z * 180, 0).normalized;
    }

    private void Start()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
        }
        else
        {
            //Application.Quit(0);
        }
    }
}
