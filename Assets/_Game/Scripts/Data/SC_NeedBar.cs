using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Sirenix.OdinInspector;

[CreateAssetMenu( menuName = "Game/Need", order = 1 )]
public class SC_NeedBar : ScriptableObject {
    public Color color;
    public bool startsLocked = true;
    [NaughtyAttributes.ShowIf("startsLocked")] public float unlockWeight = 0f;
    public float maxValue = 100f;
    public float startValue = 75f;
    public float softResetLerpPercent = .5f;
    [Range(0f,1f)] public float warningTresholdPercent = .25f;

    [AssetSelector]
    public List<SC_Card> unlockedCards = new List<SC_Card>();

    public static List<SC_NeedBar> GetAllNeed () {
        return Resources.LoadAll<SC_NeedBar>( "" ).OrderBy( x => x.unlockWeight ) as List<SC_NeedBar>;
    }
}