using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AfterNamed : MonoBehaviour {
    public Text name;

    public GameObject warningPanel;
    //玩家名字
    public string playername;

    //获得游戏数据保存脚本
    public GameObject data;

    //获取加载界面
    public GameObject loadPanel;


	// Use this for initialization
	void Start () {
        data = GameObject.FindGameObjectWithTag("Data");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

     public void  NullOrNot()
    {
        if(name.text=="")
        {
            Debug.Log("名为空");
            StartCoroutine("Warning");
        }
        else
        {
            StartCoroutine("GetName");                    
        }
    }

     IEnumerator  GetName()
    {
        playername = name.text;
        data.GetComponent<SaveStartSceneData>().playername = playername;
        loadPanel.SetActive(true);
        yield return new WaitForSeconds(1);
        Application.LoadLevel("Map");

    }

    public void InputNamePanelColse()
    {
        this.gameObject.SetActive(false);
    }

    IEnumerator Warning ()
    {
        warningPanel.SetActive(true);
        yield return new WaitForSeconds(1);
        warningPanel.SetActive(false);
    }

    
}
