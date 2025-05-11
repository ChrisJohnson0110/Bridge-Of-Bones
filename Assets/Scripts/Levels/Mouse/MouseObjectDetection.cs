using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MouseObjectDetection : MonoBehaviour
{
    [SerializeField] private GraphicRaycaster uiRaycaster;
    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private Transform cardCanvas;

    private GameObject pickedupCard;
    private MouseController mouseControllerRef;

    private void Start()
    {
        pickedupCard = Instantiate(cardPrefab);
        pickedupCard.transform.SetParent(cardCanvas);
        pickedupCard.SetActive(false);
        mouseControllerRef = MouseController.instance;
    }

    void Update()
    {
        if (mouseControllerRef == null)
            return;

        if (mouseControllerRef.isMouseActive == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RayCastUI(); // raycast for cards within hand
                RayCastScene(); //raycast for objects within scene
            }
            else if (Input.GetMouseButtonUp(0))
            {
                LetGoCardOnMouse(); //only if display is active

                //TODO burn card above fire
                //TODO PlayCard(); if in play area /play unit - will need a unit placeholder to indicate placement pos/size
                //TODO 
            }

            if (pickedupCard != null && pickedupCard.activeSelf == true)
            {
                //pickedupCard.transform.position = Input.mousePosition; //move display to mouse pos
            }
        }
    }


    private void RayCastUI()
    {
        PointerEventData pointerData = new PointerEventData(eventSystem)
        {
            position = Input.mousePosition
        };
        List<RaycastResult> uiResults = new List<RaycastResult>();
        uiRaycaster.Raycast(pointerData, uiResults);

        foreach (var result in uiResults)
        {
            if (result.gameObject.tag == "Card")
            {
                HoldCardOnMouse(result.gameObject);
            }
        }
    }

    private void RayCastScene()
    {
        if (mainCamera == null)
        {
            Debug.LogError("HoverDetection mainCamera missing");
            return;
        }

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            string objectTag = hit.transform.gameObject.tag;

            switch (objectTag)
            {
                case "Tile": TileClicked(); break;
                case "NewCard": NewCardClicked(); break;
                default: break;
            }
        }
    }

    private void TileClicked()
    {
        //TODO
        //if you click a tile
        //get unit
        //display unit info
        //probably should use a new script
    }

    //draw a new card into hand
    private void NewCardClicked()
    {
        CardPlayer.instance.DrawCard();
    }

    private void HoldCardOnMouse(GameObject a_cardToHold)
    {
        Card ClickedCard = a_cardToHold.GetComponent<UpdateDisplayCard>().cardDisplayed;
        UpdateDisplayCard updateCardDisplayReference = pickedupCard.GetComponent<UpdateDisplayCard>();

        if (ClickedCard != null)
        {
            updateCardDisplayReference.UpdateFields(ClickedCard);
            pickedupCard.SetActive(true);
            CardHandDisplay.instance.RemoveCardToHandVisual(ClickedCard); //remove card from hand
        }
    }

    private void LetGoCardOnMouse()
    {
        if (pickedupCard.activeSelf == false)
        {
            return;
        }

        //TODO

        //where is mouse let go

        //card action changes depending on position

        Card ClickedCard = pickedupCard.GetComponent<UpdateDisplayCard>().cardDisplayed;
        CardHandDisplay.instance.AddCardToHandVisual(ClickedCard); //add card back to hand


        pickedupCard.SetActive(false);
    }

    //play the card held
    private void PlayCard()
    {
        Card card = pickedupCard.GetComponent<UpdateDisplayCard>().cardDisplayed;

        if (card != null)
        {
            if (card.cardType == CardType.Unit)
            {
                CardPlayer.instance.PlayCard(card, Input.mousePosition); //TODO this vector 3 needs to be matched up to a grid pos vector 3 //temp place holder to remember logic
            }
            else
            {
                CardPlayer.instance.PlayCard(card);
            }
            
        }
        else
        {
            Debug.LogError("Card clicked but component cant be found");
        }
    }
}
