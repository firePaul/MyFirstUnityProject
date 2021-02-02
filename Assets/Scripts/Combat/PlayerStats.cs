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
    private Rigidbody rb;
    
    public static List<string> keys = new List<string>();

    private bool fire = false;
    private bool mine = false;
    private bool jump = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
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
        if (Input.GetKeyDown(KeyCode.Space) && !jump)
        {
            jump = true;
            Jump();
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
        Instantiate(bullet, bulletStartPosition.position, this.gameObject.transform.GetChild(1).rotation);
    }
    private void PlaceMine()
    {
        mine = false;
        Instantiate(DelayMine, minePlacePosition.position, Quaternion.identity);
    }
    public void TakeKey(string tkey)
    {
        keys.Add(tkey);
    }
    void Jump()
    {
        rb.AddForce(Vector3.up*400, ForceMode.Impulse);
        Invoke("Jumpdelay",1f);
    }
    void Jumpdelay()
    {
        jump = false;
    }
}
