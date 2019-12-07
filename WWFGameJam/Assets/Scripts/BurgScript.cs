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
}
