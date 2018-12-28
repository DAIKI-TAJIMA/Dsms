using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Xml.Serialization;
using System.Configuration;

namespace Frap3Core.BCore
{
    /// <summary>
    /// DataAccessHelper抽象クラス
    /// </summary>
    ///	<remarks>
    ///	SQL Server、Oracleを意識しないDataAccessを提供します。
    ///	<para>作成年月日 2009/11/12</para>
    /// <para>作成者 (株)フューチャーイン 横井 忠司</para>
    ///	<para>修正年月日</para>
    ///	<para>修正者</para>
    ///	<para>修正内容</para>
    ///	</remarks>
    public abstract class AbstractDataAccessHelper
    {
        #region メンバ変数

        /// <summary>
        /// 接続情報
        /// </summary>
        private ConnectionInfo _connectInfo;

        #endregion

        #region プロパティ

        /// <summary>
        /// 接続情報
        /// </summary>
        ///	<remarks>
        ///	接続情報を取得、設定
        ///	<para>作成年月日 2009/11/12</para>
        /// <para>作成者 (株)フューチャーイン 横井 忠司</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<value>接続情報</value>
        protected ConnectionInfo connectionInfo
        {
            get
            {
                return this._connectInfo;
            }
            set
            {
                this._connectInfo = value;
            }
        }

        #endregion

        #region 抽象プロパティ

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
        public abstract string currentTimestampFunctionString
        {
            get;
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
        public abstract string currentDatetimeFunctionString
        {
            get;
        }

        #endregion

        #region メソッド

        /// <summary>
        /// 接続情報リストを読み込む
        /// </summary>
        ///	<remarks>
        /// 接続情報リストを読み込む
        ///	<para>作成年月日 2009/11/12</para>
        /// <para>作成者 (株)フューチャーイン 横井 忠司</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<returns>接続情報コレクション</returns>
        private static ConnectionInfoCollection LoadConnectionInfoCollection()
        {
            // 接続情報のXMLファイルのパスを取得
            //string fileName = Path.Combine(Environment.SpecialFolder.CommonApplicationData.ToString(), Constants.FILENAME_CONNECTIONINFO_XML);
            //string fileName = Path.Combine("C:\\Thunderbird1\\Thunderbird1\\solutions\\Z\\CommonApplicationData", Constants.FILENAME_CONNECTIONINFO_XML);
            string fileName = GetAppSetting();

            // シリアライザ
            XmlSerializer serializer = new XmlSerializer(typeof(ConnectionInfoCollection));

            FileStream fs = null;                   // ストリーム
            ConnectionInfoCollection collection;    // 接続情報コレクション

            try
            {
                // 接続情報のXMLファイルを読み込む
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                // 読み込んだXMLをデシリアライズして接続情報コレクションにする。
                collection = (ConnectionInfoCollection)serializer.Deserialize(fs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                // 後処理
                if (fs != null)
                {
                    fs.Close();
                    fs.Dispose();
                }

            }

            return collection;

        }

        /// <summary>
        /// AbstractDataAccessHelperのインスタンスを作成
        /// </summary>
        ///	<remarks>
        /// AbstractDataAccessHelperのインスタンスを作成
        ///	<para>作成年月日 2009/11/12</para>
        /// <para>作成者 (株)フューチャーイン 横井 忠司</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        /// <returns>AbstractDataAccessHelper</returns>
        public static AbstractDataAccessHelper GetInstance()
        {
            //接続情報をXMLから読み込む
            ConnectionInfoCollection connectInfoCollection = AbstractDataAccessHelper.LoadConnectionInfoCollection();

            //デフォルトの接続情報を取得する
            ConnectionInfo connectInfo = connectInfoCollection.DefaultConnectionInfo;

            //インスタンスを生成して返却
            return AbstractDataAccessHelper.GetInstance(connectInfo);
        }

        /// <summary>
        /// 指定した接続識別子で作成した接続情報オブジェクトを持つAbstractDataAccessHelperのインスタンスを作成
        /// </summary>
        ///	<remarks>
        /// 指定した接続識別子で作成した接続情報オブジェクトを持つAbstractDataAccessHelperのインスタンスを作成
        ///	<para>作成年月日 2009/11/12</para>
        /// <para>作成者 (株)フューチャーイン 横井 忠司</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        /// <param name="id">接続識別子</param>
        /// <returns>AbstractDataAccessHelper</returns>
        public static AbstractDataAccessHelper GetInstance(String id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return AbstractDataAccessHelper.GetInstance();
            }
            else
            {
                //接続情報をXMLから読み込む
                ConnectionInfoCollection connectInfoCollection = AbstractDataAccessHelper.LoadConnectionInfoCollection();

                //接続情報を取得する
                ConnectionInfo connectInfo = connectInfoCollection[int.Parse(id)];

                //インスタンスを生成して返却
                return AbstractDataAccessHelper.GetInstance(connectInfo);
            }

        }

        /// <summary>
        /// 指定した接続情報オブジェクトを持つAbstractDataAccessHelperのインスタンスを作成
        /// </summary>
        ///	<remarks>
        /// 指定した接続情報オブジェクトを持つAbstractDataAccessHelperのインスタンスを作成
        ///	<para>作成年月日 2009/11/12</para>
        /// <para>作成者 (株)フューチャーイン 横井 忠司</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        /// <param name="connectInfo">接続情報オブジェクト</param>
        /// <returns>AbstractDataAccessHelper</returns>
        public static AbstractDataAccessHelper GetInstance(ConnectionInfo connectInfo)
        {
            AbstractDataAccessHelper dataAccessHelper = null;

            if (connectInfo.DBMS == DBMS.SQLServer)
            {
                // SQLServerの場合、SQLServer用のインスタンスを生成
                dataAccessHelper = new SQLDataAccessHelper(connectInfo);
            }
            else if (connectInfo.DBMS == DBMS.Oracle)
            {
                // Oracleの場合、Oracle用のインスタンスを生成
                dataAccessHelper = new OracleDataAccessHelper(connectInfo);
            }
            else if (connectInfo.DBMS == DBMS.Oracle2)
            {
                dataAccessHelper = new OracleDataAccessHelper2(connectInfo);
            }
            else if (connectInfo.DBMS == DBMS.PostgreSQL)
            {
                // PostgreSQLの場合、PostgreSQL用のインスタンスを生成
                dataAccessHelper = new PostgreSQLDataAccessHelper(connectInfo);
            }

            return dataAccessHelper;
        }

        /// <summary>
        /// SQLを実行する。
        /// </summary>
        ///	<remarks>
        /// SQLを実行する。
        ///	<para>作成年月日 2009/11/12</para>
        /// <para>作成者 (株)フューチャーイン 横井 忠司</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<param name="dbCommand">コマンド</param>
        /// <returns>件数</returns>
        public virtual int ExecuteNonQuery(DbCommand dbCommand)
        {
            return dbCommand.ExecuteNonQuery();
        }

        /// <summary>
        /// SQLを実行して、DbDataReaderを取得する
        /// </summary>
        ///	<remarks>
        /// SQLを実行して、DbDataReaderを取得する
        ///	<para>作成年月日 2009/11/12</para>
        /// <para>作成者 (株)フューチャーイン 横井 忠司</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<param name="dbCommand">コマンド</param>
        /// <returns>DbDataReader</returns>
        public virtual DbDataReader ExecuteReader(DbCommand dbCommand)
        {
            return dbCommand.ExecuteReader();
        }

        /// <summary>
        /// SQLを実行して、その結果の最初の行の最初の列の値を取得する。
        /// </summary>
        ///	<remarks>
        /// SQLを実行して、その結果の最初の行の最初の列の値を取得する。
        ///	<para>作成年月日 2009/11/12</para>
        /// <para>作成者 (株)フューチャーイン 横井 忠司</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        /// <returns></returns>
        public virtual object ExecuteScalar(DbCommand dbCommand)
        {
            return dbCommand.ExecuteScalar();
        }

        /// <summary>
        /// システム設定の値を取得する
        /// </summary>
        ///	<remarks>
        /// システム設定の値を取得する
        ///	<para>作成年月日 2014/10/06</para>
        ///	<para>作成者 株式会社フューチャーイン 岩本 佳丈</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<returns>値</returns>
        private static string GetAppSetting()
        {

            // 返却値
            string result = null;

           Configuration rootWebConfig1;
            
        // 実行ファイルのアセンブリを取得する。
        String stTarget   = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
        // 物理パスを取得する。
        System.Uri hUri = new System.Uri(stTarget);
        // ファイル情報を取得する。
        System.IO.FileInfo FilePath = new System.IO.FileInfo(hUri.LocalPath);

        // アセンブリのパスを取得
        String pathAssembly = FilePath.FullName + ".config";

            // ファイルが存在しない場合は空文字を返却する
        if (!File.Exists(pathAssembly))
            {
                return null;
            }

            // ファイルマップを生成する
            var file_map = new ExeConfigurationFileMap();
            // マップにDLLのConfigパスを設定する
            file_map.ExeConfigFilename = pathAssembly;
            // Configファイルを取得する
            rootWebConfig1 = ConfigurationManager.OpenMappedExeConfiguration(file_map, ConfigurationUserLevel.None);
            
            if (0 < rootWebConfig1.AppSettings.Settings.Count)
            {
                System.Configuration.KeyValueConfigurationElement customSetting =
                    rootWebConfig1.AppSettings.Settings["ConnectionInfo"];
                if (null != customSetting)
                {
                    result = customSetting.Value;
                }
            }

            return result;
        }

        #endregion

        #region 抽象メソッド

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
        public abstract void CloseConnection(DbConnection connection);

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
        public abstract DbConnection GetConnection();

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
        public abstract DbCommand CreateCommand(string sql, DbConnection con);

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
        public abstract DbCommand CreateCommand(string sql, DbConnection con, DbTransaction txn);

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
        public abstract DbParameter CreateParameter(String name, Frap3DBType type, ParameterDirection direction, Object value);

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
        public abstract DbParameter CreateParameter(String name, Frap3DBType type, ParameterDirection direction, int size, Object value);

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
        public abstract DbParameter CreateParameter(String name, Frap3DBType type, ParameterDirection direction, byte precision, byte scale, Object value);

        ///// <summary>
        ///// サーバ時間のパラメータを作成する
        ///// </summary>
        ///// <param name="name">パラメータ名前</param>
        ///// <param name="direction">パラメータ入出力方向</param>
        ///// <returns>DbParameter</returns>
        //public abstract DbParameter CreateDateParameter(String name, ParameterDirection direction);
        ///// <summary>
        ///// DBパラメータを作成する
        ///// </summary>
        ///// <param name="name">パラメータ名前</param>
        ///// <param name="direction">パラメータ入出力方向</param>
        ///// <returns>DbParameter</returns>
        //public abstract DbParameter CreateTimeParameter(String name, ParameterDirection direction);

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
        public abstract int Fill(DbCommand dbCommand, DataSet dataSet, string tableName);

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
        public abstract int Fill(DbCommand dbCommand, DataTable dataTable);

        /// <summary>
        /// Frap3のデータ型に対応するDBのデータ型を取得。
        /// </summary>
        ///	<remarks>
        /// Frap3のデータ型に対応するDBのデータ型を取得。
        ///	<para>作成年月日 2009/11/12</para>
        /// <para>作成者 (株)フューチャーイン 横井 忠司</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<param name="type">Frap3のデータ型</param>
        /// <returns>DBのデータ型を表す値</returns>
        protected abstract int ConvertDbType(Frap3DBType type);

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
        public abstract string CreateBindVariablesString(String name, int cnt);

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
        public abstract void AddParameters<T>(ref DbCommand dbCommand, string name, Frap3DBType type, List<T> values);

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
        public abstract bool CheckInsertError(Exception ex);

        #endregion

    }

}
