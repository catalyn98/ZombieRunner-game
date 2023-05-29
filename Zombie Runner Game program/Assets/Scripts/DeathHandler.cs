using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour {
  [SerializeField] Canvas gameOverCanvas;

  private void Start() {
    /* când jocul începe dezactivează ecranul de Game Over */
    gameOverCanvas.enabled = false;
  }
  
  /* metoda HandleDeath() va fi apelată în clasa  PlayerHealth.cs */
  public void HandleDeath() {
    /* când jucătorul a pierdut activează ecranul de Game Over */
    gameOverCanvas.enabled = true;
    Time.timeScale = 0;
    /* dezactivează armele atunci când jucătorul a pierdut */
    FindObjectOfType<WeaponSwitcher>().enabled = false;
    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;
  }
}