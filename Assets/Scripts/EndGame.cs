using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndGame : MonoBehaviour
{
    public TextMeshProUGUI loseText;
    public GameObject textObject;

    void Start()
    {
        textObject.SetActive(false);
    }

    void Update()
    {
        if(EnemyHP.staticHp <= 0)
        {
            textObject.SetActive(true);
            loseText.text = "You Win";
        }
    }
}
