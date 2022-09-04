using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    [SerializeField] ParticleSystem particle;
    [SerializeField] Image ImgFade;
    bool ending;
    bool realEnd;

    void Start()
    {
        StartCoroutine("StartScene");
        realEnd = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Moon")
        {
            if (realEnd) return;
            StartCoroutine("ChangeEndingScene");
        }
    }

    IEnumerator ChangeEndingScene()
    {
        realEnd = true;

        particle.Play();

        yield return new WaitForSeconds(3f);
        
        GameManager.Instance.isGameClear = true;

        float fadeValue = 0;

        while (fadeValue <= 1)
        {
            ImgFade.color = new Color(0, 0, 0, fadeValue);
            fadeValue += 0.01f;
            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(0);
        // �� ����
    }

    IEnumerator StartScene()
    {
        float fadeValue = 1;

        while (fadeValue > 0)
        {
            ImgFade.color = new Color(0, 0, 0, fadeValue);
            fadeValue -= 0.01f;
            yield return new WaitForSeconds(0.01f);
        }

        TTS.Instance.TTSPlay($"{GameManager.Instance.playerName}�� �ȳ��ϼ���. ���α׷��� ������ �ּż� ����� ����帳�ϴ�. �� ���α׷������� �� �������� ���� �̾߱⸦ �Ϸ��� �մϴ�.");
    }
}
