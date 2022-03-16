using VisualHint.SmartPropertyGrid;
using System.ComponentModel;
using System.Resources;
using System.Reflection;

namespace QuickStart
{
    public class MyPropertyGrid : VisualHint.SmartPropertyGrid.PropertyGrid
    {
        private bool _useWaitCursor;

        [PropertyValueDisplayedAs(new string[] { "Use", "Don't use" })]
        public new bool UseWaitCursor
        {
            set { _useWaitCursor = value; }
            get { return _useWaitCursor; }
        }

        private int _opacity;

        [PropertyValidator(typeof(PropertyValidatorMinMax), 0, 100)]
        public int Opacity
        {
            set { _opacity = value; }
            get { return _opacity; }
        }

        private Color _backColor;

        public Color FormBackColor
        {
            get { return _backColor; }
            set { _backColor = value; }
        }

        public void Initialize()
        {
            PropertyEnumerator catEnum = AppendRootCategory(1, "Application");

            PropertyEnumerator propEnum = AppendManagedProperty(catEnum, 2, "AllowQuit",
                typeof(bool), Application.AllowQuit, "", new ReadOnlyAttribute(true));
            propEnum.Property.DisabledForeColor = Color.Firebrick;
            propEnum.Property.Feel = GetRegisteredFeel(VisualHint.SmartPropertyGrid.PropertyGrid.FeelList);

            UseWaitCursor = Application.UseWaitCursor;
            propEnum = AppendProperty(catEnum, 3, "Wait cursor", this, "UseWaitCursor", "");
            propEnum.Property.Feel = GetRegisteredFeel(VisualHint.SmartPropertyGrid.PropertyGrid.FeelCheckbox);
            propEnum.Property.Look = new PropertyCheckboxLook();

            catEnum = AppendRootCategory(4, "Form");

            FormBackColor = ParentForm.BackColor;
            propEnum = AppendProperty(catEnum, 5, "Back color", this, "FormBackColor", "", new PropertyDropDownContentAttribute(typeof(AlphaColorPicker)));
            propEnum.Property.Feel = GetRegisteredFeel(VisualHint.SmartPropertyGrid.PropertyGrid.FeelList);
            propEnum.Property.Look = new PropertyAlphaColorLook();

            propEnum = AppendProperty(catEnum, 6, "Size", ParentForm, "Size", "");
            ExpandProperty(propEnum, true);

            Opacity = (int)(ParentForm.Opacity * 100.0);
            propEnum = InsertProperty(propEnum, 7, "Opacity", this, "Opacity", "");
            propEnum.Property.Feel = GetRegisteredFeel(VisualHint.SmartPropertyGrid.PropertyGrid.FeelTrackbarEdit);
            propEnum.Property.BackColor = Color.SkyBlue;
            propEnum.Property.Value.BackColor = GridBackColor;

            propEnum = AppendManagedProperty(catEnum, 10, "Size readonly", typeof(bool), false, "");
            propEnum.Property.Feel = GetRegisteredFeel(VisualHint.SmartPropertyGrid.PropertyGrid.FeelCheckbox);
            propEnum.Property.Look = new PropertyCheckboxLook();

            propEnum = AppendManagedProperty(catEnum, 8, "Chess pawn", typeof(string), "Pawn", "");
            propEnum.Property.Feel = GetRegisteredFeel(VisualHint.SmartPropertyGrid.PropertyGrid.FeelList);

            propEnum = AppendManagedProperty(catEnum, 9, "Incremented value", typeof(double), 1.2, "");
            propEnum.Property.Feel = GetRegisteredFeel(VisualHint.SmartPropertyGrid.PropertyGrid.FeelEditUpDown);

            ToolbarVisibility = true;
            CommentsVisibility = true;

            CommentsHeight = 50;

            DrawingManager = DrawManagers.LightColorDrawManager;
        }

        protected override void OnPropertyChanged(VisualHint.SmartPropertyGrid.PropertyChangedEventArgs e)
        {
            if (e.PropertyEnum.Property.Id == 3)
                Application.UseWaitCursor = UseWaitCursor;
            else if (e.PropertyEnum.Property.Id == 7)
            {
                ParentForm.Opacity = (double)Opacity / 100.0;
                FormBackColor = Color.FromArgb((int)((double)Opacity / 100.0 * 255.0), FormBackColor);
            }
            else if (e.PropertyEnum.Property.Id == 5)
            {
                ParentForm.Opacity = FormBackColor.A / 255.0;
                Opacity = (int)(ParentForm.Opacity * 100.0);
                ParentForm.BackColor = Color.FromArgb(FormBackColor.R, FormBackColor.G, FormBackColor.B);
            }
            else if (e.PropertyEnum.Property.Id == 10)
            {
                PropertyEnumerator propEnum = FindProperty(6);
                propEnum.Property.Value.ReadOnly = (bool)e.PropertyEnum.Property.Value.GetValue();
            }

            base.OnPropertyChanged(e);
        }

        protected override void OnInPlaceCtrlVisible(InPlaceCtrlVisibleEventArgs e)
        {
            if (e.PropertyEnum.Property.Id == 7)
            {
                if (e.InPlaceCtrl is PropInPlaceTrackbar ctrl) ctrl.RealtimeChange = true;
            }
            else if (e.PropertyEnum.Property.Id == 3)
            {
                if (e.InPlaceCtrl is PropInPlaceCheckbox ctrl) ctrl.RealtimeChange = true;
            }
            else if ((e.PropertyEnum.Parent.Property != null) && (e.PropertyEnum.Parent.Property.Id == 6))
            {
                if (e.InPlaceCtrl is PropInPlaceUpDown ctrl) ctrl.RealtimeChange = true;
            }
            else if (e.PropertyEnum.Property.Id == 9)
            {
                if (e.InPlaceCtrl is PropInPlaceUpDown ctrl) ctrl.RealtimeChange = false;
            }
            else if (e.PropertyEnum.Property.Id == 10)
            {
                if (e.InPlaceCtrl is PropInPlaceCheckbox ctrl) ctrl.RealtimeChange = true;
            }

            base.OnInPlaceCtrlVisible(e);
        }

        protected override void OnPropertyCreated(PropertyCreatedEventArgs e)
        {
            if (e.PropertyEnum.Parent.Property != null)
            {
                if (e.PropertyEnum.Parent.Property.Id == 6)
                    e.PropertyEnum.Property.Feel = GetRegisteredFeel(VisualHint.SmartPropertyGrid.PropertyGrid.FeelEditUpDown);
            }

            if (e.PropertyEnum.Property.Id == 8)
            {
                ImageList il = new();
				ResourceManager resourceManager = new("QuickStart.MainResources", Assembly.GetExecutingAssembly());

                il.ColorDepth = ColorDepth.Depth32Bit;
                il.Images.Add((Bitmap?)resourceManager.GetObject("king"));
                il.Images.Add((Bitmap?)resourceManager.GetObject("queen"));
                il.Images.Add((Bitmap?)resourceManager.GetObject("rook"));
                il.Images.Add((Bitmap?)resourceManager.GetObject("bishop"));
                il.Images.Add((Bitmap?)resourceManager.GetObject("knight"));
                il.Images.Add((Bitmap?)resourceManager.GetObject("pawn"));

                e.PropertyEnum.Property.Value.ImageList = il;
            }

            base.OnPropertyCreated(e);
        }

        protected override void OnDisplayedValuesNeeded(DisplayedValuesNeededEventArgs e)
        {
            if (e.PropertyEnum.Property.Id == 8)
                e.DisplayedValues = new string[] { "King", "Queen", "Rook", "Bishop", "Knight", "Pawn" };

            base.OnDisplayedValuesNeeded(e);
        }

        protected override void OnPropertyUpDown(PropertyUpDownEventArgs e)
        {
            if (e.PropertyEnum.Property.Id == 9)
                e.Value = (Double.Parse(e.Value) + (e.ButtonPressed == PropertyUpDownEventArgs.UpDownButtons.Up ? 0.1 : -0.1)).ToString();

            base.OnPropertyUpDown(e);
        }
    }
}
