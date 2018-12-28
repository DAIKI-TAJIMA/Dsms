using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Futureinn.DB.Utility
{
    ///	<summary>
    ///	SQL Server関連のユーティリティクラス
    ///	</summary>
    ///	<remarks>
    ///	SQL Serverに関する各種機能を提供します。
    ///	<para>作成年月日 2009/06/03</para>
    /// <para>作成者 (株)フューチャーイン 伊藤 篤史</para>
    ///	<para>修正年月日</para>
    ///	<para>修正者</para>
    ///	<para>修正内容</para>
    ///	</remarks>
    public class SqlUtility
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
		private SqlUtility()
		{
		}

		#endregion

		#region メソッド

		#region SqlConnection取得


		///	<summary>
		///	SqlConnection取得(Windows認証)
		///	</summary>
		///	<remarks>
		///	Windows認証を使用してSqlConnectionを取得します。
		///	<para>作成年月日 2009/06/03</para>
		/// <para>作成者 (株)フューチャーイン 伊藤 篤史</para>
		///	<para>修正年月日</para>
		///	<para>修正者</para>
		///	<para>修正内容</para>
		///	</remarks>
		///	<param name="server">サーバー名</param>
		///	<param name="database">データベース名</param>
		///	<returns>SqlConnection</returns>
		public static SqlConnection GetConnection(string server, string database)
		{
			//	SqlConnection生成
			SqlConnection connection = new SqlConnection(CreateConnectionString(server, database, "", ""));

			//	戻り値セット
			return connection;
		}

		///	<summary>
		///	SqlConnection取得(統合認証)
		///	</summary>
		///	<remarks>
		///	統合認証を使用してSqlConnectionを取得します。
		///	<para>作成年月日 2009/06/03</para>
		/// <para>作成者 (株)フューチャーイン 伊藤 篤史</para>
		///	<para>修正年月日</para>
		///	<para>修正者</para>
		///	<para>修正内容</para>
		///	</remarks>
		///	<param name="server">サーバー名</param>
		///	<param name="database">データベース名</param>
		///	<param name="uid">ユーザー名</param>
		///	<param name="pwd">パスワード</param>
		///	<returns>SqlConnection</returns>
		public static SqlConnection GetConnection(string server, string database, string uid, string pwd)
		{
			//	SqlConnection生成
			SqlConnection connection = new SqlConnection(CreateConnectionString(server, database, uid, pwd));
			
			//	戻り値セット
			return connection;
		}

		#endregion

		#region データベースへの接続文字列

		/// <summary>
		/// データベースへの接続文字列(Windows認証)
		/// </summary>
		/// <remarks>
		/// Windows認証用のデータベース接続文字列を作成します。
		/// <para>作成年月日 2009/06/03</para>
		/// <para>作成者 (株)フューチャーイン 伊藤 篤史</para>
		/// <para>修正年月日</para>
		/// <para>修正者</para>
		/// <para>修正内容</para>
		///	</remarks>
		///	<param name="server">サーバー名</param>
		///	<param name="database">データベース名</param>
		///	<returns>データベースへの接続文字列</returns>
		public static string CreateConnectionString(string server, string database)
		{
			//	接続文字列の生成
			StringBuilder connectionString = new StringBuilder();

			//	戻り値設定
			return CreateConnectionString(server, database, "", "");
		}

		/// <summary>
		/// データベースへの接続文字列(統合認証)
		/// </summary>
		/// <remarks>
		/// 統合認証用のデータベース接続文字列を作成します。
		/// <para>作成年月日 2009/06/03</para>
		/// <para>作成者 (株)フューチャーイン 伊藤 篤史</para>
		/// <para>修正年月日</para>
		/// <para>修正者</para>
		/// <para>修正内容</para>
		///	</remarks>
		///	<param name="server">サーバー名</param>
		///	<param name="database">データベース名</param>
		///	<param name="uid">ユーザー名</param>
		///	<param name="pwd">パスワード</param>
		///	<returns>データベースへの接続文字列</returns>
		public static string CreateConnectionString(string server, string database, string uid, string pwd)
		{
			//	接続文字列の生成
			StringBuilder connectionString = new StringBuilder();

			connectionString.Append(string.Format("server={0};", server));
			connectionString.Append(string.Format("database={0};", database));

			//	ユーザー名、パスワードの指定がある場合
			if (!string.IsNullOrEmpty(uid) && !string.IsNullOrEmpty(pwd))
			{
				//	統合認証
				connectionString.Append(string.Format("uid={0};", uid));
				connectionString.Append(string.Format("pwd={0};", pwd));
			}
				//	上記以外
			else
			{
				//	Windows認証
				connectionString.Append("Integrated Security=SSPI;");
			}

			//	戻り値設定
			return connectionString.ToString();
		}

		#endregion

		#region SqlConnectionオープン

		///	<summary>
		///	SqlConnectionオープン
		///	</summary>
		///	<remarks>
		///	指定されたSqlConnectionをオープンします。
		///	<para>作成年月日 2009/06/03</para>
		/// <para>作成者 (株)フューチャーイン 伊藤 篤史</para>
		///	<para>修正年月日</para>
		///	<para>修正者</para>
		///	<para>修正内容</para>
		///	</remarks>
		///	<param name="connection">オープンするSqlConnection</param>
		public static void OpenConnection(SqlConnection connection)
		{
			//	SqlConnectionの状態が閉じている場合
			if (connection != null && connection.State == ConnectionState.Closed)
			{
				//	SqlConnectionオープン
				connection.Open();
			}
		}

		#endregion

		#region SqlConnectionクローズ

		///	<summary>
		///	SqlConnectionをクローズ
		///	</summary>
		///	<remarks>
		///	指定されたSqlConnectionをクローズします。
		///	<para>作成年月日 2009/06/03</para>
		/// <para>作成者 (株)フューチャーイン 伊藤 篤史</para>
		///	<para>修正年月日</para>
		///	<para>修正者</para>
		///	<para>修正内容</para>
		///	</remarks>
		///	<param name="connection">クローズするSqlConnection</param>
		public static void CloseConnection(SqlConnection connection)
		{
			//	SqlConnectionがオープンしている場合
			if (connection != null && connection.State == ConnectionState.Open)
			{
				//	SqlConnectionクローズ
				connection.Close();
			}
		}

		#endregion

		#region SqlParameter作成

		///	<summary>
		///	SqlParameter作成
		///	<br/>
		///	(パラメータ名、パラメータデータ型、パラメータ入出力方向指定)
		///	</summary>
		///	<remarks>
		///	SqlParameterを作成します。
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
		///	<param name="parameterName">パラメータ名</param>
		///	<param name="dbType">パラメータデータ型</param>
		///	<param name="direction">パラメータ入出力方向</param>
		///	<returns>SqlParameter</returns>
		private static SqlParameter CreateParameter(string parameterName, SqlDbType dbType, ParameterDirection direction)
		{
			//	SqlParameter
			SqlParameter parameter = new SqlParameter();

			//	SqlParameterプロパティ設定
			parameter.ParameterName = parameterName;	//	パラメータ名

			parameter.SqlDbType = dbType;			    //	データ型	
			parameter.Direction = direction;			//	入出力方法

			parameter.Value = DBNull.Value;			    //	値

			//	戻り値設定
			return parameter;
		}

		///	<summary>
		///	SqlParameter作成
		///	<br/>
		///	(パラメータ名、パラメータデータ型、パラメータ入出力方向、パラメータ桁数、パラメータ値指定)
		///	</summary>
		///	<remarks>
		///	SqlParameterを作成します。
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
		///	<param name="parameterName">パラメータ名</param>
		///	<param name="dbType">パラメータデータ型</param>
		///	<param name="direction">パラメータ入出力方向</param>
		///	<param name="size">パラメータ桁数</param>
		///	<param name="parameterValue">パラメータ値</param>
		///	<returns>SqlParameter</returns>
		public static SqlParameter CreateParameter(string parameterName, SqlDbType dbType, ParameterDirection direction, int size, object parameterValue)
		{
			//	SqlParameter
			SqlParameter parameter = CreateParameter(parameterName, dbType, direction);

			//	SqlParameterプロパティ設定
			parameter.Size = size;		    //	サイズ

			//	パラメータ値の設定
			SqlUtility.SetParameterValue(parameter, dbType, parameterValue);

			//	戻り値設定
			return parameter;
		}

		///	<summary>
		///	SqlParameter作成
		///	<br/>
		///	(パラメータ名、パラメータデータ型、パラメータ入出力方向、パラメータ値指定)
		///	</summary>
		///	<remarks>
		///	SqlParameterを作成します。
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
		///	<param name="parameterName">パラメータ名</param>
		///	<param name="dbType">パラメータデータ型</param>
		///	<param name="direction">パラメータ入出力方向</param>
		///	<param name="parameterValue">パラメータ値</param>
		///	<returns>SqlParameter</returns>
		public static SqlParameter CreateParameter(string parameterName, SqlDbType dbType, ParameterDirection direction, object parameterValue)
		{
			//	SqlParameter
			SqlParameter parameter = CreateParameter(parameterName, dbType, direction);

			//	パラメータ値の設定
			SqlUtility.SetParameterValue(parameter, dbType, parameterValue);

			//	戻り値設定
			return parameter;
		}

		///	<summary>
		///	SqlParameter作成
		///	<br/>
		///	(パラメータ名、パラメータデータ型、パラメータ入出力方向、パラメータ有効桁数、パラメータ少数桁数、パラメータ値指定)
		///	</summary>
		///	<remarks>
		///	SqlParameterを作成します。
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
		///	<param name="parameterName">パラメータ名</param>
		///	<param name="dbType">パラメータデータ型</param>
		///	<param name="direction">パラメータ入出力方向</param>
		///	<param name="precision">パラメータ有効桁数</param>
		///	<param name="scale">パラメータ少数桁数</param>
		///	<param name="parameterValue">パラメータ値</param>
		///	<returns>SqlParameter</returns>
		public static SqlParameter CreateParameter(string parameterName, SqlDbType dbType, ParameterDirection direction, byte precision, byte scale, object parameterValue)
		{
			//	SqlParameter
			SqlParameter parameter = CreateParameter(parameterName, dbType, direction);

			//	SqlParameterプロパティ設定
			parameter.Precision = precision;	//	有効桁数
			parameter.Scale = scale;			//	少数桁数

			//	パラメータ値の設定
			SqlUtility.SetParameterValue(parameter, dbType, parameterValue);

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
		private static void SetParameterValue(SqlParameter parameter, SqlDbType dbType, object parameterValue)
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
