using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class BurgScript : MonoBehaviour
{
    public int Health;

    private EnemyMover enemy;

    public Slider HealthBar;

    [SerializeField] private GameObject stage1;
    [SerializeField] private GameObject stage2;
    [SerializeField] private GameObject stage3;
    [SerializeField] private GameObject deathAnim;
    private float delay;

    private GameObject[] knack;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyMover>();
        enemy.WalkForward = true;
        Health = 100;
        knack = GameObject.FindGameObjectsWithTag("Knack");
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

            WarningManager warn = WarningManager.FindClosestWarningManager(other.transform.position);
            warn.StartCoroutine(warn.ColorWarnObjects("damage"));
        }
    }

    public void BurgDamageTaken()
    {

        switch (Health)
        {
            case 0:
                StartCoroutine(DamStoleSound(3));
                stage3.SetActive(false);
                GameObject.Find("biber").GetComponent<Renderer>().enabled = false;
                deathAnim.SetActive(true);
                StartCoroutine(GameOver());
                break;

            case 25:
                stage2.SetActive(false);
                StartCoroutine(DamStoleSound(4));
                break;

            case 50: 
                stage1.SetActive(false);
                StartCoroutine(DamStoleSound(3));
                break;
            case 75:
                StartCoroutine(DamStoleSound(2));
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

    private void BurgRegeneration()
    {

        switch (Health)
        {
            case 50:
                GameObject.Find("Stage2").SetActive(true);
                break;

            case 75:
                GameObject.Find("Stage1").SetActive(true);
                break;

            default:
                break;
        }

    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(0.8f);
        GameObject.Find("Platsch").GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadSceneAsync("DefeatScreen");
    }

    IEnumerator DamStoleSound(int timer)
    {
        while (timer > 0)
        {
            knack[Random.Range(0, knack.Length)].GetComponent<AudioSource>().Play();
            timer--;
            yield return new WaitForSeconds(0.2f);
        }
    }
    

}
