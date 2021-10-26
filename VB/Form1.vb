Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports DevExpress.XtraPrinting
Imports MyBrick
' ...

Namespace CustomBricks
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) _
            Handles button1.Click

            ' Create a brick.
            Dim hyperBrick As New HyperLinkBrick("http://www.devexpress.com", _
                                                 "Developer Express Inc.")

            ' Start the report generation.
            printingSystem1.Begin()

            ' Specify the page area to draw a brick.
            printingSystem1.Graph.Modifier = BrickModifier.Detail

            ' Add the brick with specified dimensions to the document.
            printingSystem1.Graph.DrawBrick(hyperBrick, New RectangleF(0, 0, 300, 20))

            ' Finish the report generation.
            printingSystem1.End()

            ' Preview the result.
            printingSystem1.PreviewFormEx.Show()
        End Sub

#Region "#UsingEllipseBrick"
        Private Sub button2_Click(ByVal sender As Object, ByVal e As EventArgs) _
            Handles button2.Click

            ' Create a brick.
            Dim brick As Brick = New EllipseBrick(Color.LightGreen, Color.Blue, _
                                                   LinearGradientMode.ForwardDiagonal)

            ' Start the report generation.
            printingSystem1.Begin()
            Dim graph As IBrickGraphics = printingSystem1.Graph

            ' Specify the page area to draw a brick.
            printingSystem1.Graph.Modifier = BrickModifier.Detail

            ' Add the brick with specified dimensions to the document.
            graph.DrawBrick(brick, New RectangleF(0, 0, 150, 100))

            ' Finish the report generation.
            printingSystem1.End()

            ' Preview the result.
            printingSystem1.PreviewFormEx.Show()
        End Sub
#End Region

    End Class
End Namespace