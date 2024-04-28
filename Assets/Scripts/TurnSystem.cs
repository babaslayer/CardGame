using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TurnSystem : MonoBehaviour
{
    public static bool isYourTurn;
    public int yourTurn;
    public int isEnemyTurn;
    public TextMeshProUGUI turnText;

    public static int maxMana;
    public static int currentMana;
    public TextMeshProUGUI manaText;

    public static bool startTurn;

    public int random;

    public bool turnEnd;
    public TextMeshProUGUI timerText;
    public int seconds;
    public bool timerStart;

    public static int maxEnemyMana;
    public static int currentEnemyMana;
    public TextMeshProUGUI enemyManaText;

    void Start()
    {
       StartGame();

        seconds = 20;
        timerStart = true;
    }


    void Update()
    {
        if(isYourTurn == true)
        {
            turnText.text = "Your Turn";

        }
        else
        {
            turnText.text = "Enemy Turn";
        }

        manaText.text = currentMana + "/" + maxMana;

        if(isYourTurn == true && seconds>0 && timerStart == true)
        {
            StartCoroutine(Timer());
            timerStart = false;
        }

        if (seconds == 0 && isYourTurn == true)
        {
            EndYourTurn();
            seconds = 20;
            timerStart = true;
            
        }

        timerText.text = "Timer: " + seconds;

        if (isYourTurn == false && seconds>0 && timerStart ==  true)
        {
            StartCoroutine(EnemyTimer());
            timerStart = false;
        }

        if(seconds == 0 && isYourTurn == false)
        {
            EndEnemyTurn();
            seconds = 20;
            timerStart = true;
            
        }

        enemyManaText.text = currentEnemyMana + "/" + maxEnemyMana;
    }

    public void EndYourTurn()
    {
        isYourTurn = false;
        isEnemyTurn += 1;

        maxEnemyMana += 1;
        currentEnemyMana +=1;

        AI.draw = false;
    }

    public void EndEnemyTurn()
    {
        isYourTurn = true;
        yourTurn += 1;

        startTurn = true;
        maxMana += 1;
        currentMana += 1;
    }

    public void StartGame()
    {
        random = Random.Range(0,2);
        if(random == 0)
        {
            isYourTurn = true;
            yourTurn = 1;
            isEnemyTurn = 0;

            startTurn = false;

            maxMana = 1;
            currentMana = 1;

            maxEnemyMana = 0;
            currentEnemyMana = 0;
        }

        if(random == 1)
        {
            isYourTurn = false;
            yourTurn = 0;
            isEnemyTurn = 1;

            maxMana = 0;
            currentMana = 0;

            maxEnemyMana = 1;
            currentEnemyMana = 1;

        }
    }

    IEnumerator Timer()
    {
        if(isYourTurn == true && seconds > 0)
        {
            yield return new WaitForSeconds(1);
            seconds--;
            StartCoroutine(Timer());
        }
    }

    IEnumerator EnemyTimer()
    {
        if (isYourTurn == false && seconds > 0)
        {
            yield return new WaitForSeconds(1);
            seconds--;
            StartCoroutine(EnemyTimer());
        }
    }
}
