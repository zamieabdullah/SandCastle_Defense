using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class CastleHealth : MonoBehaviour
{
    public LayerMask castle;
    private Collider2D[] castleTowers;
    SpriteRenderer spriteRenderer;
    Vector3 target = new Vector3(0, 5, 0);

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        castleTowers = Physics2D.OverlapCircleAll(target, 2f, castle);

    }

    private void Update()
    {
        castleTowers = Physics2D.OverlapCircleAll(target, 2f, castle);

        Vulnerable();
    }

    void Vulnerable()
    {
        if ((castleTowers != null) && (castleTowers.Length <= 6))
        {
            Debug.Log("VULNERABLE!!!");

            if (spriteRenderer.color == Color.white)
            {
                Debug.Log("should turn red now!");
                spriteRenderer.color = Color.red;
                //StartCoroutine(Wait());
                //spriteRenderer.color = Color.white;
            }
  
        }
    }

    void OnDrawGizmosSelected()
    {
        if (transform.position == null) return;
        Gizmos.DrawWireSphere(target, 1f);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
    }
}
