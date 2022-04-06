using VisualHint.SmartPropertyGrid.FluentApi;
using static VisualHint.SmartPropertyGrid.PropertyGrid;
using VisualHint.SmartPropertyGrid;
using System.Reflection;
using System.Resources;
using System.ComponentModel.Design;
using System.Collections;

namespace PropertyGridShowRoom
{
    public class TargetClassProfile : SelectedObjectProfile
    {
        private static readonly string TextboxesCategory = "Textboxes alone";
        private static readonly string ButtonsCategory = "Buttons";
        private static readonly string ListsCategory = "Lists";
        private static readonly string EditorsCategory = "UITypeEditors";
        private static readonly string ReflectionCategory = "Reflection";
        private static readonly string MiscellaneousCategory = "Miscellaneous";

        private static int propertySortedIndex = 1;

        public ArrayList upDownString = new();

        public TargetClassProfile()
        {
            // TODO: how to insert managed properties?
            // TODO: how to manage subcategories?

            upDownString.Add("Red");
            upDownString.Add("Green");
            upDownString.Add("Blue");
            upDownString.Add("Yellow");
            upDownString.Add("Magenta");

            AddTargetConfiguration<TargetClass>()
                .OnSelectedObjectChanging(grid =>
                {

                })

                /*.ForCategory("x", config => config
                    .Comment("")
                    .ValueText("")
                    .Sorted(1)
                    .ForProperty(x => x.Editbox1, config => ....)
                )*/

                // Unit property is not created because it's used on another property (Frequency) as an added value
                .ForProperty(x => x.Unit, config => config.FilterOut(PropertyPreFilterOutEventArgs.FilterModes.FilterOut))

                // FontColor property is not created because it is later added manually as a child of a Font property
                .ForProperty(x => x.FontColor, config => config.FilterOut(PropertyPreFilterOutEventArgs.FilterModes.FilterOut))

                // Textboxes category

                .ForProperty(x => x.Editbox1, config => config
                    .Id(1000)
                    .Sorted(propertySortedIndex++)
                    .Category(TextboxesCategory, 1)
                    .DisplayName("Simple string")
                    .Comment("Icons can be set on property labels. They are supplied through an ImageList set on the grid.\n\nA bold font has been set on the Value. A validator is also attached: it checks that the first letter is uppercase.")
                    .Validator<PropertyValidatorFirstLetterUppercase>()
                    .PropertyCreated((args, grid) =>
                    {
                        args.PropertyEnum.Property.Value.Font = new Font(grid.Font, FontStyle.Italic);
                        args.PropertyEnum.Property.ImageIndex = 1;
                        args.PropertyEnum.Property.Value.ImageSource = ImageSources.Grid;
                        args.PropertyEnum.Property.Value.ImageIndex = 5;
                    })
                )

                .ForProperty(x => x.Editbox11, config => config
                    .Sorted(propertySortedIndex++)
                    .Category(TextboxesCategory, 1)
                    .DisplayName("Masked textbox")
                    .Feel(FeelMaskedEdit)
                    .Look<PropertyMaskedEditLook>("(000) 000-0000")
                    .Comment("The text color can be changed on the value.")
                    .PropertyCreated((args, grid) =>
                    {
                        args.PropertyEnum.Property.Value.ForeColor = Color.Red;
                        args.PropertyEnum.Property.Value.Font = new Font(grid.Font, FontStyle.Bold);
                    })
                )

                .ForProperty(x => x.Editbox3, config => config
                    .Sorted(propertySortedIndex++)
                    .Category(TextboxesCategory, 1)
                    .DisplayName("Multiline Edit box")
                    .Feel(FeelMultilineEdit)
                    .Look<PropertyMultilineEditLook>()
                    .Comment("Icons can be set on values. They can be supplied through various sources. Here it comes from an ImageList.\n\nYou can choose the height of a multiline property.")
                    .PropertyCreated((args, grid) =>
                    {
                        args.PropertyEnum.Property.HeightMultiplier = 3;
                        args.PropertyEnum.Property.Value.ImageSource = ImageSources.Grid;
                        args.PropertyEnum.Property.Value.ImageIndex = 3;
                    })
                )

                .ForProperty(x => x.Editbox2, config => config
                    .Sorted(propertySortedIndex++)
                    .Category(TextboxesCategory, 1)
                    .DisplayName("Simple integer")
                    .Feel(FeelEdit)
                    .Validator<PropertyValidatorMinMax>(0, 200)
                    .Comment("A validator object has been attached to this property to set a valid range [0..200].")
                )

                .ForProperty(x => x.Editbox10, config => config
                    .Sorted(propertySortedIndex++)
                    .Category(TextboxesCategory, 1)
                    .DisplayName("Password")
                    .IsPassword()
                    .Comment("This property uses custom look and feel classes to display a password.")
                )

                // Buttons category

                .ForCategory(ButtonsCategory, property => {
                    property.Comment = "This category has a non editable value. This is useful for example to show a key child property value when the category is collapsed.";
                    ((RootCategory)property).ValueText = "(14 properties)";
                })

                .ForProperty(x => x.ButtonVar1, config => config
                    .Sorted(propertySortedIndex++)
                    .Category(ButtonsCategory, 2)
                    .DisplayName("Button1")
                    .Feel(FeelButton)
                    .Comment("The button has a custom text.")
                    .InPlaceCtrlVisible((args, grid) => {
                        var e = args as InPlaceCtrlVisibleEventArgs;
                        if (e.InPlaceCtrl is PropInPlaceButton btn) btn.ButtonText = "test";
                    })
                )

                .ForProperty(x => x.ButtonVar2, config => config
                    .Sorted(propertySortedIndex++)
                    .Category(ButtonsCategory, 2)
                    .DisplayName("Button2")
                    .Feel(FeelButton)
                    .Comment("When the button is clicked, a message is displayed and the value is changed to 99.")
                    .PropertyCreated((args, grid) => {
                        args.PropertyEnum.Property.Font = new Font(grid.Font, FontStyle.Italic);
                        args.PropertyEnum.Property.Value.Font = new Font(grid.Font, FontStyle.Bold);
                    })
                    .PropertyButtonClicked((args, grid) => {
                        var e = args as PropertyButtonClickedEventArgs;

                        MessageBox.Show("OnPropertyButtonClicked");

                        e.PropertyEnum.Property.Value.SetValue(99);
                        e.PropertyChanged = true;
                    })
                    .InPlaceCtrlVisible((args, grid) => {
                        var e = args as InPlaceCtrlVisibleEventArgs;
                        if (e.InPlaceCtrl is PropInPlaceButton btn) btn.ButtonText = "...";
                    })
                )

                .ForProperty(x => x.ButtonVar3, config => config
                    .Sorted(propertySortedIndex++)
                    .Category(ButtonsCategory, 2)
                    .DisplayName("Enumeration")
                    .Feel(FeelCheckbox)
                    .Look<PropertyCheckboxLook>()
                    .Comment("This property is linked to an enumeration which has the [Flags] attribute.")
                    .PropertyCreated((args, grid) => {
                        args.PropertyEnum.Property.Value.Font = new Font(grid.Font, FontStyle.Bold);
                    })
                )

                .ForProperty(x => x.ListVar9, config => config
                    .Sorted(propertySortedIndex++)
                    .Category(ButtonsCategory, 2)
                    .DisplayName("Boolean")
                    .Feel(FeelCheckbox)
                    .Look<PropertyCheckboxLook>()
                    .DisplayedValues(new string[] { "Enabled", "Disabled" })
                    .Comment("Checkboxes can also be applied to a simple boolean and the displayed values can be customized.")
                )

                .ForProperty(x => x.ButtonVar4, config => config
                    .Sorted(propertySortedIndex++)
                    .Category(ButtonsCategory, 2)
                    .DisplayName("Radio buttons")
                    .Feel(FeelRadioButton)
                    .Look<PropertyRadioButtonLook>()
                    .Comment("This property is linked to an enumeration and displays custom strings.")
                )

                .ForProperty(x => x.Time, config => config
                    .Sorted(propertySortedIndex++)
                    .Category(ButtonsCategory, 2)
                    .Feel(FeelDateTime)
                    .Look<PropertyDateTimeLook>("mm:ss")
                )

                .ForProperty(x => x.UpDownVar1, config => config
                    .Sorted(propertySortedIndex++)
                    .DisplayName("Enum")
                    .Category(ButtonsCategory, 2)
                    .Feel(FeelUpDown)
                    .Comment("An updown control is also neat with an enumeration. Realtime mode has been set to true so no cancellation possible with Escape.")
                    .PropertyCreated((args, grid) =>
                    {
                        args.PropertyEnum.Property.Value.BackColor = Color.Cornsilk;
                    })
                )

                .ForProperty(x => x.UpDownVar2, config => config
                    .Sorted(propertySortedIndex++)
                    .DisplayName("Enum")
                    .Category(ButtonsCategory, 2)
                    .Feel(FeelEditUpDown)
                    .Comment("An updown control is also neat with an enumeratiom. Here I added a textbox.")
                    .PropertyCreated((args, grid) =>
                    {
                        args.PropertyEnum.Property.Value.Font = new Font(grid.Font, FontStyle.Bold);
                    })
                )

                .ForProperty(x => x.UpDownVar3, config => config
                    .Sorted(propertySortedIndex++)
                    .DisplayName("Boolean")
                    .Category(ButtonsCategory, 2)
                    .Feel(FeelEditUpDown)
                    .Comment("An updown control can also be used with a boolean. Maybe not very common but it shows you how value types and inplace controls can be associated in a flexible way.")
                    .PropertyCreated((args, grid) =>
                    {
                        args.PropertyEnum.Property.BackColor = Color.WhiteSmoke;
                        args.PropertyEnum.Property.ForeColor = Color.CadetBlue;
                        args.PropertyEnum.Property.Value.BackColor = grid.GridBackColor;
                        args.PropertyEnum.Property.Value.ForeColor = grid.GridForeColor;
                    })
                )

                .ForProperty(x => x.UpDownVar4, config => config
                    .Sorted(propertySortedIndex++)
                    .DisplayName("Custom increment")
                    .Category(ButtonsCategory, 2)
                    .Feel(FeelEditUpDown)
                    .Comment("The content is modified dynamically via notification. Here the increment is changed to 0.05. Limits between -1.0 and 1.0.")
                    .Validator<PropertyValidatorMinMax>(-1.0, 1.0)
                    .PropertyUpDown((args, grid) => {
                        try
                        {
                            var e = args as PropertyUpDownEventArgs;
                            e.Value = (double.Parse(e.Value) + (e.ButtonPressed == PropertyUpDownEventArgs.UpDownButtons.Up ? 0.05 : -0.05)).ToString();
                        }
                        catch (FormatException)
                        {
                        }
                    })
                    .InPlaceCtrlVisible((args, grid) => {
                        var e = args as InPlaceCtrlVisibleEventArgs;
                        if (e.InPlaceCtrl is PropInPlaceUpDown ctrl) ctrl.RealtimeChange = false;
                    })
                )

                .ForProperty(x => x.UpDownVar5, config => config
                    .Sorted(propertySortedIndex++)
                    .DisplayName("Custom list")
                    .Category(ButtonsCategory, 2)
                    .Feel(FeelEditUpDown)
                    .Comment("The content of this property is changed at runtime. This is in fact a simple string.")
                    .PropertyUpDown((args, grid) => {
                        var e = args as PropertyUpDownEventArgs;
                        int index = upDownString.IndexOf(e.Value);
                        try
                        {
                            e.Value = (string?)upDownString[index + (e.ButtonPressed == PropertyUpDownEventArgs.UpDownButtons.Up ? -1 : 1)];
                        }
                        catch
                        {
                        }
                    })
                )

                // Lists category

                .ForProperty(x => x.ListVar1, config => config
                    .Sorted(propertySortedIndex++)
                    .Category(ListsCategory, 3)
                    .DisplayName("Enum")
                    .Feel(FeelList)
                    .Comment("Displays a simple enumeration. It has no textbox. A checkbox allows the user to disable the property.")
                    .PropertyCreated((args, grid) =>
                    {
                        grid.SetManuallyDisabled(args.PropertyEnum, true);
                        grid.EnableProperty(args.PropertyEnum, false);
                    })
                )

                .ForProperty(x => x.ListVar2, config => config
                    .Sorted(propertySortedIndex++)
                    .Category(ListsCategory, 3)
                    .DisplayName("Enum")
                    .Feel(FeelEditList)
                    .Comment("The list is linked to a boolean but the displayed strings have been customized.")
                )

                .ForProperty(x => x.ListVar8, config => config
                    .Sorted(propertySortedIndex++)
                    .Category(ListsCategory, 3)
                    .DisplayName("Enum with icons")
                    .Feel(FeelList)
                    .Comment("By just adding an ImageList to the Value, you can nicely enhance the user experience.")
                    .DisplayedValues(new string[] { "Firefox", "Internet Explorer", "Netscape", "Opera" })
                    .PropertyCreated((args, grid) =>
                    {
                        var resourceManager = new ResourceManager("PropertyGridShowRoom.MainResources", Assembly.GetExecutingAssembly());
                        var il = new ImageList { ColorDepth = ColorDepth.Depth32Bit };
                        il.Images.Add((Bitmap?)resourceManager.GetObject("browser_firefox"));
                        il.Images.Add((Bitmap?)resourceManager.GetObject("browser_internetexplorer"));
                        il.Images.Add((Bitmap?)resourceManager.GetObject("browser_netscape"));
                        il.Images.Add((Bitmap?)resourceManager.GetObject("browser_opera"));
                        args.PropertyEnum.Property.Value.ImageList = il;
                    })
                )

                .ForProperty(x => x.ListVar3, config => config
                    .Sorted(propertySortedIndex++)
                    .Category(ListsCategory, 3)
                    .DisplayName("Boolean")
                    .Feel(FeelEditList)
                    .DisplayedValues(new string[] { "Enabled", "Disabled" })
                    .Comment("The list is linked to a boolean but the displayed strings have been customized.")
                )

                .ForProperty(x => x.ListVar4, config => config
                    .Sorted(propertySortedIndex++)
                    .Category(ListsCategory, 3)
                    .DisplayName("Alpha color")
                    .Feel(FeelList)
                    .Look<PropertyAlphaColorLook>()
                    .Comment("Uses a custom look and feel to edit color with alpha.")
                )

                .ForProperty(x => x.ListVar6, config => config
                    .Sorted(propertySortedIndex++)
                    .Category(ListsCategory, 3)
                    .DisplayName("List of dynamic strings")
                    .Comment("This property displays a simple string. Possible values are requested to the client app by callback.")
                    .DisplayedValues(new string[] { "Mercury", "Venus", "Earth", "Mars", "Jupiter", "Saturn" })
                    .UseFeelCache()
                )

                .ForProperty(x => x.ListVar7, config => config
                    .Sorted(propertySortedIndex++)
                    .Category(ListsCategory, 3)
                    .DisplayName("Frequency")
                    .Feel(FeelEditUnit)
                    .Look<PropertyUnitLook>()
                    .Comment("This property displays 2 values in one row.")
                    .Validator<PropertyValidatorMinMax>(0.0, 5.0)
                    .PropertyCreated((args, grid) =>
                    {
                        args.PropertyEnum.Property.AddValue(PropertyUnitLook.UnitValue, grid.SelectedObject, "Unit", null);  // .AddedValue(PropertyUnitLook.UnitValue, x => x.Unit, null) // Use ValueAddedToPropertyAttribute internally
                        args.PropertyEnum.Property.GetValue(PropertyUnitLook.UnitValue).SetValue(TargetClass.Units.Hz);
                    })
                )

                .ForProperty(x => x.Date, config => config
                    .Sorted(propertySortedIndex++)
                    .Category(ListsCategory, 3)
                    .DisplayName("Date")
                )

                // UITypeEditors category

                .ForCategory(EditorsCategory, property => property.Comment = "SPG.Net is now compatible with all Microsoft and custom UITypeEditors.")

                .ForProperty(x => x.FontName, config => config
                    .Sorted(propertySortedIndex++)
                    .Category(EditorsCategory, 4)
                    .DisplayName("Font name")
                    .Look<PropertyFontNameLook>()
                    .TypeConverter<FontConverter.FontNameConverter>()
                )

                .ForProperty(x => x.LongString, config => config
                    .Sorted(propertySortedIndex++)
                    .Category(EditorsCategory, 4)
                    .DisplayName("Long string")
                    .UITypeEditor<MultilineStringEditor>()
                )

                .ForProperty(x => x.ColorArray, config => config
                    .Sorted(propertySortedIndex++)
                    .Category(EditorsCategory, 4)
                    .DisplayName("Colors")
                    .Comment("When the collection is changed, each child property gets a new special name. It is also initially expanded.")
                    .PropertyCreated((args, grid) =>
                    {
                        grid.ExpandProperty(args.PropertyEnum, true);
                    })
                    .PropertyChanged((args, grid) => {
                        var e = args as PropertyChangedEventArgs;
                        PropertyEnumerator childEnum = e.PropertyEnum.Children;
                        childEnum.MoveFirst();
                        int i = 1;
                        while (childEnum != childEnum.RightBound)
                        {
                            childEnum.Property.DisplayName = "Color " + (i++);
                            childEnum.MoveNext();
                        }
                    })
                )

                .ForProperty(x => x.Icon, config => config
                    .Sorted(propertySortedIndex++)
                    .Category(EditorsCategory, 4)
                    .ShowAllChildProperties(true)
                    .Comment("On this property, there is a ValueValidation event handler to show a message when its UITypeEditor throws an exception.")
                    .ValueValidation((args, grid) => {
                        var e = args as ValueValidationEventArgs;
                        if (e.ValueValidationResult == PropertyValue.ValueValidationResult.ExceptionByUITypeEditor)
                        {
                            MessageBox.Show(e.Exception.InnerException != null ? e.Exception.InnerException.Message : e.Message,
                                "Properties window", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                            return;
                        }
                    })
                )

                // Miscellaneous category

                .ForProperty(x => x.Editbox5, config => config
                    .Sorted(propertySortedIndex++)
                    .Category(MiscellaneousCategory, 5)
                    .DisplayName("Trackbar")
                    .Feel(FeelTrackbar)
                    .Validator<PropertyValidatorMinMax>(0, 200)
                    .Comment("Property is updated in realtime. The limits have been set to [0..200].")
                    .InPlaceCtrlVisible((args, grid) => {
                        var e = args as InPlaceCtrlVisibleEventArgs;
                        if (e.InPlaceCtrl is PropInPlaceUpDown ctrl) ctrl.RealtimeChange = true;
                    })
                )

                .ForProperty(x => x.MyPoint, config => config
                    .Sorted(propertySortedIndex++)
                    .Category(MiscellaneousCategory, 5)
                    .DisplayName("PointF/generic trackbars")
                    .Comment("Trackbars are attached to the child properties. A trackbar can be associated with integer, float, double and decimal properties.")
                    .TypeConverter<PointFConverter>()
                    .ChildFeel("X", FeelTrackbarEdit)
                    .ChildFeel("Y", FeelTrackbarEdit)
                    .ChildValidator<PropertyValidatorMinMax>("X", 0.0f, 10.0f)
                    .ChildValidator<PropertyValidatorMinMax>("Y", 0.0f, 10.0f)
                    .Validator<PropertyValidatorPointFMinMax>(0.0f, 10.0f, 0.0f, 10.0f)
                    .ChildTrackBarSettings("X", 0.1f, 0.1f, 1.0f)
                    .ChildTrackBarSettings("Y", 0.1f, 0.1f, 1.0f)
                )

                .ForProperty(x => x.Editbox13, config => config
                    .Sorted(propertySortedIndex++)
                    .Category(MiscellaneousCategory, 5)
                    .DisplayName("Progress bar")
                    .Look<PropertyProgressBarLook>(true, "{0}%")
                    .Feel(FeelNone)
                    .Comment("The value of the progress bar depends on the above sliders. The text has been customized to show a percentage.")
                )

                .ForProperty(x => x.Editbox6, config => config
                    .Sorted(propertySortedIndex++)
                    .Category(MiscellaneousCategory, 5)
                    .DisplayName("Disabled item")
                    .Comment("This property has been explicitely disabled even if the underlying C# property is not readonly.")
                    .PropertyCreated((args, grid) => {
                        grid.EnableProperty(args.PropertyEnum, false);
                    })
                )

                .ForProperty(x => x.Editbox12, config => config
                    .Sorted(propertySortedIndex++)
                    .Category(MiscellaneousCategory, 5)
                    .DisplayName("Readonly item")
                    .Comment("This underlying C# property is decorated with the Readonly attribute so you can't change this state. The color of the text can still be changed.")
                    .PropertyCreated((args, grid) => {
                        args.PropertyEnum.Property.ReadOnlyForeColor = Color.DarkGreen;
                    })
                )

                // Reflection category

                .ForProperty(x => x.MyFont, config => config
                    .Sorted(propertySortedIndex++)
                    .Category(ReflectionCategory, 5)
                    .DisplayName("Font")
                    .Comment("This property content is discovered by reflection but I customized it to hide certain subproperties, add a Color property, set the booleans as checkboxes with various texts and assigned up/down buttons to Size.")
                    .ChildLook<PropertyCheckboxLook>("Italic")
                    .ChildLook<PropertyCheckboxLook>("Strikeout")
                    .ChildLook<PropertyCheckboxLook>("Underline")
                    .ChildLook<PropertyCheckboxLook>("Bold")
                    .ChildFeel("Strikeout", FeelCheckbox)
                    .ChildFeel("Italic", FeelCheckbox)
                    .ChildFeel("Underline", FeelCheckbox)
                    .ChildFeel("Bold", FeelCheckbox)
                    .ChildFeel("Size", FeelEditUpDown)
                    .ChildDisplayedValues("Bold", new string[] { "", "" })
                    .ChildDisplayedValues("Italic", new string[] { "Yes", "No" })
                    .HideChildProperties("GdiCharSet", "GdiVerticalFont", "Unit")
                    .PropertyCreated((args, grid) =>
                    {
                        args.PropertyEnum.Property.Value.Validator = new PropertyValidatorFontSize(5.0f, 15.0f);

                        // In case LazyLoading==true, the children have not been created yet, so expand the property to be sure...
                        grid.ExpandProperty(args.PropertyEnum, true);

                        var childEnum = args.PropertyEnum.Children;
                        if (childEnum.Count > 0)
                        {
                            childEnum.MoveFirst();
                            childEnum.Property.Comment = "Uses a UITypeEditor. By the way, you can set comments to auto-discovered subproperties...";
                            childEnum.MoveNext();
                            childEnum.Property.Comment = "A custom feel has been applied to this property. It is done by setting an attribute to its parent. Also a validator constrains the value between 5 and 15.";
                            childEnum.Property.Value.Validator = new PropertyValidatorMinMax((Single)5.0, (Single)15.0);
                            childEnum.MoveNext();

                            var propEnum = grid.InsertProperty(childEnum, 150, "Color", grid.SelectedObject, "FontColor", "");
                            propEnum.Property.Feel = grid.GetRegisteredFeel(FeelList);
                            propEnum.Property.Look = new PropertyAlphaColorLook();
                            propEnum.Property.Comment = "This color has been added to the children of the font. It uses an alpha color editor.";

                            propEnum.MoveNext();
                            propEnum.Property.Comment = "The text of a checkbox can be removed.";
                            propEnum.MoveNext();
                            propEnum.Property.Comment = "The text of a checkbox can be customized.";

                            grid.ExpandProperty(args.PropertyEnum, false);
                        }
                    })
                )

                .ForProperty(x => x.Rect, config => config
                    .Sorted(propertySortedIndex++)
                    .Category(ReflectionCategory, 5)
                    .DisplayName("Rectangle")
                    .Feel(FeelEdit)
                    .Comment("This property content is discovered by reflection but I customized it to hide certain subproperties.")
                    .HideChildProperties("Width", "Y")
                )

                .ForProperty(x => x.Pen, config => config
                    .Sorted(propertySortedIndex++)
                    .Category(ReflectionCategory, 5)
                    .Feel(FeelNone)
                    .Look<PropertyPenLook>()
                    .Comment("This property content is discovered by reflection but I customized it to hide certain subproperties. The parent node is custom drawn to reflect the color, width and type of the pen. The color has custom feel and look.")
                    .HideChildProperties("CompoundArray", "Transform", "Brush", "CustomStartCap", "CustomEndCap", "DashPattern")
                    .ShowAllChildProperties(true)
                    .ChildFeel("Width", FeelEditUpDown)
                    .ChildFeel("DashOffset", FeelEditUpDown)
                    .ChildFeel("MiterLimit", FeelEditUpDown)
                    .ChildFeel("Color", FeelList)
                    .ChildLook<PropertyAlphaColorLook>("Color")
                    .ChildDropDownContent<AlphaColorPicker>("Color")
                );
        }
    }
}
