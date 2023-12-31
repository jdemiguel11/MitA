using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Items : ScriptableObject
{
    public string Name;
    public int armor;
    
    public void Equip(PlayerBehavior character)
    {
        character.armor = armor;
    }

    public void UnEquip(PlayerBehavior character)
    {
        character.armor -= armor;
    }
}
