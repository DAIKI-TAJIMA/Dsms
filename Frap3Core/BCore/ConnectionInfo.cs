using System;

namespace Frap3Core.BCore
{
    ///	<summary>
    ///	データベース接続情報
    ///	</summary>
    ///	<remarks>
    ///	データベースへ接続するために必要な情報を保持するクラス
    ///	<para>作成年月日 2010/02/02</para>
    /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
    ///	<para>修正年月日</para>
    ///	<para>修正者</para>
    ///	<para>修正内容</para>
    ///	</remarks>
    [Serializable]
    public class ConnectionInfo
    {
        #region メンバ変数

        /// <summary>
        /// 接続情報を識別するためのID
        /// </summary>
        private string _id;

        /// <summary>
        /// デフォルトの接続情報かどうか
        /// </summary>
        private bool _isDefault;

        /// <summary>
        /// ログインに使用する接続情報かどうか
        /// </summary>
        private bool _useLogin;

        /// <summary>
        /// DBMS
        /// </summary>
        private DBMS _dbms;

        /// <summary>
        /// データソース
        /// </summary>
        private string _dataSource;

        /// <summary>
        /// ユーザーID
        /// </summary>
        private string _userId;

        /// <summary>
        /// パスワード
        /// </summary>
        private string _password;

        /// <summary>
        /// 接続するDB名
        /// </summary>
        private string _database;

        /// <summary>
        /// Windows認証を使用するかどうか
        /// </summary>
        private bool _integratedSecurity;

        /// <summary>
        /// プロトコル
        /// </summary>
        private string _protocl;

        /// <summary>
        /// ポート番号
        /// </summary>
        private int _port;

        #endregion

        #region プロパティ

        /// <summary>
        /// 接続情報を識別するためのIDの取得、設定
        /// </summary>
        ///	<remarks>
        ///	接続情報を識別するためのIDを取得、設定します。
        ///	<para>作成年月日 2010/02/02</para>
        /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<value>接続情報を識別するためのID</value>
        public string Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        /// <summary>
        /// デフォルトの接続情報かどうかの取得、設定
        /// </summary>
        ///	<remarks>
        ///	デフォルトの接続情報かどうかを取得、設定します。
        ///	<para>作成年月日 2010/02/02</para>
        /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<value>デフォルトの接続情報かどうか</value>
        public bool IsDefault
        {
            get
            {
                return this._isDefault;
            }
            set
            {
                this._isDefault = value;
            }
        }

        /// <summary>
        /// ログインに使用する接続情報かどうかの取得、設定
        /// </summary>
        ///	<remarks>
        ///	ログインに使用する接続情報かどうかを取得、設定します。
        ///	<para>作成年月日 2010/03/31</para>
        /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<value>ログインに使用する接続情報かどうか</value>
        public bool useLogin
        {
            get
            {
                return this._useLogin;
            }
            set
            {
                this._useLogin = value;
            }
        }

        /// <summary>
        /// DBMSの取得、設定
        /// </summary>
        ///	<remarks>
        ///	DBMSを取得、設定します。
        ///	<para>作成年月日 2010/02/02</para>
        /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<value>DBMS</value>
        public DBMS DBMS
        {
            get
            {
                return this._dbms;
            }
            set
            {
                this._dbms = value;
            }
        }

        /// <summary>
        /// データソースの取得、設定
        /// </summary>
        ///	<remarks>
        ///	データソースを取得、設定します。
        ///	<para>作成年月日 2010/02/02</para>
        /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<value>データソース</value>
        public string DataSource
        {
            get
            {
                return this._dataSource;
            }
            set
            {
                this._dataSource = value;
            }
        }

        /// <summary>
        /// ユーザーIDの取得、設定
        /// </summary>
        ///	<remarks>
        ///	ユーザーIDを取得、設定します。
        ///	<para>作成年月日 2010/02/02</para>
        /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<value>ユーザーID</value>
        public string UserId
        {
            get
            {
                return this._userId;
            }
            set
            {
                this._userId = value;
            }
        }

        /// <summary>
        /// パスワードの取得、設定
        /// </summary>
        ///	<remarks>
        ///	パスワードを取得、設定します。
        ///	<para>作成年月日 2010/02/02</para>
        /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<value>パスワード</value>
        public string Password
        {
            get
            {
                return this._password;
            }
            set
            {
                this._password = value;
            }
        }

        /// <summary>
        /// 接続するDB名の取得、設定
        /// </summary>
        ///	<remarks>
        ///	接続するDB名を取得、設定します。
        ///	<para>作成年月日 2010/02/02</para>
        /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<value>接続するDB名</value>
        public string Database
        {
            get
            {
                return this._database;
            }
            set
            {
                this._database = value;
            }
        }

        /// <summary>
        /// Windows認証を使用するかどうかの取得、設定
        /// </summary>
        ///	<remarks>
        ///	Windows認証を使用するかどうかを取得、設定します。
        ///	<para>作成年月日 2010/02/02</para>
        /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<value>Windows認証を使用するかどうか</value>
        public bool IntegratedSecurity
        {
            get
            {
                return this._integratedSecurity;
            }
            set
            {
                this._integratedSecurity = value;
            }
        }

        /// <summary>
        /// プロトコルの取得、設定
        /// </summary>
        ///	<remarks>
        ///	プロトコルを取得、設定します。
        ///	<para>作成年月日 2010/02/02</para>
        /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<value>プロトコル</value>
        public string Protocol
        {
            get
            {
                return this._protocl;
            }
            set
            {
                this._protocl = value;
            }
        }

        /// <summary>
        /// ポート番号の取得、設定
        /// </summary>
        ///	<remarks>
        ///	ポート番号を取得、設定します。
        ///	<para>作成年月日 2010/02/02</para>
        /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<value>ポート番号</value>
        public int Port
        {
            get
            {
                return this._port;
            }
            set
            {
                this._port = value;
            }
        }
        
        #endregion

        #region コンストラクタ

        /// <summary>
        /// データベース接続情報オブジェクトの作成
        /// </summary>
        ///	<remarks>
        ///	データベース接続情報オブジェクトを作成します。
        ///	<para>作成年月日 2010/02/02</para>
        /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        public ConnectionInfo()
        {

        }

        #endregion
    }
}
