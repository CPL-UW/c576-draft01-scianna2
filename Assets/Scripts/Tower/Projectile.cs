using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float m_speed;

    private const float CELL_OFFSET = 0.5f;

    public GameObject TargetObj {
        get; set;
    }
    public float Damage {
        get; set;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject == TargetObj) {
            // affect the target
            TargetObj.GetComponent<Oncomer>().ApplyDamage(this.Damage);

            // destroy this projectile
            Destroy(this.gameObject);
        }
    }

    private void Update() {
        if (TargetObj == null) {
            // target has been destroyed before this projectile reached it
            Destroy(this.gameObject);
            return;
        }

        // calculate trajectory
        Vector3 targetPos = new Vector3(
            TargetObj.transform.position.x + CELL_OFFSET,
            TargetObj.transform.position.y + CELL_OFFSET,
            TargetObj.transform.position.z
            );
        Vector2 dir = (targetPos - this.transform.position).normalized;

        // move towards target
        this.transform.Translate(dir * m_speed * Time.deltaTime);
    }
}
