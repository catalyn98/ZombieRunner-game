using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

/* acest fișier va fi atașat la Obiectul Game Session */
public class SceneLoader : MonoBehaviour {
    public void ReloadScene () {
        /* LoadScene încarcă scena */
        /* în acest joc avem 4 scene, fiecărei scene îi este atașat un număr */
        SceneManager.LoadScene (4);
		EnemyHealth.nrEnemies = 12;
		PlayerHealth.levelLifePlayer = 100;
        Time.timeScale = 1;
    }

    public void StartGame () {
        SceneManager.LoadScene (4);
		EnemyHealth.nrEnemies = 12;
		PlayerHealth.levelLifePlayer=100;
		Time.timeScale = 1;
    }

    public void HomeScene () {
        SceneManager.LoadScene (0);
    }

    public void PickupsScene () {
        SceneManager.LoadScene (3);
    }

    public void SeeControls () {
        SceneManager.LoadScene (1);
    }

    public void WeaponsScene () {
        SceneManager.LoadScene (2);
    }
}