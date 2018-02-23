using UnityEngine;

public class EquipmentManager : MonoBehaviour {

    #region Singleton
    public static EquipmentManager instance;
	
    void Awake() {
        instance = this;
    }
    #endregion

    Equipment[] currentEquimpent;

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    Inventory inventory;

    void Start() {
        inventory = Inventory.instance;

        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquimpent = new Equipment[numSlots];
    }

    public void Equip(Equipment newItem) {
        int slotIndex = (int)newItem.equipSlot;

        Equipment oldItem = null;

        if (currentEquimpent[slotIndex] != null) {
            oldItem = currentEquimpent[slotIndex];
            inventory.Add(oldItem);
        }
        if (onEquipmentChanged !=  null) {
            onEquipmentChanged.Invoke(newItem, oldItem);
        }

        currentEquimpent[slotIndex] = newItem;
    }

    public void Unequip(int slotIndex) {
        if (currentEquimpent[slotIndex] != null) {
            Equipment oldItem = currentEquimpent[slotIndex];
            inventory.Add(oldItem);

            currentEquimpent[slotIndex] = null;
        }
        if (onEquipmentChanged != null) {
            onEquipmentChanged.Invoke(null, oldItem);
        }
    }

    public void UnequipAll() {
        for (int i = 0; i < currentEquimpent.Length; i++) {
            Unequip(i);
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.U)) {
            UnequipAll();
        }
    }
}
