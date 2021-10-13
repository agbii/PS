using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{

    public GameObject startPanel;
    public GameObject continuePanel;
    public GameObject successPanel;
    public GameObject failPanel;
    public static gameManager I;

    void Awake()
    {
        I = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        initializeGame();
    }

    private void initializeGame() {
        showStartPanel();
    }

    private void showStartPanel()
    {
        startPanel.SetActive(true);
        // spawnStones
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gameStart() {
        //string sceneName = "TestLevel";
        // SceneManager.LoadScene(sceneName);
        startPanel.SetActive(false);
        //spawnStones();
    }
}
