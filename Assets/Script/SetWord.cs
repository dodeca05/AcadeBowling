using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

public class SetWord : MonoBehaviour
{
    public LanguageMgr.Lcode thisWordCode;
    // Start is called before the first frame update
 
    void OnEnable()
    {

        StartCoroutine(LoadWait());
    }
    IEnumerator LoadWait()
    {
        while (LanguageMgr.Instance == null)
        {
            yield return new WaitForSeconds(0.1f);
        }

        GetComponent<UnityEngine.UI.Text>().text = LanguageMgr.Instance.GetWord(thisWordCode);


    }
    // Update is called once per frame

}
