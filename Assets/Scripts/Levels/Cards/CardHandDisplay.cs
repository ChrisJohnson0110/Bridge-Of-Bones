using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHandDisplay : MonoBehaviour
{
    public static CardHandDisplay instance;

    [SerializeField] private GameObject handCardPrefab;
    [SerializeField] private Transform cardsParent;

    private List<GameObject> handCards = new List<GameObject>();
    private int cardsDisplayed = 0;
    private int poolSize;
    

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);

        poolSize = DeckHandManager.instance.handSize;

        for (int i = 0; i < poolSize; i++)
        {
            GameObject newObj = Instantiate(handCardPrefab);
            newObj.transform.SetParent(cardsParent);
            newObj.gameObject.SetActive(false);
            handCards.Add(newObj);
        }
    }

    //add card to hand
    public void AddCardToHandVisual(Card a_cardToDisplay)
    {
        if (poolSize <= cardsDisplayed)
        {
            Debug.LogWarning($"Hand is full {poolSize} & {cardsDisplayed}");
            return;
        }

        GameObject cardObj = GetFirstInactive();
        UpdateDisplayCard card = cardObj.GetComponent<UpdateDisplayCard>();
        card.UpdateFields(a_cardToDisplay);
        cardObj.SetActive(true);
        cardsDisplayed++;
    }

    //remove card from hand
    public void RemoveCardToHandVisual(Card a_cardToRemove)
    {
        foreach (GameObject go in handCards)
        {
            UpdateDisplayCard card = go.GetComponent<UpdateDisplayCard>();
            if (card.CompareToCard(a_cardToRemove) == true)
            {
                go.SetActive(false);
                cardsDisplayed--;
                break;
            }
        }
        
    }

    private GameObject GetFirstInactive()
    {
        for (int i = 0; i < handCards.Count; i++)
        {
            if (!handCards[i].gameObject.activeInHierarchy)
            {
                return handCards[i];
            }
        }
        Debug.LogWarning("No inactive objects found in the pool.");
        return null;
    }
}
