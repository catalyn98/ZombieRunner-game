using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour {
  [SerializeField] AmmoSlot[] ammoSlots;
  /* această clasă poate fi accesată doar de clasa Ammo.cs, deoarece este privată */
  /* clasa Ammo.cs poate accesa variabilele publice a clasei AmmoSlot */
  /* [System.Serializable] permite să vizualizăm conținutul acestei clase în Unity Inspector */
  [System.Serializable] private class AmmoSlot {
    public AmmoType ammoType;
    public int ammoAmount;
  }

  public int GetCurrentAmmo(AmmoType ammoType) {
    /* utilizează GetAmmoSlot() pentru a obține tipul slotului de muniție la care se adaugă suma de muniții a acelui slot */
    return GetAmmoSlot(ammoType).ammoAmount;
  }

  /* metoda  IncreaseCurrentAmmo(AmmoType ammoType, int ammoAmount) va fi apelată în clasa AmmoPickup.cs */
  public void IncreaseCurrentAmmo(AmmoType ammoType, int ammoAmount) {
    /* după ce s-a preluat tipul slotului de muniții adaugă câmpului ammoAmount munițiile adunate */
    GetAmmoSlot(ammoType).ammoAmount += ammoAmount;
  }

  public void ReduceCurrentAmmo(AmmoType ammoType) {
    /* după ce s-a folosit din cantitatea totală de muniții redu aceasta */
    GetAmmoSlot(ammoType).ammoAmount--;
  }

  /* slotul de muniție cuprinde toate tipurile de muniții */
  private AmmoSlot GetAmmoSlot(AmmoType ammoType) {
    foreach (AmmoSlot slot in ammoSlots) {
      if (slot.ammoType == ammoType) {
        return slot;
      }
    }
    return null;
  }
}