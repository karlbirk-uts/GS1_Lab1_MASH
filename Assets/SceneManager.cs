using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public GameObject TreePrefab;
    public GameObject SoldierPrefab;
    public GameObject HospitalPrefab;

    private Vector3 PlayerSpawn = new Vector3(-7.5f, 0.0f, 0.0f);
    private Vector3 TreeSpawn1 = new Vector3(-7.5f, 0.0f, 0.0f);
    private Vector3 TreeSpawn2 = new Vector3(-7.5f, 0.0f, 0.0f);
    private Vector3 SoldierPrefab1 = new Vector3(-7.5f, 0.0f, 0.0f);
    private Vector3 SoldierPrefab2 = new Vector3(-7.5f, 0.0f, 0.0f);
    private Vector3 SoldierPrefab3 = new Vector3(-7.5f, 0.0f, 0.0f);
    private Vector3 SoldierPrefab4 = new Vector3(-7.5f, 0.0f, 0.0f);
    private Vector3 SoldierPrefab5 = new Vector3(-7.5f, 0.0f, 0.0f);
    private Vector3 HospitalSpawn1 = new Vector3(-7.5f, 0.0f, 0.0f);
    private Vector3 HospitalSpawn2 = new Vector3(-7.5f, 0.0f, 0.0f);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(PlayerPrefab, PlayerSpawn, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
    }
}