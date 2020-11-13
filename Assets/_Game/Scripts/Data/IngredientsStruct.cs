using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public struct IngredientsStruct
{
    [AssetSelector]
    public SC_IngredientType type;
    [EnumToggleButtons, Space]
    public TypeOfCookingEnum cookingLevel;
}
