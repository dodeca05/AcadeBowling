using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageMgr : MonoBehaviour
{
    public enum Lcode { Menu,Setting,Fail,Success};
    // Start is called before the first frame update
    private SystemLanguage contury;

    private static LanguageMgr instance;
    public static LanguageMgr Instance
    {
        get
        {
            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        contury = Application.systemLanguage;
    }

    public string GetWord(Lcode code)
    {
        string result="404 Error";

        if (contury == SystemLanguage.Korean)
        {
            switch (code)
            {
                case Lcode.Menu:
                    result = "메뉴";
                    break;
                case Lcode.Setting:
                    result = "설정";
                    break;
                case Lcode.Success:
                    result = "클리어";
                    break;
                case Lcode.Fail:
                    result = "실 패";
                    break;
                
            }
        }
        else//영어
        {
            switch (code)
            {
                case Lcode.Menu:
                    result = "Menu";
                    break;
                case Lcode.Setting:
                    result = "Setting";
                    break;
                case Lcode.Success:
                    result = "Success";
                    break;
                case Lcode.Fail:
                    result = "try Again";
                    break;
                
            }
        }
        return result;
    }
        

    // Update is called once per frame
    
}
