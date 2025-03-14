using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuList : MonoBehaviour
{
    public GameObject menulist;
    public Animator animator;

    [SerializeField] private bool menuKeys = true;


    void Update()
    {
        if (menuKeys)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                menulist.SetActive(true);
                menuKeys = false;
                Time.timeScale = 0f; // 时间暂停
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            menulist.SetActive(false);
            menuKeys = true;
            Time.timeScale = 1f; // 时间恢复
        }
    }

    public void Return()
    {
        menulist.SetActive(false);
        menuKeys = true;
        Time.timeScale = 1f; // 时间恢复
    }

    public void ExitToStart()
    {
        StartCoroutine(LoadScene(0));
    }

    public void Exit()
    {
        Application.Quit();
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
