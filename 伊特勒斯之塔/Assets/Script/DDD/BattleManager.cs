
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BattleManager : MonoBehaviour
{
    public GameObject canvas;
    public GameObject backScence;
    public GameObject backPond;
    public GameObject[] enemy;
    public GameObject Player;
    public float generateTime = -1;
    public int jingdu = 0;
    public int generateNum;
    public int generateBOSS = 0;

    void Start()
    {
        Player = GameObject.Find("Player");
        generateTime = 0;
        generateNum = UnityEngine.Random.Range(10, 15);
        Player.GetComponent<PlayerManager>().equip(WeaponAnswer.a);
        WeaponAnswer.a = -1;
    }

    void zhunchang()
    {
        for(int i = 0; i < gameObject.transform.childCount; i++)
        {
            GameObject child = gameObject.transform.GetChild(i).GameObject();
            if (child.name == "Bullet(Clone)")
                Destroy(child);
        }
        canvas.SetActive(false);
        canvas.SetActive(true);
        if (jingdu == 4)
        {
            SceneManager.LoadScene(4);
        }
        else
        {
            backScence.GetComponent<SpriteRenderer>().sprite = backPond.transform.GetChild(jingdu).GetComponent<SpriteRenderer>().sprite;
            Player.GetComponent<PlayerManager>().equip(-1);
        }
    }
    void generateEnamy()
    {
        if (generateTime >= 0)
            generateTime += Time.deltaTime;
        if (generateTime >= UnityEngine.Random.Range(10, 15) && generateNum > 0)
        {
            for (int i = 1; i < UnityEngine.Random.Range(3, 5); i++)
            {
                GameObject enemys = GameObject.Instantiate(enemy[jingdu], gameObject.transform);
                enemys.transform.localPosition = new Vector3(UnityEngine.Random.Range(-475, 475), UnityEngine.Random.Range(-225, 225));
                generateNum--;
            }
            generateTime = 0;
        }
        if (jingdu == 3 && generateNum <= 0 && generateBOSS == 3)
        {
            generateBOSS = 4;
            GameObject enemys = GameObject.Instantiate(enemy[4], gameObject.transform);
            enemys.transform.localPosition = new Vector3(UnityEngine.Random.Range(-475, 475), UnityEngine.Random.Range(-225, 225));
        }

    }
    void success()
    {
        GameObject enemySY = GameObject.FindWithTag("Enemy");
        if (enemySY == null && generateNum <= 0 && generateBOSS != 3)
        {
            generateBOSS++;
            jingdu++;
            zhunchang();
            Player.transform.localPosition = new Vector3(0, 0, 0);
            generateNum = UnityEngine.Random.Range(10, 15);
            generateTime = 0;
        }

    }
    void Update()
    {
        generateEnamy();
        success();
    }
}
