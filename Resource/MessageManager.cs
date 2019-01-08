using System.Reflection;

namespace Dsms.Resource
{
    public class MessageManager
    {
        #region メソッド

        /// <summary>
        /// リソースからメッセージを取得
        /// </summary>
        ///	<remarks>
        /// リソースからメッセージを取得
        ///	<para>作成年月日 2018/05/08</para>
        /// <para>作成者 (株)フューチャーイン 林　隆一</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        /// <param name="key">メッセージコード</param>
        /// <returns>メッセージ</returns>
        public static string GetMessage(string key)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            return Frap3.ResourceTaro.MessageManager.GetMessage(ref asm, "Dsms.Resource.Message", key);

        }

        /// <summary>
        /// Messageからメッセージを取得する。
        /// </summary>
        ///	<remarks>
        /// Messageからメッセージを取得する。
        ///	<para>作成年月日 2018/05/08</para>
        /// <para>作成者 (株)フューチャーイン 林　隆一</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        /// <param name="key">メッセージコード</param>
        /// <param name="msgParams">メッセージのパラメータ</param>
        /// <returns>メッセージ</returns>
        public static string GetMessage(string key, string[] msgParams)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            return Frap3.ResourceTaro.MessageManager.GetMessage(ref asm, "Dsms.Resource.Message", key, msgParams);
        }

        #endregion
    }
}
