#Region "usings"
Imports System.Collections
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports DevExpress.Drawing
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraPrinting.BrickExporters
#End Region

Namespace MyBrick
    #Region "HyperLinkBrick"
    Public Class HyperLinkBrick
        Inherits TextBrick

        Public Sub New(ByVal url As String)
            Me.New(url, url)
        End Sub

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
#End Region
#Region "EllipseBrick"
    <BrickExporter(GetType(EllipseBrickExporter))> _
    Public Class EllipseBrick
        Inherits Brick

        ' Set gradient colors for inner and outer ellipse regions.
        Public InnerColor As Color = Color.Transparent
        Public OuterColor As Color = Color.Peru

        Public Sub New()
        End Sub

        Public Sub New(ByVal InnerColor As Color, ByVal OuterColor As Color)
            Me.InnerColor = InnerColor
            Me.OuterColor = OuterColor
        End Sub
    End Class

    Public Class EllipseBrickExporter
        Inherits BrickExporter
        Private ReadOnly Property EllipseBrick() As EllipseBrick
            Get
                Return TryCast(Brick, EllipseBrick)
            End Get
        End Property
        ' Fills an ellipse with a linear color gradient.
        Public Overloads Overrides Sub Draw(ByVal gr As IGraphics, ByVal rect As RectangleF)
            Using brush As New DXLinearGradientBrush(rect, EllipseBrick.OuterColor, EllipseBrick.InnerColor)
                Dim colorBlend As New ColorBlend()
                colorBlend.Positions = New Single() {0.0F, 0.5F, 1.0F}
                colorBlend.Colors = New Color() {EllipseBrick.OuterColor, EllipseBrick.InnerColor,
                    EllipseBrick.OuterColor}
                brush.InterpolationColors = colorBlend
                gr.FillEllipse(brush, rect)
            End Using
        End Sub
    End Class
#End Region

End Namespace
