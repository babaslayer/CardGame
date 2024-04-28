using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

[System.Serializable]
public class DisplayCard : MonoBehaviour
{
    [SerializeField]
    public List<Card> displayCard = new List<Card>();

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

        displayCard[0] = CardDatabase.cardList[displayId];

        
    }

    void Update()
    {
        id = displayCard[0].id;
        cardName = displayCard[0].cardName;
        power = displayCard[0].power;
        hp = displayCard[0].hp;
        artwork = displayCard[0].artwork;

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
            displayCard[0] = PlayerDeck.staticDeck[numberOfCardsInDeck - 1];
            numberOfCardsInDeck -= 1;
            PlayerDeck.deckSize -= 1;
            cardBack = false;
            this.tag = "Untagged";

        }
    }
}
