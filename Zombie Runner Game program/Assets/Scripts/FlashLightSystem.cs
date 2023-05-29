using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightSystem : MonoBehaviour {
  [SerializeField] float lightDecay = 0.1f;
  [SerializeField] float angleDecay = 1.0f;
  /* unghiul minim de vizibilitate la care se poate ajunge este 40 */
  [SerializeField] float minimumAngle = 40f;
  Light myLight;

  void Start() {
    myLight = GetComponent<Light>();
  }

  void Update() {
    DecreaseLightAngle();
    DecreaseLightIntensity();
  }

  /* restaurează unghiul de vizibilitate când jucătorul face coliziune cu o baterie */
  public void RestoreLightAngle(float restoreAngle) {
    myLight.spotAngle = restoreAngle;
  }

  /* adaugă intensitate luminoasă la intensitatea actuală */
  public void AddLightIntensity(float intensityAmount) {
    myLight.intensity += intensityAmount;
  }

  /* scade unghiul de vizibilitate treptat cu fiecare rată de refresh al ecranului (Time.deltaTime) */
  private void DecreaseLightAngle() {
    if (myLight.spotAngle <= minimumAngle) {
      return;
    }
    else {
      myLight.spotAngle -= angleDecay * Time.deltaTime;
    }
  }

  /* scade intensitatea luminoasă treptat cu fiecare rată de refresh al ecranului (Time.deltaTime) */
  private void DecreaseLightIntensity() {
    myLight.intensity -= lightDecay * Time.deltaTime;
  }
}