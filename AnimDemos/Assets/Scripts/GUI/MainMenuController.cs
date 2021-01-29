using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    EventSystem es;
    // Start is called before the first frame update
    void Start()
    {
        es = GetComponentInChildren<EventSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (es == null) return;

        if(es.currentSelectedGameObject == null)
        {
            if(es.firstSelectedGameObject != null) es.SetSelectedGameObject(es.firstSelectedGameObject);
        }
    }

    public void BttnPlay()
    {
        SceneManager.LoadScene(1);
    }

    public void BttnAbout()
    {
        print("about");
    }
    public void BttnQuit()
    {
        Application.Quit();
    }
}

