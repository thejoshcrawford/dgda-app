using System;

namespace DGDABackend.DataLayer
{
    public class NotFoundException : Exception
    {
        public string ObjectName { get; set; }

        public NotFoundException(string objectName)
        {
            ObjectName = objectName;
        }
    }
}
