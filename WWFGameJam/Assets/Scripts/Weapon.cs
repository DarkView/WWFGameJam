using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject projectile;

    [SerializeField]
    private Transform ShootPoint;

    [SerializeField]
    private float firingSpeed = 1f;

    private float lastShotDelay = 0f;

    void Update()
    {
        lastShotDelay += Time.deltaTime;
    }
    //Sorgt für den Delay den man beim schießen hat aka wie schnell man schießen kann
    public void Shoot()
    {
        if (lastShotDelay >= firingSpeed)
        {
            Instantiate(projectile, ShootPoint.position, ShootPoint.rotation);
            lastShotDelay = 0f;
        }
        
    }
}
