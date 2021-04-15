using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    //让小兵能够向前
    //让小兵能够朝向目标点移动 到达目标点附近时切换到下一个路径点，改变方向，朝向新的目标点
    //小兵死亡 定义血量 ，定义方法减血  血量<=0进入死亡
    //死亡状态：播放死亡动画，尸体下沉，销毁
    
    public float speed = 1f;
    public Transform[] Paths;
    public Transform target; //路径点
    public int index=0;  //索引值
    public float HP=100f;
    public Animator animator;
    public bool isDead = false; //存活状态
    private AudioSource enemyAudio;//怪物死亡音效
    

    void Start () {
        animator = GetComponent<Animator>();
        //设置第一个目标点
        target = Paths[index];
        //设置朝向
        transform.rotation = Quaternion.LookRotation(target.position-transform.position);
        enemyAudio = transform.GetComponent<AudioSource>();
	}
	
	
	void Update () {
        //活着向前移动，死了向下移动
        if (isDead==false)
        {
           
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            //判断距离是否到达目标点附近
            if (Vector3.Distance(transform.position,target.position) < 0.5)
            {
                //切换目标点
                //Debug.Log("123");
                index++;
                //防止索引越界
                if (index < Paths.Length)
                {
                    target = Paths[index];
                    transform.rotation = Quaternion.LookRotation(target.position - transform.position);
                }

            }
        }
        else
        {
            //死亡状态 尸体下沉
            transform.Translate(Vector3.down * Time.deltaTime*0.5f);
        }
        


	}
    //减血
    public void TakeDamage(float damage)
    {
        HP -= damage;
        if(HP<=0&&isDead==false)
        {
            //获取敌人死亡数量
            GameManager.instance.DieEnemyCount++;
            isDead = true;
            enemyAudio.Play();
            //死亡
            animator.SetTrigger("Die");
            //延迟2s销毁
            Destroy(gameObject, 2);
            //判断怪物类别
            if (gameObject.tag=="enemy")
            {
                UIManager.instance.Money += 20;
            }
            if (gameObject.tag == "enemy1")
            {
                UIManager.instance.Money += 30;
            }
            if (gameObject.tag == "enemy2")
            {
                UIManager.instance.Money += 60;
            }
            if (gameObject.tag == "enemy3")
            {
                UIManager.instance.Money += 100;
            }
        }
    }
}
