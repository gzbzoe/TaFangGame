using UnityEngine;
using System.Collections;

public class EnemyDie : MonoBehaviour {

    private int EnemyPassCount;//小兵死亡的数量
   
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    private void OnTriggerExit(Collider other)
    {
        if(other.tag=="enemy"|| other.tag == "enemy1" ||
             other.tag == "enemy2"|| other.tag == "enemy3")
        {
            //print(other.tag);
            EnemyPassCount++;
            GameManager.instance.EnemyPassCount++;
            //小兵通过 人物减血
            UIManager.instance.HP -= 20;
            if(EnemyPassCount>=5)
            {   //调用游戏失败界面
                //uimanager.Lose();
                UIManager.instance.Lose();
            }
        }

    }
}
