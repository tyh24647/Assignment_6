using System;

namespace Assignment_6.Services {
    public class GuidRequestIdGenerator : IRequestIdGenerator {
        public string Generate { get { return Guid.NewGuid().ToString(); } }
    }
}
