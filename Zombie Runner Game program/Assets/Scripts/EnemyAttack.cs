using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {
  /* câmpul target face referire la nivelul de viață al jucătorului */
  PlayerHealth target;
  /* fiecare atac al inamicului scade un procent de 25 din nivelul de viață al jucătorului */
  [SerializeField] float damage = 25f;

  void Start() {
    target = FindObjectOfType<PlayerHealth>();
  }

  public void AttackHitEvent() {
    if (target == null) return;
    target.TakeDamage(damage);
    /* când jucătorul este atacat afișează imaginea DamageImpact.png pe ecran */
    target.GetComponent<DisplayDamage>().ShowDamageImpact();
  }
}