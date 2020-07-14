using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageMgr : MonoBehaviour
{
    public enum Lcode { Menu,Setting,Fail,Success,Restart,Back2L,Back2M,NextStage,T1};
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
        contury = Application.systemLanguage;
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
                case Lcode.Restart:
                    result = "재시작";
                    break;
                case Lcode.Back2L:
                    result = "로비로 돌아가기";
                    break;
                case Lcode.Back2M:
                    result = "메뉴로 돌아가기";
                    break;
                case Lcode.NextStage:
                    result = "다음 스테이지";
                    break;
                case Lcode.T1:
                    result = "공을 드래그 하여 조준하고 파워를 조절할 수 있습니다.\n공을 발사시켜 볼링핀을 모두 넘어뜨리세요";
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
                case Lcode.Restart:
                    result = "Restart";
                    break;
                case Lcode.Back2L:
                    result = "Back to the Lobby";
                    break;
                case Lcode.Back2M:
                    result = "Back to the menu";
                    break;
                case Lcode.NextStage:
                    result = "Next Stage";
                    break;

            }
        }
        return result;
    }
        

    // Update is called once per frame
    
}
