using System.Collections;
using UnityEngine;


[System.Serializable] //unity o sa poata sa salveze datele din clasa asta
public class TurretBlueprint 
{
    public GameObject prefab;
    public int cost;

    public GameObject upgradedPrefab;
    public int upgradeCost;

    public int GetSellAmount()
    {
        return cost / 2;
    }


}
