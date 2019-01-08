using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Common;
using System.Reflection;

using Frap3Core.BCore;

using Dsms.Resource;

namespace Dsms.DataAccess
{
    public class ProjectDataAccessBase : DataAccessBase
    {
        #region メンバ変数

        /// <summary>
        /// ページから受けとった共通パラメータ
        /// </summary>
        private BusinessCommonParams _bcp;

        #endregion

        #region プロパティ

        /// <summary>
        /// ページから受けとった共通パラメータ
        /// </summary>
        ///	<remarks>
        ///	ページから受けとった共通パラメータを取得
        ///	<para>作成年月日 2010/04/09</para>
        ///	<para>作成者 (株)フューチャーイン 鈴木 辰宣</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<value>ページから受けとった共通パラメータ</value>
        protected BusinessCommonParams BCP
        {
            get
            {
                return this._bcp;
            }
        }

        #endregion

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        ///	<remarks>
        /// コンストラクタ
        ///	<para>作成年月日 2018/3/29</para>
        /// <para>作成者 (株)フューチャーイン 林隆一</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        /// <param name="helper">AbstractDataAccessHelper</param>
        public ProjectDataAccessBase(AbstractDataAccessHelper helper, BusinessCommonParams bcp) : base(null, helper)
        {
            this._bcp = bcp;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        ///	<remarks>
        /// コンストラクタ
        ///	<para>作成年月日 2018/3/29</para>
        /// <para>作成者 (株)フューチャーイン 林隆一</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        /// <param name="con">Connection</param>
        /// <param name="helper">AbstractDataAccessHelper</param>
        public ProjectDataAccessBase(DbConnection con, AbstractDataAccessHelper helper, BusinessCommonParams bcp) : base(con, helper)
        {
            this._bcp = bcp;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        ///	<remarks>
        /// コンストラクタ
        ///	<para>作成年月日 2018/3/29</para>
        /// <para>作成者 (株)フューチャーイン 林隆一</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        /// <param name="con">コネクション</param>
        /// <param name="txn">トランザクション</param>
        /// <param name="helper">AbstractDataAccessHelper</param>
        public ProjectDataAccessBase(DbConnection con, DbTransaction txn, AbstractDataAccessHelper helper, BusinessCommonParams bcp) : base(con, txn, helper)
        {
            this._bcp = bcp;
        }

        #endregion

        #region メソッド

        /// <summary>
        /// SQLコマンドを実行する。
        /// </summary>
        ///	<remarks>
        /// SQLコマンドを実行する。
        ///	<para>作成年月日 2018/3/29</para>
        /// <para>作成者 (株)フューチャーイン 林隆一</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        /// <param name="command">DbCommand</param>
        /// <returns>実行結果件数</returns>
        public int ExecuteNonQuery(DbCommand command)
        {
            return this.Helper.ExecuteNonQuery(command);
        }

        /// <summary>
        /// readerの実行結果を１件取得
        /// </summary>
        ///	<remarks>
        /// readerの実行結果を１件取得。
        ///	<para>作成年月日 2018/3/29</para>
        /// <para>作成者 (株)フューチャーイン 林隆一</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        /// <param name="command">DbCommand</param>
        /// <returns>実行結果件数</returns>
        public object ExecuteScalar(DbCommand command)
        {
            return this.Helper.ExecuteScalar(command);
        }

        /// <summary>
        /// readerの実行結果をリストに格納
        /// </summary>
        ///	<remarks>
        /// readerの実行結果をリストに格納
        ///	<para>作成年月日 2018/3/29</para>
        /// <para>作成者 (株)フューチャーイン 林隆一</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        /// <param name="command">DbCommand</param>
        /// <returns>List</returns>
        public List<object> ExecuteList(DbCommand command)
        {
            return this.ExecuteList<object>(command);
        }

        public List<T> ExecuteList<T>(DbCommand command)
        {
            List<T> retList = new List<T>();

            DbDataReader reader = this.Helper.ExecuteReader(command);
            try
            {
                while (reader.Read())
                {
                    if (reader[0] != null)
                    {
                        retList.Add((T)reader[0]);
                    }

                }

            }
            finally
            {
                this.CloseReader(reader);
            }
            return retList;
        }

        /// <summary>
        /// readerの実行処理
        /// </summary>
        ///	<remarks>
        /// readerの実行処理
        ///	<para>作成年月日 2018/3/29</para>
        /// <para>作成者 (株)フューチャーイン 林隆一</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        /// <param name="command">DbCommand</param>
        /// <returns>DbDataReader</returns>
        public DbDataReader ExecuteReader(DbCommand command)
        {
            return this.Helper.ExecuteReader(command);
        }

        /// <summary>
        /// readerの終了処理
        /// </summary>
        ///	<remarks>
        ///readerの終了処理
        ///	<para>作成年月日 2018/3/29</para>
        /// <para>作成者 (株)フューチャーイン 林隆一</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        /// <param name="reader">DbDataReader</param>
        public void CloseReader(DbDataReader reader)
        {
            if (reader != null)
            {
                if (!reader.IsClosed)
                {
                    reader.Close();
                    reader = null;
                }
            }
        }

        /// <summary>
        /// コマンドの生成
        /// </summary>
        ///	<remarks>
        /// コマンドの生成
        ///	<para>作成年月日 2018/3/29</para>
        /// <para>作成者 (株)フューチャーイン 林隆一</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        /// <param name="sql">string</param>
        /// <returns>DbCommand</returns>
        public DbCommand CreateCommand(string sql)
        {
            DbCommand command = base.Helper.CreateCommand(sql, base.Con);
            command.CommandText = sql;
            if (this.Txn != null)
            {
                command.Transaction = this.Txn;
            }
            return command;
        }

        /// <summary>
        /// パラメータの生成
        /// </summary>
        ///	<remarks>
        /// パラメータの生成
        ///	<para>作成年月日 2018/3/29</para>
        /// <para>作成者 (株)フューチャーイン 林隆一</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        /// <param name="name">string</param>
        /// <param name="type">Frap3DBType</param>
        /// <param name="direction">ParameterDirection</param>
        /// <param name="size">int</param>
        /// <param name="value">object</param>
        /// <returns>DbParameter</returns>
        public DbParameter CreateParameter(string name
            , Frap3DBType type
            , ParameterDirection direction
            , int size
            , object value)
        {
            DbParameter parameter;
            if (value == null)
            {
                parameter = this.Helper.CreateParameter(name, type, direction, size, value);
            }
            else if (value.GetType().IsEnum)
            {
                parameter = this.Helper.CreateParameter(name, type, direction, size, (int)(value));
            }
            else
            {
                parameter = this.Helper.CreateParameter(name, type, direction, size, value);
            }
            return parameter;
        }

        /// <summary>
        /// パラメータの生成
        /// </summary>
        ///	<remarks>
        /// パラメータの生成
        ///	<para>作成年月日 2018/3/29</para>
        /// <para>作成者 (株)フューチャーイン 林隆一</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        /// <param name="name">string</param>
        /// <param name="type">Frap3DBType</param>
        /// <param name="direction">ParameterDirection</param>
        /// <param name="value">object</param>
        /// <returns>DbParameter</returns>
        public DbParameter CreateParameter(string name
            , Frap3DBType type
            , ParameterDirection direction
            , object value)
        {
            DbParameter parameter;
            if (value == null)
            {
                parameter = this.Helper.CreateParameter(name, type, direction, value);
            }
            else if (value.GetType().IsEnum)
            {
                parameter = this.Helper.CreateParameter(name, type, direction, (int)value);
            }
            else
            {
                parameter = this.Helper.CreateParameter(name, type, direction, value);
            }
            return parameter;
        }

        /// <summary>
        /// 実行結果をモデルに格納
        /// </summary>
        ///	<remarks>
        /// 実行結果をモデルに格納
        ///	<para>作成年月日 2018/3/29</para>
        /// <para>作成者 (株)フューチャーイン 林隆一</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        /// <param name="reader">DbDataReader</param>
        /// <returns>T</returns>
        public T CreateModelFromDataReader<T>(DbDataReader reader)
        {

            Type modelType = typeof(T);
            T model = (T)Activator.CreateInstance(modelType);

            IEnumerable<PropertyInfo> propertyInfoList = modelType.GetProperties();

            for (int i = 0; i < reader.FieldCount; i++)
            {
                string fieldName = reader.GetName(i);

                try
                {
                    PropertyInfo pi;

                    pi = propertyInfoList.SingleOrDefault(d => d.Name.ToUpper() == fieldName.ToUpper());

                    if (pi == null)
                    {
                        continue;
                    }

                    var value = reader[fieldName];

                    if (value is DBNull)
                    {
                        value = null;
                    }

                    if (value == null)
                    {
                        pi.SetValue(model, null, null);
                    }
                    else
                    {
                        Type typ = pi.PropertyType;

                        if (pi.PropertyType.IsGenericType)
                        {
                            if (pi.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                            {
                                typ = Nullable.GetUnderlyingType(pi.PropertyType);
                            }
                        }

                        pi.SetValue(model, Convert.ChangeType(value, typ), null);
                    }
                }
                catch
                {

                }
                finally
                {
                }
            }
            return model;
        }

        /// <summary>
        /// 実行結果をデータテーブルに格納
        /// </summary>
        ///	<remarks>
        /// 実行結果をデータテーブルに格納
        ///	<para>作成年月日 2018/3/29</para>
        /// <para>作成者 (株)フューチャーイン 林隆一</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        /// <param name="reader">DbDataReader</param>
        /// <returns>DataTableT</returns>
        public DataTable CreateDataTableFromDataReader(DbDataReader reader)
        {
            DataTable dt = new DataTable();

            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (!string.IsNullOrEmpty(reader.GetName(i)))
                {
                    DataColumn col = new DataColumn(reader.GetName(i), reader.GetFieldType(i));
                    dt.Columns.Add(col);
                }
            }

            while (reader.Read())
            {
                DataRow dr = dt.NewRow();

                foreach (DataColumn col in dt.Columns)
                {
                    dr[col.ColumnName] = reader[col.ColumnName];
                }

                dt.Rows.Add(dr);
            }
            return dt;
        }

        #endregion
    }
}
