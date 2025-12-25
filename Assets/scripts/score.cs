using System;
using System.Collections;
using NUnit.Framework.Constraints;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    private GameObject panel;
    private GameObject player_obj;
    private Transform player;
    private player_movement player_script;
    private TextMeshProUGUI scorebox;
    void Start()
    {
        panel = transform.parent.Find("Panel").gameObject;
        if (panel == null)
        {
            Debug.Log("panel is not assigned");
        }
        player_obj = GameObject.Find("Player");
        player_script = player_obj.GetComponent<player_movement>(); 
        if (player_script == null)
        {
            Debug.Log("PLayer script is not assigned correctly !");
        }
        scorebox = GetComponent<TextMeshProUGUI>();
        player = player_obj.transform;
    }
    void Update()
    {
        int final = (int)player.position.z + 98;
        final = Mathf.Clamp(final,-1,200);
        scorebox.text = final.ToString();
        if (player.position.y >= 0.99f && final == 200)
        {
            panel.SetActive(true);
            // Invoke("",1f);
            // player_script.Stop();
            player_script.Invoke("Next",1f);
        }
    }
}