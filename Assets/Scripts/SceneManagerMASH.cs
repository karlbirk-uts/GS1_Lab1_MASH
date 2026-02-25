using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagerMASH : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public GameObject TreePrefab;
    public GameObject SoldierPrefab;
    public GameObject HospitalPrefab;

    public GameObject GameOverPrefab;
    public GameObject YouWinPrefab;

    private InputAction inputActionReloadMap;

    private Vector3 PlayerSpawn = new Vector3(-7.5f, 0.0f, 0.0f);
    private Vector3 TreeSpawn1 = new Vector3(1.0f, 1.9f, 0.0f);
    private Vector3 TreeSpawn2 = new Vector3(4.5f, -2.0f, 0.0f);
    private Vector3 SoldierSpawn1 = new Vector3(2.7f, 3.4f, 0.0f);
    private Vector3 SoldierSpawn2 = new Vector3(6.3f, -3.1f, 0.0f);
    private Vector3 SoldierSpawn3 = new Vector3(3.5f, 0.0f, 0.0f);
    private Vector3 SoldierSpawn4 = new Vector3(8.0f, 4.0f, 0.0f);
    private Vector3 SoldierSpawn5 = new Vector3(7.5f, -1.0f, 0.0f);
    private Vector3 HospitalSpawn1 = new Vector3(-5.5f, 2.8f, 0.0f);
    private Vector3 HospitalSpawn2 = new Vector3(-5.6f, -2.5f, 0.0f);

    private Vector3 GameOverSpawn = new Vector3(0.0f, 0.0f, -1.0f);
    private Vector3 YouWinSpawn = new Vector3(0.0f, 0.0f, -1.0f);
    // private Vector3 ResetButtonSpawn = new Vector3(0.0f, 0.0f, -1.0f);


    public int SoldiersInField = 5;
    public int SoldiersInHelicopter = 0;
    public int SoldiersInHospital = 0;

    public bool isGameRunning = true;

    public Text scoreKeepingText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(PlayerPrefab, PlayerSpawn, Quaternion.identity);
        Instantiate(TreePrefab, TreeSpawn1, Quaternion.identity);
        Instantiate(TreePrefab, TreeSpawn2, Quaternion.identity);
        Instantiate(SoldierPrefab, SoldierSpawn1, Quaternion.identity);
        Instantiate(SoldierPrefab, SoldierSpawn2, Quaternion.identity);
        Instantiate(SoldierPrefab, SoldierSpawn3, Quaternion.identity);
        Instantiate(SoldierPrefab, SoldierSpawn4, Quaternion.identity);
        Instantiate(SoldierPrefab, SoldierSpawn5, Quaternion.identity);
        Instantiate(HospitalPrefab, HospitalSpawn1, Quaternion.identity);
        Instantiate(HospitalPrefab, HospitalSpawn2, Quaternion.identity);

        SoldiersInField = GameObject.FindGameObjectsWithTag("Soldier").Length;

        Instantiate(GameOverPrefab, GameOverSpawn, Quaternion.identity);
        Instantiate(YouWinPrefab, YouWinSpawn, Quaternion.identity);

        inputActionReloadMap = InputSystem.actions.FindAction("ReloadMap");

        scoreKeepingText = GameObject
            .FindGameObjectWithTag("Score")
            .GetComponentInChildren<Canvas>()
            .GetComponent<Text>();
        // print(scoreKeepingText.text);
        scoreKeepingText.text = "Soldiers in Helicopter: "
                                + SoldiersInHelicopter
                                + "\nSoldiers Rescued: "
                                + SoldiersInHospital;
    }

    // Update is called once per frame
    void Update()
    {
        if (inputActionReloadMap.IsPressed())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            isGameRunning = true;
        }

        if (isGameRunning)
        {
            if (SoldiersInField <= 0)
            {
                print("You Win!");
                endGameWin();
            }

            if (Time.timeScale < 0.9f)
            {
                Time.timeScale = 1.0f;
            }
        }
        else
        {
            Time.timeScale = 0.0f;
        }
    }


    public void endGameDeath()
    {
        print("endGameDeath()");
        GameObject.FindGameObjectWithTag("GameOver").GetComponent<SpriteRenderer>().enabled = true;
        isGameRunning = false;
    }

    private void endGameWin()
    {
        print("endGameWin()");
        GameObject.FindGameObjectWithTag("YouWin").GetComponent<SpriteRenderer>().enabled = true;
        isGameRunning = false;
    }
}