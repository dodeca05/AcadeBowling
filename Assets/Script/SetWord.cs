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
        
        GetComponent<UnityEngine.UI.Text>().text = LanguageMgr.Instance.GetWord(thisWordCode);
    }

    // Update is called once per frame
   
}
