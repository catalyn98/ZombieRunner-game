using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyHealth : MonoBehaviour {
  /* procentul de viață al inamicului */
  [SerializeField] float hitPoints = 100f;
  [SerializeField] TextMeshProUGUI ammoText;
  bool isDead = false;
  bool ok1 = false;
  bool ok2 = false;
  float delay = 0;
  public static int nrEnemies = 12;
  public GameObject winn_message;
  
  void Start(){
    winn_message.SetActive(false);
  }

  void Update(){
    if(ok1 == true) {
      delay += Time.deltaTime;
      if(delay >= 1f){
        ok2 = true;
		ammoText.text = "\nYour level life: " + PlayerHealth.levelLifePlayer.ToString();
        winn_message.SetActive(true);
        Time.timeScale = 0;
        /* dezactivează armele atunci când jucătorul a pierdut */
        FindObjectOfType<WeaponSwitcher>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        ok1 = false;
      }
    }
  }

  public bool IsDead() {
    return isDead;
  }
  
  /* metoda TakeDamage(float damage) va fi apelată în clasa Weapons.cs */
  public void TakeDamage(float damage) {
    /* metoda BroadcastMessage("OnDamageTaken") apelează pentru ficare obiect în parte scriptul care îi este atașat */
    BroadcastMessage("OnDamageTaken");
    hitPoints -= damage;
    if (hitPoints <= 0) { /* dacă procentul de viață al inamicului scade sub 0 */
            Die(); /* atunci acesta este eliminat */
            nrEnemies--;
            if(nrEnemies <= 0) {
              ok1 = true;
            }
    }
  }

  private void Die() {
    /* dacă inamicul este deja eliminat atunci return, astfel încât jucătorul să nu fie nevoit să elimine din nou același inamic */
    if (isDead) return;
    isDead = true;
    /* Setează inamicului animația de moarte */
    GetComponent<Animator>().SetTrigger("die");
  }
}