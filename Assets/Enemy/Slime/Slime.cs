
using UnityEngine;

public class Slime : MonoBehaviour
{
    [Header("巡回ポイントの設定")]
    public Transform[] waypoints; // インスペクター上で設定する巡回ポイントの配列
    public float speed = 3.0f;   // 敵の移動速度



    private int currentWaypointIndex = 0; // 現在向かっているポイントの番号



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {



    }



    // Update is called once per frame
    void Update()
    {
        // 巡回ポイントが設定されていない場合は何もしない
        if (waypoints.Length == 0) return;



        // 現在のポイントを取得
        Transform targetWaypoint = waypoints[currentWaypointIndex];



        // 目標に向かって移動
        transform.position = Vector3.MoveTowards(transform.position,      // 現在地
                                                 targetWaypoint.position, // 目的地
                                                 speed * Time.deltaTime); // 今回のフレームで進む距離



        // 敵と目標ポイントの距離を計算し、十分に近づいたら次のポイントへ
        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            currentWaypointIndex++;



            // 最期のポイントに到達したら、最初のポイント（０番目）に戻る
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
    }
}
