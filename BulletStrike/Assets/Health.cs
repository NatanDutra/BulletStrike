using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class Health : MonoBehaviour
{
   public int health;

   public bool IsLocalPlayer;

   public RectTransform healthBar;
   private float originalHealthBarSize;

   [Header("UI")]
   public TextMeshProUGUI healthText;

   public void Start()
   {
    originalHealthBarSize = healthBar.sizeDelta.x;
   }

   private void Update()
   {
        // healthBar.sizeDelta = new Vector2(originalHealthBarSize * health / 100f, healthBar.sizeDelta.y);
   }

   [PunRPC] 
   public void TakeDamage(int _damage)
   {
        health -= _damage;

        healthBar.sizeDelta = new Vector2(originalHealthBarSize * health / 100f, healthBar.sizeDelta.y);

        healthText.text = healthText.ToString();

        if(health <= 0)
        {
            if(IsLocalPlayer)
            {
                RoomManager.instance.SpawnPlayer();
                RoomManager.instance.deaths++;
                RoomManager.instance.SetHashes();
            }
            
            Destroy(gameObject);
        }
   }
}
