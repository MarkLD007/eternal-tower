using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WeaponSeclect : MonoBehaviour
{
    public Button Weapon1;
    public Button Weapon2;
    public Button Weapon3;
    public Button Weapon4;
    public Button Weapon5;
    public Animator animator;
    void Start()
    {
        // GameObject.DontDestroyOnLoad(gameObject);
        Weapon1.onClick.AddListener(LoadScene1);
        Weapon2.onClick.AddListener(LoadScene2);
        Weapon3.onClick.AddListener(LoadScene3);
        Weapon4.onClick.AddListener(LoadScene4);
        Weapon5.onClick.AddListener(LoadScene5);
        WeaponAnswer.a = 0;
    }


    private void LoadScene1()
    {
        WeaponAnswer.a = 0;
        StartCoroutine(LoadScene(3));
    }

    private void LoadScene2()
    {
        WeaponAnswer.a = 1;
        StartCoroutine(LoadScene(3));
    }

    private void LoadScene3()
    {
        WeaponAnswer.a = 2;
        StartCoroutine(LoadScene(3));
    }

    private void LoadScene4()
    {
        WeaponAnswer.a = 3;
        StartCoroutine(LoadScene(3));
    }

    private void LoadScene5()
    {
        WeaponAnswer.a = 4;
        StartCoroutine(LoadScene(3));
    }
    IEnumerator LoadScene(int index)
    {
        animator.SetBool("Fadein", true);
        animator.SetBool("Fadeout", false);

        yield return new WaitForSeconds(1);

        AsyncOperation async = SceneManager.LoadSceneAsync(index);
        async.completed += OnloadedScene;
    }

    private void OnloadedScene(AsyncOperation obj)
    {
        animator.SetBool("Fadein", false);
        animator.SetBool("Fadeout", true);
    }

}
