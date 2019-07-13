using MvvmCross.Presenters.Attributes;

namespace NotatnikMechanika.WPF.Presenters.Attributes
{
    public class MasterDetailPageAttribute : MvxBasePresentationAttribute
    {
        public enum MasterDetailPosition
        {
            Master,
            Detail
        }
        public MasterDetailPosition Position { get; set; }
    }
}
