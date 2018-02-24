using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats {

	void Start () {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;

    }
	
	void OnEquipmentChanged(Equipment newItem, Equipment oldItem) {
        if (newItem != null) {
            armour.Addmodifier(newItem.armorModifier);
            damage.Addmodifier(newItem.damageModifier);
        }

        if(oldItem != null) {
            armour.Removemodifier(oldItem.armorModifier);
            damage.Removemodifier(oldItem.damageModifier);
        }
    }

    public override void Die() {
        base.Die();
        PlayerManager.instance.KillPlayer();
    }
}
