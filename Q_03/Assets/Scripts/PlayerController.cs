using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [field: SerializeField]
    public int Hp /*{ get; private set; }*/;
    public int curHp;

    private AudioSource _audio;

    private void Awake()
    {
        Init();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        // 총알과 충돌하는 경우
        if (other.CompareTag("Bullet"))
        {
            Debug.Log("총알과충돌");
            int damage = other.gameObject.GetComponent<BulletController>()._damageValue;
            TakeHit(damage);
        }
    }
    

    private void Init()
    {
        _audio =gameObject.GetComponent<AudioSource>();
        curHp = Hp;
    }

    public void TakeHit(int damage)
    {
        curHp -= damage;
        Debug.Log(curHp);
        if (curHp <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        //Debug.Log("체력0");
        _audio.Play();
        gameObject.SetActive(false);
    }
}
