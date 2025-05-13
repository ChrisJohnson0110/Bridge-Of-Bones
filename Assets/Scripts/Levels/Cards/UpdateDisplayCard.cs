using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//visualal update the display info on a card
public class UpdateDisplayCard : MonoBehaviour
{
    public Card cardDisplayed;

    [SerializeField] private TMP_Text cardCost;
    [SerializeField] private TMP_Text cardName;
    [SerializeField] private Image cardImage;
    [SerializeField] private Image cardBackground;
    [SerializeField] private TMP_Text cardDescription;

    //TODO
    //changes with card
    //need to enabble / disable and set based on card type
    [SerializeField] private TMP_Text cardLeftField;
    [SerializeField] private TMP_Text cardRightField;
    [SerializeField] private TMP_Text cardCenterField;

    public void UpdateFields(Card a_cardData)
    {
        cardDisplayed = a_cardData;

        cardCost.text = a_cardData.cost.ToString();
        cardName.text = a_cardData.cardName;
        cardImage.sprite = a_cardData.cardImage;
        cardBackground.sprite = a_cardData.cardBackground;
        cardDescription.text = a_cardData.description;

        UpdateCardFieldsColor();

        cardCenterField.gameObject.SetActive(false); // TODO set up fields and colors- hide center field as currently not used

        if (a_cardData is SummonUnitCard summonUnitCard)
        {
            cardLeftField.text = summonUnitCard.attackDmg.ToString();
            cardRightField.text = summonUnitCard.totalHealth.ToString();
        }
        else if (a_cardData is DrawCard drawCard)
        {
            cardLeftField.text = drawCard.drawAmount.ToString();
            
            if (drawCard.drawType == DrawType.SacrificeHPSet)
            {
                cardRightField.color = Color.red;
                cardRightField.text = drawCard.otherAmount.ToString(); // TODO changes display depending on draw type 
            }
        }


    }

    private void UpdateCardFieldsColor()
    {
        cardLeftField.color = Color.white;
        cardRightField.color = Color.white;
        cardCenterField.color = Color.white;
    }


    public bool CompareToCard(Card a_cardData)
    {
        if (cardDisplayed == a_cardData)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
