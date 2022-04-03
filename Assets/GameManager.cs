using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int amountOfSimlyes = 1000;
    public int startAmount = 1000;
    public int extraAmount = 10;
    public bool gameStarted = false;
    public float timer = 0;
    public float errorTime = 1;
    public float timerstart = 10;
    public GameObject happySmilyPrefab;
    public GameObject sadSmilyPrefab;
    public GameObject SmilesObject;
    public string gameobjectName = "";
    
    public AudioClip hitRight;
    public AudioClip hitWrong;
    [SerializeField]
    Text timerText;
    [SerializeField]
    Text secondTimerText;
    [SerializeField]
    Text score;
    [SerializeField]
    Text seconfScore;

    public int scoreNumb = 0;
    [SerializeField]
    GameObject starPage;
    [SerializeField]
    GameObject gamePage;
    void Start()
    {
        
    }


    public void startGame() {
        gameStarted = true;
        amountOfSimlyes = startAmount;
        timer = timerstart;
        creatAllSmilyes();
        scoreNumb = 0;
        score.text = "round " + scoreNumb.ToString();
        seconfScore.text = "round " + scoreNumb.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        if (gameStarted)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else {
                endGame();
            }
            
            //create timer
            if (Input.GetMouseButtonUp(0))
            {

                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                
                if (Physics.Raycast(ray, out hit))
                {
                   
                    if (hit.transform.name == gameobjectName)
                    {
                        clearSmilyes();
                        timer = timerstart;
                        amountOfSimlyes += 10;
                        creatAllSmilyes();
                        SoundManager.instance.playSFX(hitRight);
                        scoreNumb += 1;
                        score.text = "round " + scoreNumb.ToString();
                        seconfScore.text = "round " + scoreNumb.ToString();
                    }
                    else 
                    {
                        SoundManager.instance.playSFX(hitWrong);
                        Debug.Log(hit.transform.name);
                        timer -= errorTime;
                        
                    }
                }

            }
        }
    }

    private void endGame()
    {
        clearSmilyes();
        gameStarted = false;
        gamePage.SetActive(false);
        starPage.SetActive(true);

    }

    private void LateUpdate()
    {
        if (gameStarted) {
            timerText.text = timer.ToString();
            secondTimerText.text = timer.ToString();
        }
            
    }

    void creatAllSmilyes() {
        for (int i = 0; i<amountOfSimlyes;i++) {
            creatSmilyes(happySmilyPrefab);
        }

        creatSmilyes(sadSmilyPrefab);
    }

    void clearSmilyes() {
        foreach (Transform child in SmilesObject.transform)
        {
            if (child.gameObject != null)
                Destroy(child.gameObject);
        }
    }
    void creatSmilyes(GameObject gameObject) {
        Vector3 screenPosition = 
            Camera.main.ScreenToWorldPoint(
                new Vector3(UnityEngine.Random.Range(0, Screen.width)
                , UnityEngine.Random.Range(0, Screen.height)
                , 10));

        GameObject g = Instantiate(gameObject, screenPosition, Quaternion.identity);
        g.transform.parent = SmilesObject.transform;
        g.name = gameObject.name;
    }
}
