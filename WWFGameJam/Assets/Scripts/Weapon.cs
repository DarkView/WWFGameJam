using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    Transform ShootPoint;

    public GameObject projectile;

    [SerializeField]
    float firingSpeed = 20;

    public static Weapon Instance;

    private float lastTimeShot = 0;

    void Awake()
    {
        Instance = GetComponent<Weapon>();
    }

    void Update()
    {


    }
    //Sorgt für den Delay den man beim schießen hat aka wie schnell man schießen kann
    public void Shoot()
    {
        if (lastTimeShot + firingSpeed <= Time.time)
        {
            lastTimeShot = Time.time;
            Instantiate(projectile, ShootPoint.position, ShootPoint.rotation);
        }
        
    }
}
