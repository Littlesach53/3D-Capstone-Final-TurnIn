using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SmeltingData", menuName = "SciptableObjects/SmeltingData", order = 1)]

public class SmeltingData : ScriptableObject
{
   public List<string> validFuels = new List<string>();

   public List<SmeltableOre> validOres = new List<SmeltableOre>();
}

[System.Serializable]
public class SmeltableOre
{
    public string name;
    public float timeToSmelt;
    public string smeltedOreName;
}
