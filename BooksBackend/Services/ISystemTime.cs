using System;

namespace BooksBackend.Services
{
    public interface ISystemTime
    {
        DateTime GetCurrent();
    }
}