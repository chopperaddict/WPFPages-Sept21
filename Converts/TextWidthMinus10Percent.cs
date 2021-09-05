using System;
using System . Globalization;
using System . Windows . Data;

namespace WPFPages . Converts
{
	public partial class TextWidthMinus10Percent : IValueConverter
	{
		public object Convert ( object value, Type targetType, object parameter, CultureInfo culture )
		{
			if ( value == null )
				return null;
			double  val = System . Convert . ToDouble ( value );
			if ( val == 0 )
				return value;
			if ( parameter != null )
			{
				if ( parameter . ToString ( ) != "" )
					return val - System . Convert . ToDouble( parameter );
				else
					return val;
			}
			else
			{
				double converter = ( val * 90 ) / 100;
				return converter;
			}
		}

		public object ConvertBack ( object value, Type targetType, object parameter, CultureInfo culture )
		{
			throw new NotImplementedException ( );
		}
	}
}
