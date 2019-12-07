using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField]
    private float Speed = 4f;

    private float currentSpeed;

    private Vector3 target;

    public bool WalkForward = true;

    private Vector3 startposition;

    public bool StealStick = false;

    private bool gotHit = false;

    [SerializeField] private GameObject stick;

    [SerializeField]
    private float health = 20f;
    
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Burg").transform.position;
        startposition = transform.position;
        stick.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        currentSpeed = Speed * Time.deltaTime;
        if(WalkForward)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, currentSpeed);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startposition, currentSpeed);
        }
        //transform.position = Vector3.MoveTowards(transform.position, player.transform.position, currentSpeed);
        if (!WalkForward && startposition == transform.position)
        {
            Destroy(gameObject);
        }
    }

    public void GotStick()
    {
        stick.gameObject.SetActive(true);
        StealStick = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            WalkForward = false;
            if (StealStick && !gotHit)
            {
                stick.gameObject.SetActive(false);
                GameObject.Find("Burg").GetComponent<BurgScript>().Health += 25;
                GameObject.Find("Score").GetComponent<ScoreScript>().Score += 5;
                StealStick = false;
            }
            else
            {
                GameObject.Find("Score").GetComponent<ScoreScript>().Score += 10;
            }
            gotHit = true;
        }
    }
}
