using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem_WebAPI_Client.IInputOutputClient
{
   public interface IOutputClient
    {
        void Write(string text);
        void WriteLine(string text);
        void Write(string format, params object [] values);
        void WriteLine(string format, params object [] values);
    }
}
