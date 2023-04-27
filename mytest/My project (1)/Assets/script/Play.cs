using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{
    public List<GameObject> ballType;
    public float ceiling;
    public float flySpeed = 1;
    public float createSpeed = 1;
    public Vector2 randomAreaCenter = Vector2.zero;
    public Vector2 randomAreaLengh = Vector2.one;

    private float timer = 0;
    private List<GameObject> ballList;

    private void Start()
    {
        ballList = new List<GameObject>();
    }


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 1.0f / createSpeed)
        {
            int index = Random.Range(0, 21);
            GameObject _ball = GameObject.Instantiate(ballType[index], new Vector3(Random.Range(randomAreaCenter.x - randomAreaLengh.x, randomAreaCenter.x + randomAreaLengh.x),
                Random.Range(randomAreaCenter.y - randomAreaLengh.y, randomAreaCenter.y + randomAreaLengh.y), 0), Quaternion.identity, transform);
            _ball.GetComponent<Rigidbody2D>().gravityScale = 0; // �������ı�������Ϊ0
            _ball.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => Blow(_ball)); // ��̬���Ӱ�ť����¼������������Ǹ���������
            ballList.Add(_ball);
            timer = 0;
        }

        List<GameObject> destroy = new List<GameObject>();
        foreach(GameObject _ball in ballList)
        {
            if (_ball.transform.position.y < ceiling)
                _ball.transform.Translate(flySpeed * Time.deltaTime * Vector3.up);
            else
                destroy.Add(_ball);
        }
        foreach (GameObject _ball in destroy)
        {
            if (_ball.GetComponent<UnityEngine.UI.Image>().enabled)
                Blow(_ball);
        }
    }

    public void Blow(GameObject _ball)
    {
        ballList.Remove(_ball);
        GameObject.Destroy(_ball, 21);
        //��ը ���� ����
        _ball.GetComponent<AudioSource>().Play();
        _ball.GetComponent<UnityEngine.UI.Image>().enabled = false;
    }
    void Awake()
{
    Screen.sleepTimeout = SleepTimeout.NeverSleep; //禁止熄屏
}

void OnApplicationPause(bool pause)
{
    if (!pause)
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep; //禁止熄屏
    }
}

void OnApplicationFocus(bool focus)
{
    if (focus)
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep; //禁止熄屏
    }
}

}
