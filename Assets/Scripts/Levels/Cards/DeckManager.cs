using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public static DeckManager instance;

    public List<Card> deck = new List<Card>();
    public List<Card> hand = new List<Card>();

    [SerializeField] private int handSize = 5;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public void ShuffleDeck()
    {
        for (int i = 0; i < deck.Count; i++)
        {
            Card temp = deck[i];
            int randomIndex = Random.Range(0, deck.Count);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = temp;
        }
    }

    public void DrawCard()
    {
        if (deck.Count == 0)
        {
            return;
        }

        Card drawnCard = deck[0];
        hand.Add(drawnCard);
        deck.RemoveAt(0);
    }

    public void StartGame()
    {
        ShuffleDeck();
        for (int i = 0; i < handSize; i++)
        {
            DrawCard();
        }
    }
}
