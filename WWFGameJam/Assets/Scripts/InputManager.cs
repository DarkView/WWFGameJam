using UnityEngine;

public class InputManager : MonoBehaviour
{

    public GameObject BiberGameObject;

    private Gyroscope gyro;

    void Update()
    {
        //TestObject.transform.rotation = gyro.attitude * rot;
        BiberGameObject.transform.rotation = Quaternion.Euler(90, gyro.attitude.z * -180, 0);

        if (Input.touchCount > 0)
        {
            GameObject.Find("Weapon").GetComponent<Weapon>().Shoot();
        }
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
