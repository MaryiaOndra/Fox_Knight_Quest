using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AppPrefs
{
    public static void SetBool(string _key, bool _value) 
    {
        PlayerPrefs.SetInt(_key, _value ? 1 : 0);
    }
    public static bool GetBool(string _key) 
    {
        return PlayerPrefs.GetInt(_key) == 1;
    }

    public static void SetInt(string _key, int _value) 
    {
        PlayerPrefs.SetInt(_key, _value);
    }
    public static int GetInt(string _key) 
    {
        return PlayerPrefs.GetInt(_key);
    }

    public static void SetFloat(string _key, float _value) 
    {
        PlayerPrefs.SetFloat(_key, _value);
    }
    public static float GetFloat(string _key) 
    {
        return PlayerPrefs.GetFloat(_key);
    }

    public static void SetString(string _key, string _value) 
    {
        PlayerPrefs.SetString(_key, _value);
    }
    public static string GetString(string _key) 
    {
        return PlayerPrefs.GetString(_key);
    }

    public static void DeleteAll() 
    {
        PlayerPrefs.DeleteAll();
    }

    public static void DeleteKey(string _key) 
    {
        PlayerPrefs.DeleteKey(_key);
    }

    public static void Save() 
    {
        PlayerPrefs.Save();
    }
}
