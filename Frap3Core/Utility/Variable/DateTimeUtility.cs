using System;
using System.Globalization;

namespace Futureinn.Utility.Variable
{
    ///	<summary>
    ///	日付に関するユーティリティ。
    ///	</summary>
    ///	<remarks>
    ///	日付に関する各種機能を提供します。
    ///	<para>作成年月日 2009/06/02</para>
    ///	<para>作成者 (株)フューチャーイン 伊藤 篤史</para>
    ///	<para>修正年月日</para>
    ///	<para>修正者</para>
    ///	<para>修正内容</para>
    ///	</remarks>
    public class DateTimeUtility
	{
		#region 月初日の取得
		
		///	<summary>
		///	月初日の取得
		///	</summary>
		///	<remarks>
		///	指定年月の月初日を取得します。
		///	<para>作成年月日 2009/06/02</para>
		///	<para>作成者 (株)フューチャーイン 伊藤 篤史</para>
		///	<para>修正年月日</para>
		///	<para>修正者</para>
		///	<para>修正内容</para>
		///	</remarks>
		///	<param name="target">変換対象の日付</param>
		///	<returns>対象年月の月初日</returns>
		public static DateTime FirstDay(DateTime target)
		{
			return new DateTime(target.Year, target.Month, 1);
		}

		///	<summary>
		///	月初日の取得
		///	</summary>
		///	<remarks>
		///	指定年月の月初日を取得します。
		///	<para>作成年月日 2009/06/02</para>
		///	<para>作成者 (株)フューチャーイン 伊藤 篤史</para>
		///	<para>修正年月日</para>
		///	<para>修正者</para>
		///	<para>修正内容</para>
		///	</remarks>
		///	<param name="year">年</param>
		///	<param name="month">月</param>
		///	<returns>対象年月の月初日</returns>
		public static DateTime FirstDay(int year, int month)
		{
			return new DateTime(year, month, 1);
		}

		#endregion

		#region 月末日の取得
		
		///	<summary>
		///	月末日の取得
		///	</summary>
		///	<remarks>
		///	指定年月の月末日を取得します。
		///	<para>作成年月日 2009/06/02</para>
		///	<para>作成者 (株)フューチャーイン 伊藤 篤史</para>
		///	<para>修正年月日</para>
		///	<para>修正者</para>
		///	<para>修正内容</para>
		///	</remarks>
		///	<param name="target">変換対象の日付</param>
		///	<returns>対象年月の月末日</returns>
		public static DateTime LastDay(DateTime target)
		{
			// 変換用変数宣言
			DateTime convertDateTime = new DateTime(target.Year, target.Month, 1);

			// 対象日付が'9999'年で'12'月の場合
			if (target.Year == 9999 && target.Month == 12)
			{
				return convertDateTime = new DateTime(target.Year, target.Month, 31);
			}

			// 対象日付の月+1
			convertDateTime = convertDateTime.AddMonths(1);

			// 対象日付の日にち-1
			convertDateTime = convertDateTime.AddDays(-1);

			// 対象日付を変換します
			return new DateTime(convertDateTime.Year, convertDateTime.Month, convertDateTime.Day);
		}

		///	<summary>
		///	月末日の取得
		///	</summary>
		///	<remarks>
		///	指定年月の月末日を取得します。
		///	<para>作成年月日 2009/06/02</para>
		///	<para>作成者 (株)フューチャーイン 伊藤 篤史</para>
		///	<para>修正年月日</para>
		///	<para>修正者</para>
		///	<para>修正内容</para>
		///	</remarks>
		///	<param name="year">年</param>
		///	<param name="month">月</param>
		///	<returns>対象年月の月末日</returns>
		public static DateTime LastDay(int year, int month)
		{
			// 対象日付の月初日を取得
			DateTime convertDateTime = LastDay(year, month);

			// 対象日付を変換
			return LastDay(convertDateTime);
		}

		#endregion

		#region 和暦変換

		///	<summary>
		///	和暦変換
		///	</summary>
		///	<remarks>
		///	日付書式を和暦変換します。
		///	<para>作成年月日 2009/06/02</para>
		///	<para>作成者 (株)フューチャーイン 伊藤 篤史</para>
		///	<para>修正年月日</para>
		///	<para>修正者</para>
		///	<para>修正内容</para>
		///	</remarks>
		///	<param name="target">対象日付</param>
		///	<param name="format">日付書式 (例)ggyy年M月d日</param>
		///	<returns>書式変換した日付文字列</returns>
		public static String FormatWareki(DateTime target, String format)
		{
			// CultureInfoの設定
			CultureInfo culture = new CultureInfo("ja-JP", true);

			// 和暦の設定
			culture.DateTimeFormat.Calendar = new JapaneseCalendar();

			// 対象日付を和暦に変換
			return target.ToString(format, culture);
		}

		#endregion

		#region 時分秒のクリア

		///	<summary>
		///	時分秒のクリア
		///	</summary>
		///	<remarks>
		///	時分秒の各値を0に設定します。
		///	<para>作成年月日 2009/06/02</para>
		///	<para>作成者 (株)フューチャーイン 伊藤 篤史</para>
		///	<para>修正年月日</para>
		///	<para>修正者</para>
		///	<para>修正内容</para>
		///	</remarks>
		///	<param name="target">対象日付</param>
		///	<returns>時分秒をクリアした日付</returns>
		public static DateTime ClearTime(DateTime target)
		{
			// 対象日付の時分秒をクリア
			return new DateTime(target.Year, target.Month, target.Day, 0, 0, 0);

		}

		#endregion

		//#region 2つの日付の間の時間間隔数取得
		
		/////	<summary>
		/////	2つの日付の間の時間間隔数取得
		/////	</summary>
		/////	<remarks>
		/////	2つの日付の間の時間間隔数を指定する値を返します。
		/////	<para>作成年月日 2009/06/02</para>
		/////	<para>作成者 (株)フューチャーイン 伊藤 篤史</para>
		/////	<para>修正年月日</para>
		/////	<para>修正者</para>
		/////	<para>修正内容</para>
		/////	</remarks>
		/////	<param name="target1">対象日付1</param>
		/////	<param name="target2">対象日付2</param>
		/////	<param name="interval">対象日付1と対象日付2の間の差異の単位として使用する時間間隔を表すDateInterval列挙値</param>
		/////	<returns>2つの日付の間に含まれる時間間隔の数</returns>
		//public static long DateDiff(DateInterval interval, DateTime target1, DateTime target2)
		//{
		//	return DateAndTime.DateDiff(interval, target1, target2, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
		//}

		//#endregion

		#region 第何週取得

		///	<summary>
		///	第何週取得
		///	</summary>
		///	<remarks>
		///	指定された日付がその月の第何週にあたるかを戻します。
		///	<para>作成年月日 2009/06/02</para>
		///	<para>作成者 (株)フューチャーイン 伊藤 篤史</para>
		///	<para>修正年月日</para>
		///	<para>修正者</para>
		///	<para>修正内容</para>
		///	</remarks>
		///	<param name="target">対象日付</param>
		///	<returns>第何週</returns>
		public static int GetMonthWeek(DateTime target)
		{
			//	月初日を取得
			DateTime firstDay = FirstDay(target);

			decimal result = (int)firstDay.DayOfWeek + target.Day - 1;

			result /= 7;

			result = Math.Ceiling(result);

			if (firstDay.DayOfWeek == DayOfWeek.Sunday)
			{
				result += 1;
			}

			return (int)result;
		}

		#endregion
	}
}
