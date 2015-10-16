using System.Collections.Generic;

namespace Assignment_6.Services {
    public interface IDatabase {
        int Size { get; }
        void AddString(string key, string newData);
        IEnumerable<string> GetData(string key);
    }
}
