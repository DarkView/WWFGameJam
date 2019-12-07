using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector3 shootPoint;

    [SerializeField]
    float projectileSpeed = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        shootPoint = transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        MoveProjectile();

        
    }
    /// <summary>
    /// Bewegt dass Projectile nach vorne wenn die entfernung zum shootPoint zu groß wird zerstört sich das geschoss
    /// </summary>
    void MoveProjectile()
    {
        if (Vector3.Distance(shootPoint, transform.position) > GameObject.Find("GameManager").GetComponent<Ability>().MaxProjectileDistance)
        {
            Destroy(this.gameObject);
        }
        else
        {
            transform.Translate(Vector3.forward * projectileSpeed * Time.deltaTime);
        }

    }

   

    private void OnTriggerEnter(Collider other)
    {
        if (!GameObject.Find("GameManager").GetComponent<Ability>().BeaverFever)
        {
            Destroy(gameObject);
        }
    }
}
