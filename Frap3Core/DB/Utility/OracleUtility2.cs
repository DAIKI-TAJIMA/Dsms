using System;
using System.Collections.Generic;
using System.Data;
//using Oracle.DataAccess.Client;
using Oracle.ManagedDataAccess.Client;
using System.IO;
using System.Linq;
using System.Text;

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
    public class OracleUtility2
    {
        #region コンストラクタ

        ///	<summary>
        ///	コンストラクタ
        ///	</summary>
        ///	<remarks>
        ///	コンストラクタ
        ///	<para>作成年月日 2009/06/03</para>
        /// <para>作成者 (株)フューチャーイン 伊藤 篤史</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        private OracleUtility2()
        {
        }

        #endregion

        #region メソッド

        #region OracleConnection取得


        ///	<summary>
        ///	OracleConnection取得
        ///	<br/>
        ///	(ユーザーID、パスワード、ホスト指定)
        ///	</summary>
        ///	<remarks>
        ///	OracleConnectionを取得します。
        ///	<br/>
        ///	(ユーザーID、パスワード、ホスト指定)
        ///	<para>作成年月日 2009/06/03</para>
        /// <para>作成者 (株)フューチャーイン 伊藤 篤史</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<param name="userId">ユーザーID</param>
        ///	<param name="password">パスワード</param>
        ///	<param name="host">ホスト</param>
        ///	<returns>OracleConnection</returns>
        public static OracleConnection GetConnection(string userId, string password, string host)
        {
            //	OracleConnection生成
            OracleConnection connection = new OracleConnection(CreateConnectionString(userId, password, host));

            //	戻り値セット
            return connection;
        }

        ///	<summary>
        ///	OracleConnection取得
        ///	<br/>
        ///	(ユーザーID、パスワード、ホスト、サービス名指定)
        ///	</summary>
        ///	<remarks>
        ///	OracleConnectionを取得します。
        ///	<br/>
        ///	(ユーザーID、パスワード、ホスト、サービス名指定)
        ///	<para>作成年月日 2009/06/03</para>
        /// <para>作成者 (株)フューチャーイン 伊藤 篤史</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<param name="userId">ユーザーID</param>
        ///	<param name="password">パスワード</param>
        ///	<param name="host">ホスト</param>
        ///	<param name="serviceName">サービス名</param>
        ///	<returns>OracleConnection</returns>
        public static OracleConnection GetConnection(string userId, string password, string host, string serviceName)
        {
            //	OracleConnection生成
            OracleConnection connection = new OracleConnection(CreateConnectionString(userId, password, host, serviceName));

            //	戻り値セット
            return connection;
        }

        ///	<summary>
        ///	OracleConnection取得
        ///	<br/>
        ///	(ユーザーID、パスワード、ホスト、サービス名、プロトコル、ポート指定)
        ///	</summary>
        ///	<remarks>
        ///	OracleConnectionを取得します。
        ///	<br/>
        ///	(ユーザーID、パスワード、ホスト、サービス名、プロトコル、ポート指定)
        ///	<para>作成年月日 2009/06/03</para>
        /// <para>作成者 (株)フューチャーイン 伊藤 篤史</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<param name="userId">ユーザーID</param>
        ///	<param name="password">パスワード</param>
        ///	<param name="host">ホスト</param>
        ///	<param name="serviceName">サービス名</param>
        ///	<param name="protocol">プロトコル</param>
        ///	<param name="port">ポート</param>
        ///	<returns>OracleConnection</returns>
        public static OracleConnection GetConnection(string userId, string password, string host, string serviceName, string protocol, string port)
        {
            //	OracleConnection生成
            OracleConnection connection = new OracleConnection(CreateConnectionString(userId, password, host, serviceName, protocol, port));

            //	戻り値セット
            return connection;
        }

        #endregion

        #region データベースへの接続文字列

        /// <summary>
        /// データベースへの接続文字列
        ///	<br/>
        ///	(ユーザーID、パスワード、ホスト指定)
        /// </summary>
        /// <remarks>
        /// データベース接続文字列を作成します。
        ///	<br/>
        ///	(ユーザーID、パスワード、ホスト指定)
        /// <para>作成年月日 2009/06/03</para>
        /// <para>作成者 (株)フューチャーイン 伊藤 篤史</para>
        /// <para>修正年月日</para>
        /// <para>修正者</para>
        /// <para>修正内容</para>
        ///	</remarks>
        ///	<param name="userId">ユーザーID</param>
        ///	<param name="password">パスワード</param>
        ///	<param name="host">ホスト</param>
        ///	<returns>データベースへの接続文字列</returns>
        public static string CreateConnectionString(string userId, string password, string host)
        {
            //	戻り値設定
            return CreateConnectionString(userId, password, host, "ORCL");
        }

        /// <summary>
        /// データベースへの接続文字列
        ///	<br/>
        ///	(ユーザーID、パスワード、ホスト、サービス名指定)
        /// </summary>
        /// <remarks>
        /// データベース接続文字列を作成します。
        ///	<br/>
        ///	(ユーザーID、パスワード、ホスト、サービス名指定)
        /// <para>作成年月日 2009/06/03</para>
        /// <para>作成者 (株)フューチャーイン 伊藤 篤史</para>
        /// <para>修正年月日</para>
        /// <para>修正者</para>
        /// <para>修正内容</para>
        ///	</remarks>
        ///	<param name="userId">ユーザーID</param>
        ///	<param name="password">パスワード</param>
        ///	<param name="host">ホスト</param>
        ///	<param name="serviceName">サービス名</param>
        ///	<returns>データベースへの接続文字列</returns>
        public static string CreateConnectionString(string userId, string password, string host, string serviceName)
        {
            //	戻り値設定
            return CreateConnectionString(userId, password, host, serviceName, "TCP", "1521");
        }

        /// <summary>
        /// データベースへの接続文字列
        ///	<br/>
        ///	(ユーザーID、パスワード、ホスト、サービス名、プロトコル、ポート指定)
        /// </summary>
        /// <remarks>
        /// データベース接続文字列を作成します。
        ///	<br/>
        ///	(ユーザーID、パスワード、ホスト、サービス名、プロトコル、ポート指定)
        /// <para>作成年月日 2009/06/03</para>
        /// <para>作成者 (株)フューチャーイン 伊藤 篤史</para>
        /// <para>修正年月日</para>
        /// <para>修正者</para>
        /// <para>修正内容</para>
        ///	</remarks>
        ///	<param name="userId">ユーザーID</param>
        ///	<param name="password">パスワード</param>
        ///	<param name="host">ホスト</param>
        ///	<param name="serviceName">サービス名</param>
        ///	<param name="protocol">プロトコル</param>
        ///	<param name="port">ポート</param>
        ///	<returns>データベースへの接続文字列</returns>
        public static string CreateConnectionString(string userId, string password, string host, string serviceName, string protocol, string port)
        {
            //	接続文字列の生成
            StringBuilder connectionString = new StringBuilder();

            connectionString.Append(string.Format(" User ID={0}; ", userId));
            connectionString.Append(string.Format(" Password={0}; ", password));
            connectionString.Append(string.Format(" Data Source =(DESCRIPTION = (ADDRESS_LIST = (ADDRESS=(PROTOCOL = {0})(HOST = {1})(PORT = {2})))(CONNECT_DATA =(SERVICE_NAME = {3}))) ", protocol, host, port, serviceName));

            //	戻り値設定
            return connectionString.ToString();
        }

        #endregion

        #region OracleConnectionオープン

        ///	<summary>
        ///	OracleConnectionオープン
        ///	</summary>
        ///	<remarks>
        ///	指定されたOracleConnectionをオープンします。
        ///	<para>作成年月日 2009/06/03</para>
        /// <para>作成者 (株)フューチャーイン 伊藤 篤史</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<param name="connection">オープンするOracleConnection</param>
        public static void OpenConnection(OracleConnection connection)
        {
            //	OracleConnectionの状態が閉じている場合
            if (connection != null && connection.State == ConnectionState.Closed)
            {
                //	OracleConnectionオープン
                connection.Open();
            }
        }

        #endregion

        #region OracleConnectionクローズ

        ///	<summary>
        ///	OracleConnectionをクローズ
        ///	</summary>
        ///	<remarks>
        ///	指定されたOracleConnectionをクローズします。
        ///	<para>作成年月日 2009/06/03</para>
        /// <para>作成者 (株)フューチャーイン 伊藤 篤史</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<param name="connection">クローズするOracleConnection</param>
        public static void CloseConnection(OracleConnection connection)
        {
            //	OracleConnectionがオープンしている場合
            if (connection != null && connection.State == ConnectionState.Open)
            {
                //	OracleConnectionクローズ
                connection.Close();
            }
        }

        #endregion

        #region OracleParameter作成

        ///	<summary>
        ///	OracleParameter作成
        ///	<br/>
        ///	(パラメータ名、パラメータデータ型、パラメータ入出力方向指定)
        ///	</summary>
        ///	<remarks>
        ///	OracleParameterを作成します。
        ///	<br/>
        ///	(パラメータ名、パラメータデータ型、パラメータ入出力方向指定)
        ///	<br/>
        ///	Valueの初期値は、DBNull.Valueに設定します。
        ///	<para>作成年月日 2009/06/03</para>
        /// <para>作成者 (株)フューチャーイン 伊藤 篤史</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<param name="parameterName">パラメータ名前</param>
        ///	<param name="dbType">パラメータデータ型</param>
        ///	<param name="direction">パラメータ入出力方向</param>
        ///	<returns>OracleParameter</returns>
        private static OracleParameter CreateParameter(string parameterName, OracleDbType dbType, ParameterDirection direction)
        {
            //	OracleParameter
            OracleParameter parameter = new OracleParameter();

            //	OracleParameterプロパティ設定
            parameter.ParameterName = parameterName;	//	パラメータ名

            parameter.OracleDbType = dbType;			    //	データ型	
            parameter.Direction = direction;			//	入出力方法

            parameter.Value = DBNull.Value;			    //	値

            //	戻り値設定
            return parameter;
        }

        ///	<summary>
        ///	OracleParameter作成
        ///	<br/>
        ///	(パラメータ名、パラメータデータ型、パラメータ入出力方向、パラメータ桁数、パラメータ値指定)
        ///	</summary>
        ///	<remarks>
        ///	OracleParameterを作成します。
        ///	<br/>
        ///	(パラメータ名、パラメータデータ型、パラメータ入出力方向、パラメータ桁数、パラメータ値指定)
        ///	<br/>
        ///	parameterValueの値がnull、空文字列の場合はValueをDBNull.Valueに設定します。
        ///	<para>作成年月日 2009/06/03</para>
        /// <para>作成者 (株)フューチャーイン 伊藤 篤史</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<param name="parameterName">パラメータ名前</param>
        ///	<param name="dbType">パラメータデータ型</param>
        ///	<param name="direction">パラメータ入出力方向</param>
        ///	<param name="size">パラメータ桁数</param>
        ///	<param name="parameterValue">パラメータ値</param>
        ///	<returns>OracleParameter</returns>
        public static OracleParameter CreateParameter(string parameterName, OracleDbType dbType, ParameterDirection direction, int size, object parameterValue)
        {
            //	OracleParameter
            OracleParameter parameter = CreateParameter(parameterName, dbType, direction);

            //	OracleParameterプロパティ設定
            parameter.Size = size;		    //	サイズ

            //	パラメータ値の設定
            OracleUtility2.SetParameterValue(parameter, dbType, parameterValue);

            //	戻り値設定
            return parameter;
        }

        ///	<summary>
        ///	OracleParameter作成
        ///	<br/>
        ///	(パラメータ名、パラメータデータ型、パラメータ入出力方向、パラメータ値指定)
        ///	</summary>
        ///	<remarks>
        ///	OracleParameterを作成します。parameterValueの値がnull、空文字列の場合はValueをDBNull.Valueに設定します。
        ///	<br/>
        ///	(パラメータ名、パラメータデータ型、パラメータ入出力方向、パラメータ値指定)
        ///	<br/>
        ///	parameterValueの値がnull、空文字列の場合はValueをDBNull.Valueに設定します。
        ///	<para>作成年月日 2009/06/03</para>
        /// <para>作成者 (株)フューチャーイン 伊藤 篤史</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<param name="parameterName">パラメータ名前</param>
        ///	<param name="dbType">パラメータデータ型</param>
        ///	<param name="direction">パラメータ入出力方向</param>
        ///	<param name="parameterValue">パラメータ値</param>
        ///	<returns>OracleParameter</returns>
        public static OracleParameter CreateParameter(string parameterName, OracleDbType dbType, ParameterDirection direction, object parameterValue)
        {
            //	OracleParameter
            OracleParameter parameter = CreateParameter(parameterName, dbType, direction);

            //	パラメータ値の設定
            OracleUtility2.SetParameterValue(parameter, dbType, parameterValue);

            //	戻り値設定
            return parameter;
        }

        ///	<summary>
        ///	OracleParameterを作成
        ///	<br/>
        ///	(パラメータ名、パラメータデータ型、パラメータ入出力方向、パラメータ有効桁数、パラメータ少数桁数、パラメータ値指定)
        ///	</summary>
        ///	<remarks>
        ///	OracleParameterを作成します。
        ///	<br/>
        ///	(パラメータ名、パラメータデータ型、パラメータ入出力方向、パラメータ有効桁数、パラメータ少数桁数、パラメータ値指定)
        ///	<br/>
        ///	parameterValueの値がnull、空文字列の場合はValueをDBNull.Valueに設定します。
        ///	<para>作成年月日 2009/06/03</para>
        /// <para>作成者 (株)フューチャーイン 伊藤 篤史</para>
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
        ///	<returns>OracleParameter</returns>
        public static OracleParameter CreateParameter(string parameterName, OracleDbType dbType, ParameterDirection direction, byte precision, byte scale, object parameterValue)
        {
            //	OracleParameter
            OracleParameter parameter = CreateParameter(parameterName, dbType, direction);

            ////	OracleParameterプロパティ設定

            //parameter.Precision = precision;	//	有効桁数
            //parameter.Scale = scale;			//	少数桁数

            //	パラメータ値の設定
            OracleUtility2.SetParameterValue(parameter, dbType, parameterValue);

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
        /// <para>作成年月日 2009/06/03</para>
        /// <para>作成者 (株)フューチャーイン 伊藤 篤史</para>
        /// <para>修正年月日</para>
        /// <para>修正者</para>
        /// <para>修正内容</para>
        /// </remarks>
        ///	<param name="parameter">パラメータオブジェクト</param>
        ///	<param name="dbType">パラメータデータ型</param>
        ///	<param name="parameterValue">パラメータ値</param>
        private static void SetParameterValue(OracleParameter parameter, OracleDbType dbType, object parameterValue)
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