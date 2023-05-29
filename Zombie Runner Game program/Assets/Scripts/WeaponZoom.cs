using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour {
  [SerializeField] Camera fpsCamera;
  [SerializeField] RigidbodyFirstPersonController fpsController;
  [SerializeField] float zoomedOutFOV = 60f; 
  [SerializeField] float zoomedInFOV = 20f; 
  [SerializeField] float zoomOutSensitivity = 2f;
  [SerializeField] float zoomInSensitivity = 0.5f;
  bool zoomedInToggle = false;

  /* metoda OnDisable() asigură faptul că arma nu dispare din ecran
     în momentul în care jucătorul face prea mult ZoomOut.
     Cu alte cuvinte metoda controlează limita de ZoomOut */
  void OnDisable() {
    ZoomOut();
  }

  void Update() {
    /* dacă jucătorul apasă butonul dreapta al mouse-ului sau tastat Z */
    if (Input.GetMouseButton(1) || Input.GetKeyDown(KeyCode.Z)) {
      if (zoomedInToggle == false) {
        ZoomIn();
      }
      else {
        ZoomOut();
      }
    }
  }

  private void ZoomIn() {
    zoomedInToggle = true;
    /* mărește cu 20 de procente dimensiunea de vizualizare */
    fpsCamera.fieldOfView = zoomedInFOV;
    /* senzitivitatea mouse-ului */
    fpsController.mouseLook.XSensitivity = zoomInSensitivity;
    fpsController.mouseLook.YSensitivity = zoomInSensitivity;
  }

  private void ZoomOut() {
    zoomedInToggle = false;
    /* revin-o la dimensiunea de vizualizare inițială */
    fpsCamera.fieldOfView = zoomedOutFOV;
    fpsController.mouseLook.XSensitivity = zoomOutSensitivity;
    fpsController.mouseLook.YSensitivity = zoomOutSensitivity;
  }
}