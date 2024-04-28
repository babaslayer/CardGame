using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{
    public static List<Card> cardList = new List<Card>();

    void Awake()
    {
        cardList.Add(new Card(0, "Samuraý", 3, 2, Resources.Load<Sprite>("Artwork/Samurai"), 1, 0, 0, 0, 0));
        cardList.Add(new Card(1, "Guardýan", 4, 4, Resources.Load<Sprite>("Artwork/Guardian"), 1, 0, 0, 0, 0));
        cardList.Add(new Card(2, "Soul", 1, 5, Resources.Load<Sprite>("Artwork/Soul"), 1, 0, 0, 0, 0));
        cardList.Add(new Card(3, "Anomaly", 1, 1, Resources.Load<Sprite>("Artwork/Anomaly"), 1, 0, 0, 0, 0));
    }
}
