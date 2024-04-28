using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AICardToHand : MonoBehaviour
{
    public List<Card> displayCard = new List<Card>();

    public int thisId;

    public int id;
    public int cost;
    public string cardName;
    public int hp;
    public int power;
    public Sprite artwork;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI powerText;
    public Image artworkImage;

    public static int DrawX;
    public int drawXcards;
    public int addXmaxMana;

    public int hurted;
    public int actualhp;
    public int returnXcards;

    public GameObject Hand;

    public int z = 0;
    public GameObject It;

    public int numberOfCardsInDeck;

    void Start()
    {
        displayCard[0] = CardDatabase.cardList[thisId];
        Hand = GameObject.Find("EnemyHand");

        z = 0;
        numberOfCardsInDeck = AI.deckSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (z== 0)
        {
            It.transform.SetParent(Hand.transform);
            It.transform.localScale = Vector3.one;
            It.transform.position = new Vector3(transform.position.x, transform.position.y, -48);
            It.transform.eulerAngles = new Vector3(0, 0, 0);
            z = 1;
        }

        id = displayCard[0].id;
        cost = displayCard[0].cost;
        cardName = displayCard[0].cardName;
        power = displayCard[0].power;
        hp = displayCard[0].hp;
        artwork = displayCard[0].artwork;

        drawXcards = displayCard[0].drawXcards;
        addXmaxMana = displayCard[0].addXmaxMana;

        returnXcards = displayCard[0].returnXcards;


        nameText.text = "" + cardName;
        hpText.text = "" + actualhp;

        actualhp = hp - hurted;
        powerText.text = "" + power;
        artworkImage.sprite = artwork;

        if(this.tag == "Clone")
        {
            displayCard[0] = AI.staticEnemyDeck[numberOfCardsInDeck - 1];
            numberOfCardsInDeck -= 1;
            AI.deckSize -= 1;
            this.tag = "Untagged";
        }
    }
}
