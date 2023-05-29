using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour {
  [SerializeField] Camera FPCamera;
  /* distanța până la care poată să ajungă glonțul */
  [SerializeField] float range = 100f;
  /* procentul de lovitură al unui glonț */
  [SerializeField] float damage = 25f;
  [SerializeField] ParticleSystem muzzleFlash;
  [SerializeField] GameObject hitEffect;
  [SerializeField] Ammo ammoSlot;
  /* tipul armei folosite */
  [SerializeField] AmmoType ammoType;
  [SerializeField] TextMeshProUGUI ammoText;
  /* primul glonț nu va avea nici o întârziere */
  bool canShoot = true;
  /* se va dăuga o întârziere de 0.5 între focurile de armă */
  [SerializeField] float timeBetweenShots = 0.5f;

  private void OnEnable() {
    canShoot = true;
  }
  
  void Start(){
	  int currentAmmo = ammoSlot.GetCurrentAmmo(ammoType);
	  ammoText.text = "Ammo: " + currentAmmo.ToString() + "\nYour level life: " + PlayerHealth.levelLifePlayer.ToString();
  }

  void Update() {
    DisplayAmmo();
    /* dacă jucătorul a apăsat pe trăgaci */
    if ((Input.GetButtonDown("Fire1") || Input.GetMouseButtonDown(0)) && canShoot == true) {
      /* împușcă inamicul */
      StartCoroutine(Shoot());
    }
  }

  /* metoda DisplayAmmo() afișează pe ecran numărul de muniții disponibile în timpul jocului */
  private void DisplayAmmo() {
    int currentAmmo = ammoSlot.GetCurrentAmmo(ammoType);
    ammoText.text = "Ammo: " + currentAmmo.ToString() + "\nYour level life: " + PlayerHealth.levelLifePlayer.ToString();
  }

  IEnumerator Shoot() {
    canShoot = false;
    /* se verifică dacă jucătorul are muniție */
    if (ammoSlot.GetCurrentAmmo(ammoType) > 0) {
      PlayMuzzleFlash();
      ProcessRaycast();
      /* în momentul în care jucătorul împușcă inamicul se scade din numărul de muniții disponibile */
      ammoSlot.ReduceCurrentAmmo(ammoType);
    }
    /* jucătorul va fi nevoit să aștepte un timp de 0.5 pentru a putea trage următorul glonț*/
    yield return new WaitForSeconds(timeBetweenShots);
    canShoot = true;
  }

  /* se pornește așa-numitul efect de particule */
  private void PlayMuzzleFlash() {
    muzzleFlash.Play();
  }

  private void ProcessRaycast() {
    RaycastHit hit;
    if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range)) {
      CreateHitImpact(hit);
      /* apelează o metodă pentru a scădea din nivelul de viață al inamicului */
      EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
      /* dacă jucătorul trage în ceva, și acel ceva nu este inamicul return pentru a se evita excepția nulă */
      if (target == null) return;
      target.TakeDamage(damage);
    }
    else {
      /* analog și pentru cazul în care jucătorul trage un glonț spre cer */
      return;
    }
  }

  private void CreateHitImpact(RaycastHit hit) {
    GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
    Destroy(impact, .1f);
  }
}

/* Mențiune!!!
   Toate valorile câmpurilor disponibile din orice script pot fi schimbate în Unity. */