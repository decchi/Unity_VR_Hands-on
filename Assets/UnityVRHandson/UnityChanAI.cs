using UnityEngine;
using System.Collections;

public class UnityChanAI : MonoBehaviour
{
    private UnityChan.UnityChanAIControlScriptWithRgidBody script;    //ユニティちゃんの移動＆アニメーション関連のスクリプト
    public Transform goal;
    private Transform tr;
    private Animator anim;	// キャラにアタッチされるアニメーターへの参照
    Quaternion heading;
    private Rigidbody rb;
    private GameObject retryCanpas;
    // Use this for initialization
    void Start()
    {
        // Animatorコンポーネントを取得する
        anim = GetComponent<Animator>();
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        script = gameObject.GetComponent<UnityChan.UnityChanAIControlScriptWithRgidBody>();
        retryCanpas = GameObject.Find("RetryUI");
        if (retryCanpas != null)
        {
            retryCanpas.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

        //if (FlagManager.moveFlg)
        //{

            //現時点からの目標への向きを取得する
            heading = Quaternion.LookRotation(goal.position - tr.transform.position);
            //現時点からの目標との角度を取得する
            float angle = Mathf.DeltaAngle(tr.transform.rotation.y, GetHeadingAngle().y);
            script.KeyForward = true;
            //角度が急だと目的地の周りで円運動し続けるので、角度が大きい時は回転量を増やす
            if (Mathf.Abs(angle) < 60)
            {
                tr.transform.rotation = Quaternion.RotateTowards(tr.transform.rotation, heading, 90 * Time.deltaTime);
            }
            else
            {
                tr.transform.rotation = Quaternion.RotateTowards(tr.transform.rotation, heading, 180 * Time.deltaTime);
            }

        //}
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            goal = collision.gameObject.transform;
            script.KeyForward = false; //移動停止
            anim.SetTrigger("Win");
            FlagManager.moveFlg = false;
            rb.angularVelocity = Vector3.zero;//回転の運動量を0にして停止させる。
            // 衝突したプレーヤーの前に移動
            tr.position = new Vector3(collision.gameObject.transform.position.x, 0, collision.gameObject.transform.position.z + 3);
            // 衝突したプレーヤーのほうを向く
            tr.transform.rotation = Quaternion.LookRotation(collision.gameObject.transform.position - tr.transform.position);
            retryCanpas.SetActive(true);// リトライUIの表示
            // リトライUIの位置調整
            retryCanpas.GetComponent<RectTransform>().position = new Vector3(collision.gameObject.transform.position.x, 20, collision.gameObject.transform.position.z + 45);
        }
    }

    Vector3 GetHeadingAngle()
    {
        Vector3 heading = goal.position - tr.transform.position;
        heading.y = 0;
        return Quaternion.LookRotation(heading).eulerAngles;
    }
}
