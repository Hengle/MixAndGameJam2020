using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "Need 0", menuName = "Game/Need", order = 1)]
public class SC_NeedType : ScriptableObject
{
	public int requiredWeight = 0;
	public List<SC_Card> unlockedCard = new List<SC_Card>();


	public static List<SC_NeedType> GetAllNeed()
	{
		return Resources.LoadAll<SC_NeedType>("").OrderBy(x => x.requiredWeight) as List<SC_NeedType>;
	}

}
