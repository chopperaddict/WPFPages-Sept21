//#define TESTING

using System;
using System . Collections;
using System . Collections . Generic;
using System . Diagnostics;
using System . Dynamic;
using System . IO;
using System . Linq;
using System . Text;
using System . Threading;
using System . Threading . Tasks;
using System . Timers;
using System . Windows;
using System . Windows . Controls;
using System . Windows . Data;
using System . Windows . Documents;
using System . Windows . Input;
using System . Windows . Media;
using System . Windows . Media . Animation;
using System . Windows . Media . Imaging;
using System . Windows . Shapes;
using System . Windows . Threading;

using WPFPages . UserControls;

using static System . Net . Mime . MediaTypeNames;


namespace WPFPages . Views
{
	/// <summary>
	/// Interaction logic for AnimationTe.xaml
	/// </summary>
	public partial class AnimationTest : Window
	{
		static int counter = 1;
		private Point MousePosition = new Point ( 0, 0 );
		private bool MouseDn = false;
		private int defaultMenuheight = 0;
		private bool IsMenuOpen
		{
			get; set;
		}
		private bool Menu1Open
		{
			get; set;
		}
		private bool Menu2Open
		{
			get; set;
		}
		private bool Menu3Open
		{
			get; set;
		}
		private bool Menu4Open
		{
			get; set;
		}
		private bool Menu5Open
		{
			get; set;
		}
		private bool Menu6Open
		{
			get; set;
		}
		private bool Menu7Open
		{
			get; set;
		}

		DispatcherTimer timer = new( );

		private long _timercount;

		public long timercount 
		{

			get{return (long)_timercount;}
			set{_timercount = value;}
		}
		#region Full Properties
		private string menuOpenText = "Hide Menu Options";
		public string MenuOpenText
		{
			get
			{
				return menuOpenText;
			}
			set
			{
				menuOpenText = value;
			}
		}

		private string menu0Text = "Open 3D Buttons Panel";
		public string Menu0Text
		{
			get{return menu0Text;}
			set{menu0Text = value;}
		}
		private string menu1Text = "Open Panel 1";
		public string Menu1Text
		{
			get
			{
				return menu1Text;
			}
			set
			{
				menu1Text = value;
			}
		}
		private string menu2Text = "Image Button Panel";
		public string Menu2Text
		{
			get{return menu2Text;}
			set{menu2Text = value;}
		}
		private string menu3Text = "Open Panel 3";
		public string Menu3Text
		{
			get
			{
				return menu3Text;
			}
			set
			{
				menu3Text = value;
			}
		}

		private string menu4Text = "Tab Control Panel";
		
		public string Menu4Text
		{
			get
			{
				return menu4Text;
			}
			set
			{
				menu4Text = value;
			}
		}
		private string menu5Text = "3D Button Panel"; 
		public string Menu5Text
		{
			get
			{
				return menu5Text;
			}
			set
			{
				menu5Text = value;
			}
		}

		private string menu6Text = "Panel 2";
		public string Menu6Text
		{
			get
			{
				return menu6Text;
			}
			set
			{
				menu6Text = value;
			}
		}

		private string menu7Text = "Close All Panels";
		public string Menu7Text
		{
			get
			{
				return menu7Text;
			}
			set
			{
				menu7Text = value;
			}
		}
		#endregion

		#region Dummy strings
		private string dummymenutext1 = "\n3D Buttons ";
		private string dummymenutext2 = "\njust uses the Width property of the image but the values of the From [the Width property of the image but the values of the From] ... ";
		private string dummymenutext3 = "\n\nthe Completed event handler to restart the animation... ";
		private string dummymenutext4 = "\n\nI have created an application which displays... ";
		private string dummymenutext5 = "\n\nhe above code initially creates a rectangle... ";
		private string dummymenutext6 = "\n\nFollowing is the output of the above code:... ";
		private string dummymenutext7 = "\n\nThe Very End....";
		#endregion
		public AnimationTest ( )
		{
			InitializeComponent ( );
			Utils . SetupWindowDrag ( this );
			Storyboard s = ( Storyboard ) TryFindResource ( "HideLeftMenu" );
			s . Begin ( );
			LeftMenuTogglePanel . Opacity = 0.0;
			timercount = 0L;
			timer . Interval = TimeSpan . FromMilliseconds ( 1 );
			timer . Tick += Timer_Tick;
			timer . Start ( );
			//DoErrorBeep ( 280, 100, 3 );
		}

		private void Timer_Tick ( object sender, EventArgs e )
		{
			// this is called every millisecond by dispatchTimer
			if ( timercount >= long. MaxValue )
				timercount = 0;
			timercount++;
//			Console . WriteLine ( $"{timercount}" );
		}

		public class PointAnimationExample : Page
		{
			//public PointAnimationExample ( )
			//{
			//      // Create a NameScope for this page so that
			//      // Storyboards can be used.
			//      NameScope . SetNameScope ( this , new NameScope ( ) );

			//      EllipseGeometry myEllipseGeometry = new EllipseGeometry();
			//      myEllipseGeometry . Center = new Point ( 200 , 100 );
			//      myEllipseGeometry . RadiusX = 15;
			//      myEllipseGeometry . RadiusY = 15;

			//      // Assign the EllipseGeometry a name so that
			//      // it can be targeted by a Storyboard.
			//      this . RegisterName (
			//          "MyAnimatedEllipseGeometry" , myEllipseGeometry );

			//      Path myPath = new Path();
			//      myPath . Fill = Brushes . Blue;
			//      myPath . Margin = new Thickness ( 15 );
			//      myPath . Data = myEllipseGeometry;

			//      PointAnimation myPointAnimation = new PointAnimation();
			//      myPointAnimation . Duration = TimeSpan . FromSeconds ( 2 );

			//      // Set the animation to repeat forever.
			//      myPointAnimation . RepeatBehavior = RepeatBehavior . Forever;

			//      // Set the From and To properties of the animation.
			//      myPointAnimation . From = new Point ( 200 , 100 );
			//      myPointAnimation . To = new Point ( 450 , 250 );

			//      // Set the animation to target the Center property
			//      // of the object named "MyAnimatedEllipseGeometry."
			//      Storyboard . SetTargetName ( myPointAnimation , "MyAnimatedEllipseGeometry" );
			//      Storyboard . SetTargetProperty (
			//          myPointAnimation , new PropertyPath ( EllipseGeometry . CenterProperty ) );

			//      // Create a storyboard to apply the animation.
			//      Storyboard ellipseStoryboard = new Storyboard();
			//      ellipseStoryboard . Children . Add ( myPointAnimation );

			//      // Start the storyboard when the Path loads.
			//      myPath . Loaded += delegate ( object sender , RoutedEventArgs e )
			//      {
			//            ellipseStoryboard . Begin ( this );
			//      };

			//      Canvas containerCanvas = new Canvas();
			//      containerCanvas . Children . Add ( myPath );

			//      Content = containerCanvas;
			//}
		}

		private void TestRectangle_Copy3_MouseLeftButtonDown ( object sender, MouseButtonEventArgs e )
		{
			this . Close ( );
		}


		#region menu Bar Control
		/// <summary>
		/// Makes the Button menu disappear/Reappear to/from bottom right 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Image_MouseLeftButtonDown ( object sender, MouseButtonEventArgs e )
		{
			Storyboard s = null;
			if ( counter == 0 )
			{
				s = ( Storyboard ) TryFindResource ( "SlideStackPanelRight" );
				var uri = new Uri ( "/Icons/left-arrow.png", UriKind . Relative );
				var bitmap = new BitmapImage ( uri );
				OpenCloseButton . Source = bitmap;
				myimage . Visibility = Visibility . Visible;
				OpenCloseButton . Visibility = Visibility . Hidden;
				myimage2 . Visibility = Visibility . Visible;

				counter++;
			}
			else
			{
				s = ( Storyboard ) TryFindResource ( "SlideStackPanelLeft" );
				var uri = new Uri ( "/Icons/right-arrow.png", UriKind . Relative );
				var bitmap = new BitmapImage ( uri );
				OpenCloseButton . Source = bitmap;
				myimage . Visibility = Visibility . Hidden;
				OpenCloseButton . Visibility = Visibility . Visible;
				myimage2 . Visibility = Visibility . Hidden;
				//				//				RectbuttonStackPanel . RenderTransform = mySliderLeft;
				//				mySliderLeft . Begin ( this, true );
				//				s = ( Storyboard ) TryFindResource ( "mySliderLeft" );
				counter = 0;
			}
			try
			{
				if ( s != null )
					s . Begin ( );
			}
			catch
			{

			}
			return;
		}
		#endregion menu Bar Control

		#region Dependency properties

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
				SetValue ( TextHeightProperty, value );
				this . Refresh ( );
			}
			//set{}
		}
		public static readonly DependencyProperty TextHeightProperty =
			DependencyProperty . Register ( "TextHeightProperty",
			typeof ( int ),
			typeof ( AnimationTest ),
			new PropertyMetadata ( 40 ) );
		#endregion

		#region TextTopZero
		/// <summary>
		/// Size of the button text we store for use elsewhere
		/// </summary>
		public Thickness TextTopZero
		{
			get
			{
				return ( Thickness ) GetValue ( TextTopZeroProperty );
			}
			set
			{
				SetValue ( TextTopZeroProperty, value );
				this . Refresh ( );
			}
			//set{}
		}
		public static readonly DependencyProperty TextTopZeroProperty =
			DependencyProperty . Register ( "TextTopZero",
			typeof ( Thickness ),
			typeof ( AnimationTest ),
			new PropertyMetadata ( new Thickness ( 0, 0, 0, 0 ) ) );

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
			typeof ( AnimationTest ),
			new PropertyMetadata ( ( double ) 1.0 ), OnTextWidthScalePropertyChanged );

		private static bool OnTextWidthScalePropertyChanged ( object value )
		{
			//			Console . WriteLine ( $"TextWidthScaleProperty   = {value}" );
			return true;
		}
		#endregion

		#region TestButton functionality
		private void Testbutton_MouseEnter ( object sender, MouseEventArgs e )
		{
			//Button b = sender as Button;
			//if ( b != null )
			//	b . Background = ( SolidColorBrush ) FindResource ( "Magenta2" );
			//else
			//{
			//	Rectangle r = sender as Rectangle;
			//	if ( r != null )
			//		r . Fill = ( SolidColorBrush ) FindResource ( "Magenta2" );
			//}
		}

		private void Testbutton_MouseLeave ( object sender, MouseEventArgs e )
		{
			//Button b = sender as Button;
			//if ( b != null )
			//	b . Background = ( SolidColorBrush ) FindResource ( "Red3" );
			//else
			//{
			//	Rectangle r = sender as Rectangle;
			//	if ( r != null )
			//		r . Fill = ( SolidColorBrush ) FindResource ( "Red3" );
			//}
		}

		private void Xscale_Click ( object sender, RoutedEventArgs e )
		{
			//Testbuton functionality
		}
		#endregion TestButton functionality

		#endregion

		/// <summary>
		/// Set up scale info in window on startup
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void RightPanel_Loaded ( object sender, RoutedEventArgs e )
		{
			ScaleDimensions . Text = $"{Btn1 . TextHeightScale } : {Btn1 . TextWidthScale }";
			return;
		}
		private void AnimWin_Loaded ( object sender, RoutedEventArgs e )
		{
			LeftMenuTogglePanel . Opacity = 0.0;
		}
		private void TestEllipse_Click ( object sender, RoutedEventArgs e )
		{
			System . Diagnostics . Debugger . Break ( );
		}

		private void Btn2_Click ( object sender, RoutedEventArgs e )
		{
			Close ( );
		}
		#region scale changing
		private void TestRectangle_MouseLeftButtonUp ( object sender, MouseButtonEventArgs e )
		{
			Btn1 . TextWidthScale += 0.1;
			TestEllipse . TextWidthScale += 0.1;
			TestEllipse_Copy . TextWidthScale += 0.1;
			Btn2_Copy . TextWidthScale += 0.1;
			ScaleDimensions . Text = $"{Btn1 . TextHeightScale } : {Btn1 . TextWidthScale }";
		}

		private void TextScaleDn ( object sender, MouseButtonEventArgs e )
		{
			Btn1 . TextWidthScale -= 0.1;
			TestEllipse . TextWidthScale -= 0.1;
			TestEllipse_Copy . TextWidthScale -= 0.1;
			Btn2_Copy . TextWidthScale -= 0.1;
			ScaleDimensions . Text = $"{Btn1 . TextHeightScale } : {Btn1 . TextWidthScale }";
		}

		private void TextScaleUp ( object sender, MouseButtonEventArgs e )
		{
			Btn1 . TextWidthScale += 0.1;
			TestEllipse . TextWidthScale += 0.1;
			TestEllipse_Copy . TextWidthScale += 0.1;
			Btn2_Copy . TextWidthScale += 0.1;
			ScaleDimensions . Text = $"{Btn1 . TextHeightScale } : {Btn1 . TextWidthScale }";
		}

		private void TextHeightScaleUp ( object sender, MouseButtonEventArgs e )
		{
			Btn1 . TextHeightScale += 0.1;
			TestEllipse . TextHeightScale += 0.1;
			TestEllipse_Copy . TextHeightScale += 0.1;
			Btn2_Copy . TextHeightScale += 0.1;
			ScaleDimensions . Text = $"{Btn1 . TextHeightScale } : {Btn1 . TextWidthScale }";
		}

		private void TextHeightScaleDn ( object sender, MouseButtonEventArgs e )
		{
			Btn1 . TextHeightScale -= 0.1;
			TestEllipse . TextHeightScale -= 0.1;
			TestEllipse_Copy . TextHeightScale -= 0.1;
			Btn2_Copy . TextHeightScale -= 0.1;
			ScaleDimensions . Text = $"{Btn1 . TextHeightScale } : {Btn1 . TextWidthScale }";
		}
		#endregion scale changing

		#region Drag functionality

		private void DragEllipse ( object sender, MouseButtonEventArgs e )
		{
			MousePosition = Mouse . GetPosition ( LeftPanel );
			MouseDn = true;
		}

		private void Btn1_MouseMove ( object sender, MouseEventArgs e )
		{
			if ( MouseDn )
			{
				ThreeDeeBtnControl tdbc = sender as ThreeDeeBtnControl;
				if ( tdbc == null )
					return;
			}


		}

		private void DrqagEllipseStop ( object sender, MouseButtonEventArgs e )
		{
			MouseDn = false;
		}
		#endregion Drag functionality

		private void TextHeightChange ( object sender, MouseButtonEventArgs e )
		{
			//Rectangle r = sender as Rectangle;
			//TestRectangle_Copy4 . Visibility = Visibility . Hidden;
			//TextHeightSettings . Visibility = Visibility . Visible;
			//TextHeightSettings . Text = Btn1 . Height . ToString ( );
			////TextHeightSettings . Text.
			//TextHeightSettings . Focus ( );
		}

		private void TextHeightSettings_KeyDown ( object sender, KeyEventArgs e )
		{
			if ( e . Key == Key . Enter )
			{
				//int val = Convert.ToInt32(TextHeightSettings.Text);
				////				Btn1 . TextHeight = val;
				////				Btn1 . FontSize = val;
				//if ( val < 30 )
				//	val = 30;
				//Btn1 . Height = val;
				//Btn1 . Refresh ( );
				//TextHeightSettings . Visibility = Visibility . Hidden;
				//TestRectangle_Copy4 . Visibility = Visibility . Visible;
			}
		}

		private void Togglepanel ( object sender, MouseButtonEventArgs e )
		{
			if ( LeftPanel . Visibility == Visibility . Visible )
			{
				LeftPanel . Visibility = Visibility . Hidden;
				TabControlPanel . Visibility = Visibility . Visible;
				//You can use this format almost anywhere to changfe a Dependency Poperty
			}
			else
			{
				LeftPanel . Visibility = Visibility . Visible;
				TabControlPanel . Visibility = Visibility . Hidden;
			}
		}

		private void Toggle_Click ( object sender, RoutedEventArgs e )
		{
			if ( LeftPanel . Visibility == Visibility . Visible )
			{
				LeftPanel . Visibility = Visibility . Hidden;
				TabControlPanel . Visibility = Visibility . Visible;
			}
			else
			{
				LeftPanel . Visibility = Visibility . Visible;
				TabControlPanel . Visibility = Visibility . Hidden;
			}
		}

		private void Image_Click ( object sender, MouseButtonEventArgs e )
		{
			this . Close ( );
		}

		private void Tb1_MouseLeftButtonDown ( object sender, MouseButtonEventArgs e )
		{

			if ( SlideOutMenu . Width > 0 )
			{
				Storyboard s = ( Storyboard ) TryFindResource ( "HideLeftMenu" );
				s . Begin ( );
				//				SlideOutMenu . Visibility = Visibility . Visible;
				Tb1 . Visibility = Visibility . Visible;
			}

			else
			{
				Storyboard s = ( Storyboard ) TryFindResource ( "ShowLeftMenu" );
				s . Begin ( );
				//				SlideOutMenu . Visibility = Visibility . Collapsed;
				Tb1 . Visibility = Visibility . Hidden;
			}
		}

		private void Menu0_Click ( object sender, MouseButtonEventArgs e )
		{
		}
		private void Menu1_Click ( object sender, MouseButtonEventArgs e )
		{
			LeftStackpanel . Visibility = Visibility . Hidden;
			Panel3Canvas . Visibility = Visibility . Hidden;
			Panel4 . Visibility = Visibility . Hidden;
			TabControlPanel . Visibility = Visibility . Hidden;

			Panel1Canvas . Visibility = Visibility . Visible;
		}
		private void Menu2_Click ( object sender, MouseButtonEventArgs e )
		{
			LeftStackpanel . Visibility = Visibility . Hidden;
			Panel1Canvas . Visibility = Visibility . Hidden;
			Panel3Canvas . Visibility = Visibility . Hidden;
			TabControlPanel . Visibility = Visibility . Hidden;

			Panel4 . Visibility = Visibility . Visible;
		}
		private void Menu3_Click ( object sender, MouseButtonEventArgs e )
		{
			LeftStackpanel . Visibility = Visibility . Hidden;
			Panel1Canvas . Visibility = Visibility . Hidden;
			Panel4. Visibility = Visibility . Hidden;
			TabControlPanel . Visibility = Visibility . Hidden;

			Panel3Canvas . Visibility = Visibility . Visible;
		}
		private void Menu4_Click ( object sender, MouseButtonEventArgs e )
		{
			LeftStackpanel . Visibility = Visibility . Hidden;
			Panel1Canvas . Visibility = Visibility . Hidden;
			Panel3Canvas . Visibility = Visibility . Hidden;
			Panel4 . Visibility = Visibility . Hidden;
			TabControlPanel . Visibility = Visibility . Hidden;

			TabControlPanel . Visibility = Visibility . Visible;
			LeftslidingMenuMarker . Visibility = Visibility.Visible;
			
		}
		private void Menu5_Click ( object sender, MouseButtonEventArgs e )
		{
			Panel1Canvas . Visibility = Visibility . Hidden;
			Panel3Canvas . Visibility = Visibility . Hidden;
			Panel4 . Visibility = Visibility . Hidden;
			TabControlPanel . Visibility = Visibility . Hidden;

			LeftStackpanel . Visibility = Visibility . Visible;
		}
		private void Menu6_Click ( object sender, MouseButtonEventArgs e )
	{
			LeftStackpanel . Visibility = Visibility . Hidden;
			Panel1Canvas . Visibility = Visibility . Hidden;
			Panel3Canvas . Visibility = Visibility . Hidden;
			Panel4 . Visibility = Visibility . Hidden;
			TabControlPanel . Visibility = Visibility . Hidden;

			}
		private void Menu7_Click ( object sender, MouseButtonEventArgs e )
		{
			LeftStackpanel . Visibility = Visibility . Hidden;
			Panel1Canvas . Visibility = Visibility . Hidden;
			Panel3Canvas . Visibility = Visibility . Hidden;
			Panel4 . Visibility = Visibility . Hidden;
		}

		private void Expand_MenuItemBorder ( object sender, MouseEventArgs e )
		{
			Thickness t = new Thickness ( );
			Border b = sender as Border;
			b . Height = 120;
			if ( b . Name == "Menu6" )
			{
				t = tb6 . Margin;
				t . Top = 0;
				//				tb6 . Margin = t;
				TextTopZero = t;
			}
		}

		private void Expand_MenuItemTextblock ( object sender, MouseEventArgs e )
		{
			TextBlock b = sender as TextBlock;
			b . Height = 120;
		}

		private void Contract_Textblock1 ( object sender, MouseEventArgs e )
		{
			TextBlock b = sender as TextBlock;
			b . Height = 40;
		}
		private void Contract_Textblock2 ( object sender, MouseEventArgs e )
		{
			TextBlock b = sender as TextBlock;
			b . Height = 40;
		}
		private void Contract_Textblock3 ( object sender, MouseEventArgs e )
		{
			TextBlock b = sender as TextBlock;
			b . Height = 40;
		}
		private void Contract_Textblock4 ( object sender, MouseEventArgs e )
		{
			TextBlock b = sender as TextBlock;
			b . Height = 40;
		}
		private void Contract_Textblock5 ( object sender, MouseEventArgs e )
		{
			TextBlock b = sender as TextBlock;
			b . Height = 40;
		}
		private void Contract_Textblock7 ( object sender, MouseEventArgs e )
		{
			TextBlock b = sender as TextBlock;
			b . Height = 40;
		}
		private static void GetPointerPosition ( AnimationTest AnimWin, Canvas LeftPanel, Border Menu1 )
		{
			currentwinpos = Mouse . GetPosition ( AnimWin );
			currentCtrlpos = Mouse . GetPosition ( LeftPanel );
			menupos = Mouse . GetPosition ( Menu1 );
			if ( menupos . Y < 10 )
			{
				menupos . Y += Menu1 . ActualHeight / 2;
				currentCtrlpos . Y = Menu1 . ActualHeight / 2;
			}
		}

		static Point currentwinpos;
		static Point currentCtrlpos;
		static Point menupos;
		private void SetPointerPosition ( AnimationTest AnimWin, Canvas LeftPanel, Border Menu1 )
		{
			currentCtrlpos . Y += menupos . Y;
			currentwinpos = PointToScreen ( currentCtrlpos );
			Point newpos = new Point ( 0, 0 );
			newpos . X = ( int ) currentwinpos . X;
			newpos . Y = ( int ) currentwinpos . Y + 20;//
			Console . WriteLine ( $"win= {currentwinpos . X}:{currentwinpos . Y}\nMenu1 = {menupos . X} : {menupos . Y}\nnewpos = {newpos . X} : {newpos . Y}\n" );
			NativeMethods . SetCursorPos ( ( int ) newpos . X, ( int ) newpos . Y );

		}
		private void Expand_MenuItemBorder1 ( object sender, MouseEventArgs e )
		{
			defaultMenuheight = ( int ) Menu1 . ActualHeight;
			//			GetPointerPosition (AnimWin, LeftPanel, Menu1 );
			Border b = sender as Border;
			TextBlock tb = new TextBlock ( );
			if ( b != null )
			{
				Border o = ( Border ) FindName ( "Menu1" );
				currentCtrlpos = Mouse . GetPosition ( o );
				Expanded ( b, tb1, Menu1Text, dummymenutext1 );
			}
			else
			{
				tb = sender as TextBlock;
				Border o = ( Border ) FindName ( "Menu1" );
				currentCtrlpos = Mouse . GetPosition ( o );
				Expanded ( o, tb, Menu1Text, dummymenutext1 );
			}
			//ShowMenuOptions ( null, true );
		}
		private void Contract_Border1 ( object sender, MouseEventArgs e )
		{
			Border b = sender as Border;
			TextBlock t = new TextBlock ( );
			if ( b != null )
			{
				if ( CheckCallerOpen ( Menu1 ) == false )
					return;
				Contract ( b, tb1, Menu1Text );
				//				Menu1 . Height = defaultMenuheight;
				Menu1 . Refresh ( );
			}
			else
			{
				if ( CheckCallerOpen ( Menu1 ) == false )
					return;
				t = sender as TextBlock;
				Contract ( Menu1, t, Menu1Text );
				//				Menu1. Height = defaultMenuheight;
				Menu1 . Refresh ( );
			}
			//			ShowMenuOptions ( Menu1, false );
		}
		private void Expand_MenuItemBorder2 ( object sender, MouseEventArgs e )
		{
			defaultMenuheight = ( int ) Menu2 . ActualHeight;
			//			GetPointerPosition ( AnimWin, LeftPanel, Menu2 );
			Border b = sender as Border;
			TextBlock t = new TextBlock ( );
			if ( b != null )
			{
				defaultMenuheight = ( int ) b . Height;
				Expanded ( b, tb2, Menu2Text, dummymenutext2 );
			}
			else
			{
				t = sender as TextBlock;
				defaultMenuheight = ( int ) t . Height;
				Expanded ( Menu2, t, Menu2Text, dummymenutext2 );
			}
			//			ShowMenuOptions ( null, false );
		}
		private void Contract_Border2 ( object sender, MouseEventArgs e )
		{
			Border b = sender as Border;
			TextBlock t = new TextBlock ( );
			if ( b != null )
			{
				if ( CheckCallerOpen ( Menu2 ) == false )
					return;
				Contract ( b, tb2, Menu2Text );
				//				Menu2 . Height = defaultMenuheight;
				Menu2 . Refresh ( );
			}
			else
			{
				if ( CheckCallerOpen ( Menu2 ) == false )
					return;
				t = sender as TextBlock;
				Contract ( Menu2, t, Menu2Text );
				//				Menu2 . Height = defaultMenuheight;
				Menu2 . Refresh ( );
			}
			//			ShowMenuOptions ( Menu2, false );
		}
		private void Expand_MenuItemBorder3 ( object sender, MouseEventArgs e )
		{
			defaultMenuheight = ( int ) Menu3 . ActualHeight;
			//			GetPointerPosition ( AnimWin, LeftPanel, Menu3 );
			Border b = sender as Border;
			TextBlock t = new TextBlock ( );
			if ( b != null )
			{
				defaultMenuheight = ( int ) b . Height;
				Expanded ( b, tb3, Menu3Text, dummymenutext3 );
			}
			else
			{
				t = sender as TextBlock;
				defaultMenuheight = ( int ) t . Height;
				Expanded ( Menu3, t, Menu3Text, dummymenutext3 );
			}
			//			ShowMenuOptions ( Menu3, true );
		}
		private void Contract_Border3 ( object sender, MouseEventArgs e )
		{
			Border b = sender as Border;
			TextBlock t = new TextBlock ( );
			if ( b != null )
			{
				if ( CheckCallerOpen ( Menu3 ) == false )
					return;
				Contract ( b, tb3, Menu3Text );
				//				Menu3 . Height = defaultMenuheight;
				Menu3 . Refresh ( );
			}
			else
			{
				if ( CheckCallerOpen ( Menu3 ) == false )
					return;
				t = sender as TextBlock;
				Contract ( Menu3, t, Menu3Text );
				//				Menu3 . Height = defaultMenuheight;
				Menu3 . Refresh ( );
			}
			//			ShowMenuOptions ( Menu3, false );
		}
		private void Expand_MenuItemBorder4 ( object sender, MouseEventArgs e )
		{
			defaultMenuheight = ( int ) Menu4 . ActualHeight;
			//			GetPointerPosition ( AnimWin, LeftPanel, Menu4 );
			Border b = sender as Border;
			TextBlock t = new TextBlock ( );
			if ( b != null )
			{
				defaultMenuheight = ( int ) b . Height;
				Expanded ( b, tb4, Menu4Text, dummymenutext4 );
			}
			else
			{
				t = sender as TextBlock;
				defaultMenuheight = ( int ) t . Height;
				Expanded ( Menu4, t, Menu4Text, dummymenutext4 );
			}
			//			ShowMenuOptions ( Menu4, true );
		}
		private void Contract_Border4 ( object sender, MouseEventArgs e )
		{
			Border b = sender as Border;
			TextBlock t = new TextBlock ( );
			if ( b != null )
			{
				if ( CheckCallerOpen ( Menu4 ) == false )
					return;
				Contract ( b, tb4, Menu4Text );
				//				Menu4 . Height = defaultMenuheight;
				Menu4 . Refresh ( );
			}
			else
			{
				if ( CheckCallerOpen ( Menu4 ) == false )
					return;
				t = sender as TextBlock;
				Contract ( Menu4, t, Menu4Text );
				//				Menu4 . Height = defaultMenuheight;
				Menu4 . Refresh ( );
			}
			//			ShowMenuOptions ( Menu4, false );
		}
		private void Expand_MenuItemBorder5 ( object sender, MouseEventArgs e )
		{
			defaultMenuheight = ( int ) Menu5 . ActualHeight;
			//			GetPointerPosition ( AnimWin, LeftPanel, Menu5 );
			Border b = sender as Border;
			TextBlock t = new TextBlock ( );
			if ( b != null )
			{
				defaultMenuheight = ( int ) b . Height;
				Expanded ( b, tb5, Menu5Text, dummymenutext5 );
			}
			else
			{
				t = sender as TextBlock;
				defaultMenuheight = ( int ) t . Height;
				Expanded ( Menu5, t, Menu5Text, dummymenutext5 );
			}
			//			ShowMenuOptions ( Menu5, true );
		}
		private void Contract_Border5 ( object sender, MouseEventArgs e )
		{
			Border b = sender as Border;
			TextBlock t = new TextBlock ( );
			if ( b != null )
			{
				if ( CheckCallerOpen ( Menu5 ) == false )
					return;
				Contract ( b, tb5, Menu5Text );
				//				Menu5 . Height = defaultMenuheight;
				Menu5 . Refresh ( );
			}
			else
			{
				if ( CheckCallerOpen ( Menu5 ) == false )
					return;
				t = sender as TextBlock;
				Contract ( Menu5, t, Menu5Text );
				//				Menu5 . Height = defaultMenuheight;
				Menu5 . Refresh ( );
			}
			//			ShowMenuOptions ( Menu5, false );
		}
		private void Expand_MenuItemBorder6 ( object sender, MouseEventArgs e )
		{
			defaultMenuheight = ( int ) Menu6 . ActualHeight;
			//			GetPointerPosition ( AnimWin, LeftPanel, Menu6 );
			Border b = sender as Border;
			TextBlock t = new TextBlock ( );
			if ( b != null )
			{
				defaultMenuheight = ( int ) b . Height;
				Expanded ( b, tb6, Menu6Text, dummymenutext6 );
			}
			else
			{
				t = sender as TextBlock;
				defaultMenuheight = ( int ) t . Height;
				Expanded ( Menu6, t, Menu6Text, dummymenutext6 );
			}
			//			ShowMenuOptions ( Menu6, true );
		}
		private void Contract_Border6 ( object sender, MouseEventArgs e )
		{
			Border b = sender as Border;
			TextBlock t = new TextBlock ( );
			if ( b != null )
			{
				if ( CheckCallerOpen ( Menu6 ) == false )
					return;
				Contract ( b, tb6, Menu6Text );
				Menu6 . Refresh ( );
			}
			else
			{
				if ( CheckCallerOpen ( Menu6 ) == false )
					return;
				t = sender as TextBlock;
				Contract ( Menu6, t, Menu6Text );
				Menu6 . Refresh ( );
			}
			Thread . Sleep ( 100 );
			//			ShowMenuOptions ( Menu6, false );
		}
		private void Expand_MenuItemBorder7 ( object sender, MouseEventArgs e )
		{
			defaultMenuheight = ( int ) Menu7 . ActualHeight;
			//			GetPointerPosition ( AnimWin, LeftPanel, Menu7 );
			Border b = sender as Border;
			TextBlock t = new TextBlock ( );
			if ( b != null )
			{
				defaultMenuheight = ( int ) b . Height;
				Expanded ( b, tb7, Menu7Text, dummymenutext7 );
			}
			else
			{
				t = sender as TextBlock;
				defaultMenuheight = ( int ) t . Height;
				Expanded ( Menu7, t, Menu7Text, dummymenutext7 );
			}
			//			ShowMenuOptions ( Menu7, true );
		}
		private void Contract_Border7 ( object sender, MouseEventArgs e )
		{
			Border b = sender as Border;
			TextBlock t = new TextBlock ( );
			if ( b != null )
			{
				if ( CheckCallerOpen ( Menu7 ) == false )
					return;
				Contract ( b, tb7, Menu7Text );
				Menu7 . Refresh ( );
			}
			else
			{
				if ( CheckCallerOpen ( Menu7 ) == false )
					return;
				t = sender as TextBlock;
				Contract ( Menu7, t, Menu7Text );
				Menu7 . Refresh ( );
			}
			Thread . Sleep ( 100 );
			//			ShowMenuOptions ( Menu7, false );
		}

		private void Tb1_Mouseover ( object sender, MouseEventArgs e )
		{
			if ( SlideOutMenu . Width > 0 )
			{
				Storyboard s = ( Storyboard ) TryFindResource ( "HideLeftMenu" );
				s . Begin ( );
				Tb1 . Visibility = Visibility . Visible;
			}

			else
			{
				Storyboard s = ( Storyboard ) TryFindResource ( "ShowLeftMenu" );
				s . Begin ( );
				Tb1 . Visibility = Visibility . Hidden;
			}
		}

		private void MenuTimerCallback ( object state )
		{
			TimeSpan ts = timer .Interval;
			if ( timer .IsEnabled && ts . Ticks < 500 )
			{
				Thread . Sleep ( 200 );
			}

		}

		private void Expand_MenuItemBorder0 ( object sender, MouseEventArgs e )
		{

		}

		private void Contract_Border0 ( object sender, MouseEventArgs e )
		{
			//ShowMenuOptions ( null, false);

		}

		private void MenuOpen_Click ( object sender, MouseButtonEventArgs e )
		{
			if ( Menu2 . Visibility == Visibility . Visible )
			{
				ShowMenuOptions ( null, false );
				tb0 . Text = "Show Menu Options";
				SlideOutMenu . Background = new SolidColorBrush(Colors.Transparent);
			}
			else
			{
				ShowMenuOptions ( null, true );
				tb0 . Text = "Hide Menu Options";
				SlideOutMenu .Background = ( Brush)FindResource("Black5");
			}
		}

		private void Expand_MenuItemBorderOpen ( object sender, MouseEventArgs e )
		{
			//if ( Menu1 . Visibility == Visibility . Visible )
			//	ShowMenuOptions ( null, false );
			//else 
			ShowMenuOptions ( null, true );
		}

		private void Contract_BorderOpen ( object sender, MouseEventArgs e )
		{
			ShowMenuOptions ( null, true );
		}
		private void ShowMenuOptions ( Border menu, bool open )
		{
			if ( menu == null && open )
			{
				Menu1 . Visibility = Visibility . Visible;
				Menu2 . Visibility = Visibility . Visible;
				Menu3 . Visibility = Visibility . Visible;
				Menu4 . Visibility = Visibility . Visible;
				Menu5 . Visibility = Visibility . Visible;
				Menu6 . Visibility = Visibility . Visible;
				Menu7 . Visibility = Visibility . Visible;
				return;
			}
			else if ( menu == null && open == false )
			{
				Menu1 . Visibility = Visibility . Collapsed;
				Menu2 . Visibility = Visibility . Collapsed;
				Menu3 . Visibility = Visibility . Collapsed;
				Menu4 . Visibility = Visibility . Collapsed;
				Menu5 . Visibility = Visibility . Collapsed;
				Menu6 . Visibility = Visibility . Collapsed;
				Menu7 . Visibility = Visibility . Collapsed;
				return;
			}
			Menu1 . Visibility = Visibility . Collapsed;
			Menu2 . Visibility = Visibility . Collapsed;
			Menu3 . Visibility = Visibility . Collapsed;
			Menu4 . Visibility = Visibility . Collapsed;
			Menu5 . Visibility = Visibility . Collapsed;
			Menu6 . Visibility = Visibility . Collapsed;
			Menu7 . Visibility = Visibility . Collapsed;
			AnimWin . Refresh ( );
			if ( menu == Menu1 && open )
			{
				Menu1 . Visibility = Visibility . Visible;
			}
			else if ( menu == Menu2 && open )
			{
				Menu2 . Visibility = Visibility . Visible;
			}
			else if ( menu == Menu3 && open )
			{
				Menu3 . Visibility = Visibility . Visible;
			}
			else if ( menu == Menu4 && open )
			{
				Menu4 . Visibility = Visibility . Visible;
			}
			else if ( menu == Menu5 && open )

			{
				Menu6 . Visibility = Visibility . Visible;
			}
			else if ( menu == Menu6 && open )
			{
				Menu6 . Visibility = Visibility . Visible;
			}
			else if ( menu == Menu7 && open )
			{
				Menu7 . Visibility = Visibility . Visible;
			}
		}
		private void Expanded ( Border border, TextBlock textblock, string originaltext, string newtext )
		{
//	if ( IsMenuOpen )
//		return;
			//			if ( timer . IsRunning )
			//				return;
//			timer . Start ( );
			double dtemp = 0;
			textblock . Text = "";
			textblock . Height = 0;
			textblock . Text = originaltext + newtext;
			textblock . Refresh ( );
			dtemp = textblock . ActualHeight + 15;
			border . Height = dtemp;
			textblock . Height = dtemp;
			textblock . Refresh ( );
			border . Height = dtemp + 15;
			border . Refresh ( );
			//			Thread . Sleep ( 10 );
			Thickness t = textblock . Margin;
			t . Top = 0;
			t . Bottom = 0;
			t . Left = 0;
			t . Right = 0;
			textblock . Margin = t;
			textblock . Refresh ( );
			IsMenuOpen = true;
			border . Refresh ( );
			Console . WriteLine ( $"Menu {border . Name} Opened ...." );
			ReSetOpenFlags ( border, true );
		}
		private void Contract ( Border border, TextBlock textblock, string originaltext )
		{
			//if ( !IsMenuOpen )
			//	return;
//			timer . Stop ( );
			if ( CheckCallerOpen ( border ) == false )
				return;
//			if ( timer .< 10000)
//				return;
			textblock . Text = "";
			textblock . Height = 0;
			border . Height = 0;
			textblock . Text = originaltext;
			textblock . Refresh ( );
			//textblock . Height = textblock . Height;
			border . Height = 0;
			border . Refresh ( );
			border . Height = textblock . ActualHeight + 15;
			textblock . Height = border . Height;
			textblock . Refresh ( );
			Thickness t = textblock . Margin;
			t . Top = 0;
			t . Bottom = 0;
			t . Left = 0;
			t . Right = 0;
			textblock . Margin = t;
			textblock . Refresh ( );
			IsMenuOpen = false;
			Console . WriteLine ( $"Menu {border . Name} Closed ...." );
			ReSetOpenFlags ( border, false );
		}
		private bool CheckCallerOpen ( Border border )
		{
			if ( border == Menu1 )
				return Menu1Open;
			else if ( border == Menu2 )
				return Menu2Open;
			else if ( border == Menu3 )
				return Menu3Open;
			else if ( border == Menu4 )
				return Menu4Open;
			else if ( border == Menu5 )
				return Menu5Open;
			else if ( border == Menu6 )
				return Menu6Open;
			else if ( border == Menu7 )
				return Menu7Open;
			return false;
		}
		private void ReSetOpenFlags ( Border border, bool setting )
		{
			if ( setting == true )
			{
				Menu1Open = false;
				Menu2Open = false;
				Menu3Open = false;
				Menu4Open = false;
				Menu5Open = false;
				Menu6Open = false;
				Menu7Open = false;
			}

			if ( border == Menu1 )
				Menu1Open = setting;
			else if ( border == Menu2 )
				Menu2Open = setting;
			else if ( border == Menu3 )
				Menu3Open = setting;
			else if ( border == Menu4 )
				Menu4Open = setting;
			else if ( border == Menu5 )
				Menu5Open = setting;
			else if ( border == Menu6 )
				Menu5Open = setting;
			else if ( border == Menu7 )
				Menu7Open = setting;
		}

		private void SlideMenu_mouseEnter ( object sender, MouseEventArgs e )
		{
			if ( LeftMenuTogglePanel . Opacity < 1.0 )
			{
				Storyboard s = ( Storyboard ) TryFindResource ( "FadeInMenu" );
				s . Begin ( );
			}
		}

		private void SlideMenu_mouseLeave ( object sender, MouseEventArgs e )
		{
			if ( LeftMenuTogglePanel . Opacity >= 1.0 )
			{
				Storyboard s = ( Storyboard ) TryFindResource ( "FadeOutMenu" );
				s . Begin ( );
			}
		}
	}
}