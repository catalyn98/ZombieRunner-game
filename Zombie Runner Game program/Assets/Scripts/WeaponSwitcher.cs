using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour {
  /* arma curentă este aceea care are indexul 0 setat în Unity */
  /* în cazul acestui joc este arma SHOTGUN */
  [SerializeField] int currentWeapon = 0;

  void Start() {
    SetWeaponActive();
  }

  void Update() { 
    /* se setează inițial previousWeapon ca fiind crrentWeapon */
    int previousWeapon = currentWeapon;
    ProcessKeyInput();
    if (previousWeapon != currentWeapon) {
      SetWeaponActive();
    }
  }

  private void ProcessKeyInput() {
    /* dacă jucătorul apasă tasta 1 */
    if (Input.GetKeyDown(KeyCode.Alpha1))  {
      currentWeapon = 0; /* setează ca și armă, arma a cărui index este 0 */
    }

    if (Input.GetKeyDown(KeyCode.Alpha2)) {
      currentWeapon = 1;
    }

    if (Input.GetKeyDown(KeyCode.Alpha3)) {
      currentWeapon = 2;
    }
  }

  /* metoda SetWeaponActive() setează care armă este activă la un moment dat */
  private void SetWeaponActive() {
    int weaponIndex = 0;
    /* se parcurge întraga listă de arme și se activează arma al cărui indice este egal cu currentWeapon */
    foreach (Transform weapon in transform) {
      if (weaponIndex == currentWeapon) {
        weapon.gameObject.SetActive(true);
      }
      else {
        weapon.gameObject.SetActive(false);
      }
      /* dacă nu incrementăm toate armele vor fi active la un moment dat */
      weaponIndex++;
    }
  }
}