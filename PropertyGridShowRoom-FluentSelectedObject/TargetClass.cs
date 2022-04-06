using VisualHint.SmartPropertyGrid;
using System.Collections;
using System.ComponentModel;
using System.Drawing.Design;
using System.ComponentModel.Design;

namespace PropertyGridShowRoom
{
    public class TargetClass
    {
        private DateTime _time = DateTime.Now;
        public DateTime Time
        {
            set { _time = value; }
            get { return _time; }
        }

        private string _editbox1 = "This is a string";

        public string Editbox1 { get { return _editbox1; } set { _editbox1 = value; } }

        private int _editbox2 = 300;

        public int Editbox2 { get { return _editbox2; } set { _editbox2 = value; } }

        private string _editbox3 = "This is a very very long string that cannot be displayed on a single line of text.";

        public string Editbox3 { get { return _editbox3; } set { _editbox3 = value; } }

        private int _editbox5 = 100;

        public int Editbox5 { get { return _editbox5; } set { _editbox5 = value; } }

        private int _editbox6 = 0;

        public int Editbox6 { get { return _editbox6; } set { _editbox6 = value; } }

        private string _editbox10 = "password";

        public string Editbox10 { get { return _editbox10; } set { _editbox10 = value; } }

        private string _editbox11 = "7124627662";

        public string Editbox11 { get { return _editbox11; } set { _editbox11 = value; } }

        private string _editbox12 = "Readonly";
        [ReadOnly(true)]
        public string Editbox12 { get { return _editbox12; } set { _editbox12 = value; } }

        private int _editbox13 = 100;

        public int Editbox13 { get { return _editbox13; } set { _editbox13 = value; } }

        public enum MyColors
        {
            Red = 0,
            Green = 2,
            [Browsable(false)]
            Blue = 5,
            Yellow = 6,
            Magenta = 8
        }

        public MyColors _editbox4 = MyColors.Green;

        private MyColors _upDownVar1 = MyColors.Green;
        public MyColors UpDownVar1 { get { return _upDownVar1; } set { _upDownVar1 = value; } }

        private MyColors _upDownVar2 = MyColors.Yellow;
        public MyColors UpDownVar2 { get { return _upDownVar2; } set { _upDownVar2 = value; } }

        private bool _upDownVar3 = true;
        public bool UpDownVar3 { get { return _upDownVar3; } set { _upDownVar3 = value; } }

        private double _upDownVar4 = 0.45;
        public double UpDownVar4 { get { return _upDownVar4; } set { _upDownVar4 = value; } }

        public ArrayList upDownString = new();

        public string _upDownVar5 = "Red";

        public string UpDownVar5 { get { return _upDownVar5; } set { _upDownVar5 = value; } }

        private int _buttonVar1 = 150;

        public int ButtonVar1 { get { return _buttonVar1; } set { _buttonVar1 = value; } }

        private int _buttonVar2 = 150;

        public int ButtonVar2 { get { return _buttonVar2; } set { _buttonVar2 = value; } }

        private PointF _ptf = new(1.5f, 3.2f);

        public PointF MyPoint
        {
            get { return _ptf; }
            set { _ptf = value; }
        }

        [Flags]
        public enum Countries
        {
            NoCountry = 0,
            Country1 = 1,
            Country2 = 2,
            AllCountries = 3
        }

        private Countries _buttonVar3 = Countries.Country2;

        [PropertyValueDisplayedAs(new string[] { "None", "France", "Spain", "All" })]
        public Countries ButtonVar3 { get { return _buttonVar3; } set { _buttonVar3 = value; } }

        private MyColors _buttonVar4 = MyColors.Magenta;

        //        [PropertyValueDisplayedAs(new string[] { "Red color", "Green", "Blue", "Yellow", "Magenta" })]
        public MyColors ButtonVar4 { get { return _buttonVar4; } set { _buttonVar4 = value; } }

        private MyColors _listVar1 = MyColors.Green;
        public MyColors ListVar1
        {
            set { _listVar1 = value; }
            get { return _listVar1; }
        }

        private MyColors _listVar2 = MyColors.Red;
        public MyColors ListVar2
        {
            set { _listVar2 = value; }
            get { return _listVar2; }
        }

        private bool _listVar3 = false;

        public bool ListVar3
        {
            set { _listVar3 = value; }
            get { return _listVar3; }
        }

        private Color _listVar4 = Color.FromArgb(40, Color.GreenYellow);

        [PropertyDropDownContent(typeof(AlphaColorPicker))]
        public Color ListVar4
        {
            set { _listVar4 = value; }
            get { return _listVar4; }
        }

        private string _listVar6 = "Earth";
        public string ListVar6
        {
            set { _listVar6 = value; }
            get { return _listVar6; }
        }

        private double _listVar7 = 1.053;

        public double ListVar7
        {
            set { _listVar7 = value; }
            get { return _listVar7; }
        }

        public enum Browsers
        {
            Firefox,
            // [PropertyValueDisplayedAs("Internet Explorer")]
            IE,
            Netscape,
            Opera
        }

        private Browsers _listVar8 = Browsers.Firefox;
        public Browsers ListVar8
        {
            set { _listVar8 = value; }
            get { return _listVar8; }
        }

        private bool _listVar9 = false;

        public bool ListVar9
        {
            set { _listVar9 = value; }
            get { return _listVar9; }
        }

        public enum Units
        {
            Hz,
            KHz,
            MHz,
            GHz
        }

        private Units _unit = Units.GHz;
        public Units Unit
        {
            set { _unit = value; }
            get { return _unit; }
        }

        private Rectangle _rect = new(0, 0, 100, 200);

        public Rectangle Rect
        {
            get { return _rect; }
            set { _rect = value; }
        }

        private Pen _pen = new(Color.FromArgb(128, Color.Red));

        public Pen Pen { get { return _pen; } set { _pen = value; } }

        private Color _fontColor = Color.FromArgb(150, Color.DodgerBlue);

        private Font _myFont = new("Arial", 10.0f);

        public Font MyFont
        {
            set { _myFont = value; }
            get { return _myFont; }
        }

        [PropertyDropDownContent(typeof(AlphaColorPicker))]
        public Color FontColor
        {
            get { return _fontColor; }
            set { _fontColor = value; }
        }

        private string _fontName = "Arial";

        public string FontName
        {
            get { return _fontName; }
            set { _fontName = value; }
        }

        private string _longString = "Very long text";

        public string LongString
        {
            get { return _longString; }
            set { _longString = value; }
        }

        private Color[] _colors = new Color[2];

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color[] ColorArray
        {
            set { _colors = value; }
            get { return _colors; }
        }

        private Icon _icon = SystemIcons.Error;
        public Icon Icon
        {
            get { return _icon; }
            set { _icon = value; }
        }

        private DateTime _date = new(2007, 06, 19);

        public DateTime Date
        {
            set { _date = value; }
            get { return _date; }
        }

        public TargetClass()
        {
            _colors[0] = SystemColors.ActiveBorder;
            _colors[1] = Color.FromArgb(100, 100, 100);

            upDownString.Add("Red");
            upDownString.Add("Green");
            upDownString.Add("Blue");
            upDownString.Add("Yellow");
            upDownString.Add("Magenta");
        }
    }
}
