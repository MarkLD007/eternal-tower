using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class SceneLoader : MonoBehaviour
{
    public Button btA;
    public Button btB;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {

        btA.onClick.AddListener(LoadSceneA);
        btB.onClick.AddListener(loadSceenB);
    }

    private void LoadSceneA()
    {
        StartCoroutine(LoadScene(1));
    }

    private void loadSceenB()
    {
        StartCoroutine(LoadScene(2));
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
