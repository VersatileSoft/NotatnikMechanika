using System;

namespace MvvmPackage.Core.Attributes
{
    /// <summary>
    /// Mark service implementation to register as singleton
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class SingleInstanceAttribute : Attribute
    {
    }
}
