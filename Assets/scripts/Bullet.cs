using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    // 追击目标移动，可以把小兵打死 自毁
    public float speed = 1f;
    public Enemy target; //子弹攻击对象
    public float damage = 10f; //攻击力
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(target!=null)
        {
            //子弹有目标
            transform.LookAt(target.transform);
        }
        else
        {
            //目标消失，自毁
            Destroy(gameObject, 1);
        }
        transform.Translate(Vector3.forward*Time.deltaTime*speed);

	}
    private void OnTriggerEnter(Collider other)
    {
        //子弹碰到小兵，小兵减血，子弹销毁
        if(other.GetComponent<Enemy>()!=null)
        {
            target.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
