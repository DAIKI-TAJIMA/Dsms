using System.Reflection;
using System.Resources;

namespace Frap3.ResourceTaro
{
    /// <summary>
    /// リソースからメッセージを取得するクラス
    /// </summary>
    ///	<remarks>
    /// リソースからメッセージを取得するクラス
    ///	<para>作成年月日 2009/3/1</para>
    /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
    ///	<para>修正年月日</para>
    ///	<para>修正者</para>
    ///	<para>修正内容</para>
    ///	</remarks>
    public class MessageManager
    {
        #region メソッド

        /// <summary>
        /// Frap3.ResourceTaroのリソース(Message)からメッセージを取得する。
        /// </summary>
        ///	<remarks>
        /// Frap3.ResourceTaroのリソース(Message)からメッセージを取得する。
        ///	<para>作成年月日 2009/3/1</para>
        /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        /// <param name="key">メッセージコード</param>
        /// <returns>メッセージ</returns>
        public static string GetMessage(string key)
        {
            string[] msgParams = null;
            return MessageManager.GetMessage(key, msgParams);
        }

        /// <summary>
        /// Frap3.ResourceTaroのリソース(Message)からメッセージを取得する。
        /// </summary>
        ///	<remarks>
        /// Frap3.ResourceTaroのリソース(Message)からメッセージを取得する。
        ///	<para>作成年月日 2009/3/1</para>
        /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        /// <param name="key">メッセージコード</param>
        /// <param name="msgParams">メッセージのパラメータ</param>
        /// <returns>メッセージ</returns>
        public static string GetMessage(string key, string[] msgParams)
        {
            //todo:リソースファイル名を定数にする。
            return MessageManager.GetMessage("Frap3.ResourceTaro.Message", key, msgParams);
        }

        /// <summary>
        /// Frap3.ResourceTaroの指定したリソースからメッセージを取得する。
        /// </summary>
        ///	<remarks>
        /// Frap3.ResourceTaroの指定したリソースからメッセージを取得する。
        ///	<para>作成年月日 2009/3/1</para>
        /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        /// <param name="resxName">リソース名</param>
        /// <param name="key">メッセージコード</param>
        /// <returns>メッセージ</returns>
        public static string GetMessage(string resxName, string key)
        {
            string[] msgParams = null;
            return MessageManager.GetMessage(resxName, key, msgParams);
        }

        /// <summary>
        /// Frap3.ResourceTaroの指定したリソースからメッセージを取得する。
        /// </summary>
        ///	<remarks>
        /// Frap3.ResourceTaroの指定したリソースからメッセージを取得する。
        ///	<para>作成年月日 2009/3/1</para>
        /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        /// <param name="resxName">リソース名</param>
        /// <param name="key">メッセージコード</param>
        /// <param name="msgParams">メッセージのパラメータ</param>
        /// <returns>メッセージ</returns>
        public static string GetMessage(string resxName, string key, string[] msgParams)
        {
            Assembly asm = null;
            return MessageManager.GetMessage(ref asm, resxName, key, msgParams);
        }

        /// <summary>
        /// 指定したアセンブリのリソースからメッセージを取得する。
        /// </summary>
        ///	<remarks>
        /// 指定したアセンブリのリソースからメッセージを取得する。
        ///	<para>作成年月日 2009/3/1</para>
        /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        /// <param name="asm">アセンブリ</param>
        /// <param name="resxName">リソース名</param>
        /// <param name="key">メッセージコード</param>
        /// <returns>メッセージ</returns>
        public static string GetMessage(ref Assembly asm, string resxName, string key)
        {
            string[] msgParams = null;
            return MessageManager.GetMessage(ref asm, resxName, key, msgParams);
        }

        /// <summary>
        /// 指定したアセンブリのリソースからメッセージを取得する。
        /// </summary>
        ///	<remarks>
        /// 指定したアセンブリのリソースからメッセージを取得する。
        ///	<para>作成年月日 2009/3/1</para>
        /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        /// <param name="asm">リソースファイルを含むアセンブリ</param>
        /// <param name="resxName">リソース名</param>
        /// <param name="key">メッセージコード</param>
        /// <param name="msgParams">メッセージのパラメータ</param>
        /// <returns>メッセージ</returns>
        public static string GetMessage(ref Assembly asm, string resxName, string key, string[] msgParams)
        {
            ResourceManager rm;     // リソースマネージャ
            string value;           // メッセージ

            // アセンブリがNullの場合
            if (asm == null)
            {
                // 現在実行中のアセンブリを取得
                asm = Assembly.GetExecutingAssembly();
            }

            // リソースマネージャを生成
            rm = new ResourceManager(resxName, asm);

            // リソースからメッセージ文字列を取得
            value = rm.GetString(key);

            if (value == null)
            {
                value = string.Empty;
            }

            // メッセージのパラメータが指定されている場合
            if (msgParams != null)
            {
                // メッセージ内の{N}を変換
                value = string.Format(value, msgParams);
            }

            return value;
        }

        #endregion

    }
}
