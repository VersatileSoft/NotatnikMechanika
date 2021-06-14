using System;

namespace NotatnikMechanika.Core.Interfaces
{
    public interface IMessageDialogService
    {
        void ShowMessageDialog(string message, MessageDialogType type, string? title = null);
    }

    public enum MessageDialogType
    {
        Info = 0,
        Success = 1,
        Warning = 2,
        Error = 3
    }

    public static class EnumHelper
    {
        public static T ConvertTo<T>(this object value) where T : struct, IConvertible
        {
            var sourceType = value.GetType();
            if (!sourceType.IsEnum)
            {
                throw new ArgumentException("Source type is not enum");
            }

            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("Destination type is not enum");
            }

            return (T)Enum.Parse(typeof(T), value.ToString());
        }
    }
}