using System;

namespace OOO_NAN.Common
{
    public interface ICloseWindow
    {
        Action Close { get; set; }

        bool CanClose();
    }
}
