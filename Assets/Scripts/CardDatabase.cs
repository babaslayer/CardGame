using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{
    public static List<Card> cardList = new List<Card>();

    void Awake()
    {
        cardList.Add(new Card(0, "Dragon", 3, 2));
        cardList.Add(new Card(1, "Dark", 2, 4));
    }
}
