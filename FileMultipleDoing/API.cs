using FileMultipleDoing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

public enum IntSortMode
{
    int_Big2Small,
    int_Small2Big,
}

public static class API
{
    public static int GetInt(this TextBox input)
    {
        try
        {
            int i = int.Parse(input.Text);
            if (i < 0)
                i = 0;
            else if (i > 255)
                i = 255;

            return i;
        }
        catch (Exception e)
        {
            if (e != null)
                Console.WriteLine(e.ToString());
        }
        return 0;
    }

    public static bool GetBool(this float f, ComboBox drop, TextBox input)
    {
        if (f < 0)
            f = 0;
        else if (f > 1)
            f = 1;

        if (drop.SelectedIndex == 0)
            return (f < ((float)(input.GetInt()) / 255f));
        else if (drop.SelectedIndex == 1)
            return (f == ((float)(input.GetInt()) / 255f));
        else if (drop.SelectedIndex == 2)
            return (f > ((float)(input.GetInt()) / 255f));

        return false;
    }

    /// <summary>
    /// 注：返回值是脚标，而不是数组本身
    /// </summary>
    public static string AddUp(this string[] array, string fenGeFu = "")
    {
        string temp = "";
        int length = array.Length;
        for (int i = 0; i < length; ++i)
        {
            temp += array[i] + fenGeFu;
        }
        return temp;
    }

    static int CompareChar(this char c1, char c2)
    {
        if (c1 > c2)
            return 1;
        else if (c1 < c2)
            return -1;
        return 0;
    }


    /// <summary>
    /// 比较字符串
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public static int Compare(string x, string y)
    {
        if (x == null || y == null)
            throw new ArgumentException("Parameters can't be null");
        string fileA = x as string;
        string fileB = y as string;
        char[] arr1 = fileA.ToCharArray();
        char[] arr2 = fileB.ToCharArray();
        int i = 0, j = 0;
        while (i < arr1.Length && j < arr2.Length)
        {
            if (char.IsDigit(arr1[i]) && char.IsDigit(arr2[j]))
            {
                string s1 = "", s2 = "";
                while (i < arr1.Length && char.IsDigit(arr1[i]))
                {
                    s1 += arr1[i];
                    i++;
                }
                while (j < arr2.Length && char.IsDigit(arr2[j]))
                {
                    s2 += arr2[j];
                    j++;
                }
                if (int.Parse(s1) > int.Parse(s2))
                {
                    return 1;
                }
                if (int.Parse(s1) < int.Parse(s2))
                {
                    return -1;
                }
            }
            else
            {
                if (arr1[i] > arr2[j])
                {
                    return 1;
                }
                if (arr1[i] < arr2[j])
                {
                    return -1;
                }
                i++;
                j++;
            }
        }
        if (arr1.Length == arr2.Length)
        {
            return 0;
        }
        else
        {
            return arr1.Length > arr2.Length ? 1 : -1;
        }

    }


    /// <summary>
    /// 按名字排序。注：返回值是数组本身
    /// </summary>
    public static string[] SortByFileName(this string[] array)
    {
        int length = array.Length;
        List<string> strArray = new List<string>();
        for (int i = 0; i < length; ++i)
        {
            strArray.Add(array[i]);
        }

        strArray.Sort((string str1, string str2) =>
        {
            return Compare(str1, str2);
        });

        return strArray.ToArray();
    }


    /// <summary>
    /// 按名字排序。注：返回值是数组本身
    /// </summary>
    public static FileInfo[] SortByFileName(this FileInfo[] fArray)
    {
        int length = fArray.Length;
        List<FileInfo> fStrArray = new List<FileInfo>();
        for (int i = 0; i < length; ++i)
        {
            fStrArray.Add(fArray[i]);
        }

        fStrArray.Sort((FileInfo fName1, FileInfo fName2) =>
        {
            return Compare(fName1.Name, fName2.Name);
        });

        return fStrArray.ToArray();
    }


    /// <summary>
    /// 注：返回值是数组本身
    /// </summary>
    public static string[] SortStr(this string[] array, char sortSeparator = '.')
    {
        int length = array.Length;
        int[] arrayTemp = new int[length];
        int intTemp = 0;
        string toIntStr = "";
        string toIntCompoleteStr = "";
        int toIntStrLength = 0;

        string[] strArray = new string[length];
        string strTemp = "";
        int tryNumber = 0;

        for (int i = 0; i < length; ++i)
        {
            toIntStr = array[i].Split(sortSeparator)[0];
            toIntStrLength = toIntStr.Length;

            for (int ii = 0; ii < toIntStrLength; ++ii)
            {
                if (toIntStr[ii] > '9' || toIntStr[ii] < '0')
                {
                    if (ii != 0)
                        continue;
                    else if (ii == 0 && toIntStr[ii] == '-')
                        toIntCompoleteStr += toIntStr[ii];
                    else
                        continue;
                }
                else
                    toIntCompoleteStr += toIntStr[ii];
            }

            if (toIntCompoleteStr == "")
                toIntCompoleteStr = "0";



            if (int.TryParse(toIntCompoleteStr, out tryNumber))
            {
                intTemp = tryNumber;
            }
            else
            {
                if (toIntCompoleteStr[0] == '-')
                    intTemp = -2147483648;
                else
                    intTemp = 2147483647;
            }


            arrayTemp[i] = intTemp;
            toIntCompoleteStr = "";
        }


        for (int j = 0; j < length; ++j)
        {
            strArray[j] = array[j];
        }

        for (int x = 0; x < length; ++x)
        {
            for (int y = x; y < length; ++y)
            {
                if (arrayTemp[y] < arrayTemp[x])
                {
                    intTemp = arrayTemp[y];
                    arrayTemp[y] = arrayTemp[x];
                    arrayTemp[x] = intTemp;

                    strTemp = strArray[y];
                    strArray[y] = strArray[x];
                    strArray[x] = strTemp;
                }
            }
        }

        return strArray;
    }




    /// <summary>
    /// 转换为简体
    /// </summary>
    public static string ToSimpleChinese(this string str, String2[] list)
    {
        int len = list.Length;
        string strTemp = str;
        for (int i = 0; i < len; ++i)
        {
            strTemp = strTemp.Replace(list[i].str2, list[i].str1);
        }

        return strTemp;
    }

    /// <summary>
    /// 转换为繁体
    /// </summary>
    public static string ToTraditionalChinese(this string str, String2[] list)
    {
        int len = list.Length;
        string strTemp = str;
        for (int i = 0; i < len; ++i)
        {
            strTemp = strTemp.Replace(list[i].str1, list[i].str2);
        }

        return strTemp;
    }

    /// <summary>
    /// 去掉数字
    /// </summary>
    public static string DeleteNumber(this string str, char separator, string fullName)
    {
        if (str == "")
            return str;

        //包括断位符
        if (str.Contains(separator.ToString()))
        {
            string[] strTemp = str.Split(separator);
           
            for (int i = 0; i < strTemp[0].Length; ++i)
            {
                if (strTemp[0][i] >= '0' && strTemp[0][i] <= '9')
                    continue;
                else //首位不是数字
                    return str;
            }

            if (strTemp.Length == 2 && separator == '.')
            {
                string strLog = "除去扩展名就只剩序号，不建议切！" +
                    "没有切除序号。文件名：\n" + fullName;
                FileLog.WriteLog(strLog);
                //MessageBox.Show("除去扩展名就只剩序号，不建议切！" +
                //    "\n没有切除序号。文件名：\n" + str + "\n" + fullName,
                //    "通知", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return str;
            }

            //首位是数字，而且也不是只有序号。
            // Length +1 的逻辑是把 separator 也切掉。
            return str.Remove(0, strTemp[0].Length + 1);
        }
        else //不包括断位符
        {
            for (int i = 0; i < str.Length; ++i)
            {
                if (str[i] >= '0' && str[i] <= '9')
                    continue;
                else
                    return str;
            }

            string strLog = "数字就是文件名，" +
                "再切没了！所以没切。文件名：\n" + fullName;
            FileLog.WriteLog(strLog);

            //MessageBox.Show("数字就是文件名，\n" +
            //    "再切没了！所以没切。文件名：\n" + str + "\n" + fullName, 
            //    "通知", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return str;
        }
    }

    /// <summary>
    /// 加上数字
    /// </summary>
    public static string AddNumber(this string str, int number, char separator)
    {
        string strTemp = number.ToString() + separator.ToString() + str;
        return strTemp;
    }

}



