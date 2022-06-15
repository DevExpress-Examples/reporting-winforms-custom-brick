using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using DevExpress.Drawing;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.BrickExporters;

namespace MyBrick {
    public class HyperLinkBrick : TextBrick {

        public HyperLinkBrick(string url)
            : this(url, url) {
        }

        public HyperLinkBrick(string url, string hint)
            : base() {
            this.Url = url;
            this.Text = url;
            this.Hint = hint;
        }

        // Specifies the brick text color. 
        public new Color ForeColor {
            get {
                return Color.Blue;
            }
        }

        // Specifies the brick text font.
        public new Font Font {
            get {
                return base.Font;
            }
            set {
                base.Font = new Font(value.Name, value.Size,
              value.Style | FontStyle.Underline);
            }
        }

        // Initializes the brick.
        protected override void OnSetPrintingSystem(bool cacheStyle) {
            base.OnSetPrintingSystem(cacheStyle);
            base.ForeColor = Color.Blue;
            base.Sides = BorderSide.None;
            this.Font = base.Font;
        }
    }
    [BrickExporter(typeof(EllipseBrickExporter))]
    public class EllipseBrick : Brick {

        // Set gradient colors for inner and outer ellipse regions.
        public Color InnerColor = Color.Transparent;
        public Color OuterColor = Color.Peru;

        public EllipseBrick() {
        }
        
        public EllipseBrick(Color InnerColor, Color OuterColor) {
            this.InnerColor = InnerColor;
            this.OuterColor = OuterColor;
        }
    }

    public class EllipseBrickExporter : BrickExporter {
        EllipseBrick EllipseBrick { get { return (EllipseBrick)Brick; } }
        // Fills an ellipse with a linear color gradient.
        public override void Draw(IGraphics gr, RectangleF rect) {
            using(DXLinearGradientBrush brush = new DXLinearGradientBrush(rect, EllipseBrick.OuterColor, EllipseBrick.InnerColor)) {
                ColorBlend colorBlend = new ColorBlend();
                colorBlend.Positions = new float[] { 0.0f, 0.5f, 1.0f };
                colorBlend.Colors = new Color[] { EllipseBrick.OuterColor, EllipseBrick.InnerColor, EllipseBrick.OuterColor };
                brush.InterpolationColors = colorBlend;
                gr.FillEllipse(brush, rect);
            }
        }
    }

}
