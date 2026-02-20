using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public GameObject TreePrefab;
    public GameObject SoldierPrefab;
    public GameObject HospitalPrefab;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(PlayerPrefab, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
    }
}