using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public List<Card> container = new List<Card>();
    public static List<Card> staticEnemyDeck = new List<Card>();

    public GameObject Hand;
    public GameObject Zone;
    public GameObject Graveyard;

    public int x;
    public static int deckSize;

    public GameObject cardInDeck1;
    public GameObject cardInDeck2;
    public GameObject cardInDeck3;
    public GameObject cardInDeck4;

    public GameObject CardToHand;

    public GameObject[] Clones;

    public static bool draw;

    public GameObject CardBack;

    void Start()
    {
        StartCoroutine(StartGame());

        Hand = GameObject.Find("EnemyHand");
        Zone = GameObject.Find("EnemyZone");
        Graveyard = GameObject.Find("EnemyGraveyard");

        x = 0;
        deckSize = 40;

        draw = true;

        for(int i =0; i < deckSize; i++)
        {
            x = Random.Range(1, CardDatabase.cardList.Count);
            deck[i] = CardDatabase.cardList[x];
        }
    }

    void Update()
    {
        staticEnemyDeck = deck;

        if (deckSize == 3)
        {
            cardInDeck1.SetActive(false);
        }
        if (deckSize == 2)
        {
            cardInDeck2.SetActive(false);
        }
        if (deckSize == 1)
        {
            cardInDeck3.SetActive(false);
        }
        if (deckSize == 0)
        {
            cardInDeck4.SetActive(false);
        }

        if(DisplayCard.drawX > 0)
        {
            StartCoroutine(Draw(DisplayCard.drawX));
            DisplayCard.drawX = 0;
        }

        if(TurnSystem.startTurn == false && draw == false)
        {
            StartCoroutine(Draw(1));
            draw = true;
        }
    }

    public void Shuffle()
    {
        for(int i=0; i < deckSize; i++)
        {
            container[0] = deck[i];
            int randomIndex = Random.Range(i, deckSize);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = container[0];
        }

        Instantiate(CardBack, transform.position, transform.rotation);

        StartCoroutine(ShuffleNow());
    }

    IEnumerator StartGame()
    {
        for(int i = 0; i <= 2; i++)
        {
            yield return new WaitForSeconds(0.5f);
            Instantiate(CardToHand, transform.position, transform.rotation);

        }
    }

    IEnumerator ShuffleNow()
    {
        yield return new WaitForSeconds(0.5f);
        Clones = GameObject.FindGameObjectsWithTag("Clone");

        foreach(GameObject Clone in Clones)
        {
            Destroy(Clone);
        }
    }
    IEnumerator Draw(int x)
    {
        for(int i = 0; i < x; i++)
        {
            yield return new WaitForSeconds(0.5f);
            Instantiate(CardToHand, transform.position, transform.rotation);
        }
    }
}
