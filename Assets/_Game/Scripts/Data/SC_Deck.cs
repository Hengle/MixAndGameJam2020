using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( menuName = "Game/Deck" )]
public class SC_Deck : ScriptableObject {
    public List<SC_Card> cards;
}