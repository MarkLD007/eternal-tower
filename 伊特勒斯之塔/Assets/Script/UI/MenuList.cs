using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuList : MonoBehaviour
{
    
    public GameObject menulist;
    public GameObject TeamList;
    public Animator animator;

    [SerializeField] private bool menuKeys = true;
    [SerializeField] private bool TeamKeys = true;

    void Update()
    {
        if (menuKeys)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && TeamKeys)
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

        if (!TeamKeys)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                TeamList.SetActive(false);
                TeamKeys = true;
                Time.timeScale = 1f; // 时间恢复
            }
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
        menulist.SetActive(false);
        menuKeys = true;
        Time.timeScale = 1f; // 时间恢复
        StartCoroutine(LoadScene(0));
    }

    public void Thanks()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Maker()
    {
        if (TeamKeys)
        {
            TeamList.SetActive(true);
            TeamKeys = false;
            Time.timeScale = 0f; //  时间静止
        }
    }

    public void TSettings()
    {
        if (!TeamKeys)
        {
            TeamList.SetActive(false);
            TeamKeys = true;
            Time.timeScale = 1f;
        }
    }

    public void Settings()
    {
        if (menuKeys)
        {
            menulist.SetActive(true);
            menuKeys = false;
            Time.timeScale = 0f; // 时间暂停
        }
        else
        {
            menulist.SetActive(false);
            menuKeys = true;
            Time.timeScale = 1f; // 时间恢复
        }
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
