using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using DevExpress.XtraPrinting;
using MyBrick;
// ...

namespace CustomBricks {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            // Create a brick.
            HyperLinkBrick hyperBrick = new HyperLinkBrick("http://www.devexpress.com",
                "Developer Express Inc.");

            // Start the report generation.
            printingSystem1.Begin();

            // Specify the page area to draw a brick.
            printingSystem1.Graph.Modifier = BrickModifier.Detail;

            // Add the brick with specified dimensions to the document.
            printingSystem1.Graph.DrawBrick(hyperBrick, new RectangleF(0, 0, 300, 20));

            // Finish the report generation.
            printingSystem1.End();

            // Preview the result.
            printingSystem1.PreviewFormEx.Show();
        }

        #region #UsingEllipseBrick
        private void button2_Click(object sender, EventArgs e) {
            // Create a brick.
            Brick brick = new EllipseBrick(Color.LightGreen, Color.Blue,
                LinearGradientMode.ForwardDiagonal);

            // Start the report generation.
            printingSystem1.Begin();
            IBrickGraphics graph = printingSystem1.Graph;

            // Specify the page area to draw a brick.
            printingSystem1.Graph.Modifier = BrickModifier.Detail;

            // Add the brick with specified dimensions to the document.
            graph.DrawBrick(brick, new RectangleF(0, 0, 150, 100));

            // Finish the report generation.
            printingSystem1.End();

            // Preview the result.
            printingSystem1.PreviewFormEx.Show();
        }
        #endregion #UsingEllipseBrick

    }
}