using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{
    public static List<Card> cardList = new List<Card>();

    void Awake()
    {
        cardList.Add(new Card(0, "Samuraý", 3, 2, Resources.Load<Sprite>("Artwork/Samurai")));
        cardList.Add(new Card(1, "Guardýan", 4, 4, Resources.Load<Sprite>("Artwork/Guardian")));
        cardList.Add(new Card(2, "Soul", 1, 5, Resources.Load<Sprite>("Artwork/Soul")));
        cardList.Add(new Card(3, "Anomaly", 0, 0, Resources.Load<Sprite>("Artwork/Anomaly")));
    }
}
