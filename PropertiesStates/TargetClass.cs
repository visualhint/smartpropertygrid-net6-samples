using System.ComponentModel;
using VisualHint.SmartPropertyGrid;

namespace PropertiesStates
{
    public class TargetClass
    {
        [PropertyExpanded]
        [Category("Settings")]
        [DefaultSelectedProperty]
        [Description("This property is initially expanded thanks to the PropertyExpanded attribute attached to it. It is also selected by default.")]
        public Size Size { get; set; } = new Size(10, 20);

        [Category("Settings")]
        public Font Font { get; set; } = new Font("Arial", 8f);
    }
}
