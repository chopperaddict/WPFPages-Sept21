using System;
using System . Globalization;
using System . Windows . Data;

namespace WPFPages . Converts
{
	public class ResetTextWidth : IValueConverter
	{
		/// <summary>
		/// Adds a dependency value received an XPath Converter parameter to move a textbolock downwrds to fit correctly
		/// </summary>
		/// <param name="value"></param>
		/// <param name="targetType"></param>
		/// <param name="parameter"></param>
		/// <param name="culture"></param>
		/// <returns></returns>
		public object Convert ( object value, Type targetType, object parameter, CultureInfo culture )
		{
			//			return value;
			if ( value == null || parameter == null )
				return value;
			int offset = System . Convert . ToInt32 ( parameter );
			int currentvalue = System . Convert . ToInt32 ( value );
			//currentvalue -= offset;
			return currentvalue;
		}

		public object ConvertBack ( object value, Type targetType, object parameter, CultureInfo culture )
		{
			return value;
		}
	}
}
