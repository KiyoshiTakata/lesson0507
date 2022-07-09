using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class WeatherController : MonoBehaviour
{
    private static readonly string DEFINITION_TABLE_URL = "http://weather.livedoor.com/forecast/rss/primary_area.xml";
    private static readonly System.Xml.Linq.XName CITY_TITLE_ATTRIBUTE = System.Xml.Linq.XName.Get("title");
    private static readonly System.Xml.Linq.XName CITY_ID_ATTRIBUTE = System.Xml.Linq.XName.Get("id");

    private CityData[] m_cities = null;

    private void Start()
    {
        StartCoroutine(Initialize());
    }

    #region Initialize

    private IEnumerator Initialize()
    {
        CityData[] cities = null;
        {
            System.Action<CityData[]> onFinished = (i_cities) =>
               {
                   cities = i_cities;
               };
            yield return GetCityTableProcess(onFinished);
        }

        if(cities==null||cities.Length==0)
        {
            Debug.LogErrorFormat("�s�s������Ă���񂩂�����B�t�H�[�}�b�g�ł��ς�����̂��Ȃ��B");
            yield break;
        }

        m_cities = cities;
    }

    private IEnumerator GetCityTableProcess(System.Action<CityData[]>i_onFinished)
    {
        if(i_onFinished==null)
        {
            Debug.LogErrorFormat("�R�[���o�b�O���w�肳��ĂȂ����B���ꂶ�ጋ�ʂ��킩��Ȃ����B");
            yield break;
        }

        string xmIText = null;
        {
            System.Action<string> onFinished = (i_text) =>
               {
                   xmIText = i_text;
               };
            yield return CallWebRequest(DEFINITION_TABLE_URL, onFinished);
        }

        if(string.IsNullOrEmpty(xmIText))
        {
            Debug.LogFormat("1���ו����`�\�̎擾�Ɏ��s���I");
            i_onFinished(null);
            yield break;
        }

        Debug.LogFormat("1���ו����`�\(XML):\n{0}", xmIText);
        CityData[] cities = ParseCityList(xmIText);

        i_onFinished(cities);
    }

    private object CallWebRequest(string dEFINITION_TABLE_URL, Action<string> onFinished)
    {
        throw new NotImplementedException();
    }

    private CityData[]ParseCityList(string i_xmIText)
    {
        var cities = new List<CityData>();

        try
        {
            System.Xml.Linq.XDocument xml = System.Xml.Linq.XDocument.Parse(i_xmIText);
            System.Xml.Linq.XElement root = xml.Root;

            // city�^�O�ɓs�s��񂪂���͂����I
            // �t�H�[�}�b�g���ς������A���̕��@���ᖳ���ɂȂ邩������Ȃ��ˁB
            var cityElements = root.Descendants("city");
            if(cityElements!=null)
            {
                foreach(var element in cityElements)
                {
                    var titleAttribute = element.Attribute(CITY_TITLE_ATTRIBUTE);
                    var idAttribute = element.Attribute(CITY_ID_ATTRIBUTE);
                    if(titleAttribute==null||idAttribute==null)
                    {
                        continue;
                    }

                    cities.Add(new CityData(idAttribute.Value, titleAttribute.Value));
                }
            }
        }
        catch(System.Exception i_exception)
        {
            Debug.LogErrorFormat("���[�ށA����XML���͓ǂݍ��߂Ȃ������炵���B�G���[�̏ڍׂ�Y�t���Ă�����B{0}", i_exception);
        }

        return cities.ToArray();
    }

    #endregion // Initialize

}// class WeatherContoroller
