using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModule : MonoBehaviour
{
    // 접근 제한자 
    //                    private, protected, public
    // 외부접근 가능?          X       X         O
    // 부모 접근 가능?         X       O         O

    //유니티에서 public 으로 지정되어 있고
    //유니티 직렬화 조건에 맞다면
    //자동으로 [SerializedField]속성이 생성딘다
    //즉, 유니티 에디터에서 보여지게 된다
    [SerializeField] private float speed;
    private Rigidbody rigid;
    private float power;
    private GameManager manager = null;

    public Rigidbody GetRigid
    {
        get { return rigid; }
    }

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        manager = FindObjectOfType<GameManager>();
    }

    //private 이 생략된 경우
    //void Update()

    private void Update()
    {
        if (!manager.isPlaying) return;
        if(transform.position.y < -5f)
        {
            manager.isPlaying = false;
            manager.text.gameObject.SetActive(true);
            return;
        }

        //Speed 값을 이용하여 WASD키로 큐브를 움직여 보세요
        //Input.GetKeyDown 눌렀을떄 한번만 true
        //Input.GetKeyUP 눌렀다 땠을때 한번만 true
        //Input.GetKey 누를때 마다 true
        if (Input.GetKey(KeyCode.W) == true)
        {
            transform.Translate(0, 0, speed);
        }
        if (Input.GetKey(KeyCode.S) == true)
        {
            transform.Translate(0, 0, -speed);
        }
        if (Input.GetKey(KeyCode.A) == true)
        {
            transform.Translate(-speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.D) == true)
        {
            transform.Translate(speed, 0, 0);
        }

        //A && B :A가 true이고 B가 true이면
        //A || B : A나 B 둘 중 하나가 true 이면
      
            if (Input.GetKey(KeyCode.Space))
            {
                 power += Time.deltaTime * 5000f;
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                 rigid.AddForce(power / 2f, power, 0);
                 power = 0;
            }

        //Debug.Log(string.Format("{0:F6}, {1:F6}, {2:F6}",
        //              rigid.velocity.x,
        //              rigid.velocity.y,
        //              rigid.velocity.z));
    }


}
