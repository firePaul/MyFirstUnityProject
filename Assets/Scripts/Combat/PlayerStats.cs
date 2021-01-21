using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour, ITakeDamage, IAmmo, IKey
{
    [SerializeField] private int hp = 100;
    [SerializeField] private int bullets = 60;
    [SerializeField] private int mines = 10;
    [SerializeField] private GameObject bullet = null;
    [SerializeField] private Transform bulletStartPosition = null;
    [SerializeField] private GameObject DelayMine = null;
    [SerializeField] private Transform minePlacePosition = null;
    public static string key = null;

    private bool fire = false;
    private bool mine = false;
    void FixedUpdate()
    {
        if (bullets == 0)  fire = false;
        if (mines == 0)  mine = false;
        if (fire) { Fire(); bullets -= 1; }
        if (mine) { PlaceMine(); mines -= 1; }
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            fire = true;
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            mine = true;
        }
    }
    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Death();
        }
    }
    private void Death()
    {
        Destroy(gameObject, 1);
    }
    public void BulletChange(int ammobullet)
    {
        bullets += ammobullet;
    }
    public void MineChange(int ammomine)
    {
        mines += ammomine;
    }
    private void Fire()
    {
        fire = false;
        var bul = Instantiate(bullet, bulletStartPosition.position, this.gameObject.transform.GetChild(1).rotation);
    }
    private void PlaceMine()
    {
        mine = false;
        var DelMine = Instantiate(DelayMine, minePlacePosition.position, Quaternion.identity);
    }

    public void TakeKey(string tkey)
    {
        key = $"{tkey}";
    }
}
