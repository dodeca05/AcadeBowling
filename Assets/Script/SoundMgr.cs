using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMgr : MonoBehaviour
{
    // Start is called before the first frame update

    private static SoundMgr instance;
    public static SoundMgr Instance
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

    private void Start()
    {
        if (!PlayerPrefs.HasKey("BGM"))
        {
            PlayerPrefs.SetInt("BGM", 1);
        }
        else
        {
            if (PlayerPrefs.GetInt("BGM") == 0)
                GetComponent<AudioSource>().Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
