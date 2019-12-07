using UnityEngine;
using UnityEngine.UI;

public class BurgScript : MonoBehaviour
{
    public int Health;

    private EnemyMover enemy;

    public Slider HealthBar;

    [SerializeField] private GameObject stage1;
    [SerializeField] private GameObject stage2;
    [SerializeField] private GameObject stage3;



    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyMover>();
        enemy.WalkForward = true;
        Health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.value = Health;
    }

    /* private void OnCollisionEnter(Collision collision)
     {
         if (collision.collider.CompareTag("Enemy"))
         {
             health -= 25;
             enemy.WalkForward = false;
             enemy.GotStick();
         }

     } */

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Health -= 25;
            other.gameObject.GetComponent<EnemyMover>().WalkForward = false;
            other.gameObject.GetComponent<EnemyMover>().GotStick();
            BurgDamageTaken();
        }
    }

    public void BurgDamageTaken()
    {

        switch (Health)
        {
            case 0:
                stage3.SetActive(false);
                break;

            case 25:
                stage2.SetActive(false);
                break;

            case 50: 
                stage1.SetActive(false);
                break;
            default:
                break;
        }

    }

    public void BurgHealthReceived()
    {
        switch (Health)
        {
            case 50:
                stage2.SetActive(true);
                break;

            case 75:
                stage1.SetActive(true);
                break;
            default:
                break;
        }
    }
}
