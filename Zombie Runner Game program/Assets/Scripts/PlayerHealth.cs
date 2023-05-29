using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour {
  /* procentul de viață al jucătorului */
  [SerializeField] float hitPoints = 100f;
  public static float levelLifePlayer = 100f;
  [SerializeField] TextMeshProUGUI ammoText;
  
  /* metoda TakeDamage(float damage) va fi apelată în clasa EnemyAttack.cs */
  public void TakeDamage(float damage) {
    hitPoints -= damage;
	levelLifePlayer -= damage;
    if (hitPoints <= 0) { /* dacă procentul de viață al jucătorului scade sub 0 */
      EnemyHealth.nrEnemies = 12;
	  ammoText.text = "\nYour level life: " + PlayerHealth.levelLifePlayer.ToString();
      GetComponent<DeathHandler>().HandleDeath(); /* atunci apelează metoda HandleDeath() din clasa DeathHandler.cs */
    }
  }
}