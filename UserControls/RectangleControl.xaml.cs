using System . ComponentModel;
using System . Windows;
using System . Windows . Controls;
using System . Windows . Input;
using System . Windows . Media;
using System . Windows . Media . Effects;
using System . Windows . Shapes;

using WPFPages . Views;

namespace WPFPages . UserControls
{
	/// <summary>
	/// Interaction logic for RectangleControl.xaml
	/// </summary>
	public partial class RectangleControl : UserControl
	{
		public RectangleControl ( )
		{
			this . DataContext = this;
			InitializeComponent ( );
			//			BtnRectangle .Width = this . Width;
			//			BtnRectangle . Height = this . Height;

			//			RectButton. Height = this.ActualHeight;
			//			RectButton . Width = this.ActualWidth;

			//			RectButton . Height = this . Height;
			//			RectButton . Width= this . Width;
			//BtnText.Height =
			//this . Width = Double . NaN;

		}
		public LinearGradientBrush lgb
		{
			get; set;
		}
		//		private GradientDisplay gw = null;
		public bool Loading = true;
		private LinearGradientBrush brush1;
		public Rectangle Rect;
		public Point RectSize;
		public static Ellipse H2;
		public static Ellipse H3;
		//		private bool IsMouseOver = false;
		public Rectangle BtnRectangle
		{
			get; set;
		}
		public Thickness RectThickness
		{
			get; set;
		}
		public int GradientStyle
		{
			get
			{
				return 0;
			}
			set
			{
				GradientStyle = value;
				//				InvalidateVisual ( );
			}
		}


		public bool Startup = false;

		#region   colors for use in system
		//#############################
		public LinearGradientBrush Brush1
		{
			get
			{
				return brush1;
			}
			set
			{
				brush1 = value;
				OnPropertyChanged ( "Brush1" );
			}
		}
		//		private LinearGradientBrush brush2;
		public Brush BorderGreen;
		public Brush BorderYellow;
		public Brush BorderOrange;
		public Brush BorderBlue;
		public Brush BorderBlack;

		//#############################
		#endregion   colors for use in system
		//#############################


		//$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$//

		/*																									
		BtnText			
		BtnTextColor		
		FillSide			
		FillHole
		FillTop					 
		FontDecoration		 
		FontSize				 	
		TextSize
		
		  */


		#region  Dependencies
		//#############################

		#region BtnBorder
		/// <summary>
		/// Color of the border around the top surface of the button
		/// </summary>
		public Brush BtnBorder
		{
			get
			{
				return ( Brush ) GetValue ( BtnBorderProperty );
			}
			set
			{
				SetValue ( BtnBorderProperty, value );
				ButtonText . Refresh ( );
			}
			//set{}
		}
		public static readonly DependencyProperty BtnBorderProperty =
			DependencyProperty . Register ( "BtnBorder",
			typeof ( Brush ),
			typeof ( RectangleControl ),
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
				ButtonText . Refresh ( );
			}
			//set { }
		}
		public static readonly DependencyProperty BorderWidthProperty =
			DependencyProperty . Register ( "BorderWidth",
			typeof ( double ),
			typeof ( RectangleControl ),
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
				ButtonText . Refresh ( );
			}
			//set{}
		}
		public static readonly DependencyProperty BtnTextProperty =
			DependencyProperty . Register ( "BtnText",
			typeof ( string ),
			typeof ( RectangleControl ),
			new FrameworkPropertyMetadata ( "", new PropertyChangedCallback ( OnBtnTextChangedCallBack ) ) );
		private static void OnBtnTextChangedCallBack ( DependencyObject sender, DependencyPropertyChangedEventArgs e )
		{
			//			Console . WriteLine ( $"BtnText DP changed to [{ e . NewValue}]" );

			// Save width of our text to DP TextWidth 
			RectangleControl tc = sender as RectangleControl;
			string s = e . NewValue . ToString ( );
			tc . TextWidth = s . Length;

			//			Console . WriteLine ( $"BtnText changed - Width changed to [{ s . Length}]" );
			//			Console . WriteLine ( $"BtnText DP changed - Width changed to [{ s . Length}]" );
		}

		DependencyPropertyDescriptor BtnTextLength = DependencyPropertyDescriptor .
			    FromProperty ( RectangleControl . BtnTextProperty, typeof ( RectangleControl ) );
		#endregion

		#region BtnTextDown
		public string BtnTextDown
		{
			get
			{
				return ( string ) GetValue ( BtnTextDownProperty );
			}
			set
			{
				SetValue ( BtnTextDownProperty, value );
				ButtonText . Refresh ( );
			}
			//set{}
		}
		public static readonly DependencyProperty BtnTextDownProperty =
			DependencyProperty . Register ( "BtnTextDown",
			typeof ( string ),
			typeof ( RectangleControl ),
			new PropertyMetadata ( "" ) );
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
				ButtonText . Refresh ( );
			}
			//set{}
		}
		public static readonly DependencyProperty BtnTextColorProperty =
			DependencyProperty . Register ( "BtnTextColor",
			typeof ( Brush ),
			typeof ( RectangleControl ),
			new PropertyMetadata ( new SolidColorBrush ( Colors . Gray ) ) );
		#endregion

		#region BtnTextColorDown
		/// <summary>
		/// Color of the button Text when it is depressed
		/// </summary>
		public Brush BtnTextColorDown
		{
			get
			{
				return ( Brush ) GetValue ( BtnTextColorDownProperty );
			}
			set
			{
				SetValue ( BtnTextColorProperty, value );
				ButtonText . Refresh ( );
			}
			//set{}
		}
		public static readonly DependencyProperty BtnTextColorDownProperty =
			DependencyProperty . Register ( "BtnTextColorDown",
			typeof ( Brush ),
			typeof ( RectangleControl ),
			new PropertyMetadata ( new SolidColorBrush ( Colors . Black ) ) );
		#endregion

		#region ControlHeight
		/// <summary>
		/// Storage value for use elsewhere
		/// </summary>
		public int ControlHeight
		{
			get
			{
				return ( int ) GetValue ( ControlHeightProperty );
			}
			//set { }
			set
			{
				SetValue ( ControlHeightProperty, value );
				ButtonText . Refresh ( );
			}

		}
		public static readonly DependencyProperty ControlHeightProperty =
			DependencyProperty . Register ( "ControlHeight",
			typeof ( int ),
			typeof ( RectangleControl ),
			new FrameworkPropertyMetadata ( 75, new PropertyChangedCallback ( OnControlHeightChanged ) ) );

		private static void OnControlHeightChanged ( DependencyObject d, DependencyPropertyChangedEventArgs e )
		{
			Rectangle td = d as Rectangle;
			int height = ( int ) e . NewValue;
			//			if ( height < 100 )
			//				td . PressedBtnHeight -= 20;
		}

		#endregion

		#region ControlWidth
		/// <summary>
		/// Storage value for use elsewhere
		/// </summary>
		public int ControlWidth
		{
			get
			{
				return ( int ) GetValue ( ControlWidthProperty );
			}
			//set { }
			set
			{
				SetValue ( ControlWidthProperty, value );
				ButtonText . Refresh ( );
			}

		}
		public static readonly DependencyProperty ControlWidthProperty =
			DependencyProperty . Register ( "ControlWidth",
			typeof ( int ),
			typeof ( RectangleControl ),
			new PropertyMetadata ( ( int ) 100 ), OnControlWidthChanged );

		private static bool OnControlWidthChanged ( object value )
		{
			return true;
		}
		#endregion

		#region FillTop
		public Brush FillTop
		{
			get
			{
				this . Refresh ( );
				return ( Brush ) GetValue ( FillTopProperty );
			}
			set
			{
				SetValue ( FillTopProperty, value );
				ButtonText . Refresh ( );
			}
		}
		public static readonly DependencyProperty FillTopProperty =
			DependencyProperty . Register ( "FillTop",
			typeof ( Brush ),
			typeof ( RectangleControl ),
			new PropertyMetadata ( new SolidColorBrush ( Colors . Gray ), OnFillTopChangedCallBack ) );
		private static void OnFillTopChangedCallBack ( DependencyObject d, DependencyPropertyChangedEventArgs e )
		{
			RectangleControl tc = d as RectangleControl;

		}

		#endregion

		#region FillSide
		//NOT USED
		public Brush FillSide
		{
			get
			{
				return ( Brush ) GetValue ( FillSideProperty );
			}
			set
			{
				SetValue ( FillSideProperty, value );
				ButtonText . Refresh ( );
			}
			//set{}
		}
		public static readonly DependencyProperty FillSideProperty =
			DependencyProperty . Register ( "FillSide",
			typeof ( Brush ),
			typeof ( RectangleControl ),
			new PropertyMetadata ( new SolidColorBrush ( Colors . Transparent ) ), OnFillSideChangedCallBack );
		private static bool OnFillSideChangedCallBack ( object value )
		{
			//			Console . WriteLine ( $"FillSide Property changed to [{ value}]" );
			return value != null ? true : false;
		}
		#endregion

		#region FillHole
		public Brush FillHole
		{
			get
			{
				return ( Brush ) GetValue ( FillHoleProperty );
			}
			set
			{
				SetValue ( FillHoleProperty, value );
				ButtonText . Refresh ( );
			}
		}
		public static readonly DependencyProperty FillHoleProperty =
			DependencyProperty . Register ( "FillHole",
			typeof ( Brush ),
			typeof ( RectangleControl ),
			new PropertyMetadata ( new SolidColorBrush ( Colors . Transparent ) ), OnFillHoleChangedCallBack );
		private static bool OnFillHoleChangedCallBack ( object value )
		{
			//			Console . WriteLine ( $"FillHoleProperty changed to [{ value}]" );
			return value != null ? true : false;
		}
		#endregion

		#region FillShadow
		public Brush FillShadow
		{
			get
			{
				return ( Brush ) GetValue ( FillShadowProperty );
			}
			set
			{
				//value . Opacity = 250;
				SetValue ( FillShadowProperty, value );
				ButtonText . Refresh ( );
			}
		}
		public static readonly DependencyProperty FillShadowProperty =
			DependencyProperty . RegisterAttached ( "FillShadow",
			typeof ( Brush ),
			typeof ( RectangleControl ),
			new FrameworkPropertyMetadata ( new SolidColorBrush ( Colors . DarkSlateGray ), OnFillShadowChangedCallBack ) );

		private static void OnFillShadowChangedCallBack ( DependencyObject d, DependencyPropertyChangedEventArgs e )
		{
			RectangleControl tc = d as RectangleControl;
			//tc . FillHole . Opacity = (double) e . NewValue;
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
				ButtonText . Refresh ( );
			}
			//set{}
		}
		public static readonly DependencyProperty FontDecorationProperty =
			DependencyProperty . Register ( "FontDecoration",
			typeof ( string ),
			typeof ( RectangleControl ),
			new FrameworkPropertyMetadata ( "Normal", new PropertyChangedCallback ( OnFontDecorationChangedCallBack ) ) );

		private static void OnFontDecorationChangedCallBack ( DependencyObject sender, DependencyPropertyChangedEventArgs e )
		{
			//			Console . WriteLine ( $"FontDecoration Property changed to [{ value}]" );
			RectangleControl tc = sender as RectangleControl;
			//FontWeight fw = ( FontWeight)e . NewValue ;
			//tc . FontWeight = fw;

		}
		#endregion

		#region MouseoverColor
		public Brush MouseoverColor
		{
			get
			{
				return ( Brush ) GetValue ( MouseoverColorProperty );
			}
			set
			{
				SetValue ( MouseoverColorProperty, value );
				ButtonText . Refresh ( );
			}
		}
		public static readonly DependencyProperty MouseoverColorProperty =
			DependencyProperty . Register ( "MouseoverColor",
			typeof ( Brush ),
			typeof ( RectangleControl ),
			new PropertyMetadata ( new SolidColorBrush ( Colors . Transparent ) ), OnMouseoverColorPropertyChangedCallBack );
		private static bool OnMouseoverColorPropertyChangedCallBack ( object value )
		{
			//			Console . WriteLine ( $"FillHoleProperty changed to [{ value}]" );
			return value != null ? true : false;
		}
		#endregion

		#region PressedBtnHeight

		public int PressedBtnHeight
		{
			get
			{
				return ( int ) GetValue ( PressedBtnHeightProperty );
			}
			//set { }
			set
			{
				SetValue ( PressedBtnHeightProperty, value );
				ButtonText . Refresh ( );
			}

		}
		public static readonly DependencyProperty PressedBtnHeightProperty =
			DependencyProperty . Register ( "PressedBtnHeight",
			typeof ( int ),
			typeof ( RectangleControl ),
			new FrameworkPropertyMetadata ( 85 ) );
		#endregion

		#region RotateAngle
		public double RotateAngle
		{
			get
			{
				return ( double ) GetValue ( RotateAngleProperty );
			}
			//set { }
			set
			{
				SetValue ( RotateAngleProperty, value );
				ButtonText . Refresh ( );
			}
		}
		public static readonly DependencyProperty RotateAngleProperty =
			DependencyProperty . Register ( "RotateAngle",
			typeof ( double ),
			typeof ( RectangleControl ),
			new PropertyMetadata ( ( double ) 0 ), OnRotateAngleChanged );

		private static bool OnRotateAngleChanged ( object value )
		{
			//			Console . WriteLine ( $"RotateAngle  = {value}" );

			return true;
		}
		#endregion

		#region ShadowBlurColor
		public Color ShadowBlurColor
		{
			get
			{
				return ( Color ) GetValue ( ShadowBlurColorProperty );
			}
			set
			{
				SetValue ( ShadowBlurColorProperty, value );
				ButtonText . Refresh ( );
			}
			//set{}
		}
		public static readonly DependencyProperty ShadowBlurColorProperty =
			DependencyProperty . Register ( "ShadowBlurColor",
			typeof ( Color ),
			typeof ( RectangleControl ),
			new PropertyMetadata ( Colors . DarkGray ) );

		#endregion

		#region ShadowBlurRadius
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
				ButtonText . Refresh ( );
			}
		}
		public static readonly DependencyProperty ShadowBlurRadiusProperty =
			DependencyProperty . Register ( "ShadowBlurRadius",
			typeof ( double ),
			typeof ( RectangleControl ),
			new PropertyMetadata ( ( double ) 5 ), OnShadowBlurRadiusProperty );

		private static bool OnShadowBlurRadiusProperty ( object value )
		{
			return true;
		}
		#endregion

		#region ShadowBlurSize
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
				ButtonText . Refresh ( );
			}
		}
		public static readonly DependencyProperty ShadowBlurSizeProperty =
			DependencyProperty . Register ( "ShadowBlurSize",
			typeof ( double ),
			typeof ( RectangleControl ),
			new PropertyMetadata ( ( double ) 10 ), OnShadowBlurSizeProperty );

		private static bool OnShadowBlurSizeProperty ( object value )
		{
			//			Console . WriteLine ( $"ShadowBlurSizeProperty = {value}" );

			return true;
		}
		#endregion

		#region ShadowDepth
		public double ShadowDepth
		{
			get
			{
				return ( double ) GetValue ( ShadowDepthProperty );
			}
			//set { }
			set
			{
				SetValue ( ShadowDepthProperty, value );
				ButtonText . Refresh ( );
			}

		}
		public static readonly DependencyProperty ShadowDepthProperty =
			DependencyProperty . Register ( "ShadowDepth",
			typeof ( double ),
			typeof ( RectangleControl ),
			new PropertyMetadata ( ( double ) 0 ), OnShadowDepthPropertyChanged );

		private static bool OnShadowDepthPropertyChanged ( object value )
		{
			//			Console . WriteLine ( $"TextSize DP = {value}" );
			//RectangleControl . Refresh();
			return true;
		}
		#endregion

		#region ShadowDirection
		public double ShadowDirection
		{
			get
			{
				return ( double ) GetValue ( ShadowDirectionProperty );
			}
			//set { }
			set
			{
				SetValue ( ShadowDirectionProperty, value );
				ButtonText . Refresh ( );
			}

		}
		public static readonly DependencyProperty ShadowDirectionProperty =
			DependencyProperty . Register ( "ShadowDirection",
			typeof ( double ),
			typeof ( RectangleControl ),
			new PropertyMetadata ( ( double ) 0 ), OnShadowDirectionChanged );

		private static bool OnShadowDirectionChanged ( object value )
		{
			//			Console . WriteLine ( $"TextSize DP = {value}" );
			//RectangleControl . Refresh();
			return true;
		}
		#endregion

		#region ShadowOpacity
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
				ButtonText . Refresh ( );
			}

		}
		public static readonly DependencyProperty ShadowOpacityProperty =
			DependencyProperty . Register ( "ShadowOpacity",
			typeof ( double ),
			typeof ( RectangleControl ),
			new PropertyMetadata ( ( double ) 0.75 ), OnShadowOpacityProperty );

		private static bool OnShadowOpacityProperty ( object value )
		{
			//			Console . WriteLine ( $"ShadowOpacityProperty   = {value}" );

			return true;
		}
		#endregion

		#region ShowBorder
		public Visibility ShowBorder
		{
			get
			{
				return ( Visibility ) GetValue ( ShowBorderProperty );
			}
			set
			{
				SetValue ( ShowBorderProperty, value );
				ButtonText . Refresh ( );
			}
		}
		public static readonly DependencyProperty ShowBorderProperty =
			DependencyProperty . Register ( "ShowBorder",
			typeof ( Visibility ),
			typeof ( RectangleControl ),
			new PropertyMetadata ( Visibility . Visible ) );
		#endregion

		#region TextShadowDirection
		public double TextShadowDirection
		{
			get
			{
				return ( double ) GetValue ( TextShadowDirectionProperty );
			}
			//set { }
			set
			{
				SetValue ( TextShadowDirectionProperty, value );
				ButtonText . Refresh ( );
			}
		}
		public static readonly DependencyProperty TextShadowDirectionProperty =
			DependencyProperty . Register ( "TextShadowDirection",
			typeof ( double ),
			typeof ( RectangleControl ),
			new PropertyMetadata ( ( double ) 330 ), OnTextShadowDirectionPropertyProperty );

		private static bool OnTextShadowDirectionPropertyProperty ( object value )
		{
			return true;
		}
		#endregion

		#region TextShadowColor
		public Color TextShadowColor
		{
			get
			{
				return ( Color ) GetValue ( TextShadowColorProperty );
			}
			set
			{
				SetValue ( TextShadowColorProperty, value );
				ButtonText . Refresh ( );
			}
			//set{}
		}
		public static readonly DependencyProperty TextShadowColorProperty =
			DependencyProperty . Register ( "TextShadowColor",
			typeof ( Color ),
			typeof ( RectangleControl ),
			new PropertyMetadata ( Colors . DarkGray ) );

		#endregion

		#region TextShadowOpacity
		public double TextShadowOpacity
		{
			get
			{
				return ( double ) GetValue ( TextShadowOpacitProperty );
			}
			//set { }
			set
			{
				SetValue ( TextShadowOpacitProperty, value );
				//				InvalidateVisual ( );

			}

		}
		public static readonly DependencyProperty TextShadowOpacitProperty =
			DependencyProperty . Register ( "TextShadowOpacity",
			typeof ( double ),
			typeof ( RectangleControl ),
			new PropertyMetadata ( ( double ) 0.5 ), OnTextShadowOpacityProperty );

		private static bool OnTextShadowOpacityProperty ( object value )
		{
			return true;
		}
		#endregion

		#region TextShadowRadius
		public double TextShadowRadius
		{
			get
			{
				return ( double ) GetValue ( TextShadowRadiusProperty );
			}
			//set { }
			set
			{
				SetValue ( TextShadowRadiusProperty, value );
				ButtonText . Refresh ( );
			}
		}
		public static readonly DependencyProperty TextShadowRadiusProperty =
			DependencyProperty . Register ( "TextShadowRadius",
			typeof ( double ),
			typeof ( RectangleControl ),
			new PropertyMetadata ( ( double ) 1 ), OnTextShadowRadiusProperty );

		private static bool OnTextShadowRadiusProperty ( object value )
		{
			return true;
		}
		#endregion

		#region TextShadowSize
		public double TextShadowSize
		{
			get
			{
				return ( double ) GetValue ( TextShadowSizeProperty );
			}
			//set { }
			set
			{
				SetValue ( TextShadowSizeProperty, value );
				ButtonText . Refresh ( );
			}
		}
		public static readonly DependencyProperty TextShadowSizeProperty =
			DependencyProperty . Register ( "TextShadowSize",
			typeof ( double ),
			typeof ( RectangleControl ),
			new PropertyMetadata ( ( double ) 2 ), OnTextShadowSizePropertyProperty );

		private static bool OnTextShadowSizePropertyProperty ( object value )
		{
			//			Console . WriteLine ( $"ShadowBlurSizeProperty = {value}" );

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
			//set { }
			set
			{
				SetValue ( TextWidthScaleProperty, value );
				ButtonText . Refresh ( );
			}

		}
		public static readonly DependencyProperty TextWidthScaleProperty =
			DependencyProperty . Register ( "TextWidthScale",
			typeof ( double ),
			typeof ( RectangleControl ),
			new PropertyMetadata ( ( double ) 1 ), OnTextWidthScalePropertyChanged );

		private static bool OnTextWidthScalePropertyChanged ( object value )
		{
			//			Console . WriteLine ( $"TextWidthScaleProperty   = {value}" );
			return true;
		}
		#endregion

		#region TextHeight
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
				ButtonText . Refresh ( );
			}
		}
		public static readonly DependencyProperty TextHeightProperty =
			DependencyProperty . Register ( "TextHeight",
			typeof ( int ),
			typeof ( RectangleControl ),
			new PropertyMetadata ( 35 ), OnTextHeightPropertyPropertyChanged );

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

		#region TextSize
		/// <summary>
		/// Size of the button text
		/// </summary>
		public int TextSize
		{
			get
			{
				return ( int ) GetValue ( TextSizeProperty );
			}
			set
			{
				SetValue ( TextSizeProperty, value );
				ButtonText . Refresh ( );
			}
		}
		public static readonly DependencyProperty TextSizeProperty =
			DependencyProperty . Register ( "TextSize",
			typeof ( int ),
			typeof ( RectangleControl ),
			new PropertyMetadata ( 18 ), OnTextSizeChanged );

		private static bool OnTextSizeChanged ( object value )
		{
			return true;
		}
		#endregion

		#region TextWidth
		public double TextWidth
		{
			get
			{
				return ( double ) GetValue ( TextWidthProperty );
			}
			set
			{
				if ( value < 50 )
					value = 120;
				SetValue ( TextWidthProperty, value );
				ButtonText . Refresh ( );
			}
		}
		public static readonly DependencyProperty TextWidthProperty =
			DependencyProperty . Register ( "TextWidth",
			typeof ( double ),
			typeof ( RectangleControl ),
			new PropertyMetadata ( (double)85 ), OnTextWidthChanged );

		private static bool OnTextWidthChanged ( object value )
		{
			return true;
		}
		#endregion

		//#############################
		#endregion Dependencies
		//#############################

		#region PropertyChanged
		//#############################

		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged ( string propertyName )
		{
			PropertyChanged?.Invoke ( this, new PropertyChangedEventArgs ( propertyName ) );
			OnApplyTemplate ( );
			//	this . VerifyPropertyName ( propertyName );

			if ( this . PropertyChanged != null )
			{
				//				var e = new PropertyChangedEventArgs ( propertyName );
				//			this . PropertyChanged ( this , e );
			}
		}
		#endregion PropertyChanged

		private void RectBtn_Loaded ( object sender, RoutedEventArgs e )
		{
			//			object child = null;
			this . DataContext = this;


			// Set initial colors
			lgb = new LinearGradientBrush ( );
			Brush1 = ( LinearGradientBrush ) FindResource ( "Greenbackground" );
			BorderBlack = new SolidColorBrush ( Colors . Black );
			//			Rectangle dp = sender as Rectangle;
			//			Rect = dp;

			//Save size of button rectangle
			RectThickness = RectBtn . Margin;

			// Increase size of ~"Shadow"
			//Thickness thickness = new Thickness ( );
			//thickness = RectBtn . Margin;
			//thickness . Left += 8;
			//thickness . Right += 8;
			//thickness . Top += 8;
			//thickness . Bottom += 8;
			//BtnHol . Margin = thickness;

			Thickness thickness = new Thickness ( );
			thickness = ButtonText . Margin;
			thickness . Top -= 10;
			ButtonText . Margin = thickness;
			//			BtnHol . RadiusX = 11;
			//			BtnHol . RadiusY = 11;

			//ControlWidth = RectBtn.ActualWidth;
			//TextWidth = (int)ActualWidth - 20;
			RectBtn . Fill = FillTop;
			if ( BtnTextDown == "" )
				BtnTextDown = BtnText;
			//			Console . WriteLine ( $"Rectangle RecBtn_Loaded W*H = {RectBtn . ActualWidth} . {RectBtn . ActualHeight}" );

		}

		/// <summary>
		/// Change color of the Text on mouseover
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void RectBtn_MouseEnter ( object sender, MouseEventArgs e )
		{
			// Move button & Text Right and Down
			TranslateTransform translateTransform = new TranslateTransform ( );
			translateTransform . X += 2;
			translateTransform . Y -= 1;
			RectBtn . RenderTransform = translateTransform;
			ButtonText . RenderTransform = translateTransform;

			// Move Shadow to match above
			DropShadowEffect dropShadowEffect = new DropShadowEffect ( );
			dropShadowEffect . BlurRadius = ShadowBlurRadius;
			dropShadowEffect . Color = ShadowBlurColor;
			dropShadowEffect . Direction = 235;
			dropShadowEffect . Opacity = ShadowOpacity;
			dropShadowEffect . ShadowDepth = ShadowBlurSize;

			RectBtn . Effect = dropShadowEffect;
			RectBtn . Fill = MouseoverColor;
			RectBtn . Refresh ( );
			return;
		}

		private void RectBtn_MouseLeave ( object sender, MouseEventArgs e )
		{
			TranslateTransform translateTransform = new TranslateTransform ( );
			RectBtn . Margin = RectThickness;
			translateTransform . X -= 2;
			translateTransform . Y += 1;
			ButtonText . RenderTransform = translateTransform;
			RectBtn . RenderTransform = translateTransform;

			DropShadowEffect dropShadowEffect = new DropShadowEffect ( );
			dropShadowEffect . BlurRadius = ShadowBlurRadius;
			dropShadowEffect . Color = ShadowBlurColor;
			dropShadowEffect . Direction = 49;
			dropShadowEffect . Opacity = ShadowOpacity;
			dropShadowEffect . ShadowDepth = ShadowBlurSize;
			RectBtn . Effect = dropShadowEffect;
			RectBtn . Fill = FillTop;
			RectBtn . Refresh ( );
			return;
		}

		public override void OnApplyTemplate ( )
		{
			base . OnApplyTemplate ( );


			if ( Template != null )
			{
				var v = this . GetTemplateChild ( "RectBtn" );
				//				Console . WriteLine ( $"v = {v}" );
			}
			return;
		}
		private void ReportStatus ( )
		{
			//Console . WriteLine ( $"REPORT On Loading : \n"
			//	+ $" BtnText		: {BtnText}\n"
			//	+ $" BtnTextColor	: {BtnTextColor}\n"
			//	+ $" FontSize		: {FontSize}\n"
			//	+ $" FontDecoration	:	{FontDecoration}\n" +
			//	   $" FillTop	: {FillTop . ToString ( )}\n" +
			//	   $" FillSide	: {FillSide . ToString ( )}\n" +
			//	   $" FillHole	: {FillHole?.ToString ( )}\n"
			//	   );


		}

		// How to allow a click event from Usercontrol  to get back to  "Click" in client app
		//public event RoutedEventHandler MouseLeftButtonDown;
		//void OnMouseLeftButtonDown ( object sender, RoutedEventArgs e )
		//{
		//	if ( this . MouseLeftButtonDown != null )
		//	{
		//		this . MouseLeftButtonDown ( this, e );
		//	}
		//}
		/// <summary>
		/// iterate thru a object to find controls ?
		/// </summary>
		/// <param name="sender"></param>
		private void GetData ( object sender )
		{
			var element = sender as FrameworkElement;
			var cp = this . FindName ( "Btn6Content" );
			var v = element as RectangleControl;
		}

		private void RectangularButton_Loaded ( object sender, RoutedEventArgs e )
		{
			RectangleControl rb = sender as RectangleControl;

			//You can use this format almost anywhere to change a Dependency Poperty
			//			SetValue ( BtnTextProperty, "here ya go !" );
		}

	}

}
