using System;

namespace Assignment_6.Services {

    /*
    * A class that generates unique request ids.
    */
    public class GuidRequestIdGenerator {
        public string Generate { get {
                return Guid.NewGuid().ToString();
            } }
    }
}
