using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 敌人坦克管理器类
/// 
/// </summary>
public class EnemyTankTrigger : MonoBehaviour {

    /// <summary>
    /// 敌人随机数组
    /// </summary>
    public GameObject[] EnemyPrefabArr;

    /// <summary>
    /// 当前在线敌人坦克列表
    /// </summary>
    public static List<GameObject> EnemyList = new List<GameObject>();

    /// <summary>
    /// 敌人位置数组
    /// </summary>
    public GameObject[] EnemyPosArr;

    //回合字幕
    public Text roundText;
    private int round=1;
	
	void Start () {
        createEnemy();
        StartCoroutine(RoundShow());
	}

    void Update()
    {

        if (EnemyList.Count == 0)
        {
            round++;
            StartCoroutine(RoundShow());
            createEnemy();
            //StopCoroutine(RoundShow());
        }
    }

    /// <summary>
    /// 创建敌人坦克函数
    /// </summary>
    private void createEnemy()
    {
        for (int i = 0; i < EnemyPosArr.Length;i++ )
        {
            GameObject pos = EnemyPosArr[i];
            //实例化
            GameObject.Instantiate(EnemyPrefabArr[Random.Range(0,4)],pos.transform.position,pos.transform.rotation);
        }
    }

    IEnumerator RoundShow ()
    {
        roundText.text = "Round " + round;
        roundText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        roundText.gameObject.SetActive(false);
    }

}
