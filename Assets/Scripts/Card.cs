using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    public string cardName;
    
    public int power;
    public int hp;
    public int id;

    public Card()
    {

    }


    public Card(int Id, string CardName, int Power, int Hp)
    {
        id = Id;
        cardName = CardName;
        power = Power;
        hp = Hp;

    }
}
