Imports Microsoft.VisualBasic
Imports System.Collections
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports DevExpress.XtraPrinting
' ...

Namespace MyBrick

	Public Class HyperLinkBrick
		Inherits TextBrick

		' Constructor, which creates a brick with a single parameter.
		Public Sub New(ByVal url As String)
			Me.New(url, url)
		End Sub

		' Constructor, which creates a brick with a specific url and hint values.
		Public Sub New(ByVal url As String, ByVal hint As String)
			MyBase.New()
			Me.Url = url
			Me.Text = url
			Me.Hint = hint
		End Sub

		' Specifies the brick text color. 
		Public Shadows ReadOnly Property ForeColor() As Color
			Get
				Return Color.Blue
			End Get
		End Property

		' Specifies the brick text font.
		Public Shadows Property Font() As Font
			Get
				Return MyBase.Font
			End Get
			Set(ByVal value As Font)
				MyBase.Font = New Font(value.Name, value.Size, value.Style Or FontStyle.Underline)
			End Set
		End Property

		' Initializes the brick.
		Protected Overrides Sub OnSetPrintingSystem(ByVal cacheStyle As Boolean)
			MyBase.OnSetPrintingSystem(cacheStyle)
			MyBase.ForeColor = Color.Blue
			MyBase.Sides = BorderSide.None
			Me.Font = MyBase.Font
		End Sub
	End Class


	Public Class EllipseBrick
		Inherits Accessible
		Implements IBrick

		' Set gradient colors for inner and outer ellipse regions.
		Public InnerColor As Color = Color.Transparent
		Public OuterColor As Color = Color.Peru

		' Set gradient direction.
		Public GradientDirection As LinearGradientMode = LinearGradientMode.Vertical

		' Default constructor.
		Public Sub New()
		End Sub

		' Constructor, initializing gradient colors and direction.
		Public Sub New(ByVal InnerColor As Color, ByVal OuterColor As Color, ByVal GradientDirection As LinearGradientMode)
			Me.InnerColor = InnerColor
			Me.OuterColor = OuterColor
			Me.GradientDirection = GradientDirection
		End Sub

		' Fills an ellipse with a linear color gradient.
		Public Sub Draw(ByVal gr As Graphics, ByVal rect As RectangleF) Implements IBrick.Draw
			Dim brush As New LinearGradientBrush(rect, OuterColor, InnerColor, GradientDirection)
			Dim colorBlend As New ColorBlend()
			colorBlend.Positions = New Single() { 0.0f, 0.5f, 1.0f }
			colorBlend.Colors = New Color() { OuterColor, InnerColor, OuterColor }
			brush.InterpolationColors = colorBlend
			gr.FillEllipse(brush, rect)
		End Sub

		' This method is required by the IBrick interface.
		Public Function GetProperties() As Hashtable Implements IBrick.GetProperties
			Return Nothing
		End Function

		' This method is required by the IBrick interface.
		Public Sub SetProperties(ByVal properties(,) As Object) Implements IBrick.SetProperties
		End Sub

		' This method is required by the IBrick interface.
		Public Sub SetProperties(ByVal properties As Hashtable) Implements IBrick.SetProperties
		End Sub
	End Class

End Namespace
