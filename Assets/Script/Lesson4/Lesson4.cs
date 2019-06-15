using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson4 : MonoBehaviour
{
    public class Boss
    {
        private int hp = 100;          // 体力
        private int power = 25;        // 攻撃力
        private int mp = 53;

        // 攻撃用の関数
        public void Attack()
        {
            Debug.Log(this.power + "のダメージを与えた");
        }

        // 防御用の関数
        public void Defence(int damage)
        {
            Debug.Log(damage + "のダメージを受けた");
            // 残りhpを減らす
            this.hp -= damage;
        }

        // 魔法用の関数
        public void Magic(int useMp)
        {
            var afterMp = mp - useMp;
            mp = afterMp > 0 ? afterMp : 0;
            if (mp > 0) Debug.Log(string.Format("魔法攻撃をした。残りMPは{0}。", mp));
            else Debug.Log("MPが足りないため魔法が使えない");
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        //課題：配列を宣言して出力しましょう
        {
            Debug.Log("課題：配列を宣言して出力しましょう");
            // 要素が5の配列
            int[] points = { 1, 2, 3, 4, 5 };
            Debug.Log("---順番に表示---");
            // 順番に表示
            for (int i = 0; i < points.Length; i++)
            {
                Debug.Log(points[i]);
            }
            Debug.Log("---逆順に表示---");
            // 逆順に表示
            for (int i = points.Length - 1; i >= 0; i--)
            {
                Debug.Log(points[i]);
            }
        }
        // 発展課題
        {
            Debug.Log("発展課題");
            // Bossクラスの変数を宣言してインスタンスを代入
            Boss lastboss = new Boss();
            // 回数
            var count = 0;
            // 消費MP
            var userMp = 5;
            // 回数上限
            const int COUNT_MAXT = 10;
            while (count <= COUNT_MAXT)
            {
                Debug.Log(string.Format("---{0}回目---", count + 1));
                lastboss.Magic(userMp);
                count++;
            }
        }
    }
}
