using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using Npgsql;
using NpgsqlTypes;

namespace Futureinn.DB.Utility
{
    ///	<summary>
    ///	Oracle関連のユーティリティクラス
    ///	</summary>
    ///	<remarks>
    ///	Oracleに関する各種機能を提供します。
    ///	<para>作成年月日 2009/06/03</para>
    /// <para>作成者 (株)フューチャーイン 伊藤 篤史</para>
    ///	<para>修正年月日</para>
    ///	<para>修正者</para>
    ///	<para>修正内容</para>
    ///	</remarks>
    public class PostgreSQLUtility
    {
        #region コンストラクタ

        ///	<summary>
        ///	コンストラクタ
        ///	</summary>
        ///	<remarks>
        ///	コンストラクタ
        ///	<para>作成年月日 2015/02/05</para>
        /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        private PostgreSQLUtility()
        {
        }

        #endregion

        #region メソッド

        #region OracleConnection取得

        ///	<summary>
        ///	NpgsqlConnection取得
        ///	<br/>
        ///	(ユーザーID、パスワード、ホスト、データベース名指定)
        ///	</summary>
        ///	<remarks>
        ///	NpgsqlConnectionを取得します。
        ///	<br/>
        ///	(ユーザーID、パスワード、ホスト、データベース名指定)
        ///	<para>作成年月日 2015/02/05</para>
        /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<param name="userId">ユーザーID</param>
        ///	<param name="password">パスワード</param>
        ///	<param name="host">ホスト</param>
        ///	<param name="database">データベース名</param>
        ///	<returns>NpgsqlConnection</returns>
        public static NpgsqlConnection GetConnection(string userId, string password, string host, string database)
        {
            //	OracleConnection生成
            NpgsqlConnection connection = new NpgsqlConnection(CreateConnectionString(userId, password, host, database));

            //	戻り値セット
            return connection;
        }

        ///	<summary>
        ///	NpgsqlConnection取得
        ///	<br/>
        ///	(ユーザーID、パスワード、ホスト、データベース名、ポート指定)
        ///	</summary>
        ///	<remarks>
        ///	NpgsqlConnectionを取得します。
        ///	<br/>
        ///	(ユーザーID、パスワード、ホスト、データベース名、ポート指定)
        ///	<para>作成年月日 2015/02/05</para>
        /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<param name="userId">ユーザーID</param>
        ///	<param name="password">パスワード</param>
        ///	<param name="host">ホスト</param>
        ///	<param name="database">データベース名</param>
        ///	<param name="port">ポート</param>
        ///	<returns>NpgsqlConnection</returns>
        public static NpgsqlConnection GetConnection(string userId, string password, string host, string database, string port)
        {
            //	OracleConnection生成
            NpgsqlConnection connection = new NpgsqlConnection(CreateConnectionString(userId, password, host, database, port));

            //	戻り値セット
            return connection;
        }

        #endregion

        #region データベースへの接続文字列

        /// <summary>
        /// データベースへの接続文字列
        ///	<br/>
        ///	(ユーザーID、パスワード、ホスト、データベース名指定)
        /// </summary>
        /// <remarks>
        /// データベース接続文字列を作成します。
        ///	<br/>
        ///	(ユーザーID、パスワード、ホスト、データベース名指定)
        ///	<para>作成年月日 2015/02/05</para>
        /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        /// <para>修正年月日</para>
        /// <para>修正者</para>
        /// <para>修正内容</para>
        ///	</remarks>
        ///	<param name="userId">ユーザーID</param>
        ///	<param name="password">パスワード</param>
        ///	<param name="host">ホスト</param>
        ///	<param name="database">データベース名</param>
        ///	<returns>データベースへの接続文字列</returns>
        public static string CreateConnectionString(string userId, string password, string host, string database)
        {
            //	戻り値設定
            return CreateConnectionString(userId, password, host, database, "5432");
        }

        /// <summary>
        /// データベースへの接続文字列
        ///	<br/>
        ///	(ユーザーID、パスワード、ホスト、データベース名、ポート指定)
        /// </summary>
        /// <remarks>
        /// データベース接続文字列を作成します。
        ///	<br/>
        ///	(ユーザーID、パスワード、ホスト、データベース名、ポート指定)
        ///	<para>作成年月日 2015/02/05</para>
        /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        /// <para>修正年月日</para>
        /// <para>修正者</para>
        /// <para>修正内容</para>
        ///	</remarks>
        ///	<param name="userId">ユーザーID</param>
        ///	<param name="password">パスワード</param>
        ///	<param name="host">ホスト</param>
        ///	<param name="database">データベース名</param>
        ///	<param name="port">ポート</param>
        ///	<returns>データベースへの接続文字列</returns>
        public static string CreateConnectionString(string userId, string password, string host, string database, string port)
        {
            //	接続文字列の生成
            StringBuilder connectionString = new StringBuilder();

            connectionString.Append(string.Format(" Server={0}; ", host));
            connectionString.Append(string.Format(" Port={0}; ", port));
            connectionString.Append(string.Format(" User ID={0}; ", userId));
            connectionString.Append(string.Format(" Password={0}; ", password));
            connectionString.Append(string.Format(" Database={0}; ", database));

            //	戻り値設定
            return connectionString.ToString();
        }

        #endregion

        #region NpgsqlConnectionオープン

        ///	<summary>
        ///	NpgsqlConnectionオープン
        ///	</summary>
        ///	<remarks>
        ///	指定されたNpgsqlConnectionをオープンします。
        ///	<para>作成年月日 2015/02/05</para>
        /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<param name="connection">オープンするNpgsqlConnection</param>
        public static void OpenConnection(NpgsqlConnection connection)
        {
            //	NpgsqlConnectionの状態が閉じている場合
            if (connection != null && connection.State == ConnectionState.Closed)
            {
                //	NpgsqlConnectionオープン
                connection.Open();
            }
        }

        #endregion

        #region NpgsqlConnectionクローズ

        ///	<summary>
        ///	NpgsqlConnectionをクローズ
        ///	</summary>
        ///	<remarks>
        ///	指定されたNpgsqlConnectionをクローズします。
        ///	<para>作成年月日 2015/02/05</para>
        /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<param name="connection">クローズするNpgsqlConnection</param>
        public static void CloseConnection(NpgsqlConnection connection)
        {
            //	OracleConnectionがオープンしている場合
            if (connection != null && connection.State == ConnectionState.Open)
            {
                //	OracleConnectionクローズ
                connection.Close();
            }
        }

        #endregion

        #region NpgsqlParameter作成

        ///	<summary>
        ///	NpgsqlParameter作成
        ///	<br/>
        ///	(パラメータ名、パラメータデータ型、パラメータ入出力方向指定)
        ///	</summary>
        ///	<remarks>
        ///	OracleParameterを作成します。
        ///	<br/>
        ///	(パラメータ名、パラメータデータ型、パラメータ入出力方向指定)
        ///	<br/>
        ///	Valueの初期値は、DBNull.Valueに設定します。
        ///	<para>作成年月日 2015/02/05</para>
        /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<param name="parameterName">パラメータ名前</param>
        ///	<param name="dbType">パラメータデータ型</param>
        ///	<param name="direction">パラメータ入出力方向</param>
        ///	<returns>OracleParameter</returns>
        private static NpgsqlParameter CreateParameter(string parameterName, NpgsqlDbType dbType, ParameterDirection direction)
        {
            //	NpgsqlParameter
            NpgsqlParameter parameter = new NpgsqlParameter();

            //	NpgsqlParameterプロパティ設定
            parameter.ParameterName = parameterName;	//	パラメータ名

            parameter.NpgsqlDbType = dbType;			    //	データ型	
            parameter.Direction = direction;			//	入出力方法

            parameter.Value = DBNull.Value;			    //	値

            //	戻り値設定
            return parameter;
        }

        ///	<summary>
        ///	NpgsqlParameter作成
        ///	<br/>
        ///	(パラメータ名、パラメータデータ型、パラメータ入出力方向、パラメータ桁数、パラメータ値指定)
        ///	</summary>
        ///	<remarks>
        ///	NpgsqlParameterを作成します。
        ///	<br/>
        ///	(パラメータ名、パラメータデータ型、パラメータ入出力方向、パラメータ桁数、パラメータ値指定)
        ///	<br/>
        ///	parameterValueの値がnull、空文字列の場合はValueをDBNull.Valueに設定します。
        ///	<para>作成年月日 2015/02/05</para>
        /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<param name="parameterName">パラメータ名前</param>
        ///	<param name="dbType">パラメータデータ型</param>
        ///	<param name="direction">パラメータ入出力方向</param>
        ///	<param name="size">パラメータ桁数</param>
        ///	<param name="parameterValue">パラメータ値</param>
        ///	<returns>NpgsqlParameter</returns>
        public static NpgsqlParameter CreateParameter(string parameterName, NpgsqlDbType dbType, ParameterDirection direction, int size, object parameterValue)
        {
            //	NpgsqlParameter
            NpgsqlParameter parameter = CreateParameter(parameterName, dbType, direction);

            //	NpgsqlParameterプロパティ設定
            parameter.Size = size;		    //	サイズ

            //	パラメータ値の設定
            PostgreSQLUtility.SetParameterValue(parameter, dbType, parameterValue);

            //	戻り値設定
            return parameter;
        }

        ///	<summary>
        ///	NpgsqlParameter作成
        ///	<br/>
        ///	(パラメータ名、パラメータデータ型、パラメータ入出力方向、パラメータ値指定)
        ///	</summary>
        ///	<remarks>
        ///	NpgsqlParameterを作成します。parameterValueの値がnull、空文字列の場合はValueをDBNull.Valueに設定します。
        ///	<br/>
        ///	(パラメータ名、パラメータデータ型、パラメータ入出力方向、パラメータ値指定)
        ///	<br/>
        ///	parameterValueの値がnull、空文字列の場合はValueをDBNull.Valueに設定します。
        ///	<para>作成年月日 2015/02/05</para>
        /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<param name="parameterName">パラメータ名前</param>
        ///	<param name="dbType">パラメータデータ型</param>
        ///	<param name="direction">パラメータ入出力方向</param>
        ///	<param name="parameterValue">パラメータ値</param>
        ///	<returns>NpgsqlParameter</returns>
        public static NpgsqlParameter CreateParameter(string parameterName, NpgsqlDbType dbType, ParameterDirection direction, object parameterValue)
        {
            //	NpgsqlParameter
            NpgsqlParameter parameter = CreateParameter(parameterName, dbType, direction);

            //	パラメータ値の設定
            PostgreSQLUtility.SetParameterValue(parameter, dbType, parameterValue);

            //	戻り値設定
            return parameter;
        }

        ///	<summary>
        ///	NpgsqlParameterを作成
        ///	<br/>
        ///	(パラメータ名、パラメータデータ型、パラメータ入出力方向、パラメータ有効桁数、パラメータ少数桁数、パラメータ値指定)
        ///	</summary>
        ///	<remarks>
        ///	NpgsqlParameterを作成します。
        ///	<br/>
        ///	(パラメータ名、パラメータデータ型、パラメータ入出力方向、パラメータ有効桁数、パラメータ少数桁数、パラメータ値指定)
        ///	<br/>
        ///	parameterValueの値がnull、空文字列の場合はValueをDBNull.Valueに設定します。
        ///	<para>作成年月日 2015/02/05</para>
        /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<param name="parameterName">パラメータ名前</param>
        ///	<param name="dbType">パラメータデータ型</param>
        ///	<param name="direction">パラメータ入出力方向</param>
        ///	<param name="precision">パラメータ有効桁数</param>
        ///	<param name="scale">パラメータ少数桁数</param>
        ///	<param name="parameterValue">パラメータ値</param>
        ///	<returns>NpgsqlParameter</returns>
        public static NpgsqlParameter CreateParameter(string parameterName, NpgsqlDbType dbType, ParameterDirection direction, byte precision, byte scale, object parameterValue)
        {
            //	NpgsqlParameter
            NpgsqlParameter parameter = CreateParameter(parameterName, dbType, direction);

            ////	NpgsqlParameterプロパティ設定

            //parameter.Precision = precision;	//	有効桁数
            //parameter.Scale = scale;			//	少数桁数

            //	パラメータ値の設定
            PostgreSQLUtility.SetParameterValue(parameter, dbType, parameterValue);

            //	戻り値設定
            return parameter;
        }

        #endregion

        #region パラメータ値のセット

        /// <summary>
        /// パラメータ値のセット
        /// </summary>
        /// <remarks>
        /// 指定されたパラメータへ値をセットします。
        ///	<para>作成年月日 2015/02/05</para>
        /// <para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        /// <para>修正年月日</para>
        /// <para>修正者</para>
        /// <para>修正内容</para>
        /// </remarks>
        ///	<param name="parameter">パラメータオブジェクト</param>
        ///	<param name="dbType">パラメータデータ型</param>
        ///	<param name="parameterValue">パラメータ値</param>
        private static void SetParameterValue(NpgsqlParameter parameter, NpgsqlDbType dbType, object parameterValue)
        {
            //	引数でパラメータ値が指定された場合
            if (parameterValue != null && !parameterValue.Equals(""))
            {
                //	引数で指定された値を設定
                parameter.Value = parameterValue;
            }
        }

        #endregion

        #endregion
    }
}
