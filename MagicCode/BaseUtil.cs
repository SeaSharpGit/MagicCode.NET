using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MagicCode
{
    public static class BaseUtil
    {
        /// <summary>
        /// 单词变成单数形式
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static string ToSingular(this string word)
        {
            var plural1 = new Regex("(?<keep>[^aeiou])ies$");
            var plural2 = new Regex("(?<keep>[aeiou]y)s$");
            var plural3 = new Regex("(?<keep>[sxzh])es$");
            var plural4 = new Regex("(?<keep>[^sxzhyu])s$");

            return plural1.IsMatch(word) ? plural1.Replace(word, "${keep}y")
                : plural2.IsMatch(word) ? plural2.Replace(word, "${keep}")
                : plural3.IsMatch(word) ? plural3.Replace(word, "${keep}")
                : plural4.IsMatch(word) ? plural4.Replace(word, "${keep}")
                : word;
        }

        /// <summary>
        /// 单词变成复数形式
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static string ToPlural(this string word)
        {
            var plural1 = new Regex("(?<keep>[^aeiou])y$");
            var plural2 = new Regex("(?<keep>[aeiou]y)$");
            var plural3 = new Regex("(?<keep>[sxzh])$");
            var plural4 = new Regex("(?<keep>[^sxzhy])$");

            return plural1.IsMatch(word) ? plural1.Replace(word, "${keep}ies")
                : plural2.IsMatch(word) ? plural2.Replace(word, "${keep}s")
                : plural3.IsMatch(word) ? plural3.Replace(word, "${keep}es")
                : plural4.IsMatch(word) ? plural4.Replace(word, "${keep}s")
                : word;
        }

        #region 字符串
        //public static string ToJson(this object obj)
        //{
        //    return JsonConvert.SerializeObject(obj);
        //}

        //public static T ToJsonObject<T>(this string json)
        //{
        //    return JsonConvert.DeserializeObject<T>(json);
        //}

        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        public static bool IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        public static char ToUpper(this char c)
        {
            return char.ToUpper(c);
        }

        public static char ToLower(this char c)
        {
            return char.ToLower(c);
        }

        public static string ToUpperFirst(this string str)
        {
            if (str == null || str.Length == 0)
            {
                return "";
            }

            if (str.Length == 1)
            {
                return str.ToUpper();
            }

            return str[0].ToUpper().ToString() + str.Substring(1);
        }

        public static string ToLowerFirst(this string str)
        {
            if (str == null || str.Length == 0)
            {
                return "";
            }

            if (str.Length == 1)
            {
                return str.ToLower();
            }

            return str[0].ToLower().ToString() + str.Substring(1);
        }
        #endregion

        #region XML序列化
        /// <summary>
        /// XML反序列化为实体类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static T XmlToObject<T>(this string fileName)
        {
            Object obj = null;
            var xs = new XmlSerializer(typeof(T));
            using (var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                obj = xs.Deserialize(stream);
            }
            return (T)obj;
        }

        /// <summary>
        /// 实体类序列化为XML
        /// </summary>
        /// <param name="xobj"></param>
        /// <param name="filename"></param>
        public static void ObjectToXml(this object xobj, string filename)
        {
            int index = filename.LastIndexOf('\\');
            if (index > 0)
            {
                string path = filename.Substring(0, index);
                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path);
                }
            }
            XmlSerializer xs = new XmlSerializer(xobj.GetType());
            using (var stream = System.IO.File.Open(filename, FileMode.Create, FileAccess.Write))
            {
                xs.Serialize(stream, xobj);
            }
        } 
        #endregion

    }
}
