using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMgr : MonoBehaviour
{

    private static InputMgr instance = null;
    // Start is called before the first frame update
    private bool IsitTouch;
    private float finger_distance;

    private Vector3 curPositionValue;
    public Vector3 curPosition
    {
        get
        {
            return curPositionValue;
        }
    }

    private Vector3 curMoveDisValue;
    public Vector3 curMoveDis {
        get {
            return curMoveDisValue;
        }
    }

    private float zoomvalue;

    public float zoom
    {
        get { return zoomvalue; }
    }
    void Awake()
    {
        if (null == instance)
        {
            //이 클래스 인스턴스가 탄생했을 때 전역변수 instance에 게임매니저 인스턴스가 담겨있지 않다면, 자신을 넣어준다.
            instance = this;
            curPositionValue = Vector3.zero;
            //씬 전환이 되더라도 파괴되지 않게 한다.
            //gameObject만으로도 이 스크립트가 컴포넌트로서 붙어있는 Hierarchy상의 게임오브젝트라는 뜻이지만, 
            //나는 헷갈림 방지를 위해 this를 붙여주기도 한다.
            //DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //만약 씬 이동이 되었는데 그 씬에도 Hierarchy에 GameMgr이 존재할 수도 있다.
            //그럴 경우엔 이전 씬에서 사용하던 인스턴스를 계속 사용해주는 경우가 많은 것 같다.
            //그래서 이미 전역변수인 instance에 인스턴스가 존재한다면 자신(새로운 씬의 GameMgr)을 삭제해준다.
            Destroy(this.gameObject);
        }
        //Debug.Log(Application.platform);
        if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
            IsitTouch = true;
        else
            IsitTouch = false;
    }
    
    public static InputMgr Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    

    void Start()
    {
        
    }

    public bool ClickDown() {
        bool result=false;
        if (IsitTouch && Input.touchCount > 0)
        {
            
            result = (Input.GetTouch(0).phase == TouchPhase.Began);
        }
        else
        {
            result = Input.GetMouseButtonDown(0);
        }
        return result;
    }
    public bool Click() {
        bool result;
        if (IsitTouch) 
        {
            if (Input.touchCount > 0)
                result = true;
            else
                result = false;
        }
        else
        {
            result = Input.GetMouseButton(0);
        }
        return result;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 temp = curPositionValue;
        if (IsitTouch) 
        {
            if (Input.touchCount > 0)
            {
                curPositionValue = Input.GetTouch(0).position;
                if (Input.GetTouch(0).phase == TouchPhase.Moved)
                    curMoveDisValue = curPositionValue - temp;
                else
                    curMoveDisValue = Vector3.zero;

                if (Input.touchCount > 1)
                {
                    float temp_dis = Vector3.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);
                    if (Input.GetTouch(1).phase != TouchPhase.Began)
                    {
                        zoomvalue = temp_dis - finger_distance;
                    }
                    else
                    {
                        zoomvalue = 0;
                    }
                    finger_distance = temp_dis;
                }
                else
                {
                    zoomvalue = 0;

                }
            }
            else
            {
                zoomvalue = 0;
            }



        }
        else 
        {
            curPositionValue = Input.mousePosition;
            curMoveDisValue = curPositionValue - temp;

            zoomvalue=Input.GetAxis("Mouse ScrollWheel")*600;

        
        }
        
    }
}
