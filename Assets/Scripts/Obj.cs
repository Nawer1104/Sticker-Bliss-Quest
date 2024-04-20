using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj : MonoBehaviour
{
    public int uniqueId;

    public GameObject vfxFinish;

    public GameObject vfxFail;

    private Vector3 startPos;

    private void Awake()
    {
        startPos = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<DragAndDrop>()._dragging = false;

        if (collision != null && collision.GetComponent<Main>() != null && collision.GetComponent<Main>().uniqueId == this.uniqueId)
        {
            gameObject.SetActive(false);

            PlayVfx(vfxFinish);

            collision.GetComponent<Main>().SetItCompleted();
        }
        else
        {
            PlayVfx(vfxFail);

            transform.position = startPos;
        }
    }

    public void PlayVfx(GameObject vfx)
    {
        GameObject vfxPlayed = Instantiate(vfx, transform.position, Quaternion.identity) as GameObject;
        Destroy(vfxPlayed, 1f);
    }
}
