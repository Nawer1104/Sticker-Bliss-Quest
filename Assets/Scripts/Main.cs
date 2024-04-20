using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Main : MonoBehaviour
{
    public int uniqueId;

    public GameObject sub;
    public GameObject main;

    private void Start()
    {
        sub.SetActive(true);
        main.SetActive(false);
    }

    public void SetItCompleted()
    {
        sub.transform.DOScale(0, 1f).OnComplete(() => {
            sub.SetActive(false);

            main.transform.localScale = new Vector3(0, 0, 0);

            main.SetActive(true);

            main.transform.DOScale(1, 1f);

            GameManager.Instance.CheckLevelUp();
        });
    }
}
