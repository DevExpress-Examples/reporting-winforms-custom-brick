#region usings
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using DevExpress.XtraPrinting;
using MyBrick;
#endregion

namespace CustomBricks {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            HyperLinkBrick hyperBrick = new HyperLinkBrick("http://www.devexpress.com",
                "Developer Express Inc.");
            printingSystem1.Begin();
            // Specify the page area to draw a brick.
            printingSystem1.Graph.Modifier = BrickModifier.Detail;
            // Add the brick with specified dimensions to the document.
            printingSystem1.Graph.DrawBrick(hyperBrick, new RectangleF(0, 0, 300, 20));
            printingSystem1.End();
            printingSystem1.PreviewFormEx.Show();
        }

        #region #UsingEllipseBrick
        private void button2_Click(object sender, EventArgs e) {
            Brick brick = new EllipseBrick(Color.LightGreen, Color.Blue,
                LinearGradientMode.ForwardDiagonal);
            printingSystem1.Begin();
            IBrickGraphics graph = printingSystem1.Graph;
            // Specify the page area to draw a brick.
            printingSystem1.Graph.Modifier = BrickModifier.Detail;
            // Add the brick with specified dimensions to the document.
            graph.DrawBrick(brick, new RectangleF(0, 0, 150, 100));
            printingSystem1.End();
            printingSystem1.PreviewFormEx.Show();
        }
        #endregion #UsingEllipseBrick

    }
}