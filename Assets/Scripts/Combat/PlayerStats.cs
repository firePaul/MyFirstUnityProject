using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour, ITakeDamage, IAmmo, IKey
{
    public static int maxhp = 300;
    public static int maxammo = 40;
    [SerializeField] private int mines = 5;
    [SerializeField] private GameObject bullet = null;
    [SerializeField] private Transform bulletStartPosition = null;
    [SerializeField] private GameObject DelayMine = null;
    [SerializeField] private Transform minePlacePosition = null;
    private Rigidbody rb;
    private Animator _anibody;

    public HpBar hpbar;
    public AmmoBar ambar;
    public static int curammo;
    public static int curhp;

    public static List<string> keys = new List<string>();

    private bool fire = false;
    private bool mine = false;
    private bool jump = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        curhp = maxhp;
        hpbar.SetMaxHP(maxhp);
        curammo = maxammo;
        ambar.SetMaxAmmo(maxammo);
        _anibody = gameObject.GetComponentInParent<Animator>();
    }
    void FixedUpdate()
    {
        if (curammo == 0)  fire = false;
        if (mines == 0)  mine = false;
        if (fire) { Fire(); curammo -= 1; ambar.SetAmmo(curammo); }
        if (mine) { PlaceMine(); mines -= 1; }
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            fire = true;
            //_anibody.SetTrigger("Fire 0");
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
        curhp -= damage;
        if (curhp > maxhp)
        {
            curhp = maxhp;
        }
        hpbar.SetHP(curhp);
        if (curhp <= 0)
        {
            Death();
        }
    }
    private void Death()
    {
        gameObject.SetActive(false);
    }
    public void BulletChange(int ammobullet)
    {              
        curammo += ammobullet;
        if (curammo > maxammo)
        {
            curammo = maxammo;
        }
        ambar.SetAmmo(curammo);
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
