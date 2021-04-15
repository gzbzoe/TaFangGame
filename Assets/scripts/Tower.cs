using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {
    //发射子弹，攻击小兵 找到目标小兵
    public Enemy target; //目标小兵
    public float attackRange = 5f; //攻击范围
    public Transform turret;//会旋转的炮塔
    public float interval = 0.5f;//子弹发射间隔
    public Bullet bullet;//子弹预设物
    public Transform firePos;//子弹开火位置
    public GameObject UpTower;//升级之后的塔
    public int TowerMoney;
    public int Money;//塔值多少钱
	void Start () {
        //把塔攻击范围表现在球的半径
        GetComponent<SphereCollider>().radius = attackRange;
        StartCoroutine(Fire());//开启协程
	}
	IEnumerator Fire()
    {
        //间隔几秒发射子弹
        while(true)
        {
            yield return new WaitForSeconds(interval);
            //一直循环
            if (target !=null)
            {
                
                //生成子弹
                Bullet newBullet = Instantiate(bullet);
                //放在开火位置上
                newBullet.transform.position = firePos.position;
                //设置攻击目标
                newBullet.target = target;
            }
        }
        
    }
	//寻找攻击目标：当小兵进入攻击范围内，就把他当成攻击目标
    //小兵走出攻击范围，目标消失


    private void OnTriggerEnter(Collider other)
    {
        print("YES");
        //当有碰撞器进入触发器时执行一次
        //执行的前提 双方都要有碰撞器，其中至少一方有刚体组件
        if (target == null)
        {
            //没有攻击目标 寻找一个小兵当作攻击目标
            Enemy oneEnemy = other.GetComponent<Enemy>();
            if(oneEnemy!=null)
            {
                //说明是一个小兵
                target = oneEnemy;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //当碰撞结束的时候执行一次
        //当目标离开攻击范围，目标清空
        Enemy oneEnemy = other.GetComponent<Enemy>();
        if (oneEnemy=target)
        {
            //离开的小兵是攻击目标
            target = null;
        }

    }

    void Update () {
        if (target!=null)
        {
            if(target.isDead==false)
            {//有攻击目标
             //让炮塔朝向攻击目标
                turret.rotation = Quaternion.LookRotation
                (target.transform.position - turret.transform.position);
            }
            else
            { //如果目标被打死就切换对象
                target = null;
            }
            
            
        }
	}
}
