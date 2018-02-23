using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName ="Inventory/Equipment")]
public class Equipment : Item {

    public EquipmentSlot equipSlot;
    public SkinnedMeshRenderer mesh;
    public EquipmentMeshRegion[] coveredMeshRegions;

    public int armorModifier;  //Increas/decreas in armor
    public int damageModifier; //Increas/decreas in damage

    public override void Use() {
        base.Use();
        //Equip the item
        EquipmentManager.instance.Equip(this);
        //Remove it from the inventory
        RemoveFromInventory();
    }
}

public enum EquipmentSlot {Head, Chest, Legs, Feet, Weapon, Shield}
public enum EquipmentMeshRegion {Legs, Arms, Torso }
