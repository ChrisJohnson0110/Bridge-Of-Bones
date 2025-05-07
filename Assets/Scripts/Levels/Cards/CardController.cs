using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    public void PlayCard(Card card)
    {
        card.PlayCard();
        DeckManager.instance.hand.Remove(card);
    }
}
