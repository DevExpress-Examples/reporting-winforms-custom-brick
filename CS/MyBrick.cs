using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using DevExpress.XtraPrinting;
// ...

namespace MyBrick {

    public class HyperLinkBrick : TextBrick {

        // Constructor, which creates a brick with a single parameter.
        public HyperLinkBrick(string url)
            : this(url, url) {
        }

        // Constructor, which creates a brick with a specific url and hint values.
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


    public class EllipseBrick : Accessible, IBrick {

        // Set gradient colors for inner and outer ellipse regions.
        public Color InnerColor = Color.Transparent;
        public Color OuterColor = Color.Peru;

        // Set gradient direction.
        public LinearGradientMode GradientDirection = LinearGradientMode.Vertical;

        // Default constructor.
        public EllipseBrick() {
        }

        // Constructor, initializing gradient colors and direction.
        public EllipseBrick(Color InnerColor, Color OuterColor, LinearGradientMode GradientDirection) {
            this.InnerColor = InnerColor;
            this.OuterColor = OuterColor;
            this.GradientDirection = GradientDirection;
        }

        // Fills an ellipse with a linear color gradient.
        public void Draw(Graphics gr, RectangleF rect) {
            LinearGradientBrush brush = new LinearGradientBrush(rect, OuterColor,
                InnerColor, GradientDirection);
            ColorBlend colorBlend = new ColorBlend();
            colorBlend.Positions = new float[] { 0.0f, 0.5f, 1.0f };
            colorBlend.Colors = new Color[] { OuterColor, InnerColor, OuterColor };
            brush.InterpolationColors = colorBlend;
            gr.FillEllipse(brush, rect);
        }

        // This method is required by the IBrick interface.
        public Hashtable GetProperties() {
            return null;
        }

        // This method is required by the IBrick interface.
        public void SetProperties(object[,] properties) {
        }

        // This method is required by the IBrick interface.
        public void SetProperties(Hashtable properties) {
        }
    }

}
