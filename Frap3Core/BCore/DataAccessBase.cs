using System.Data;
using System.Data.Common;

namespace Frap3Core.BCore
{
    /// <summary>
    /// データアクセスの基本クラス
    /// </summary>
    ///	<remarks>
    /// データアクセスの基本クラス
    ///	<para>作成年月日 2009/3/1</para>
    /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
    ///	<para>修正年月日</para>
    ///	<para>修正者</para>
    ///	<para>修正内容</para>
    ///	</remarks>
    public class DataAccessBase
    {
        #region メンバ変数

        /// <summary>
        /// コネクション
        /// </summary>
        private DbConnection _con;
        
        /// <summary>
        /// トランザクション
        /// </summary>
        private DbTransaction _txn;
        
        /// <summary>
        /// AbstractDataAccessHelper
        /// </summary>
        private AbstractDataAccessHelper _helper;

        #endregion

        #region プロパティ

        /// <summary>
        /// コネクション
        /// </summary>
        ///	<remarks>
        /// コネクションを取得
        ///	<para>作成年月日 2009/3/1</para>
        /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        /// <value>コネクション</value>
        protected DbConnection Con
        {
            get
            {
                return this._con;
            }
        }

        /// <summary>
        /// トランザクション
        /// </summary>
        ///	<remarks>
        /// トランザクションを取得
        ///	<para>作成年月日 2009/3/1</para>
        /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        /// <value>トランザクション</value>
        protected DbTransaction Txn
        {
            get
            {
                return this._txn;
            }
        }

        /// <summary>
        /// AbstractDataAccessHelper
        /// </summary>
        ///	<remarks>
        /// AbstractDataAccessHelperを取得
        ///	<para>作成年月日 2009/3/1</para>
        /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        /// <value>AbstractDataAccessHelper</value>
        protected AbstractDataAccessHelper Helper
        {
            get
            {
                return this._helper;
            }
        }

        #endregion

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        ///	<remarks>
        /// コンストラクタ
        ///	<para>作成年月日 2009/3/1</para>
        /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        /// <param name="con">コネクション</param>
        /// <param name="helper">AbstractDataAccessHelper</param>
        public DataAccessBase(DbConnection con, AbstractDataAccessHelper helper)
        {
            // メンバ変数にセット
            this._con = con;
            this._helper = helper;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        ///	<remarks>
        /// コンストラクタ
        ///	<para>作成年月日 2009/3/1</para>
        /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        /// <param name="con">コネクション</param>
        /// <param name="txn">トランザクション</param>
        /// <param name="helper">AbstractDataAccessHelper</param>
        public DataAccessBase(DbConnection con, DbTransaction txn, AbstractDataAccessHelper helper)
        {
            // メンバ変数にセット
            this._con = con;
            this._txn = txn;
            this._helper = helper;
        }

        #endregion

        #region メソッド

        /// <summary>
        /// SQLを実行してデータを取得
        /// </summary>
        ///	<remarks>
        /// SQLを実行してデータを取得
        ///	<para>作成年月日 2009/3/1</para>
        /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        /// <param name="sql">SQL</param>
        /// <returns>SQLを実行して取得したデータ</returns>
        public DataSet GetData(string sql)
        {
            DataSet ds = new DataSet();         // 戻り値用データセット
            DataTable dt = new DataTable();     // 実行結果を格納するデータテーブル

            bool isConnect = false;             // この処理ないでDBに接続したかどうか
            DbDataReader reader = null;         // リーダー
            string tmpColName = string.Empty;   // カラム名一時格納用

            try
            {
                // DBに未接続の場合は接続
                isConnect = this.CreateConnection();

                // コマンドを作成
                DbCommand cmd = this.CreateGetDataCommand(sql);

                // コマンドを実行してリーダーを取得
                reader = this.Helper.ExecuteReader(cmd);

                // リーダーからカラム名を取得して、データテーブルにカラムを追加
                for (int i = 0; i < reader.FieldCount - 1; i++)
                {
                    tmpColName = reader.GetName(i);

                    if (tmpColName != string.Empty)
                    {
                        DataColumn col = new DataColumn(tmpColName, reader.GetFieldType(i));
                        dt.Columns.Add(col);
                    }
                    
                }

                // リーダーからデータを読んで、データテーブルに行を追加
                while (reader.Read())
                {
                    DataRow dr;
                    dr = dt.NewRow();

                    for (int i = 0; i < reader.FieldCount - 1; i++)
                    {
                        tmpColName = reader.GetName(i);

                        if (tmpColName != string.Empty)
                        {
                            dr[tmpColName] = reader[i];
                        }
                    }

                    dt.Rows.Add(dr);
                }

                // データテーブルをデータセットに追加
                ds.Tables.Add(dt);

                // 大文字小文字を区別するように変更
                ds.CaseSensitive = true;

            }
            finally
            {
                // 後処理
                if (reader != null)
                {
                    if (reader.IsClosed == false)
                    {
                        reader.Close();
                    }
                }

                // この処理内でDBに接続した場合
                if (isConnect)
                {
                    // コネクションを閉じる。
                    this.Helper.CloseConnection(this.Con);
                }
                
            }

            return ds;

        }

        /// <summary>
        /// DBに未接続の場合は、DBに接続する。
        /// </summary>
        ///	<remarks>
        /// DBに未接続の場合は、DBに接続する。
        ///	<para>作成年月日 2009/3/1</para>
        /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        /// <returns>True：接続した、False：接続しなかった</returns>
        protected bool CreateConnection()
        {
            bool isConnect = false;

            // コネクションがない場合
            if (this.Con == null)
            {
                // コネクションを取得
                this._con = this.Helper.GetConnection();

                // 接続したことにする。
                isConnect = true;
            }

            return isConnect;

        }

        /// <summary>
        /// コマンドを作成
        /// </summary>
        ///	<remarks>
        /// コマンドを作成
        ///	<para>作成年月日 2009/3/1</para>
        /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        /// <param name="sql">SQL</param>
        /// <returns>コマンド</returns>
        private DbCommand CreateGetDataCommand(string sql)
        {
            DbCommand cmd;

            cmd = this.Helper.CreateCommand(sql, this.Con);

            if (this.Txn != null)
            {
                cmd.Transaction = this.Txn;
            }

            return cmd;
        }

        #endregion

    }
}
