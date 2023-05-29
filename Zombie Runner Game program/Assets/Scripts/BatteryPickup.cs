using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour {
  [SerializeField] float restoreAngle = 90f;
  [SerializeField] float addIntensity = 1f;

  private void OnTriggerEnter(Collider other) {
    /* dacă jucătorul a făcut coliziune cu o baterie */
    if (other.gameObject.CompareTag("Player")) {
      /* restaurează unghiul de luminozitate cu 90 */
      other.GetComponentInChildren<FlashLightSystem>().RestoreLightAngle(restoreAngle);
      /* adaugă intensitate luminoasă cu 1 */
      other.GetComponentInChildren<FlashLightSystem>().AddLightIntensity(addIntensity);
      /* după coliziune distruge obiectul */
      Destroy(this.gameObject);
    }
  }
}