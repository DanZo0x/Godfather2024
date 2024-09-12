using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class attackCAC : MonoBehaviour
{
    public int degats = 1;
    public float cooldown = 0.5f;
    public Transform weapon;
    public float rayonAttack = 0.5f;

    private Collider2D[] colls;
    private bool reloading;
    private Animator anim;
    private SpriteRenderer monSprite;
    private Vector3 weaponPos;

    public GameObject effect;
    private GameObject effectSave;
    private Vector2 direction;
    private float angleEffect;

    private Collider2D coll;


    void Start()
    {
        anim = GetComponent<Animator>();
        monSprite = GetComponent<SpriteRenderer>();
        weaponPos = weapon.localPosition;
        coll = GetComponent<Collider2D>();
    }

    public void OnPunch(InputAction.CallbackContext context)
    {
        if (context.performed && Input.GetButtonDown("Fire1") && !reloading)
        {
            reloading = true;
            anim.SetTrigger("attack");
            StartCoroutine(reload());
        }
    }

    IEnumerator reload()
    {
        yield return new WaitForSeconds(cooldown);
        reloading = false;
    }

    public void PAF()
    {
        colls = Physics2D.OverlapCircleAll(weapon.position, rayonAttack);
        foreach (Collider2D truc in colls)
        {
            if (truc != null && truc.CompareTag("Obstacle")) 
                Debug.Log("ennemy collision");
            {
                truc.SendMessage("TakeDamage", degats, SendMessageOptions.DontRequireReceiver);
                if (effect != null)
                {
                    effectSave = Instantiate(effect, truc.ClosestPoint(coll.bounds.center), Quaternion.identity);
                    direction = truc.ClosestPoint(coll.bounds.center) - (Vector2)coll.bounds.center;
                    direction.Normalize();
                    angleEffect = Vector3.SignedAngle(transform.up, direction, Vector3.forward);
                    effectSave.transform.rotation = Quaternion.Euler(0, 0, -angleEffect);
                }

                Destroy(effectSave, 2f);
            }
        }
        //Debug.Log("PAF !");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(weapon.position, rayonAttack);
    }
}