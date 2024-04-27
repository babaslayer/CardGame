using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class DisplayCard : MonoBehaviour
{
    public static Card displayCard;
    public int displayId;
    public int id;
    public string cardName;
    public int hp;
    public int power;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI powerText;

    void Start()
    {
        displayCard = CardDatabase.cardList[displayId];

        id = displayCard.id;
        cardName = displayCard.cardName;
        power = displayCard.power;
        hp = displayCard.hp;
        nameText.text = cardName;
        hpText.text = " " + hp;
        powerText.text = " " + power;
    }

    void Update()
    {
    }
}
