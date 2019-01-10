using System;
using System.Data.Common;
using System.Collections.Generic;

using Frap3Core.BCore;

using Dsms.DataAccess;
using Dsms.Model;
using Dsms.Resource;

namespace Dsms.Business
{
    public class CommonBusiness : ProjectBusinessBase
    {
        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        ///	<remarks>
        /// コンストラクタ
        ///	<para>作成年月日 2018/04/27</para>
        /// <para>作成者 (株)フューチャーイン 林隆一</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<value>connectionInfo</value>
        public CommonBusiness(Frap3Core.BCore.ConnectionInfo connectionInfo, BusinessCommonParams bcp) : base(connectionInfo, bcp)
        {
        }

        #endregion

        #region メソッド

        #region 操作ログ登録

        ///	<summary>
        ///	操作ログ登録
        ///	</summary>
        ///	<remarks>
        ///	操作ログ登録
        ///	<para>作成年月日 2017/12/01</para>
        ///	<para>作成者 (株)フューチャーイン 岡田 健太郎</para>
        ///	<para>修正年月日</para>
        ///	<para>修正者</para>
        ///	<para>修正内容</para>
        ///	</remarks>
        ///	<param name="model">操作ログモデル</param>
        /// <returns>件数</returns>
        public int InsertL1Sosa(L1_SOSAModel model)
        {
            AbstractDataAccessHelper helper = AbstractDataAccessHelper.GetInstance(this._connectionInfo);

            using (DbConnection con = helper.GetConnection())
            {
                DbTransaction txn = con.BeginTransaction();

                try
                {
                    // データアクセスの作成。
                    CommonDataAccess da = new CommonDataAccess(con, txn, helper, this.BCP);

                    int count = da.InsertL1Sosa(model);

                    txn.Commit();

                    // 処理件数を返却する
                    return count;
                }
                catch (Exception ex)
                {
                    if (txn != null)
                    {
                        txn.Rollback();
                    }
                    throw ex;
                }
                finally
                {
                    helper.CloseConnection(con);
                }
            }
        }

        #endregion

        #endregion
    }
}
