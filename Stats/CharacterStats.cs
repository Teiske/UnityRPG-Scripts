using UnityEngine;

public class CharacterStats : MonoBehaviour {

    public int maxHealth = 100;
    public int currentHealt { get; private set; }

    public Stat damage;
    public Stat armour;

    void Awake() {
        currentHealt = maxHealth;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.T)) {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage) {
        damage -= armour.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealt -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage");

        if(currentHealt <= 0) {
            Die();
        }
    }

    public virtual void Die() {
        Debug.Log(transform.name + " died");
    }
}
