using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{
    //HingeJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;

    // Use this for initialization
    void Start()
    {
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
    void Update()
    {
        // キーボードでの入力
        {
            //左矢印キーを押した時左フリッパーを動かす
            if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
            {
                SetAngle(this.flickAngle);
            }
            //右矢印キーを押した時右フリッパーを動かす
            if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
            {
                SetAngle(this.flickAngle);
            }

            //矢印キー離された時フリッパーを元に戻す
            if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
            {
                SetAngle(this.defaultAngle);
            }
            if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
            {
                SetAngle(this.defaultAngle);
            }
        }

        // タップでの入力
        {
            var touchCount = Input.touchCount;
            // タッチ入力がひとつでのあれば
            if (touchCount > 0)
            {
                Debug.Log("touchCount:" + touchCount);
                for(int i = 0; i < touchCount; i++)
                {
                    var touch = Input.GetTouch(i);
                    Debug.Log("pos:" + touch.position);
                    if (touch.phase == TouchPhase.Began && touch.position.x < Screen.width / 2 && tag == "LeftFripperTag")
                    {
                        SetAngle(this.flickAngle);
                    }
                    if (touch.phase == TouchPhase.Began && touch.position.x > Screen.width / 2 && tag == "RightFripperTag")
                    {
                        SetAngle(this.flickAngle);
                    }

                    if (touch.phase == TouchPhase.Ended && touch.position.x < Screen.width / 2 && tag == "LeftFripperTag")
                    {
                        SetAngle(this.defaultAngle);
                    }
                    if (touch.phase == TouchPhase.Ended && touch.position.x > Screen.width / 2 && tag == "RightFripperTag")
                    {
                        SetAngle(this.defaultAngle);
                    }
                }
            }
        }
    }

    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}
