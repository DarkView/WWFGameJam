using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BurgScript : MonoBehaviour
{
    public int Health;

    private EnemyMover enemy;

    public Slider HealthBar;


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
        BurgDamage();
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
        }
    }

    private void BurgDamage()
    {

        switch (Health)
        {
            case 25:
                GameObject.Find("Stage3").SetActive(false);
                break;

            case 50:
                GameObject.Find("Stage2").SetActive(false);
                break;

            case 75: GameObject.Find("Stage1").SetActive(false);
                break;
            case 0:
                break;
            default:
                break;
        }

    }
}
