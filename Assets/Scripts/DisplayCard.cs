using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

[System.Serializable]
public class DisplayCard : MonoBehaviour
{
    public static Card displayCard;

    public int displayId;
    public int id;
    public string cardName;
    public int hp;
    public int power;
    public Sprite artwork;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI powerText;
    public Image artworkImage;

    public bool cardBack;
    public static bool staticCardBack;

    public GameObject Hand;
    public int numberOfCardsInDeck;

    void Start()
    {
        numberOfCardsInDeck = PlayerDeck.deckSize;

        displayCard = CardDatabase.cardList[displayId];

        
    }

    void Update()
    {
        id = displayCard.id;
        cardName = displayCard.cardName;
        power = displayCard.power;
        hp = displayCard.hp;
        artwork = displayCard.artwork;

        nameText.text = "" + cardName;
        hpText.text = "" + hp;
        powerText.text = "" + power;
        artworkImage.sprite = artwork;

        Hand = GameObject.Find("Hand");
        if(this.transform.parent == Hand.transform.parent)
        {
            cardBack = false;
        }

        staticCardBack = cardBack;

        if(this.tag == "Clone")
        {
            displayCard = PlayerDeck.staticDeck[numberOfCardsInDeck - 1];
            numberOfCardsInDeck -= 1;
            PlayerDeck.deckSize -= 1;
            cardBack = false;
            this.tag = "Untagged";

        }
    }
}
