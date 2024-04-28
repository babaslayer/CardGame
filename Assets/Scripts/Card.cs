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
    public int cost;

    public int drawXcards;
    public int addXmaxMana;

    public Sprite artwork;

    public int returnXcards;

    public int healXpower;

    public Card()
    {

    }


    public Card(int Id, string CardName, int Power, int Hp, Sprite Artwork, int Cost, int DrawXcards, int AddxmaxMana, int ReturnXcards, int HealXpower )
    {
        id = Id;
        cost = Cost;
        cardName = CardName;
        power = Power;
        hp = Hp;
        artwork = Artwork;

        drawXcards = DrawXcards;
        addXmaxMana = AddxmaxMana;

        returnXcards = ReturnXcards;

        healXpower = HealXpower;

    }
}
