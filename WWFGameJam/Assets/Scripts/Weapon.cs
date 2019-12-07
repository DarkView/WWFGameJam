using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject projectile;

    [SerializeField]
    private Transform ShootPoint;

    public float FiringDelay = 0.75f;

    private float lastShotDelay = 0f;

    public bool BeaverFever = false;

    void Update()
    {
        lastShotDelay += Time.deltaTime;
        if(BeaverFever == true)
        {
            firingSpeed = 0.5f;
        }
    }
    //Sorgt für den Delay den man beim schießen hat aka wie schnell man schießen kann
    public void Shoot()
    {
        if (lastShotDelay >= FiringDelay)
        {
            Instantiate(projectile, ShootPoint.position, ShootPoint.rotation);
            lastShotDelay = 0f;
        }
        
    }
}
