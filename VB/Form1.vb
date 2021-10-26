#Region "usings"
Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports DevExpress.XtraPrinting
Imports MyBrick
#End Region

Namespace CustomBricks
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) _
            Handles button1.Click
            Dim hyperBrick As New HyperLinkBrick("http://www.devexpress.com", _
                                                 "Developer Express Inc.")
            printingSystem1.Begin()
            ' Specify the page area to draw a brick.
            printingSystem1.Graph.Modifier = BrickModifier.Detail
            ' Add the brick with specified dimensions to the document.
            printingSystem1.Graph.DrawBrick(hyperBrick, New RectangleF(0, 0, 300, 20))
            printingSystem1.End()
            printingSystem1.PreviewFormEx.Show()
        End Sub

#Region "#UsingEllipseBrick"
        Private Sub button2_Click(ByVal sender As Object, ByVal e As EventArgs) _
            Handles button2.Click
            Dim brick As Brick = New EllipseBrick(Color.LightGreen, Color.Blue, _
                                                   LinearGradientMode.ForwardDiagonal)
            printingSystem1.Begin()
            Dim graph As IBrickGraphics = printingSystem1.Graph
            ' Specify the page area to draw a brick.
            printingSystem1.Graph.Modifier = BrickModifier.Detail
            ' Add the brick with specified dimensions to the document.
            graph.DrawBrick(brick, New RectangleF(0, 0, 150, 100))
            printingSystem1.End().
            printingSystem1.PreviewFormEx.Show()
        End Sub
#End Region
    End Class
End Namespace