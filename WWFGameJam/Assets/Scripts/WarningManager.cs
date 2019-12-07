using System.Collections;
using UnityEngine;

public class WarningManager : MonoBehaviour
{

    [SerializeField] private GameObject warningObject;
    [SerializeField] private Material closeMaterial;
    [SerializeField] private Material farMaterial;
    [SerializeField] private Material damageMaterial;

    public IEnumerator ColorWarnObjects(string distance)
    {
        Material newMat = closeMaterial;

        switch (distance)
        {
            case "close":
                newMat = closeMaterial;
                break;
            case "far":
                newMat = farMaterial;
                break;
            case "damage":
                newMat = damageMaterial;
                break;
        }

        warningObject.GetComponent<Renderer>().material = newMat;
        warningObject.GetComponent<Renderer>().enabled = true;

        yield return new WaitForSeconds(0.4f);

        warningObject.GetComponent<Renderer>().enabled = false;

    }

    public static WarningManager FindClosestWarningManager(Vector3 position)
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("WarnManager");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest.GetComponent<WarningManager>();
    }

}
