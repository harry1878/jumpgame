using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text text;
    public bool isPlaying = true;


    private void Update()
    {
        if (isPlaying) return;

        if(Input.GetKeyDown(KeyCode.R))
        {
            isPlaying = true;
            text.gameObject.SetActive(false);

            var p = FindObjectOfType<PlayerModule>();
            p.transform.position = new Vector3(0, 0.5f, 0);
            p.transform.rotation = Quaternion.identity;
            p.GetRigid.velocity = Vector3.zero;
        }
    }
}
