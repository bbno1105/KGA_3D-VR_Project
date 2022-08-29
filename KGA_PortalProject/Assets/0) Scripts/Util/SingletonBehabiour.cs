using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// template <typename T> = <T>
// �׷��� �ƹ� Ÿ���̳� T�� �� �� �־ ������ �ξ�� �Ѵ�. (�츮�� �ǵ��� ������Ʈ Ÿ�Ը� �ޱ⸦ ���ϱ� ����)
// <T>�� ������ T�� MonoBegaviour�� ��� �޾ƾ� ��
public class SingletonBehabiour<T> : MonoBehaviour where T : MonoBehaviour
{
    // Unity�� ��� �ޱ� ���� MonoBehaviour�� ����Ѵ�.
    // ������Ʈ�� ���ؼ��� �����ϱ� ������ ���� ���� where ������ �ۼ��Ѵ�.

    private static T instance;
    public static T Instance 
    {  
        get 
        {
            if(instance == null)
            {
                instance = FindObjectOfType<T>();
                DontDestroyOnLoad(instance.gameObject); 
            }

            return instance; 
        }
    }

    virtual protected void Awake()
    {
        if(instance != null)
        {
            if(instance != this)
            {
                Destroy(gameObject);
            }
            return;
        }
        instance = GetComponent<T>();
        DontDestroyOnLoad(gameObject); // ���� ��ȯ�� �� �ı����� �ʾƾ� �Ѵ�.
    }
}

// [Awake���� Initialize�Ǿ�� �ϴ� ����]
// Awake�� ��ũ��Ʈ�� Ȱ��ȭ�Ǿ����� �ʾƵ� ȣ���� �ȴ�.
// OnEnable�� Start�� ��ũ���� Ȱ��ȭ (������Ʈ�� Ȱ��ȭ)�� �� ȣ��ȴ�.
