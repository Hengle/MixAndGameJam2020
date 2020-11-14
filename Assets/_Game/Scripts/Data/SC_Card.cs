using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Deirin.Utilities;

[CreateAssetMenu(fileName = "Card 0", menuName = "Game/Card", order = 1)]
public class SC_Card : SerializedScriptableObject
{
    [Space, AssetSelector]
    public Sprite img;

    [Space]
    public List<Effect> effects = new List<Effect>();


    public void Play()
    {
        foreach(Effect effect in effects)
        {
            effect.cardEffect.Invoke(effect.needType, effect.floatValue);
		}
	}


    public struct Effect 
    {
        [AssetSelector]
        public GameEvent_CardEffect cardEffect;
        [ShowIf("CheckUseNeedType"), AssetSelector, Required]
        public SC_NeedBar needType;
        [ShowIf("CheckUseFloatValue")]
        public float floatValue;

        private bool CheckUseNeedType()
        {
            return cardEffect != null && cardEffect.useNeedType;
        }

        private bool CheckUseFloatValue()
        {
            return cardEffect != null && cardEffect.useFloatValue;
        }
    }

}