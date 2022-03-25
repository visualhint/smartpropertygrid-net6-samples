using VisualHint.SmartPropertyGrid;

namespace PropertiesStates
{
public class PropertyExpandedAttribute : PropertyCreatedHandlerAttribute
{
    public override void OnPropertyCreated(PropertyEnumerator propEnum)
    {
        propEnum.Property.ParentGrid.ExpandProperty(propEnum, true);
    }
}
}
