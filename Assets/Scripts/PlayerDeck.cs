using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeck : MonoBehaviour
{
    [SerializeField]
    public int x;
    public static int deckSize;
    public List<Card> deck = new List<Card>();
    public static List<Card> staticDeck = new List<Card>();
    public List<Card> container = new List<Card>();

    public GameObject cardInDeck1;
    public GameObject cardInDeck2;
    public GameObject cardInDeck3;
    public GameObject cardInDeck4;

    public GameObject CardToHand;
    public GameObject[] Clones;
    public GameObject Hand;

    private void Start()
    {
        x = 0;
        deckSize = 40;

        for (int i = 0; i < deckSize; i++)
        {
            x = Random.Range(1, CardDatabase.cardList.Count);
            deck[i] = CardDatabase.cardList[x];
        }

        StartCoroutine(StartGame());
    }

    private void Update()
    {
        staticDeck = deck;

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
    }

    public void Shuffle()
    {
        for(int i = 0; i < deckSize; i++)
        {
            container[0] = deck[i];
            int randomIndex = Random.Range(i, deckSize);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = container[0];
        }
    }

    IEnumerator StartGame()
    {
        for (int i = 0; i <= 2; i++)
        {
            yield return new WaitForSeconds(1f);
            //NEW
            //audioSource.PlayOneShot(SpriteDrawMode, 1f);
            //NEW
            Instantiate(CardToHand, transform.position, transform.rotation);
        }
    }

}
