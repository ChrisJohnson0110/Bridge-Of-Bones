using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPlayer : MonoBehaviour
{
    public static CardPlayer instance;

    [SerializeField] private GameObject _cardPrefab;
    //[SerializeField] private CardAnimator cardAnimator;


    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public void PlayCard(Card a_card)
    {
        a_card.PlayCard();
        DeckManager.instance.hand.Remove(a_card);
    }

    public void PlayCard(Card a_card, Vector3 a_position)
    {
        if (a_card is InterfaceUnitCard unitCard)
        {
            unitCard.PlayCard(a_position);
        }
        else
        {
            a_card.PlayCard();
        }

        DeckManager.instance.hand.Remove(a_card);
    }

    public void DrawCard()
    {
        DeckManager.instance.DrawCard();
    }
}