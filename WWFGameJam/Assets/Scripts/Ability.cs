using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using  UnityEngine.UI;

public class Ability : MonoBehaviour
{
    [SerializeField] private GameObject AbilityButton;
    [SerializeField] private GameObject CooldownButton;
    [SerializeField] private Image CooldownImage;
    private bool coolingDown;
    private float cooldownTime;
    public float MaxProjectileDistance;
    public bool BeaverFever;

    // Start is called before the first frame update
    void Start()
    {
        coolingDown = true;
        cooldownTime = 30f;
        MaxProjectileDistance = 20f;
        BeaverFever = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (coolingDown)
        {
            CooldownButton.SetActive(true);
            CooldownImage.fillAmount -= 1f / cooldownTime * Time.deltaTime;
        }

        if (CooldownImage.fillAmount == 0)
        {
            CooldownButton.SetActive(false);
            CooldownImage.fillAmount = 1f;
            coolingDown = false;
            cooldownTime = 60f;
        }
    }

    public void AbilityButtonActivation()
    {
        StartCoroutine(AbilityActive());
        GameObject.Find("Nagen").GetComponent<AudioSource>().Play();
    }

    IEnumerator AbilityActive()
    {
        coolingDown = true;
        GameObject.Find("Weapon").GetComponent<Weapon>().FiringDelay /= 2;
        MaxProjectileDistance *= 2;
        BeaverFever = true;
        yield return new WaitForSeconds(10);
        GameObject.Find("Weapon").GetComponent<Weapon>().FiringDelay *= 2;
        MaxProjectileDistance /= 2;
        BeaverFever = false;
    }
}
