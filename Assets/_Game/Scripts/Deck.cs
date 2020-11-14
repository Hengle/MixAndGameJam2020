using System.Collections.Generic;
using UnityEngine;
using TMPro;
using NaughtyAttributes;

public class Deck : MonoBehaviour {
    [Header("Refs")]
    public SC_Deck deckData;
    public Card cardPrefab;
    public TextMeshProUGUI cardsCountText;
    public Transform cardContainer;

    [ReadOnly] public List<Card> cards = new List<Card>();

    public void Setup () {
        foreach ( var cardData in deckData.cards ) {
            Card c = Instantiate( cardPrefab, cardContainer.transform );
            c.cardData = cardData;
            c.UpdateUI();
            cards.Add( c );
        }
        UpdateUI();
    }

    public void Add ( Card card ) {
        card.transform.position = cardContainer.transform.position;
        card.transform.SetParent( cardContainer.transform );
        UpdateUI();
    }

    public void Remove ( Card card ) {
        cards.Remove( card );
        UpdateUI();
    }

    public void UpdateUI () {
        cardsCountText.text = cards.Count.ToString();
    }

    public void CardsUnlockHandler ( List<SC_Card> cards ) {
        foreach ( var cardData in cards ) {
            Card c = Instantiate( cardPrefab, cardContainer.transform );
            c.cardData = cardData;
            c.UpdateUI();
            this.cards.InsertInRandomPosition( c );
        }
        UpdateUI();
    }
}