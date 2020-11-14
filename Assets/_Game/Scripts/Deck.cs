using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour {
    public List<Card> cards = new List<Card>();

    public bool selected { get; set; }

    public void Add ( Card card ) {
        cards.Add( card );
    }

    public void Remove ( Card card ) {
        cards.Remove( card );
    }
}