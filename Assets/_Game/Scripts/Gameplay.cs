using System.Collections;
using UltEvents;
using UnityEngine;

public class Gameplay : MonoBehaviour {
    [Header("Refs")]
    public Deck deck;
    public Hand hand;

    [Header("Events")]
    public UltEvent OnDrawRoutineEnd;

    public void Draw () {
        Card c = deck.cards.Draw();
        c.transform.SetParent( hand.transform );
        c.Activate( true );

        deck.UpdateUI();
    }

    public void Draw ( int amount ) {
        for ( int i = 0; i < amount; i++ ) {
            Draw();
        }
    }

    public void Draw ( int amount, float delay ) {
        StartCoroutine( DrawRoutine( amount, delay ) );
    }

    public void CardUseHandler ( Card card ) {
        //shuffle used card in deck
        deck.cards.InsertInRandomPosition( card, 1 );
        deck.Add( card );
        //draw new one
        Draw();
    }

    private IEnumerator DrawRoutine ( int amount, float delay ) {
        for ( int i = 0; i < amount; i++ ) {
            Draw();
            yield return new WaitForSeconds( delay );
        }
        OnDrawRoutineEnd.Invoke();
    }
}