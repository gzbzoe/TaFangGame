using UnityEngine;
using System.Collections;

public class TowerBase : MonoBehaviour {
    //建塔
    //升级
    //出售
    //判断显示什么样的UI
    public bool isHaveTower = false;//是否有塔
    public GameObject buildTower;//建塔的UI
    public GameObject upgradeTower;//升级UI
    public Tower CurrentTower;  //获取Tower脚本                             
    public int Level=0;//塔的等级
    
    void Start() {

    }
    void Update() {

    }
    public void ToShowUI()
    {
        //有塔显示升级UI
        if (isHaveTower == true)
        {
            upgradeTower.SetActive(true);
            buildTower.SetActive(false);
        }
        else {
            buildTower.SetActive(true);
            upgradeTower.SetActive(false);
        }
    }
    //建塔
    public void BuildTower(GameObject tower)
    {
        if (UIManager.instance.Money>=100)
        {
            //生成物，生成位置，生成角度
            GameObject go = Instantiate(tower,
                transform.position + Vector3.up * 3,
                Quaternion.identity) as GameObject;
            isHaveTower = true;
            Level++;
            CurrentTower = go.GetComponent<Tower>();
            if(CurrentTower.tag == "2")
            {
                UIManager.instance.Money -= 150;
            }
            else
            {
                UIManager.instance.Money -= 100;
            }
            
        }
       
    }
    //升级塔
    public void UpTower()
    {
        //判断级别
        if(CurrentTower.tag=="2")
        {
            //判断金币是否足够
            if(UIManager.instance.Money >= CurrentTower.TowerMoney+Level*100)
            {

                if (Level < 2)
                {
                    if(CurrentTower.UpTower==null)
                    {
                        return;
                    }
                    else
                    {
                        //实例化升级之后塔
                        GameObject go = Instantiate(CurrentTower.UpTower,
                            transform.position + Vector3.up * 3,
                            Quaternion.identity) as GameObject;
                        Destroy(CurrentTower.gameObject);
                        CurrentTower = go.GetComponent<Tower>();//升级之后的塔存入tower脚本中
                        isHaveTower = true;
                        Level++;
                        UIManager.instance.Money -= (Level * 100);
                    }
                   
                }
            }
           
        }
        else
        {
            if (UIManager.instance.Money >= CurrentTower.TowerMoney + Level * 100)
            {
                if (Level < 3)
                {
                    if (CurrentTower.UpTower == null)
                    {
                        return;
                    }
                    else
                    {
                        //实例化升级之后塔
                        GameObject go = Instantiate(CurrentTower.UpTower,
                            transform.position + Vector3.up * 3,
                            Quaternion.identity) as GameObject;
                        Destroy(CurrentTower.gameObject);
                        CurrentTower = go.GetComponent<Tower>();//升级之后的塔存入tower脚本中
                        isHaveTower = true;
                        Level++;
                        UIManager.instance.Money -= (Level * 100);
                    }

                }
            }
        }
       
     
    }

    //出售塔
    public void SellTower()
    {
        Destroy(CurrentTower.gameObject);
        isHaveTower = false;//出售无塔
        Level = 0;
        UIManager.instance.Money+=CurrentTower.Money;
    }

}
