using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialMgr : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject tutorialEx;
    public int Xpos;
    public int Ypos;
    public Transform spotLightTarget;
    public bool targetIsUI;

    private int screenHeight;
    private int screenWidth;
    void Start()
    {
        Vector3 spotLightPos;
        string sceneName = SceneManager.GetActiveScene().name;
        if (PlayerPrefs.GetInt(sceneName) != 0)
            Destroy(gameObject);
        screenHeight = Screen.height;
        screenWidth = Screen.width;
        GameObject ui=GameObject.Find("UI");
        transform.SetParent(ui.transform);
        if (!targetIsUI)
        {
            spotLightPos = Camera.main.WorldToScreenPoint(spotLightTarget.position);
            spotLightPos.x -= screenWidth / 2;
            spotLightPos.y -= screenHeight / 2;
        }
        else
            spotLightPos = spotLightTarget.localPosition;

               
        spotLightPos.z = 0;
        transform.localPosition = spotLightPos;

        if (tutorialEx != null)
        {
            tutorialEx.transform.SetParent(transform);
            tutorialEx.transform.localPosition = new Vector3(Xpos, Ypos);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (InputMgr.Instance.ClickDown())
        {
            Destroy(gameObject);
        }
    }
}
