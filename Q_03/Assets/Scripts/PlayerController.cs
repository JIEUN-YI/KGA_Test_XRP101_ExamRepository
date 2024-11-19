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
        // �Ѿ˰� �浹�ϴ� ���
        if (other.CompareTag("Bullet"))
        {
            Debug.Log("�Ѿ˰��浹");
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
        //Debug.Log("ü��0");
        _audio.Play();
        gameObject.SetActive(false);
    }
}
