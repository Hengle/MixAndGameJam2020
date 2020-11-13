using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;


[CreateAssetMenu(fileName = "IngredientType 0", menuName = "Game/Ingredient Type", order = 1)]
public class SC_IngredientType : SerializedScriptableObject
{

	public static SC_IngredientType[] GetAllIngredientTypes()
	{
		return Resources.LoadAll<SC_IngredientType>("");
	}

}
