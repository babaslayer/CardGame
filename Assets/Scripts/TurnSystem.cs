using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TurnSystem : MonoBehaviour
{
    public bool isYourTurn;
    public int yourTurn;
    public int isEnemyTurn;
    public TextMeshProUGUI turnText;

    public static bool startTurn;

    void Start()
    {
        isYourTurn = true;
        yourTurn = 1;
        isEnemyTurn = 0;

        startTurn = false;
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
    }

    public void EndYourTurn()
    {
        isYourTurn = false;
        isEnemyTurn += 1;
    }

    public void EndEnemyTurn()
    {
        isYourTurn = true;
        yourTurn += 1;

        startTurn = true;
    }
}
