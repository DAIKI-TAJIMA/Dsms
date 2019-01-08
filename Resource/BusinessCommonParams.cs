using System;
using System.Collections.Generic;
using System.Text;

namespace Dsms.Resource
{
    /// <summary>
    /// ページからビジネスへ受け渡す共通パラメータクラス
    /// </summary>
    ///	<remarks>
    /// ページからビジネスへ受け渡す共通パラメータクラス
    ///	<para>作成年月日 2010/04/09</para>
    ///	<para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
    ///	<para>修正年月日</para>
    ///	<para>修正者</para>
    ///	<para>修正内容</para>
    ///	</remarks>
    public class BusinessCommonParams
    {
        #region プロパティ

        /// <summary>
        /// セッションID
        /// </summary>
        ///	<remarks>
        /// セッションIDを取得、設定
        ///	<para>作成年月日 2010/04/09</para>
        ///	<para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<value>セッションID</value>
        public string SessionId { get; set; }

        /// <summary>
        /// ユーザコード
        /// </summary>
        ///	<remarks>
        /// ユーザコードを取得、設定
        ///	<para>作成年月日 2010/04/09</para>
        ///	<para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<value>ユーザコード</value>
        public string UserCd { get; set; }

        /// <summary>
        /// 自治体コード
        /// </summary>
        ///	<remarks>
        /// 自治体コードを取得、設定
        ///	<para>作成年月日 2010/04/09</para>
        ///	<para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<value>自治体コード</value>
        public string JichitaiCd { get; set; }

        /// <summary>
        /// 権限
        /// </summary>
        ///	<remarks>
        /// 権限を取得、設定
        ///	<para>作成年月日 2010/08/24</para>
        ///	<para>作成者 (株)フューチャーイン 村上 正和</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<value>権限</value>
        public Enums.Code_ユーザ権限 Kengen { get; set; }

        #endregion

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        ///	<remarks>
        /// コンストラクタ
        ///	<para>作成年月日 2010/04/09</para>
        ///	<para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        public BusinessCommonParams()
        {
        }

        #endregion
    }
}
