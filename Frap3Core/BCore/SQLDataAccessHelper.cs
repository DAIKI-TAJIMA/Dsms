using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;

using Futureinn.DB.Utility;

namespace Frap3Core.BCore
{
    /// <summary>
    /// SQLDataAccessHelperクラス
    /// </summary>
    ///	<remarks>
    ///	SQLServerとの接続をするDataAccessを提供します。
    ///	<para>作成年月日 2009/11/12</para>
    /// <para>作成者 (株)フューチャーイン 横井 忠司</para>
    ///	<para>修正年月日</para>
    ///	<para>修正者</para>
    ///	<para>修正内容</para>
    ///	</remarks>
    public class SQLDataAccessHelper : AbstractDataAccessHelper
    {
        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        ///	<remarks>
        /// コンストラクタ
        ///	<para>作成年月日 2009/11/12</para>
        /// <para>作成者 (株)フューチャーイン 横井 忠司</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<param name="connectInfo">接続情報オブジェクト</param>
        public SQLDataAccessHelper(ConnectionInfo connectInfo)
        {
            this.connectionInfo = connectInfo;
        }

        #endregion

        #region プロパティ

        /// <summary>
        /// 現在のタイムスタンプを取得する関数の文字列
        /// </summary>
        ///	<remarks>
        /// 現在のタイムスタンプを取得する関数の文字列
        ///	<para>作成年月日 2012/03/25</para>
        /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<value>現在のタイムスタンプを取得する関数の文字列</value>
        public override string currentTimestampFunctionString
        {
            get
            {
                return "SYSDATETIME()";
            }
        }

        /// <summary>
        /// 現在の日付/時刻を取得する関数の文字列
        /// </summary>
        ///	<remarks>
        /// 現在の日付/時刻を取得する関数の文字列
        ///	<para>作成年月日 2012/03/25</para>
        /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<value>現在のタイムスタンプを取得する関数の文字列</value>
        public override string currentDatetimeFunctionString
        {
            get
            {
                return "GETDATE()";
            }
        }

        #endregion

        #region メソッド

        /// <summary>
        /// コネクションを取得する
        /// </summary>
        ///	<remarks>
        /// コネクションを取得する
        ///	<para>作成年月日 2009/11/12</para>
        /// <para>作成者 (株)フューチャーイン 横井 忠司</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        /// <returns>コネクション</returns>
        public override DbConnection GetConnection()
        {
            //接続情報の有無から、コネクション生成パターンを分岐
            DbConnection dbConnection = null;
            String server = this.connectionInfo.DataSource;
            String database = this.connectionInfo.Database;
            String user = this.connectionInfo.UserId;
            String password = this.connectionInfo.Password;
            if (this.connectionInfo.IntegratedSecurity == false)
            {
                dbConnection = SqlUtility.GetConnection(server,database,user, password);
            }
            else
            {
                dbConnection = SqlUtility.GetConnection(server, database);
            }

            SqlUtility.OpenConnection((SqlConnection)dbConnection);

            return dbConnection;
        }

        /// <summary>
        /// コネクションを取得する
        /// </summary>
        ///	<remarks>
        /// コネクションを取得する
        ///	<para>作成年月日 2009/11/12</para>
        /// <para>作成者 (株)フューチャーイン 横井 忠司</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        /// <returns>コネクション</returns>
        public override void CloseConnection(DbConnection connection)
        {
            SqlUtility.CloseConnection((SqlConnection)connection);
        }

        /// <summary>
        /// コマンドオブジェクトを作成する
        /// </summary>
        ///	<remarks>
        /// コマンドオブジェクトを作成する
        ///	<para>作成年月日 2009/11/12</para>
        /// <para>作成者 (株)フューチャーイン 横井 忠司</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<param name="sql">SQL</param>
        ///	<param name="con">コネクション</param>
        /// <returns>コマンド</returns>
        public override DbCommand CreateCommand(string sql, DbConnection con)
        {
            SqlCommand cmd = new SqlCommand(sql, (SqlConnection)con);
            cmd.CommandType = CommandType.Text;

            return cmd;
        }

        /// <summary>
        /// コマンドオブジェクトを作成する
        /// </summary>
        ///	<remarks>
        /// コマンドオブジェクトを作成する
        ///	<para>作成年月日 2009/11/12</para>
        /// <para>作成者 (株)フューチャーイン 横井 忠司</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<param name="sql">SQL</param>
        ///	<param name="con">コネクション</param>
        ///	<param name="txn">トランザクション</param>
        /// <returns>コマンド</returns>
        public override DbCommand CreateCommand(string sql, DbConnection con, DbTransaction txn)
        {
            SqlCommand cmd = new SqlCommand(sql, (SqlConnection)con, (SqlTransaction)txn);
            cmd.CommandType = CommandType.Text;

            return cmd;
        }

        /// <summary>
        /// DBパラメータを作成する
        /// </summary>
        ///	<remarks>
        /// DBパラメータを作成する
        ///	<para>作成年月日 2009/11/12</para>
        /// <para>作成者 (株)フューチャーイン 横井 忠司</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        /// <param name="name">パラメータ名前</param>
        /// <param name="type">パラメータデータ型</param>
        /// <param name="direction">パラメータ入出力方向</param>
        /// <param name="value">パラメータ値</param>
        /// <returns>DBパラメータ</returns>
        public override DbParameter CreateParameter(String name, Frap3DBType type, ParameterDirection direction, Object value)
        {
            return SqlUtility.CreateParameter(name, (SqlDbType)this.ConvertDbType(type), direction, value);
        }

        /// <summary>
        /// DBパラメータを作成する
        /// </summary>
        ///	<remarks>
        /// DBパラメータを作成する
        ///	<para>作成年月日 2009/11/12</para>
        /// <para>作成者 (株)フューチャーイン 横井 忠司</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        /// <param name="name">パラメータ名前</param>
        /// <param name="type">パラメータデータ型</param>
        /// <param name="direction">パラメータ入出力方向</param>
        /// <param name="size">パラメータ桁数</param>
        /// <param name="value">パラメータ値</param>
        /// <returns>DBパラメータ</returns>
        public override DbParameter CreateParameter(String name, Frap3DBType type, ParameterDirection direction, int size, Object value)
        {
            return SqlUtility.CreateParameter(name, (SqlDbType)this.ConvertDbType(type), direction, size, value);
        }

        /// <summary>
        /// DBパラメータを作成する
        /// </summary>
        ///	<remarks>
        /// DBパラメータを作成する
        ///	<para>作成年月日 2009/11/12</para>
        /// <para>作成者 (株)フューチャーイン 横井 忠司</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        /// <param name="name">パラメータ名前</param>
        /// <param name="type">パラメータデータ型</param>
        /// <param name="direction">パラメータ入出力方向</param>
        /// <param name="precision">パラメータ有効桁数</param>
        /// <param name="scale">パラメータ小数桁数</param>
        /// <param name="value">パラメータ値</param>
        /// <returns>DBパラメータ</returns>
        public override DbParameter CreateParameter(String name, Frap3DBType type, ParameterDirection direction, byte precision, byte scale, Object value)
        {
            return SqlUtility.CreateParameter(name, (SqlDbType)this.ConvertDbType(type), direction, scale, value);
        }

        ///// <summary>
        ///// サーバ日付のパラメータを作成する
        ///// </summary>
        ///// <param name="name">パラメータ名前</param>
        ///// <param name="direction">パラメータ入出力方向</param>
        ///// <returns>DbParameter</returns>
        //public abstract DbParameter CreateDateParameter(String name, ParameterDirection direction)
        //{
        //    DateTime dt = new DateTime();
        //    return SqlUtility.CreateParameter(name, SqlDbType.DateTime, direction, dt);
        //}
        ///// <summary>
        ///// サーバ時間のパラメータを作成する
        ///// </summary>
        ///// <param name="name">パラメータ名前</param>
        ///// <param name="direction">パラメータ入出力方向</param>
        ///// <returns>DbParameter</returns>
        //public DbParameter CreateTimeParameter(String name, ParameterDirection direction)
        //{
        //    DateTime dt = new DateTime();
        //    return SqlUtility.CreateParameter(name, SqlDbType.DateTime, direction, dt);
        //}

        /// <summary>
        /// SQLを実行してデータテーブルにデータを読み込む
        /// </summary>
        ///	<remarks>
        /// SQLを実行してデータテーブルにデータを読み込む
        ///	<para>作成年月日 2009/11/12</para>
        /// <para>作成者 (株)フューチャーイン 横井 忠司</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        /// <param name="dbCommand">コマンド</param>
        /// <param name="dataSet">データセット</param>
        /// <param name="tableName">データテーブル名</param>
        /// <returns>件数</returns>
        public override int Fill(DbCommand dbCommand, DataSet dataSet, string tableName)
        {
            SqlDataAdapter adapter;
            adapter = new SqlDataAdapter();

            adapter.SelectCommand = (SqlCommand) dbCommand;
            adapter.TableMappings.Add("Table", tableName);

            return adapter.Fill(dataSet);

        }

        /// <summary>
        /// SQLを実行してデータテーブルにデータを読み込む
        /// </summary>
        ///	<remarks>
        /// SQLを実行してデータテーブルにデータを読み込む
        ///	<para>作成年月日 2009/11/12</para>
        /// <para>作成者 (株)フューチャーイン 横井 忠司</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        /// <param name="dbCommand">コマンド</param>
        /// <param name="dataTable">データテーブル</param>
        /// <returns>件数</returns>
        public override int Fill(DbCommand dbCommand, DataTable dataTable)
        {

            SqlDataAdapter adapter;
            adapter = new SqlDataAdapter();

            adapter.SelectCommand = (SqlCommand)dbCommand;
            adapter.TableMappings.Add("Table", dataTable.TableName);

            return adapter.Fill(dataTable);

        }

        /// <summary>
        /// Frap3のデータ型に対応するDBのデータ型を取得。
        /// </summary>
        ///	<remarks>
        /// Frap3のデータ型に対応するDBのデータ型を取得。
        ///	<para>作成年月日 2009/11/12</para>
        /// <para>作成者 (株)フューチャーイン 横井 忠司</para>
        ///	<para>修正年月日　2015/01/15</para>
        ///	<para>修正者 (株)フューチャーイン 三厨 朱根</para>
        ///	<para>修正内容 DATEの追加</para>
        ///	</remarks>
        ///	<param name="type">Frap3のデータ型</param>
        /// <returns>DBのデータ型を表す値</returns>
        protected override int ConvertDbType(Frap3DBType type)
        {
            SqlDbType newType;

            switch (type)
            {
                case Frap3DBType.Char:
                    // 固定長文字列型（2000バイト）
                    newType = SqlDbType.Char;
                    break;
                case Frap3DBType.NVarChar:
                    // 文字列型（UNICODE：4000バイトまで）
                    newType = SqlDbType.NVarChar;
                    break;
                case Frap3DBType.VarChar:
                    // 文字列型（4000バイトまで）
                    newType = SqlDbType.VarChar;
                    break;
                case Frap3DBType.SmallInt:
                    // 16ビット符号付き整数
                    newType = SqlDbType.SmallInt;
                    break;
                case Frap3DBType.Int:
                    // 32ビット符号付き整数型
                    newType = SqlDbType.Int;
                    break;
                case Frap3DBType.Float:
                    // 単精度浮動小数型
                    newType = SqlDbType.Real;
                    break;
                case Frap3DBType.Double:
                    // 倍精度浮動小数型
                    newType = SqlDbType.Float;
                    break;
                case Frap3DBType.Byte:
                    // １バイト符号なし整数
                    newType = SqlDbType.TinyInt;
                    break;
                case Frap3DBType.Raw:
                    // バイナリ型（2000バイトまで）
                    newType = SqlDbType.VarBinary;
                    break;
                case Frap3DBType.LongRaw:
                    // バイナリ型（2Gバイトまで）
                    newType = SqlDbType.Image;
                    break;
                case Frap3DBType.LongVarChar:
                    // 文字列型（2Gバイトまで）
                    newType = SqlDbType.Text;
                    break;
                case Frap3DBType.Decimal:
                    // 数値型
                    newType = SqlDbType.Decimal;
                    break;
                case Frap3DBType.Bit:
                    // 1ビット型
                    newType = SqlDbType.Bit;
                    break;
                case Frap3DBType.DateTime:
                    //日付型(DateTime)
                    newType = SqlDbType.DateTime;
                    break;
                case Frap3DBType.Date:
                    //日付型(Date)
                    newType = SqlDbType.Date;
                    break;
                default:
                    throw new NotSupportedException();
            }

            return (int)newType;
        }

        /// <summary>
        /// リスト文字列作成
        /// </summary>
        ///	<remarks>
        /// リスト文字列の作成・返却を行う。
        ///	<para>作成年月日 2014/11/18</para>
        /// <para>作成者 (株)フューチャーイン 平崎 裕紀</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<param name="name">パラメータ基本名</param>
        ///	<param name="cnt">リストカウント</param>
        ///	<returns>結合文字列</returns>
        public override string CreateBindVariablesString(String name, int cnt)
        {
            // 作業用
            List<string> list = new List<string> { };
            // SQLServerパラメータ文字
            string kigo = "@";

            // 「cnt」変数分ループ
            for (int i = 0; i < cnt; i++)
            {
                list.Add(kigo + name + i.ToString());
            }
            // 作成したSQL文字列を返却
            return string.Join(",", list.ToArray());
        }

        /// <summary>
        /// リストパラメータを追加
        /// </summary>
        ///	<remarks>
        /// コマンドにリストパラメータを追加する。
        ///	<para>作成年月日 2014/11/18</para>
        /// <para>作成者 (株)フューチャーイン 平崎 裕紀</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<param name="dbCommand">コマンド</param>
        ///	<param name="name">パラメータ基本名</param>
        ///	<param name="type">Frap3のデータ型</param>
        ///	<param name="values">リスト要素</param>
        public override void AddParameters<T>(ref DbCommand dbCommand, string name, Frap3DBType type, List<T> values)
        {
            // コマンド・対象オブジェクト・パラメータ基本名が存在しない場合、処理を抜ける
            if (dbCommand == null || values == null || values.Count == 0 || string.IsNullOrEmpty(name))
            {
                return;
            }
            // リストのカウント分パラメータ作成
            for (int i = 0; i < values.Count; i++)
            {
                dbCommand.Parameters.Add(CreateParameter(name + i.ToString(), type, ParameterDirection.Input, values[i]));
            }
        }

        /// <summary>
        /// 一意制約エラー判定
        /// </summary>
        ///	<remarks>
        /// 指定したエラー情報が一意制約のエラーか判定する。
        ///	<para>作成年月日 2014/11/18</para>
        /// <para>作成者 (株)フューチャーイン 平崎 裕紀</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<param name="ex">エクセプション</param>
        ///	<returns>True：一意制約違反、Flase：その他のエラー</returns>
        public override bool CheckInsertError(Exception ex)
        {
            if (ex.GetType() == typeof(SqlException))
            {
                return ((SqlException)ex).Number == 2627;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}
