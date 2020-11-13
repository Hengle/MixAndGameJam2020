using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "Ingredient 0", menuName = "Game/CardIngredient", order = 1)]
public class SC_CardIngredient : SerializedScriptableObject
{

    [AssetSelector]
    public SC_IngredientType ingredientType;


    [FoldoutGroup("Cooking Bar"), PropertyRange(1f, 30f)]
    public float timeRequiredToFillCookingBar = 1f;
    [FoldoutGroup("Cooking Bar"), Space, PropertyRange(0, "timeBeforeWelldone")]
    public float timeBeforeUnderdone = 0.5f;
    [FoldoutGroup("Cooking Bar"), PropertyRange("timeBeforeUnderdone", "timeBeforeBurnt")]
    public float timeBeforeWelldone = 1f;
    [FoldoutGroup("Cooking Bar"), PropertyRange("timeBeforeWelldone", "timeRequiredToFillCookingBar")]
    public float timeBeforeBurnt = 1f;

    [Space]
    public Sprite img;



    public TypeOfCookingEnum EvaluateCooking(float value)
    {
        if (value < timeBeforeUnderdone) 
            return TypeOfCookingEnum.row;
        if (value < timeBeforeWelldone) 
            return TypeOfCookingEnum.underdone;
        if (value < timeBeforeBurnt) 
            return TypeOfCookingEnum.welldone;

        return TypeOfCookingEnum.burnt;
	}

}