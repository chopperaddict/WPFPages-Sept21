using System;
using System . Collections . Generic;
using System . ComponentModel;
using System . Linq;
using System . Text;
using System . Threading . Tasks;
using System . Windows;
using System . Windows . Controls;
using System . Windows . Controls . Primitives;
using System . Windows . Data;
using System . Windows . Documents;
using System . Windows . Input;
using System . Windows . Media;
using System . Windows . Media . Effects;
using System . Windows . Media . Imaging;
using System . Windows . Navigation;
using System . Windows . Shapes;

using WPFPages . Views;

namespace WPFPages . UserControls
{
	/// <summary>
	/// Interaction logic for ImgButton.xaml
	/// </summary>
	public partial class ImgButton : UserControl
	{
		DropShadowEffect DropShadEffect = new DropShadowEffect ( );
		public ImgButton ( )
		{
			this . DataContext = this;
			InitializeComponent ( );
			//DependencyPropertyDescriptor BtnTextLength = DependencyPropertyDescriptor .
			//	    FromProperty ( ImgButton . BtnTextProperty, typeof ( TextBlock ) );
			//if ( BtnTextLength != null )
			//{
			//	BtnTextLength . AddValueChanged ( BtnTextBlock, OnBtnTextChanged );
			//}
		}

		public  void ImgButton_Click ( object sender )
		{
			int x = 0;
		}

		//private void OnBtnTextChanged ( object sender, EventArgs e )
		//{
		//	Console . WriteLine ($"Button Text changed to [{e.ToString()}]");
		//}

		#region BackColor
		public Brush BackColor
		{
			get
			{
				this . Refresh ( );
				return ( Brush ) GetValue ( BackColorProperty );
			}
			set
			{
				SetValue ( BackColorProperty, value );
				this. Refresh ( );
			}
		}
		public static readonly DependencyProperty BackColorProperty =
			DependencyProperty . Register ( "BackColor",
			typeof ( Brush ),
			typeof ( ImgButton ),
			new PropertyMetadata ( new SolidColorBrush ( Colors . Gray ), OnBackColorChangedCallBack ) );
		private static void OnBackColorChangedCallBack ( DependencyObject d, DependencyPropertyChangedEventArgs e )
		{

		}

		#endregion

		#region BorderColor
		/// <summary>
		/// Color of the border around the top surface of the button
		/// </summary>
		public Brush BorderColor
		{
			get
			{
				return ( Brush ) GetValue ( BorderColorProperty );
			}
			set
			{
				SetValue ( BorderColorProperty, value );
				InvalidateVisual ( );
			}
			//set{}
		}
		public static readonly DependencyProperty BorderColorProperty =
			DependencyProperty . Register ( "BorderColor",
			typeof ( Brush ),
			typeof ( ImgButton),
			new PropertyMetadata ( new SolidColorBrush ( Colors . Transparent ) ) );
		#endregion

		#region BorderWidth
		/// <summary>
		/// Width of the border line around the top of the button
		/// </summary>
		public double BorderWidth
		{
			get
			{
				return ( double ) GetValue ( BorderWidthProperty );
			}
			set
			{
				SetValue ( BorderWidthProperty, value );
				InvalidateVisual ( );
			}
			//set { }
		}
		public static readonly DependencyProperty BorderWidthProperty =
			DependencyProperty . Register ( "BorderWidth",
			typeof ( double ),
			typeof ( ImgButton ),
			new PropertyMetadata ( ( double ) 0 ) );

		#endregion


		#region BtnText
		public string BtnText
		{
			get
			{
				return ( string ) GetValue ( BtnTextProperty );
			}
			set
			{
				SetValue ( BtnTextProperty, value );
				this . Refresh ( );
			}
			//set{}
		}
		public static readonly DependencyProperty BtnTextProperty =
			DependencyProperty . Register ( "BtnText",
			typeof ( string ),
			typeof ( ImgButton ),
			new FrameworkPropertyMetadata ( "", new PropertyChangedCallback ( OnBtnTextChangedCallBack ) ) );
		private static void OnBtnTextChangedCallBack ( DependencyObject sender, DependencyPropertyChangedEventArgs e )
		{
			Console . WriteLine ( $"BtnText set to  [{e.NewValue}] in changed handler." );
		}
		#endregion

		#region BtnTextColor
		/// <summary>
		/// Color pf the text with button at rest
		/// </summary>
		public Brush BtnTextColor
		{
			get
			{
				return ( Brush ) GetValue ( BtnTextColorProperty );
			}
			set
			{
				SetValue ( BtnTextColorProperty, value );
				this . Refresh ( );
			}
			//set{}
		}
		public static readonly DependencyProperty BtnTextColorProperty =
			DependencyProperty . Register ( "BtnTextColor",
			typeof ( Brush ),
			typeof ( ImgButton ),
			new PropertyMetadata ( new SolidColorBrush ( Colors . Black ) ) );
		#endregion



		#region Cornerradius
		/// <summary>
		/// Size of the button text we store for use elsewhere
		/// </summary>
		public CornerRadius Cornerradius
		{
			get
			{
				return ( CornerRadius ) GetValue ( CornerradiusProperty );
			}
			set
			{
				SetValue ( CornerradiusProperty, value );
				Mainborder . Refresh ( );
			}
			//set{}
		}
		public static readonly DependencyProperty CornerradiusProperty =
			DependencyProperty . Register ( "Cornerradius",
			typeof ( CornerRadius ),
			typeof ( ImgButton ),
			new PropertyMetadata ( default ), OnCornerradiusPropertyChanged );

		private static bool OnCornerradiusPropertyChanged ( object value )
		{
			//int val = Convert . ToInt32 ( value );
			//Console . WriteLine ( $"TextWidth received = {value}" );
			//if ( val < 100 )
			//{
			//	value = 120 as object;
			//	val = 120;
			//}
			//Console . WriteLine ( $"TextWidth returned = {val}" );
			return true;
		}
		#endregion

		#region FontDecoration
		/// <summary>
		/// Font Styling option - Typically Normal, Italic, Oblique
		/// </summary>
		public string FontDecoration
		{
			get
			{
				return ( string ) GetValue ( FontDecorationProperty );
			}
			set
			{
				SetValue ( FontDecorationProperty, value );
				InvalidateVisual ( );
			}
			//set{}
		}
		public static readonly DependencyProperty FontDecorationProperty =
			DependencyProperty . Register ( "FontDecoration",
			typeof ( string ),
			typeof ( ImgButton ),
			new FrameworkPropertyMetadata ( "Normal", new PropertyChangedCallback ( OnFontDecorationChangedCallBack ) ) );

		private static void OnFontDecorationChangedCallBack ( DependencyObject sender, DependencyPropertyChangedEventArgs e )
		{
			//			Console . WriteLine ( $"FontDecoration Property changed to [{ value}]" );
			RectangleControl tc = sender as RectangleControl;
			//FontWeight fw = ( FontWeight)e . NewValue ;
			//tc . FontWeight = fw;

		}
		#endregion

		#region ImgWidth
		public double ImgWidth
		{
			get
			{
				return ( double ) GetValue ( ImgWidthProperty );
			}
			set
			{
				SetValue ( ImgWidthProperty, value );
				this . Refresh ( );
				//BtnImage . UpdateLayout( );
			}
		}
		public static readonly DependencyProperty ImgWidthProperty =
			DependencyProperty . Register ( "ImgWidth",
			typeof ( double ),
			typeof ( ImgButton ),
			new FrameworkPropertyMetadata ( ( double ) 35, new PropertyChangedCallback ( OnWidthChangedCallBack ) ) );

		private static void OnWidthChangedCallBack ( DependencyObject d, DependencyPropertyChangedEventArgs e )
		{
			Console . WriteLine ( $"ImageWidth set to  [{e . NewValue}] in changed handler." );
		}
		#endregion

		#region ShadowOpacity
		/// <summary>
		/// Set the opacity of the button shadow values = 0-1
		/// </summary>
		public double ShadowOpacity
		{
			get
			{
				return ( double ) GetValue ( ShadowOpacityProperty );
			}
			//set { }
			set
			{
				SetValue ( ShadowOpacityProperty, value );
				//				InvalidateVisual ( );

			}

		}
		public static readonly DependencyProperty ShadowOpacityProperty =
			DependencyProperty . Register ( "ShadowOpacity",
			typeof ( double ),
			typeof ( ImgButton ),
			new PropertyMetadata ( ( double ) 0.75 ), OnShadowOpacityProperty );

		private static bool OnShadowOpacityProperty ( object value )
		{
			//			Console . WriteLine ( $"ShadowOpacityProperty   = {value}" );

			return true;
		}
		#endregion

		#region ShadowBlurSize
		/// <summary>
		/// Set the opacity of the button shadow values = 0-1
		/// </summary>
		public double ShadowBlurSize
		{
			get
			{
				return ( double ) GetValue ( ShadowBlurSizeProperty );
			}
			//set { }
			set
			{
				SetValue ( ShadowBlurSizeProperty, value );
				InvalidateVisual ( );
			}
		}
		public static readonly DependencyProperty ShadowBlurSizeProperty =
			DependencyProperty . Register ( "ShadowBlurSize",
			typeof ( double ),
			typeof ( ImgButton ),
			new PropertyMetadata ( ( double ) 10 ), OnShadowBlurSizeProperty );

		private static bool OnShadowBlurSizeProperty ( object value )
		{
			//			Console . WriteLine ( $"ShadowBlurSizeProperty = {value}" );

			return true;
		}
		#endregion

		#region ShadowBlurRadius
		/// <summary>
		/// Set the Radius of the button shadow values = 0-1
		/// </summary>
		public double ShadowBlurRadius
		{
			get
			{
				return ( double ) GetValue ( ShadowBlurRadiusProperty );
			}
			//set { }
			set
			{
				SetValue ( ShadowBlurRadiusProperty, value );
				InvalidateVisual ( );
				Mainborder . Refresh ( );
				this . Refresh ( );
			}
		}
		public static readonly DependencyProperty ShadowBlurRadiusProperty =
			DependencyProperty . Register ( "ShadowBlurRadius",
			typeof ( double ),
			typeof ( ImgButton ),
			new PropertyMetadata ( ( double ) 5 ), OnShadowBlurRadiusProperty );

		private static bool OnShadowBlurRadiusProperty ( object value )
		{
			return true;
		}
		#endregion

		#region ShadowBlurColor

		/// <summary>
		/// Color of the border around the top surface of the button
		/// </summary>
		public Color ShadowBlurColor
		{
			get
			{
				return ( Color ) GetValue ( ShadowBlurColorProperty );
			}
			set
			{
				SetValue ( ShadowBlurColorProperty, value );
			}
			//set{}
		}
		public static readonly DependencyProperty ShadowBlurColorProperty =
			DependencyProperty . Register ( "ShadowBlurColor",
			typeof ( Color ),
			typeof ( ImgButton ),
			new PropertyMetadata ( Colors . DarkGray ) );

		#endregion

		#region TextSize
		/// <summary>
		/// Size of the button text
		/// </summary>
		public int TextSize
		{
			get
			{
				return ( int) GetValue ( TextSizeProperty );
			}
			//set { }
			set
			{
				SetValue ( TextSizeProperty, value );
				this . Refresh ( );
			}

		}
		public static readonly DependencyProperty TextSizeProperty =
			DependencyProperty . Register ( "TextSize",
			typeof ( int),
			typeof ( ImgButton ),
			new PropertyMetadata ( (int)18 ), OnTextSizeChanged );

		private static bool OnTextSizeChanged ( object value )
		{
			//			Console . WriteLine ( $"TextSize DP = {value}" );
			return true;
		}
		#endregion

		#region TextWidth
		/// <summary>
		/// Size of the button text we store for use elsewhere
		/// </summary>
		public int TextWidth
		{
			get
			{
				return ( int ) GetValue ( TextWidthProperty );
			}
			set
			{
				if ( value < 50 )
					value = 120;
				SetValue ( TextWidthProperty, value );
				this . Refresh ( );
			}
			//set{}
		}
		public static readonly DependencyProperty TextWidthProperty =
			DependencyProperty . Register ( "TextWidth",
			typeof ( int ),
			typeof ( ImgButton ),
			new PropertyMetadata ( default ), OnTextWidthChanged );

		private static bool OnTextWidthChanged ( object value )
		{
			//int val = Convert . ToInt32 ( value );
			//Console . WriteLine ( $"TextWidth received = {value}" );
			//if ( val < 100 )
			//{
			//	value = 120 as object;
			//	val = 120;
			//}
			//Console . WriteLine ( $"TextWidth returned = {val}" );
			return true;
		}
		#endregion

		#region TextHeight
		/// <summary>
		/// Size of the button text we store for use elsewhere
		/// </summary>
		public int TextHeight
		{
			get
			{
				return ( int ) GetValue ( TextHeightProperty );
			}
			set
			{
				if ( value < 50 )
					value = 120;
				SetValue ( TextHeightProperty, value );
				this . Refresh ( );
			}
			//set{}
		}
		public static readonly DependencyProperty TextHeightProperty =
			DependencyProperty . Register ( "TextHeight",
			typeof ( int ),
			typeof ( ImgButton ),
			new PropertyMetadata ( 40 ), OnTextHeightPropertyPropertyChanged );

		private static bool OnTextHeightPropertyPropertyChanged ( object value )
		{
			//int val = Convert . ToInt32 ( value );
			//Console . WriteLine ( $"TextWidth received = {value}" );
			//if ( val < 100 )
			//{
			//	value = 120 as object;
			//	val = 120;
			//}
			//Console . WriteLine ( $"TextWidth returned = {val}" );
			return true;
		}
		#endregion

		#region TextHeightScale
		/// <summary>
		/// Set to a value of  -x to +x to shrink or stretch text on a button
		/// normally range is between 0 & 1
		/// </summary>
		public double TextHeightScale
		{
			get
			{
				return ( double ) GetValue ( TextHeightScaleProperty );
			}
			//set { }
			set
			{
				SetValue ( TextHeightScaleProperty, value );
				this . Refresh ( );
			}

		}
		public static readonly DependencyProperty TextHeightScaleProperty =
			DependencyProperty . Register ( "TextHeightScale",
			typeof ( double ),
			typeof ( AnimationTest ),
			new PropertyMetadata ( ( double ) 1.0 ), OnTextHeightScalePropertyPropertyChanged );

		private static bool OnTextHeightScalePropertyPropertyChanged ( object value )
		{
			return true;
		}
		#endregion

		#region TextWidthScale
		/// <summary>
		/// Set to a value of  -x to +x to shrink or stretch text on a button
		/// normally range is between 0 & 1
		/// </summary>
		public double TextWidthScale
		{
			get
			{
				return ( double ) GetValue ( TextWidthScaleProperty );
			}
			set
			{
				SetValue ( TextWidthScaleProperty, value );
				this . Refresh ( );

			}

		}
		public static readonly DependencyProperty TextWidthScaleProperty =
			DependencyProperty . Register ( "TextWidthScale",
			typeof ( double ),
			typeof ( ImgButton ),
			new PropertyMetadata ( ( double ) 1 ), OnTextWidthScalePropertyChanged );

		private static bool OnTextWidthScalePropertyChanged ( object value )
		{
			//			Console . WriteLine ( $"TextWidthScaleProperty   = {value}" );
			return true;
		}
		#endregion

		#region Url
		/// <summary>
		/// The Text to be displayed on the button at rest (See Button Down option below)
		/// </summary>
		public string Url
		{
			get
			{
				return ( string ) GetValue ( UrlProperty );
			}
			set
			{
				SetValue ( UrlProperty, value );
				this . Refresh ( );
			}
			//set{}
		}
		public static readonly DependencyProperty UrlProperty =
			DependencyProperty . Register ( "Url",
			typeof ( string ),
			typeof ( ImgButton ),
			new FrameworkPropertyMetadata ( "", new PropertyChangedCallback ( OnUrlChangedCallBack ) ) );
		private static void OnUrlChangedCallBack ( DependencyObject sender, DependencyPropertyChangedEventArgs e )
		{
			Console . WriteLine ( $"Url DP changed - Image set to [{ e . NewValue}]" );
		}

		DependencyPropertyDescriptor BtnTextLength = DependencyPropertyDescriptor .
			    FromProperty ( ImgButton . BtnTextProperty, typeof ( ImgButton ) );
		#endregion

		#region TextWrap
		public TextWrapping TextWrap
		{
			get
			{
				return ( TextWrapping ) GetValue ( TextWrapProperty );
			}
			set
			{
				SetValue ( TextWrapProperty, value );
				this . Refresh ( );
				//BtnImage . UpdateLayout( );
			}
		}
		public static readonly DependencyProperty TextWrapProperty =
			DependencyProperty . Register ( "TextWrap",
			typeof ( TextWrapping ),
			typeof ( ImgButton ),
			new FrameworkPropertyMetadata ( TextWrapping.NoWrap , new PropertyChangedCallback ( OnTextWrapPropertyChangedCallBack ) ) );

		private static void OnTextWrapPropertyChangedCallBack ( DependencyObject d, DependencyPropertyChangedEventArgs e )
		{
			Console . WriteLine ( $"OnTextWrap set to  [{e . NewValue}] in changed handler." );
		}
		#endregion

		private void RectBtn_MouseEnter ( object sender, MouseEventArgs e )
		{
			// Move button & Text Right and Down
			TranslateTransform translateTransform = new TranslateTransform ( );
			translateTransform . X += 2;
			translateTransform . Y -= 1;
			OuterGrid . RenderTransform = translateTransform;
			
			// Move Shadow to match above
			DropShadowEffect dropShadowEffect = new DropShadowEffect ( );
			dropShadowEffect . BlurRadius = ShadowBlurRadius;
			dropShadowEffect . Color = ShadowBlurColor;
			dropShadowEffect . Direction = 235;
			dropShadowEffect . Opacity = ShadowOpacity;
			dropShadowEffect . ShadowDepth = ShadowBlurSize;

			OuterGrid . Effect = dropShadowEffect;
			OuterGrid . Refresh ( );
			return;
		}

		private void RectBtn_MouseLeave ( object sender, MouseEventArgs e )
		{
			TranslateTransform translateTransform = new TranslateTransform ( );
			translateTransform . X -= 2;
			translateTransform . Y += 1;
			OuterGrid . RenderTransform = translateTransform;

			DropShadowEffect dropShadowEffect = new DropShadowEffect ( );
			dropShadowEffect . BlurRadius = ShadowBlurRadius;
			dropShadowEffect . Color = ShadowBlurColor;
			dropShadowEffect . Direction = 49;
			dropShadowEffect . Opacity = ShadowOpacity;
			dropShadowEffect . ShadowDepth = ShadowBlurSize;
			OuterGrid . Effect = dropShadowEffect;
			OuterGrid . Refresh ( );
			return;
		}

		//public event EventHandler ImgBtnClick;
		//public delegate void ImgButton_Clicked ( object sender );
		//private void ImgBtnClick_Clicked ( object sender, EventArgs e )
		//{
		//	if ( ImgBtnClick != null )
		//	{
		//		ImgButton_Clicked ( this );
		//	}
		//}
	}
}
