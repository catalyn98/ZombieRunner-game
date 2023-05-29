using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreenToggle : MonoBehaviour {

    private void Start()
    {
        Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
    }

    void Update() {
        /* comutare joc pe ecran complet */
        if (Screen.fullScreen == true && Input.GetKeyDown(KeyCode.Escape)) {
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }
        else if(Screen.fullScreen == false && Input.GetKeyDown(KeyCode.Escape))
        {
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        }
    }
}