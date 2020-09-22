using System;
using System.Collections.Generic;
using System.Text;

namespace Utils
{
    /// <summary>
    /// ������
    /// </summary>
    public class Tools
    {
        /// <summary>
        /// ����ֵ
        /// </summary>
        /// <param name="content"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string FindValue(string content, string key)
        {
            string sRet = string.Empty;
            int startKeyIndex = content.IndexOf(key);
            if (startKeyIndex < 0)
                return string.Empty;
            int endTabIndex = content.IndexOf("\t", startKeyIndex);
            if (startKeyIndex >= 0 && endTabIndex > 0)
            {
                sRet = content.Substring(startKeyIndex, content.IndexOf('\t', startKeyIndex) - startKeyIndex).Split('=')[1];
            }
            else if (startKeyIndex > 0 && endTabIndex < 0)
            {
                sRet = content.Substring(startKeyIndex);
                sRet = sRet.Substring(key.Length + 1);
            }
            return sRet;
        }
        /// <summary>
        /// ����ַ���
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public static string UnionString(List<string> keys)
        {
            StringBuilder strKey = new StringBuilder();
            foreach (string key in keys)
            {
                strKey.Append(string.Format("'{0}',", key));
            }
            string unionKey = strKey.ToString();
            if (!string.IsNullOrEmpty(unionKey))
            {
                unionKey = unionKey.Substring(0, unionKey.Length - 1);
            }
            return unionKey;
        }
        /// <summary>Get the current time
        /// </summary>
        /// <returns></returns>
        public static DateTime GetDateTimeNow()
        {
            return DateTime.Now;
        }
        /// <summary>
        /// ��ȡ��ǰʱ���ַ���
        /// </summary>
        /// <returns></returns>
        public static string GetDateTimeNowString()
        {
            return GetDateTimeNow().ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>String Convert to Int32
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static int TryConvertToInt32(string str, int defaultVal = 0)
        {
            try
            {
                return Convert.ToInt32(str);
            }
            catch
            {
                return defaultVal;
            }
        }

        /// <summary>String Convert to Int32
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static int TryConvertToInt32(object str, int defaultVal = 0)
        {
            try
            {
                return Convert.ToInt32(str);
            }
            catch
            {
                return defaultVal;
            }
        }

        /// <summary>
        /// ��ʼ��model������
        /// </summary>
        /// <param name="model"></param>
        /// <param name="data"></param>
        public static void InitModel(object model, string data)
        {
            if (model != null)
            {
                Type objInfo = model.GetType();
                System.Reflection.PropertyInfo[] pinfos = objInfo.GetProperties();
                if (pinfos != null && pinfos.Length > 0)
                {
                    string[] infos = data.Split(",\t".ToCharArray());
                    if (infos != null && infos.Length > 0)
                    {
                        for (int i = 0; i < infos.Length; i++)
                        {
                            string[] columndata = infos[i].Split('=');
                            if (columndata != null && columndata.Length == 2 && !string.IsNullOrEmpty(columndata[1]))
                            {
                                columndata[0] = columndata[0].Replace("~", "");
                                foreach (System.Reflection.PropertyInfo pi in pinfos)
                                {
                                    if (pi.Name.ToLower() == columndata[0].ToLower())
                                    {
                                        try
                                        {
                                            string pvalue = columndata[1];
                                            if (string.IsNullOrWhiteSpace(pvalue) || pvalue.Trim().ToLower() == "null".ToLower())
                                                pvalue = string.Empty;
                                            SetKValue(model, pvalue, pi);
                                        }
                                        catch
                                        { }
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// ������������
        /// </summary>
        /// <param name="info"></param>
        /// <param name="pvalue"></param>
        /// <param name="pi"></param>
        public static void SetKValue(object info, string pvalue, System.Reflection.PropertyInfo pi)
        {
            if (pi.PropertyType == typeof(System.Int32))
            {
                try
                {
                    int kvalue = int.Parse(pvalue);
                    pi.SetValue(info, kvalue, null);
                }
                catch
                { }
            }
            else if (pi.PropertyType == typeof(System.String))
            {
                pi.SetValue(info, pvalue, null);
            }
            else if (pi.PropertyType == typeof(System.DateTime))
            {
                try
                {
                    DateTime dt = DateTime.Parse(pvalue);
                    pi.SetValue(info, dt, null);
                }
                catch
                { }
            }
        }

        /// <summary>
        /// �ַ��������ִ�Сд�滻,���滻��һ��
        /// </summary>
        /// <param name="str">�ַ���</param>
        /// <param name="oldStr">��Ҫ�滻����</param>
        /// <param name="newStr">�滻����</param>
        /// <param name="stringComparison">���ִ�Сд����</param>
        /// <returns></returns>
        public static string Replace(string str, string oldStr, string newStr, StringComparison stringComparison = StringComparison.OrdinalIgnoreCase)
        {
            int idx = str.IndexOf(oldStr, stringComparison);
            if (idx <= -1)
                return str;

            StringBuilder sb = new StringBuilder();
            sb.Append(str.Substring(0, idx));
            sb.Append(newStr);
            sb.Append(str.Substring(idx + oldStr.Length));

            return sb.ToString();
        }

        /// <summary>
        /// ���ַ�����ȡֵ
        /// </summary>
        /// <param name="str">�ַ���</param>
        /// <param name="cSplit">ֵ�����</param>
        /// <param name="cSplitKV">��ֵ�����</param>
        /// <param name="keyToLower">���Ƿ�ת��ΪСд</param>
        /// <returns></returns>
        public static Dictionary<string, string> GetKeyValues(string str, char cSplit = '\t', char cSplitKV = '=', bool keyToLower = true)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            if (string.IsNullOrEmpty(str))
                return dic;

            string[] arr = str.Split(cSplit);
            foreach (string kv in arr)
            {
                int idx = kv.IndexOf(cSplitKV);
                if (idx <= 0)
                    continue;

                string key = kv.Substring(0, idx).Trim();
                if (keyToLower)
                    key = key.ToLower();

                if (string.IsNullOrEmpty(key) || dic.ContainsKey(key))
                    continue;

                dic.Add(key, kv.Substring(idx + 1));
            }

            return dic;
        }
        /// <summary>
        /// ���ֵ���ȡֵ
        /// </summary>
        /// <param name="dic">�ֵ�</param>
        /// <param name="key">��</param>
        /// <param name="defaultVal">Ĭ��ֵ</param>
        /// <param name="keyToLower">��ת��ΪСд</param>
        /// <returns></returns>
        public static string GetValueFromDic(Dictionary<string, string> dic, string key, string defaultVal = "", bool keyToLower = true)
        {
            if (string.IsNullOrEmpty(key))
                return defaultVal;

            if (keyToLower)
                key = key.Trim().ToLower();

            if (dic.ContainsKey(key))
                return dic[key];

            return defaultVal;
        }

    }
}
