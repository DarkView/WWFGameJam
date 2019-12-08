using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField]
    private float Speed = 4f;

    private float currentSpeed;

    private Vector3 target;

    public bool WalkForward = true;

    private Vector3 startposition;

    public bool StoleStick = false;

    private bool gotHit = false;

    private int killWithoutStick;

    private int killWithStick;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Burg").transform.position;
        startposition = transform.position;
        killWithoutStick = PlayerPrefs.GetInt("KillWithoutStickKey", 0);
        killWithStick = PlayerPrefs.GetInt("KillWithStickKey", 0);
    }

    // Update is called once per frame
    void Update()
    {
        currentSpeed = Speed * Time.deltaTime;
        if(WalkForward)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, currentSpeed);
            transform.LookAt(target);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startposition, currentSpeed);
            transform.LookAt(startposition);
        }
        //transform.position = Vector3.MoveTowards(transform.position, player.transform.position, currentSpeed);
        if (!WalkForward && startposition == transform.position)
        {
            Destroy(gameObject);
        }
    }

    public void GotStick()
    {
        StoleStick = true;
        gameObject.GetComponentInChildren<Animator>().SetBool("StoleStick", true);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile") && !gotHit)
        {
            WalkForward = false;
            if (StoleStick)
            {
                GameObject.Find("Burg").GetComponent<BurgScript>().Health += 25;
                GameObject.Find("Burg").GetComponent<BurgScript>().BurgHealthReceived();
                GameObject.Find("GameManager").GetComponent<ScoreScript>().EnemyHit(5);
                StoleStick = false;
                gameObject.GetComponentInChildren<Animator>().SetBool("StoleStick", false);
                killWithStick++;
                PlayerPrefs.SetInt("KillWithStickKey",killWithStick);
            }
            else
            {
                GameObject.Find("GameManager").GetComponent<ScoreScript>().EnemyHit(5);
                GameObject.Find("GameManager").GetComponent<ScoreScript>().EnemyHit(5);
                killWithoutStick++;
                PlayerPrefs.SetInt("KillWithoutStickKey", killWithoutStick);
            }
            gotHit = true;
            GameObject.Find("Treffer").GetComponent<AudioSource>().pitch = Random.Range(0.6f, 0.9f);
            GameObject.Find("Treffer").GetComponent<AudioSource>().Play();
            gameObject.GetComponentInChildren<Animator>().SetBool("SpatOn", true);
        } 
        else if (other.CompareTag("CloseWarning"))
        {
            WarningManager warn = WarningManager.FindClosestWarningManager(gameObject.transform.position);
            warn.StartCoroutine(warn.ColorWarnObjects("close"));
        } 
        else if (other.CompareTag("FarWarning"))
        {
            WarningManager warn = WarningManager.FindClosestWarningManager(gameObject.transform.position);
            warn.StartCoroutine(warn.ColorWarnObjects("far"));
        }
    }
}
