using System;
using System.Collections.Generic;

namespace Frap3Core.BCore
{
    ///	<summary>
    ///	データベース接続情報コレクション
    ///	</summary>
    ///	<remarks>
    ///	データベース接続情報のコレクションクラス
    ///	<para>作成年月日 2010/02/02</para>
    /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
    ///	<para>修正年月日</para>
    ///	<para>修正者</para>
    ///	<para>修正内容</para>
    ///	</remarks>
    [Serializable]
    public class ConnectionInfoCollection : List<ConnectionInfo>
    {
        #region プロパティ

        /// <summary>
        /// 識別IDを指定してコレクションから接続情報を取得
        /// </summary>
        ///	<remarks>
        ///	識別IDを指定してコレクションから接続情報を取得します。
        ///	<para>作成年月日 2010/02/02</para>
        /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<value>接続情報オブジェクト</value>
        public ConnectionInfo this[string id]
        {
            get
            {
                IdCompare compare;
                compare = new IdCompare(id);
       
                return this.Find(compare.Match);
            }
        }

        /// <summary>
        /// コレクションからデフォルトの接続情報を取得
        /// </summary>
        ///	<remarks>
        ///	コレクションからデフォルトの接続情報を取得します。
        ///	<para>作成年月日 2010/02/02</para>
        /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<value>接続情報オブジェクト</value>
        public ConnectionInfo DefaultConnectionInfo
        {
            get
            {
                return this.Find(ConnectionInfoCollection.IsDefaultConnectionInfo);
            }
        }

        /// <summary>
        /// コレクションからログインに使用する接続情報を取得
        /// </summary>
        ///	<remarks>
        ///	コレクションからログインに使用する接続情報を取得します。
        ///	<para>作成年月日 2010/03/31</para>
        /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<value>接続情報オブジェクトのリスト</value>
        public List<ConnectionInfo> LoginConnectionInfo
        {
            get
            {
                return this.FindAll(ConnectionInfoCollection.useLoginConnectionInfo);
            }
        }

        #endregion

        #region コンストラクタ

        /// <summary>
        /// データベース接続情報コレクションオブジェクトの作成
        /// </summary>
        ///	<remarks>
        ///	データベース接続情報コレクションオブジェクトを作成します。
        ///	<para>作成年月日 2010/02/02</para>
        /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        public ConnectionInfoCollection()
        {

        }

        #endregion

        #region メソッド

        /// <summary>
        /// デフォルトの接続情報かどうか
        /// </summary>
        ///	<remarks>
        ///	引数で指定された接続情報がデフォルトの接続情報かどうかを返却します。
        ///	コレクションのFindメソッドで接続情報のIsDefaultプロパティによる検索を行うためのメソッドです。
        ///	<para>作成年月日 2010/02/02</para>
        /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        /// <param name="item">接続情報オブジェクト</param>
        /// <returns>デフォルトの接続情報かどうか</returns>
        private static bool IsDefaultConnectionInfo(ConnectionInfo item)
        {
            if (item == null)
            {
                return false;
            }

            return item.IsDefault;
        }

        /// <summary>
        /// ログインに使用する接続情報かどうか
        /// </summary>
        ///	<remarks>
        ///	引数で指定された接続情報がログインに使用する接続情報かどうかを返却します。
        ///	コレクションのFindAllメソッドで接続情報のuseLoginプロパティによる検索を行うためのメソッドです。
        ///	<para>作成年月日 2010/03/31</para>
        /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        /// <param name="item">接続情報オブジェクト</param>
        /// <returns>ログインに使用する接続情報かどうか</returns>
        private static bool useLoginConnectionInfo(ConnectionInfo item)
        {
            if (item == null)
            {
                return false;
            }

            return item.useLogin;
        }

        #endregion

        #region プライベートクラス

        ///	<summary>
        ///	コレクションのFindメソッドで接続情報のIDによる検索を行うためのクラス
        ///	</summary>
        ///	<remarks>
        ///	コレクションのFindメソッドで接続情報のIDによる検索を行うためのクラス
        ///	<para>作成年月日 2010/02/02</para>
        /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        private class IdCompare
        {
            /// <summary>
            /// 検索するID
            /// </summary>
            private string _id;

            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="id">検索するID</param>
            public IdCompare(string id)
            {
                this._id = id;
            }

            /// <summary>
            /// 引数で指定された接続情報のIDが、メンバ変数のIDと同じかどうか
            /// </summary>
            /// <param name="item">
            /// 接続情報オブジェクト
            /// </param>
            /// <returns>同じ場合：true、異なる場合：false</returns>
            public bool Match(ConnectionInfo item)
            {
                if (item == null)
                {
                    return false;
                }

                if (item.Id == this._id)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        #endregion
    }
}
