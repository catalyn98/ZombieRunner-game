using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour {
  [SerializeField] Canvas impactCanvas;
  [SerializeField] float impactTime = 0.3f;

  void Start() {
    /* când jocul începe dezactivează imaginea impactCanvas.png */
    impactCanvas.enabled = false;
  }

  public void ShowDamageImpact() {
    StartCoroutine(ShowSplatter());
  }

  IEnumerator ShowSplatter() {
     /* când jucătorul este atacat de către inamic afișează imaginea impactCanvas.png pe ecran */
    impactCanvas.enabled = true;
    /* menține imaginea pentru 0.3 */
    yield return new WaitForSeconds(impactTime);
    /* dezactivează imaginea impactCanvas.png */
    impactCanvas.enabled = false;
  }
}