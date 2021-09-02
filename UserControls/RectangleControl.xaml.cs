using System;
using System . ComponentModel;
using System . Runtime . CompilerServices;
using System . Windows;
using System . Windows . Controls;
using System . Windows . Input;
using System . Windows . Media;
using System . Windows . Media . Effects;
using System . Windows . Media . Media3D;
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
		#region BtnText
		/// <summary>
		/// The Text to be displayed on the button at rest (See Button Down option below)
		/// </summary>
		public string BtnText
		{
			get
			{
				return ( string ) GetValue ( BtnTextProperty );
			}
			set
			{
				SetValue ( BtnTextProperty, value );
				InvalidateVisual ( );
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
		/// <summary>
		/// Text for button when it has  the Mouse over it
		/// </summary>
		public string BtnTextDown
		{
			get
			{
				return ( string ) GetValue ( BtnTextDownProperty );
			}
			set
			{
				SetValue ( BtnTextDownProperty, value );
			}
			//set{}
		}
		public static readonly DependencyProperty BtnTextDownProperty =
			DependencyProperty . Register ( "BtnTextDown",
			typeof ( string ),
			typeof ( RectangleControl ),
			new PropertyMetadata ( "" ) );
		#endregion

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
				InvalidateVisual ( );
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
		public double  BorderWidth
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
			typeof ( RectangleControl ),
			new PropertyMetadata ( ( double ) 0 ));

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
				RectangularButton . Refresh ( );
				this . Refresh ( );
			}
			//set{}
		}
		public static readonly DependencyProperty BtnTextColorProperty =
			DependencyProperty . Register ( "BtnTextColor",
			typeof ( Brush ),
			typeof ( RectangleControl ),
			new PropertyMetadata ( new SolidColorBrush ( Colors . Black ) ) );
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
		public int  ControlHeight
		{
			get
			{
				return ( int) GetValue ( ControlHeightProperty );
			}
			//set { }
			set
			{
				SetValue ( ControlHeightProperty, value );
			}

		}
		public static readonly DependencyProperty ControlHeightProperty =
			DependencyProperty . Register ( "ControlHeight",
			typeof ( int),
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
				return ( int) GetValue ( ControlWidthProperty );
			}
			//set { }
			set
			{
				SetValue ( ControlWidthProperty, value );
			}

		}
		public static readonly DependencyProperty ControlWidthProperty =
			DependencyProperty . Register ( "ControlWidth",
			typeof ( int),
			typeof ( RectangleControl ),
			new PropertyMetadata ( (int)100 ), OnControlWidthChanged );

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
				RectangularButton . Refresh ( );
				InvalidateVisual ( );
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
				this . Refresh ( );
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
				RectangularButton . Refresh ( );
				this . Refresh ( );
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
				this . Refresh ( );
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
				RectangularButton . Refresh ( );
				this . Refresh ( );
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
			}

		}
		public static readonly DependencyProperty PressedBtnHeightProperty =
			DependencyProperty . Register ( "PressedBtnHeight",
			typeof ( int ),
			typeof ( RectangleControl ),
			new FrameworkPropertyMetadata ( 85) );
		#endregion

		#region RotateAngle
		/// <summary>
		/// Set the angle of the text across the button 0 - 359
		/// </summary>
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
				//				InvalidateVisual ( );

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
			typeof ( RectangleControl ),
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
			typeof ( RectangleControl ),
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
				RectangularButton . Refresh ( );
				this . Refresh ( );
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
			typeof ( RectangleControl ),
			new PropertyMetadata ( Colors . DarkGray ) );

		#endregion

		#region ShowBorder
		/// <summary>
		/// Show or hide the side border that gives button a more 3D effect
		/// </summary>
		public Visibility ShowBorder
		{
			get
			{
				return ( Visibility ) GetValue ( ShowBorderProperty );
			}
			set
			{
				SetValue ( FillHoleProperty, value );
				RectangularButton . Refresh ( );
				this . Refresh ( );
			}
		}
		public static readonly DependencyProperty ShowBorderProperty =
			DependencyProperty . Register ( "ShowBorder",
			typeof ( Visibility ),
			typeof ( RectangleControl ),
			new PropertyMetadata ( Visibility . Visible ) );
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
				InvalidateVisual ( );

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
			//set { }
			set
			{
				SetValue ( TextSizeProperty, value );
				this . Refresh ( );
			}

		}
		public static readonly DependencyProperty TextSizeProperty =
			DependencyProperty . Register ( "TextSize",
			typeof ( int ),
			typeof ( RectangleControl ),
			new PropertyMetadata ( 18 ), OnTextSizeChanged );

		private static bool OnTextSizeChanged ( object value )
		{
//			Console . WriteLine ( $"TextSize DP = {value}" );
			//RectangleControl . Refresh();
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
				InvalidateVisual ( );
			}
			//set{}
		}
		public static readonly DependencyProperty TextWidthProperty =
			DependencyProperty . Register ( "TextWidth",
			typeof ( int ),
			typeof ( RectangleControl ),
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
