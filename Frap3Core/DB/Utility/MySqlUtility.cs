using System;
using System.Data;
using System.Text;

using MySql.Data.MySqlClient;

namespace Futureinn.DB.Utility
{
    ///	<summary>
    ///	MySQL関連のユーティリティクラス
    ///	</summary>
    ///	<remarks>
    ///	MySQLに関する各種機能を提供します。
    ///	<para>作成年月日 2019/01/07</para>
    /// <para>作成者 (株)フューチャーイン 田島 大輝</para>
    ///	<para>修正年月日</para>
    ///	<para>修正者</para>
    ///	<para>修正内容</para>
    ///	</remarks>
    public class MySqlUtility
    {
        #region コンストラクタ

        ///	<summary>
        ///	コンストラクタ
        ///	</summary>
        ///	<remarks>
        ///	コンストラクタ
        ///	<para>作成年月日 2019/01/07</para>
        /// <para>作成者 (株)フューチャーイン 田島 大輝</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        private MySqlUtility()
        {
        }

        #endregion

        #region メソッド

        #region MySqlConnection取得

        ///	<summary>
        ///	MySqlConnection取得
        ///	<br/>
        ///	(ユーザーID、パスワード、ホスト、データベース名指定)
        ///	</summary>
        ///	<remarks>
        ///	MySqlConnectionを取得します。
        ///	<br/>
        ///	(ユーザーID、パスワード、ホスト、データベース名指定)
        ///	<para>作成年月日 2019/01/07</para>
        /// <para>作成者 (株)フューチャーイン 田島 大輝</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<param name="userId">ユーザーID</param>
        ///	<param name="password">パスワード</param>
        ///	<param name="host">ホスト</param>
        ///	<param name="database">データベース名</param>
        ///	<returns>MySqlConnection</returns>
        public static MySqlConnection GetConnection(string userId, string password, string host, string database)
        {
            //	MySqlConnection生成
            MySqlConnection connection = new MySqlConnection(CreateConnectionString(userId, password, host, database));

            //	戻り値セット
            return connection;
        }

        ///	<summary>
        ///	MySqlConnection取得
        ///	<br/>
        ///	(ユーザーID、パスワード、ホスト、データベース名、ポート指定)
        ///	</summary>
        ///	<remarks>
        ///	MySqlConnectionを取得します。
        ///	<br/>
        ///	(ユーザーID、パスワード、ホスト、データベース名、ポート指定)
        ///	<para>作成年月日 2019/01/07</para>
        /// <para>作成者 (株)フューチャーイン 田島 大輝</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<param name="userId">ユーザーID</param>
        ///	<param name="password">パスワード</param>
        ///	<param name="host">ホスト</param>
        ///	<param name="database">データベース名</param>
        ///	<param name="port">ポート</param>
        ///	<returns>MySqlConnection</returns>
        public static MySqlConnection GetConnection(string userId, string password, string host, string database, string port)
        {
            //	MySqlConnection生成
            MySqlConnection connection = new MySqlConnection(CreateConnectionString(userId, password, host, database, port));

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
        ///	<para>作成年月日 2019/01/07</para>
        /// <para>作成者 (株)フューチャーイン 田島 大輝</para>
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
            return CreateConnectionString(userId, password, host, database, "3306");
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
        ///	<para>作成年月日 2019/01/07</para>
        /// <para>作成者 (株)フューチャーイン 田島 大輝</para>
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
            connectionString.Append(string.Format(" Uid={0}; ", userId));
            connectionString.Append(string.Format(" Pwd={0}; ", password));
            connectionString.Append(string.Format(" Database={0}; ", database));
            connectionString.Append(string.Format(" Charset={0}; ", "utf8"));

            //	戻り値設定
            return connectionString.ToString();
        }

        #endregion

        #region MySqlConnectionオープン

        ///	<summary>
        ///	MySqlConnectionオープン
        ///	</summary>
        ///	<remarks>
        ///	指定されたMySqlConnectionをオープンします。
        ///	<para>作成年月日 2019/01/07</para>
        /// <para>作成者 (株)フューチャーイン 田島 大輝</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<param name="connection">オープンするMySqlConnection</param>
        public static void OpenConnection(MySqlConnection connection)
        {
            //	MySqlConnectionの状態が閉じている場合
            if (connection != null && connection.State == ConnectionState.Closed)
            {
                //	MySqlConnectionオープン
                connection.Open();
            }
        }

        #endregion

        #region MySqlConnectionクローズ

        ///	<summary>
        ///	MySqlConnectionをクローズ
        ///	</summary>
        ///	<remarks>
        ///	指定されたMySqlConnectionをクローズします。
        ///	<para>作成年月日 2019/01/07</para>
        /// <para>作成者 (株)フューチャーイン 田島 大輝</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<param name="connection">クローズするMySqlConnection</param>
        public static void CloseConnection(MySqlConnection connection)
        {
            //	MySqlConnectionがオープンしている場合
            if (connection != null && connection.State == ConnectionState.Open)
            {
                //	MySqlConnectionクローズ
                connection.Close();
            }
        }

        #endregion

        #region MySqlParameter作成

        ///	<summary>
        ///	MySqlParameter作成
        ///	<br/>
        ///	(パラメータ名、パラメータデータ型、パラメータ入出力方向指定)
        ///	</summary>
        ///	<remarks>
        ///	MySqlParameterを作成します。
        ///	<br/>
        ///	(パラメータ名、パラメータデータ型、パラメータ入出力方向指定)
        ///	<br/>
        ///	Valueの初期値は、DBNull.Valueに設定します。
        ///	<para>作成年月日 2019/01/07</para>
        /// <para>作成者 (株)フューチャーイン 田島 大輝</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<param name="parameterName">パラメータ名前</param>
        ///	<param name="dbType">パラメータデータ型</param>
        ///	<param name="direction">パラメータ入出力方向</param>
        ///	<returns>MySqlParameter</returns>
        private static MySqlParameter CreateParameter(string parameterName, MySqlDbType dbType, ParameterDirection direction)
        {
            //	MySqlParameter
            MySqlParameter parameter = new MySqlParameter();

            //	MySqlParameterプロパティ設定
            parameter.ParameterName = parameterName;	//	パラメータ名

            parameter.MySqlDbType = dbType;			    //	データ型	
            parameter.Direction = direction;			//	入出力方法

            parameter.Value = DBNull.Value;			    //	値

            //	戻り値設定
            return parameter;
        }

        ///	<summary>
        ///	MySqlParameter作成
        ///	<br/>
        ///	(パラメータ名、パラメータデータ型、パラメータ入出力方向、パラメータ桁数、パラメータ値指定)
        ///	</summary>
        ///	<remarks>
        ///	MySqlParameterを作成します。
        ///	<br/>
        ///	(パラメータ名、パラメータデータ型、パラメータ入出力方向、パラメータ桁数、パラメータ値指定)
        ///	<br/>
        ///	parameterValueの値がnull、空文字列の場合はValueをDBNull.Valueに設定します。
        ///	<para>作成年月日 2019/01/07</para>
        /// <para>作成者 (株)フューチャーイン 田島 大輝</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<param name="parameterName">パラメータ名前</param>
        ///	<param name="dbType">パラメータデータ型</param>
        ///	<param name="direction">パラメータ入出力方向</param>
        ///	<param name="size">パラメータ桁数</param>
        ///	<param name="parameterValue">パラメータ値</param>
        ///	<returns>MySqlParameter</returns>
        public static MySqlParameter CreateParameter(string parameterName, MySqlDbType dbType, ParameterDirection direction, int size, object parameterValue)
        {
            //	MySqlParameter
            MySqlParameter parameter = CreateParameter(parameterName, dbType, direction);

            //	MySqlParameterプロパティ設定
            parameter.Size = size;		    //	サイズ

            //	パラメータ値の設定
            MySqlUtility.SetParameterValue(parameter, dbType, parameterValue);

            //	戻り値設定
            return parameter;
        }

        ///	<summary>
        ///	MySqlParameter作成
        ///	<br/>
        ///	(パラメータ名、パラメータデータ型、パラメータ入出力方向、パラメータ値指定)
        ///	</summary>
        ///	<remarks>
        ///	MySqlParameterを作成します。parameterValueの値がnull、空文字列の場合はValueをDBNull.Valueに設定します。
        ///	<br/>
        ///	(パラメータ名、パラメータデータ型、パラメータ入出力方向、パラメータ値指定)
        ///	<br/>
        ///	parameterValueの値がnull、空文字列の場合はValueをDBNull.Valueに設定します。
        ///	<para>作成年月日 2019/01/07</para>
        /// <para>作成者 (株)フューチャーイン 田島 大輝</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<param name="parameterName">パラメータ名前</param>
        ///	<param name="dbType">パラメータデータ型</param>
        ///	<param name="direction">パラメータ入出力方向</param>
        ///	<param name="parameterValue">パラメータ値</param>
        ///	<returns>MySqlParameter</returns>
        public static MySqlParameter CreateParameter(string parameterName, MySqlDbType dbType, ParameterDirection direction, object parameterValue)
        {
            //	MySqlParameter
            MySqlParameter parameter = CreateParameter(parameterName, dbType, direction);

            //	パラメータ値の設定
            MySqlUtility.SetParameterValue(parameter, dbType, parameterValue);

            //	戻り値設定
            return parameter;
        }

        ///	<summary>
        ///	MySqlParameterを作成
        ///	<br/>
        ///	(パラメータ名、パラメータデータ型、パラメータ入出力方向、パラメータ有効桁数、パラメータ少数桁数、パラメータ値指定)
        ///	</summary>
        ///	<remarks>
        ///	MySqlParameterを作成します。
        ///	<br/>
        ///	(パラメータ名、パラメータデータ型、パラメータ入出力方向、パラメータ有効桁数、パラメータ少数桁数、パラメータ値指定)
        ///	<br/>
        ///	parameterValueの値がnull、空文字列の場合はValueをDBNull.Valueに設定します。
        ///	<para>作成年月日 2019/01/07</para>
        /// <para>作成者 (株)フューチャーイン 田島 大輝</para>
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
        ///	<returns>MySqlParameter</returns>
        public static MySqlParameter CreateParameter(string parameterName, MySqlDbType dbType, ParameterDirection direction, byte precision, byte scale, object parameterValue)
        {
            //	MySqlParameter
            MySqlParameter parameter = CreateParameter(parameterName, dbType, direction);

            //	NpgsqlParameterプロパティ設定

            parameter.Precision = precision;	//	有効桁数
            parameter.Scale = scale;			//	少数桁数

            //	パラメータ値の設定
            MySqlUtility.SetParameterValue(parameter, dbType, parameterValue);

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
        ///	<para>作成年月日 2019/01/07</para>
        /// <para>作成者 (株)フューチャーイン 田島 大輝</para>
        /// <para>修正年月日</para>
        /// <para>修正者</para>
        /// <para>修正内容</para>
        /// </remarks>
        ///	<param name="parameter">パラメータオブジェクト</param>
        ///	<param name="dbType">パラメータデータ型</param>
        ///	<param name="parameterValue">パラメータ値</param>
        private static void SetParameterValue(MySqlParameter parameter, MySqlDbType dbType, object parameterValue)
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
