using UnityEngine;
using System.Collections;

public class Camera_Controller : MonoBehaviour {

    public float Min = 5f; //最小视野
    public float Max =500f; //最大视野
    public float ScrollWheelSpeed = 10f;//滚轮滑动速度
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


        CameraView();
        CameraMove();
    }
    public void CameraView()
    {
        //Mouse ScrollWheel 滑动滚轮
        float cameraView = Camera.main.fieldOfView;
        cameraView += Input.GetAxis("Mouse ScrollWheel") * ScrollWheelSpeed;
        //限制一个值在一个范围之内
        cameraView = Mathf.Clamp(cameraView, Min, Max);
        Camera.main.fieldOfView = cameraView;
    }
    public void CameraMove()
    {
        if(Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            transform.Translate(new Vector3(-mouseX, 0, -mouseY), Space.World);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -5, 15),
                transform.position.y,
                Mathf.Clamp(transform.position.z, -10, 20));
        }
       
    }
}
