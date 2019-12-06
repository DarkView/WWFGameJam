using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BurgScript : MonoBehaviour
{
    [SerializeField]
    private int health = 100;

    private EnemyMover enemy;

    public Slider HealthBar;


    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyMover>();
        enemy.WalkForward = true;
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.value = health;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            health -= 25;
            enemy.WalkForward = false;
            enemy.
        }
        
    }

}
