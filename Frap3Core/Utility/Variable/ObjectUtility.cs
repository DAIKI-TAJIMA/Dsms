using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.ComponentModel;

namespace Futureinn.Utility.Variable
{
    ///	<summary>
    ///	オブジェクトに関するユーティリティ。
    ///	</summary>
    ///	<remarks>
    ///	オブジェクトに関するユーティリティ。
    ///	<para>作成年月日 2018/04/02</para>
    ///	<para>作成者 (株)フューチャーイン 林隆一</para>
    ///	<para>修正年月日</para>
    ///	<para>修正者</para>
    ///	<para>修正内容</para>
    ///	</remarks>
    public class ObjectUtility
    {

        #region メソッド

        #region "DeepCopyProperties"

        /// <summary>
        /// DeepCopyProperties
        /// </summary>
        ///	<remarks>
        ///	DeepCopyProperties
        ///	<para>作成年月日 2018/04/02</para>
        ///	<para>作成者 (株)フューチャーイン 林隆一</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        /// <typeparam name="T"></typeparam>
        /// <param name="src"></param>
        /// <returns></returns>
        public static T DeepCopyProperties<T>(object src)
        {
            T result;

            // Properties Copy
            T dest = (T)Activator.CreateInstance<T>();
            var srcProperties = src.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p => p.CanRead && p.CanWrite);
            var destProperties = dest.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p => p.CanRead && p.CanWrite);
            var properties = srcProperties.Join(destProperties, p => new { p.Name, p.PropertyType }, p => new { p.Name, p.PropertyType }, (p1, p2) => new { p1, p2 });

            foreach(var property in properties)
            {
                property.p2.SetValue(dest, property.p1.GetValue(src));
            }

            // DeepCopy

            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();

            try
            {
                bf.Serialize(ms, dest);
                ms.Position = 0;
                result = (T)bf.Deserialize(ms);

            }
            finally
            {
                ms.Close();
            }

            return result;

        }

        #endregion

        /// <summary>
        /// GetEnumDescription
        /// </summary>
        ///	<remarks>
        ///	 GetEnumDescription
        ///	<para>作成年月日 2018/05/17</para>
        ///	<para>作成者 (株)フューチャーイン 林隆一</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        /// <typeparam name="obj">object</typeparam>
        /// <returns>string</returns>
        public static string GetEnumDescription(object obj)
        {
            var mem = obj.GetType().GetMember(obj.ToString());
            var attribute = mem[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            var description = ((DescriptionAttribute)attribute[0]).Description;
            return description;
        }



        #endregion

    }
}
