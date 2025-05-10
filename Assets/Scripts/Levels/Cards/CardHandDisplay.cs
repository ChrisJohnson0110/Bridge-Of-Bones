using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHandDisplay : MonoBehaviour
{
    public static CardHandDisplay instance;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        //create hand number of place holders
        //enable when card added
        //remove when removed
        //add update visuals component if not already
    }

    public void AddCardToHandVisual(Card a_cardToDisplay)
    {
        //if not at hand limit 

        //get card to enable
        //set card to enable data to card to display data
        //run update visuals
        //set enabled
    }

    public void RemoveCardToHandVisual(Card a_cardToRemove)
    {

    }
}
