using UltEvents;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.UI;

public class Card : MonoBehaviour {
    [Header("Refs")]
    public SC_Card cardData;
    public Image image;

    [Header("Events")]
    public UltEvent<Card> OnSelection;
    public UltEvent<Card> OnDeselection;
    public UltEvent<Card> OnUse;
    public UltEvent<bool> OnActivation;

    [SerializeField] [ReadOnly] private bool enter, down, up;
    public bool active = false;
    private bool selected = false;

    private void Update () {
        if ( selected )
            transform.position = Input.mousePosition;
    }

    #region Mouse Interactions
    public void Enter () {
        if ( active == false )
            return;

        enter = true;
    }

    public void Exit () {
        if ( active == false )
            return;

        if ( !selected && down )
            Select();

        enter = down = up = false;
    }

    public void Down () {
        if ( active == false )
            return;

        if ( selected )
            Use();

        down = true;
        up = false;
    }

    public void Up () {
        if ( active == false )
            return;

        up = true;
        down = false;

        //if the card is selected
        if ( selected ) {
            //we use it
            Use();
        }
        else if ( enter ) {
            Select();
        }
    }
    #endregion

    #region API
    public void Select () {
        selected = true;
        OnSelection.Invoke( this );
    }

    public void Deselect () {
        selected = false;
        OnDeselection.Invoke( this );
    }

    public void Activate ( bool value ) {
        active = value;
        OnActivation.Invoke( active );

        if ( active ) {

        }
        else {
            enter = up = down = false;
        }
    }

    public void Use () {
        selected = false;
        OnUse.Invoke( this );
    }

    public void UpdateUI () {
        image.sprite = cardData.img;
    }
    #endregion

    #region Handlers
    public void CardSelectionHandler ( Card card ) {
        //if the selected card is not me
        if ( card != this ) {
            Activate( false );
        }
    }

    public void CardDeselectionHandler ( Card card ) {
        //if the selected card is not me
        if ( card != this ) {
            Activate( true );
        }
    }

    public void CardUseHandler ( Card card ) {
        //if the selected card is not me
        if ( card != this ) {
            Activate( true );
        }
        else {
            cardData.Play();
            Activate( false );
        }
    }
    #endregion
}