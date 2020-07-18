using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageMgr : MonoBehaviour
{
    public enum Lcode { Menu,Setting,Fail,Success,Restart,Back2L,Back2M,NextStage,T1,T2,T3,T4,T5,T6,Update};
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
                    result = "공을 드래그하여 조준하고 파워를 조절할 수 있습니다.\n공을 발사시켜 볼링핀을 모두 넘어뜨리세요";
                    break;
                case Lcode.T2:
                    result = "맵은 드래그하여 이동하거나 축소시킬 수 있습니다.";
                    break;
                case Lcode.T3:
                    result = "노란색 오브젝트는 외부충격에 움직입니다. 이를 이용해서 클리어 해보세요";
                    break;
                case Lcode.T4:
                    result = "공의 오버랩, 카메라 따라가기, BGM은 일시정지 메뉴의 설정에서 켜고 끌 수 있습니다.";
                    break;
                case Lcode.T5:
                    result = "빨간색 오브젝트는 공에게 더 큰 힘을 줌니다. 이를 이용해서 클리어 해보세요";
                    break;
                case Lcode.T6:
                    result = "분횡색 오브젝트에 닿는 모든 물체는 더 큰 힘을 가해줍니다. 이를 이용해서 클리어 해보세요";
                    break;
                case Lcode.Update:
                    result = "곧 업데이트 됩니다.";
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

                case Lcode.T1:
                    result = "You can drag the ball to aim and adjust power.\nFire all bowling pins by firing the ball";
                    break;
                case Lcode.T2:
                    result = "The map can be moved or collapsed by dragging.";
                    break;
                case Lcode.T3:
                    result = "The yellow object is moved by external impact. Try to clear it using this.";
                    break;
                case Lcode.T4:
                    result = "Ball overlap, camera follow, and BGM can be turned on and off in the settings of the pause menu.";
                    break;
                case Lcode.T5:
                    result = "The red object gives the ball more power. Try to clear it using this";
                    break;
                case Lcode.T6:
                    result = "Any object that touches a pink object exerts more force. Try to clear it using this";
                    break;

                case Lcode.Update:
                    result = "Will be updated soon.";
                    break;

            }
        }
        return result;
    }
        

    // Update is called once per frame
    
}
