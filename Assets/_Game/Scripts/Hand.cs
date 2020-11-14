using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {
    private List<Transform> children = new List<Transform>();

    private void Start () => UpdateChildren();

    public void CardSelectionHandler ( Card card ) {
        foreach ( var child in children ) {
            if ( child == card.transform ) {
                card.transform.SetParent( transform.parent );
                break;
            }
        }
        UpdateChildren();
    }

    public void CardDeselectionHandler ( Card card ) {
        card.transform.SetParent( transform );
        UpdateChildren();
    }

    private void UpdateChildren () {
        children = new List<Transform>();
        for ( int i = 0; i < transform.childCount; i++ ) {
            children.Add( transform.GetChild( i ) );
        }
    }
}