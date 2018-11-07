using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour {

    public float attackSpeed = 1f;
    public float attackDelay = .6f;
    const float combatCooldown = 5;
    private float attackCooldown = 0f;
    float lastAttackTime;

    public bool InCombat { get; private set; }
    public event System.Action OnAttack;

    CharacterStats myStats;

    void Start() {
        myStats = GetComponent<CharacterStats>();
    }

    void Update() {
        attackCooldown -= Time.deltaTime;

        if (Time.time - lastAttackTime > combatCooldown) {
            InCombat = false;
        }
    }

	public void Attack(CharacterStats targetStats) {
        if (attackCooldown <= 0f) {
            StartCoroutine(DoDamage(targetStats, attackDelay));
            if (OnAttack != null) {
                OnAttack();
            }
            attackCooldown = 1f / attackSpeed;
            InCombat = true;
            lastAttackTime = Time.time;
        }
    }

    IEnumerator DoDamage(CharacterStats stats, float delay) {
        yield return new WaitForSeconds(delay);
        stats.TakeDamage(myStats.damage.GetValue());
        if (stats.currentHealt <= 0 ) {
            InCombat = false;
        }
    }
}
