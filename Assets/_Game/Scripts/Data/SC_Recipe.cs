using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;


[CreateAssetMenu(fileName = "Recipe 0", menuName = "Game/Recipe", order = 1)]
public class SC_Recipe : SerializedScriptableObject
{
    public IngredientsStruct[] ingredients = new IngredientsStruct[0];

	public static SC_Recipe[] GetAllRecipes()
	{
		return Resources.LoadAll<SC_Recipe>("");
	}

}