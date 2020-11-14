using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu( menuName = "Game/Deck" )]
public class SC_Deck : ScriptableObject {
    [AssetSelector]
    public List<SC_Card> cards;
}