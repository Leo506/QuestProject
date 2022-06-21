using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;

public static class StringExtension
{
    /// <summary>
    /// Получение отдельных слов в строке
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static List<string> GetWords(this string str)
    {
        var tmp = str.Split(new char[] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries).ToList();
        for (int i = 0; i < tmp.Count; i++)
            tmp[i] = tmp[i].Trim();

        return tmp;
    }


    /// <summary>
    /// Возводит строку в title case стиль
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string ToTitleCase(this string str)
    {
        TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
        return textInfo.ToTitleCase(str);
    }
}
