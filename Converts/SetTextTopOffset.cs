using System;
using System . Globalization;
using System . Linq;
using System . Windows . Data;
namespace WPFPages . Converts
{
	public class SetTextTopOffset : IValueConverter
	{
		public object Convert ( object value, Type targetType, object parameter, CultureInfo culture )
		{
			double currentvalue = System . Convert . ToDouble ( value );
			//double pvalue = System . Convert . ToDouble ( parameter );
			Console . WriteLine ( $"Args received are {value}, {parameter}" );

			if ( parameter != null )
			{
				//string s = parameter . ToString ( );
				//double offset = (double)parameter;
				Console . WriteLine ( $"offset received is {parameter}" );
				return currentvalue ;//+ offset;
			}
			else
			{
				Console . WriteLine ( $"No offset received " );
				return currentvalue;
			}
			return value;
		}

		public object ConvertBack ( object value, Type targetType, object parameter, CultureInfo culture )
		{
			throw new NotImplementedException ( );
		}
	}


}
