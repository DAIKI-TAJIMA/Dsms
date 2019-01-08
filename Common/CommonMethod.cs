using System;

namespace Dsms.Common
{
    public class CommonMethod
    {
        #region なんでも文字列に変換する。

        ///	<summary>
        ///	なんでも文字列に変換する。
        ///	</summary>
        ///	<remarks>
        ///	なんでも文字列に変換する。変換できない場合は、空文字になる。
        ///	<para>作成年月日 2010/04/09</para>
        ///	<para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<param name="value">デコードする値</param>
        public static string ToString(object value)
        {
            if (value == null)
            {
                return string.Empty;
            }

            string result = string.Empty;

            try
            {
                result = value.ToString();
            }
            catch
            {
                result = string.Empty;
            }

            return result;
        }

        #endregion
    }
}
