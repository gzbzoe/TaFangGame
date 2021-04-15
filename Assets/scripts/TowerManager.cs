using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class TowerManager : MonoBehaviour {
        //塔升级出售音效
        private AudioSource towerAudio;
        void Start()
        {
            //获取AudioSource组件
            towerAudio = transform.GetComponent<AudioSource>();

        }
        public LayerMask layerMask;//声明一个层
        public TowerBase towerBase;//定义塔基座
        Vector3 pos;//存射线检测到的基座位置
        public GameObject buildTower;//建塔的UI
        public GameObject upgradeTower;//升级UI
        void Update()
        {
            if (Input.GetMouseButtonDown(0)) //0左键 1右键 2滚轮
            {
                //声明一条射线 
                //        从屏幕构造一条射线
                //                                     获取鼠标坐标
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);  
                RaycastHit hit;  //射线检测后存储信息的变量
                                 //out 输出 
                                 //给hit赋值
                 if (Physics.Raycast(ray, out hit, 100f, layerMask))
                 {
                            
                         if (Input.GetMouseButtonDown(0))
                        {    
                                //判断鼠标是否点击UI
                                if (!EventSystem.current.IsPointerOverGameObject())
                                {
                                        //点击塔基座
                                        towerBase = hit.collider.GetComponent<TowerBase>();
                                        towerBase.ToShowUI();
                                        pos = hit.point;//hit.point射线碰到的位置
                                        //Debug.Log(hit.collider.gameObject.name);
                                }
                                else
                                {
                                    //点击到界面
                                     Invoke("HiddenUI", 0.2f);

                                }
                         }


                  }else
          
                {     //点击除塔基和UI以外的物体
                     Invoke("HiddenUI", 0.2f);

                }
                 
                 //在pos处显示UI 世界转屏幕
                buildTower.transform.position = Camera.main.WorldToScreenPoint(pos);
            
            
                upgradeTower.transform.position = Camera.main.WorldToScreenPoint(pos);

            }
        }


    public GameObject[] towers;
    //生产塔按钮绑定
    public void OnClickBuildTower(int a)
    {
        //调用生成塔
        towerBase.BuildTower(towers[a]);
        //播放音效
        towerAudio.Play();
    }
    public void HiddenUI()
    {
       
        buildTower.SetActive(false);
        upgradeTower.SetActive(false);
    }
    //升级塔的按钮
    public void UpTower()
    {

        towerBase.UpTower();
        //播放音效
        towerAudio.Play();
    }
    //出售塔的按钮
    public void SellTower()
    {
        towerBase.SellTower();
        //播放音效
        towerAudio.Play();
    }
 }
