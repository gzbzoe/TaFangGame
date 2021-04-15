using UnityEngine;
using System.Collections;
//生成几波兵，每一波指定（种类，数量，间隔）用数组
[System.Serializable]//把自定义类进行序列化（让它在编辑器看到）
public class EnemyQueue
{
    //要生成的小兵
    public GameObject enemy;
    public float interval=1f; //时间间隔
    public int count = 1;//一种小兵生成的数量
    public float QueueInterval = 5f;//两波兵之间间隔
}
public class GameManager : MonoBehaviour {

    //批量生产小兵
    //生成一个小兵 指定一个小兵 制定生成位置 设置好目标点
    
    public EnemyQueue[] Enemies; //几对兵的数组 Unity只识别系统所带类
    //要生成的小兵
    //public GameObject enemy;
   // public float interval; //时间间隔
    //public int count=1;//一种小兵生成的数量
    public Transform[] Paths; //路径点
    public int Enemycount;//敌人总数
    public static GameManager instance;
    public  int DieEnemyCount;//打死敌人总数
    public  int EnemyPassCount;//通过敌人的总数
    void Start () {
        StartCoroutine(Produce());
        Time.timeScale = 1;
        instance = this;
	}
	//协程 可以有延迟返回的方法
    IEnumerator Produce()
    {   
        //遍历几波兵
        for (int j = 0; j < Enemies.Length; j++)
        {
            //获取敌人总数
            Enemycount += Enemies[j].count;
            //每一波兵
            for (int i = 0; i < Enemies[j].count; i++)
            {
                yield return new WaitForSeconds(Enemies[j].interval);
                //生成一个小兵，生成在第一个目标点
                GameObject go = Instantiate(Enemies[j].enemy, Paths[0].position, Quaternion.identity) as GameObject;
                go.GetComponent<Enemy>().Paths = Paths; //设置新生成小兵的目标点
            }
            //生成完一波兵后延迟一段时间开始下一波兵的生成
            yield return new WaitForSeconds(Enemies[j].QueueInterval);
        }
    }
    void Update () {
        //判断游戏胜利
        if ((EnemyPassCount + DieEnemyCount) == Enemycount)
        {
         
            UIManager.instance.VictoryPanel.SetActive(true);
        }
	}
}
