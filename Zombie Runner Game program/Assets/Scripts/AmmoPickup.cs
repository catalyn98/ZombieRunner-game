using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour {
  /* numărul de muniții care se adugă la cantitatea de muniție curentă 
     când jucătorul face coliziune pe parcursul jocului cu unul din cele 3 tipuri de muniție */
  [SerializeField] int ammoAmount = 5;
  /* următorul câmp va fi atribuit în Unity Inspector, astfel încât să poată fi transmis metodelor din acest script */
  [SerializeField] AmmoType ammoType;

  void OnTriggerEnter(Collider other) {
    if (other.gameObject.CompareTag("Player")) {
      /* dacă jucătorul a făcut coliziune cu unul din cele 3 tipuri de muniții disponibile mărește numărul de muniții actual în funcție de tip */
      FindObjectOfType<Ammo>().IncreaseCurrentAmmo(ammoType, ammoAmount);
      /* după coliziune distruge obiectul */
      Destroy(this.gameObject);
    }
  }
}