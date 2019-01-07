using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;

using MySql.Data.MySqlClient;

using Futureinn.DB.Utility;

namespace Frap3Core.BCore
{
    /// <summary>
    /// MySQLDataAccessHelperクラス
    /// </summary>
    ///	<remarks>
    ///	MySQLとの接続をするDataAccessを提供します。
    ///	<para>作成年月日 2019/01/07</para>
    /// <para>作成者 (株)フューチャーイン 田島 大輝</para>
    ///	<para>修正年月日</para>
    ///	<para>修正者</para>
    ///	<para>修正内容</para>
    ///	</remarks>
    public class MySQLDataAccessHelper : AbstractDataAccessHelper
    {
        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        ///	<remarks>
        /// コンストラクタ
        ///	<para>作成年月日 2019/01/07</para>
        /// <para>作成者 (株)フューチャーイン 田島 大輝</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<param name="connectInfo">接続情報オブジェクト</param>
        public MySQLDataAccessHelper(ConnectionInfo connectInfo)
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
        ///	<para>作成年月日 2019/01/07</para>
        /// <para>作成者 (株)フューチャーイン 田島 大輝</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<value>現在のタイムスタンプを取得する関数の文字列</value>
        public override string currentTimestampFunctionString
        {
            get
            {
                return "current_timestamp";
            }
        }

        /// <summary>
        /// 現在の日付/時刻を取得する関数の文字列
        /// </summary>
        ///	<remarks>
        /// 現在の日付/時刻を取得する関数の文字列
        ///	<para>作成年月日 2019/01/07</para>
        /// <para>作成者 (株)フューチャーイン 田島 大輝</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<value>現在のタイムスタンプを取得する関数の文字列</value>
        public override string currentDatetimeFunctionString
        {
            get
            {
                return "current_date";
            }
        }

        #endregion

        #region メソッド

        /// <summary>
        /// コネクションを取得する
        /// </summary>
        ///	<remarks>
        /// コネクションを取得する
        ///	<para>作成年月日 2019/01/07</para>
        /// <para>作成者 (株)フューチャーイン 田島 大輝</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        /// <returns>コネクション</returns>
        public override DbConnection GetConnection()
        {
            DbConnection dbConnection = null;                   // コネクション

            String server = this.connectionInfo.DataSource;     // サーバー
            String database = this.connectionInfo.Database;     // サービス
            String user = this.connectionInfo.UserId;           // ユーザー
            String password = this.connectionInfo.Password;     // パスワード
            int port = this.connectionInfo.Port;                // ポート

            try
            {
                dbConnection = MySqlUtility.GetConnection(user, password, server, database, port.ToString());
            }
            catch (Exception)
            {
                dbConnection = MySqlUtility.GetConnection(user, password, server, database);
            }

            MySqlUtility.OpenConnection((MySqlConnection)dbConnection);

            return dbConnection;
        }

        /// <summary>
        /// コネクションを取得する
        /// </summary>
        ///	<remarks>
        /// コネクションを取得する
        ///	<para>作成年月日 2019/01/07</para>
        /// <para>作成者 (株)フューチャーイン 田島 大輝</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        /// <returns>コネクション</returns>
        public override void CloseConnection(DbConnection connection)
        {
            MySqlUtility.CloseConnection((MySqlConnection)connection);
        }

        /// <summary>
        /// コマンドオブジェクトを作成する
        /// </summary>
        ///	<remarks>
        /// コマンドオブジェクトを作成する
        ///	<para>作成年月日 2019/01/07</para>
        /// <para>作成者 (株)フューチャーイン 田島 大輝</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<param name="sql">SQL</param>
        ///	<param name="con">コネクション</param>
        /// <returns>コマンド</returns>
        public override DbCommand CreateCommand(string sql, DbConnection con)
        {
            MySqlCommand cmd = new MySqlCommand(sql, (MySqlConnection)con);
            cmd.CommandType = CommandType.Text;

            return cmd;
        }

        /// <summary>
        /// コマンドオブジェクトを作成する
        /// </summary>
        ///	<remarks>
        /// コマンドオブジェクトを作成する
        ///	<para>作成年月日 2019/01/07</para>
        /// <para>作成者 (株)フューチャーイン 田島 大輝</para>
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
            MySqlCommand cmd = new MySqlCommand(sql, (MySqlConnection)con);

            if (txn != null)
            {
                cmd.Transaction = (MySqlTransaction)txn;
            }

            cmd.CommandType = System.Data.CommandType.Text;

            return cmd;
        }

        /// <summary>
        /// DBパラメータを作成する
        /// </summary>
        ///	<remarks>
        /// DBパラメータを作成する
        ///	<para>作成年月日 2019/01/07</para>
        /// <para>作成者 (株)フューチャーイン 田島 大輝</para>
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
            return MySqlUtility.CreateParameter(name, (MySqlDbType)this.ConvertDbType(type), direction, value);
        }

        /// <summary>
        /// DBパラメータを作成する
        /// </summary>
        ///	<remarks>
        /// DBパラメータを作成する
        ///	<para>作成年月日 2019/01/07</para>
        /// <para>作成者 (株)フューチャーイン 田島 大輝</para>
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
            return MySqlUtility.CreateParameter(name, (MySqlDbType)this.ConvertDbType(type), direction, size, value);
        }

        /// <summary>
        /// DBパラメータを作成する
        /// </summary>
        ///	<remarks>
        /// DBパラメータを作成する
        ///	<para>作成年月日 2019/01/07</para>
        /// <para>作成者 (株)フューチャーイン 田島 大輝</para>
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
            return MySqlUtility.CreateParameter(name, (MySqlDbType)this.ConvertDbType(type), direction, scale, value);
        }

        /// <summary>
        /// SQLを実行してデータテーブルにデータを読み込む
        /// </summary>
        ///	<remarks>
        /// SQLを実行してデータテーブルにデータを読み込む
        ///	<para>作成年月日 2019/01/07</para>
        /// <para>作成者 (株)フューチャーイン 田島 大輝</para>
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
            MySqlDataAdapter adapter;
            adapter = new MySqlDataAdapter();

            adapter.SelectCommand = (MySqlCommand)dbCommand;
            adapter.TableMappings.Add("Table", tableName);

            return adapter.Fill(dataSet);
        }

        /// <summary>
        /// SQLを実行してデータテーブルにデータを読み込む
        /// </summary>
        ///	<remarks>
        /// SQLを実行してデータテーブルにデータを読み込む
        ///	<para>作成年月日 2019/01/07</para>
        /// <para>作成者 (株)フューチャーイン 田島 大輝</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        /// <param name="dbCommand">コマンド</param>
        /// <param name="dataTable">データテーブル</param>
        /// <returns>件数</returns>
        public override int Fill(DbCommand dbCommand, DataTable dataTable)
        {
            MySqlDataAdapter adapter;
            adapter = new MySqlDataAdapter();

            adapter.SelectCommand = (MySqlCommand)dbCommand;
            adapter.TableMappings.Add("Table", dataTable.TableName);

            return adapter.Fill(dataTable);
        }

        /// <summary>
        /// Frap3のデータ型に対応するDBのデータ型を取得。
        /// </summary>
        ///	<remarks>
        /// Frap3のデータ型に対応するDBのデータ型を取得。
        ///	<para>作成年月日 2019/01/07</para>
        /// <para>作成者 (株)フューチャーイン 田島 大輝</para>
        ///	</remarks>
        ///	<param name="type">Frap3のデータ型</param>
        /// <returns>DBのデータ型を表す値</returns>
        protected override int ConvertDbType(Frap3DBType type)
        {
            MySqlDbType newType;

            switch (type)
            {
                case Frap3DBType.Char:
                    // 固定長文字列型（2000バイト）
                    newType = MySqlDbType.String;
                    break;
                case Frap3DBType.NVarChar:
                    // 文字列型（UNICODE：4000バイトまで）
                    throw new NotSupportedException();
                case Frap3DBType.VarChar:
                    // 文字列型（4000バイトまで）
                    newType = MySqlDbType.VarString;
                    break;
                case Frap3DBType.SmallInt:
                    // 16ビット符号付き整数
                    newType = MySqlDbType.Int16;
                    break;
                case Frap3DBType.Int:
                    // 32ビット符号付き整数型
                    newType = MySqlDbType.Int32;
                    break;
                case Frap3DBType.Float:
                    // 単精度浮動小数型
                    newType = MySqlDbType.Float;
                    break;
                case Frap3DBType.Double:
                    // 倍精度浮動小数型
                    newType = MySqlDbType.Double;
                    break;
                case Frap3DBType.Byte:
                    // １バイト符号なし整数
                    throw new NotSupportedException();
                case Frap3DBType.Raw:
                    // バイナリ型（2000バイトまで）
                    throw new NotSupportedException();
                case Frap3DBType.LongRaw:
                    // バイナリ型（2Gバイトまで）
                    throw new NotSupportedException();
                case Frap3DBType.LongVarChar:
                    // 文字列型（2Gバイトまで）
                    throw new NotSupportedException();
                case Frap3DBType.Decimal:
                    // 数値型
                    newType = MySqlDbType.Decimal;
                    break;
                case Frap3DBType.Bit:
                    // 1ビット型
                    newType = MySqlDbType.Bit;
                    break;
                case Frap3DBType.DateTime:
                    //日付型(TimeStamp)
                    newType = MySqlDbType.DateTime;
                    break;
                case Frap3DBType.BLOB:
                    // バイナリデータを格納
                    newType = MySqlDbType.Blob;
                    break;
                case Frap3DBType.CLOB:
                    // 文字データを格納
                    newType = MySqlDbType.Text;
                    break;
                case Frap3DBType.NCLOB:
                    // 各国語キャラクタ・セットの文字データを格納(Oracle専用)
                    throw new NotSupportedException();
                case Frap3DBType.Date:
                    // 日付型(Date)
                    newType = MySqlDbType.Date;
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
        ///	<para>作成年月日 2019/01/07</para>
        /// <para>作成者 (株)フューチャーイン 田島 大輝</para>
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
            // PostgreSQLパラメータ文字
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
        ///	<para>作成年月日 2019/01/07</para>
        /// <para>作成者 (株)フューチャーイン 田島 大輝</para>
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
        ///	<para>作成年月日 2019/01/07</para>
        /// <para>作成者 (株)フューチャーイン 田島 大輝</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<param name="ex">エクセプション</param>
        ///	<returns>True：一意制約違反、Flase：その他のエラー</returns>
        public override bool CheckInsertError(Exception ex)
        {
            if (ex.GetType() == typeof(MySqlException))
            {
                return ((MySqlException)ex).ErrorCode == 1169;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}
