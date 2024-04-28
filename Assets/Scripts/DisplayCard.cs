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

    public int id;
    public int displayId;

    public int cost;
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

    public bool canBeSummon;
    public bool summoned;
    public GameObject safeZone;
    public GameObject safeZone2;
    public GameObject safeZone3;

    public static int drawX;
    public int drawXcards;
    public int addXmaxMana;

    public GameObject attackBorder;

    public GameObject Target;
    public GameObject Enemy;

    public bool summoningSickness;
    public bool cantAttack;

    public bool canAttack;

    public static bool staticTargeting;
    public static bool staticTargetingEnemy;

    public bool targeting;
    public bool targetingEnemy;

    public bool onlyThisCardAttack;

    public GameObject summonBorder;

    public bool canBeDestroyed;
    public GameObject Graveyard;
    public bool beInGraveyard;

    public int hurted;
    public int actualhp;
    public int returnXcards;
    public bool useReturn;

    public static bool UcanReturn;

    public int healXpower;
    public bool canHeal;

    void Start()
    {
        numberOfCardsInDeck = PlayerDeck.deckSize;

        displayCard[0] = CardDatabase.cardList[displayId];
        canBeSummon = false;
        summoned = false;

        drawX = 0;

        canAttack = false;
        summoningSickness = true;

        Enemy = GameObject.Find("Enemy HP");

        targeting = false;
        targetingEnemy = false;

        canHeal = true;
    }
    
    void Update()
    {
        id = displayCard[0].id;
        cost = displayCard[0].cost;
        cardName = displayCard[0].cardName;
        power = displayCard[0].power;
        hp = displayCard[0].hp;
        artwork = displayCard[0].artwork;

        drawXcards = displayCard[0].drawXcards;
        addXmaxMana = displayCard[0].addXmaxMana;

        returnXcards = displayCard[0].returnXcards;

        healXpower = displayCard[0].healXpower;

        nameText.text = "" + cardName;
        hpText.text = "" + actualhp;

        actualhp = hp-hurted;
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


        if (TurnSystem.currentMana >= cost && summoned == false && beInGraveyard == false && TurnSystem.isYourTurn == true)
        {
            canBeSummon = true;
        }
        else
        {
            canBeSummon = false;
        }

        if (canBeSummon ==true)
        {
            gameObject.GetComponent<DragDrop3>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<DragDrop3>().enabled = false;
        }

        safeZone = GameObject.Find("SafeZone");
        safeZone2 = GameObject.Find("SafeZone2");
        safeZone3 = GameObject.Find("SafeZone3");

        if (summoned ==false && this.transform.parent == safeZone.transform)
        {
            Summon();
        }

        if (summoned == false && this.transform.parent == safeZone2.transform)
        {
            Summon();
        }

        if (summoned == false && this.transform.parent == safeZone3.transform)
        {
            Summon();
        }

        if(canAttack == true && beInGraveyard == false)
        {
            attackBorder.SetActive(true);
        }
        else
        {
            attackBorder.SetActive(false);
        }

        if(TurnSystem.isYourTurn == false && summoned == true)
        {
            summoningSickness = false;
            cantAttack = false;
        }

        if(TurnSystem.isYourTurn == true && summoningSickness == false && cantAttack == false)
        {
            canAttack = true;
        }
        else
        {
            canAttack = false;
        }

        targeting = staticTargeting;
        targetingEnemy = staticTargetingEnemy;

        if(targetingEnemy == true)
        {
            Target = Enemy;
        }
        else
        {
            Target = null;
        }

        if(targeting == true && targetingEnemy == true && onlyThisCardAttack == true)
        {
            Attack();
        }

        if(canBeSummon == true || UcanReturn == true && beInGraveyard ==true)
        {
            summonBorder.SetActive(true);
        }
        else
        {
            summonBorder.SetActive(false);
        }

        if (actualhp <= 0)
        {
            Destroy();
        }

        if(returnXcards >0 && summoned == true && useReturn == false && TurnSystem.isYourTurn == true)
        {
            Return(returnXcards);
            useReturn = true;

        }

        if (TurnSystem.isYourTurn ==false)
        {
            UcanReturn = false;
        }

        if(canHeal == true && summoned == true)
        {
            Heal();
            canHeal = false;
        }
    }

    public void Summon()
    {

        TurnSystem.currentMana -= cost;
        summoned = true;

        MaxMana(addXmaxMana);
        drawX = drawXcards;
    }

    public void MaxMana(int x)
    {
        TurnSystem.maxMana += x;
    }

    public void Attack()
    {
        if(canAttack == true && summoned == true)
        {
            if(Target != null)
            {
                if (Target == Enemy)
                {
                    EnemyHP.staticHp -= power;
                    targeting = false;
                    cantAttack = true;
                }
                
            }

            if(Target.name == "CardToHand(Clone)")
            {
                canAttack = true;
            }
        }
    }

    public void UntargetEnemy()
    {
        staticTargetingEnemy = false;
    }
    public void TargetEnemy()
    {
        staticTargetingEnemy = true;
    }
    public void StartAttack()
    {
        staticTargeting = true;
    }
    public void StopAttack()
    {
        staticTargeting = false;
    }
    public void OneCardAttack()
    {
        onlyThisCardAttack = true;
    }
    public void OneCardAttackStop()
    {
        onlyThisCardAttack = false;
    }

    public void Destroy()
    {
        Graveyard = GameObject.Find("GraveyardZone");
        canBeDestroyed = true;
        if(canBeDestroyed == true)
        {
            this.transform.SetParent(Graveyard.transform);
            canBeDestroyed = false;
            summoned = false;
            beInGraveyard = true;

            hurted = 0;
        }
    }

    public void Return(int x)
    {
        for(int i = 0; i <= x; i++)
        {
            ReturnCard();
        }
    }

    public void ReturnCard()
    {
        UcanReturn = true;
    }

    public void ReturnThis()
    {
        if(beInGraveyard == true && UcanReturn == true)
        {
            this.transform.SetParent(Hand.transform);
            UcanReturn = false;
            beInGraveyard = false;
            summoningSickness = true;
        }
    }

    public void Heal()
    {
        PlayerHP.staticHp += healXpower;
    }
}
