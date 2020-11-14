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
        deck.cards.Draw().transform.SetParent( hand.transform );
        deck.UpdateUI();
    }

    public void Draw ( int amount ) {
        for ( int i = 0; i < amount; i++ ) {
            deck.cards.Draw()?.transform.SetParent( hand.transform );
        }
        deck.UpdateUI();
    }

    public void Draw ( int amount, float delay ) {
        StartCoroutine( DrawRoutine( amount, delay ) );
    }

    public void CardUseHandler ( Card card ) {
        //shuffle used card in deck
        deck.cards.InsertInRandomPosition( card );
        deck.Add( card );
        //draw new one
        Draw();
    }

    private IEnumerator DrawRoutine ( int amount, float delay ) {
        for ( int i = 0; i < amount; i++ ) {
            deck.cards.Draw()?.transform.SetParent( hand.transform );
            deck.UpdateUI();
            yield return new WaitForSeconds( delay );
        }
        OnDrawRoutineEnd.Invoke();
    }
}