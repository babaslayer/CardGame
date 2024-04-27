using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Card
{
    public string cardName;
    
    public int power;
    public int hp;
    public int id;

    public Sprite artwork;

    public Card()
    {

    }


    public Card(int Id, string CardName, int Power, int Hp, Sprite Artwork)
    {
        id = Id;
        cardName = CardName;
        power = Power;
        hp = Hp;
        artwork = Artwork;

    }
}
