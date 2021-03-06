using System;
using System.Configuration;

namespace ConfigFiles {
    public class NewUserDefaultsSection : ConfigurationSection {

        [CallbackValidator(CallbackMethodName = "ValidateCity", Type = typeof(NewUserDefaultsSection))]
        [ConfigurationProperty("city", IsRequired = true)]
        public string City {
            get { return (string)this["city"]; }
            set { this["city"] = value; }
        }

        [ConfigurationProperty("country", DefaultValue = "USA")]
        public string Country {
            get { return (string)this["country"]; }
            set { this["country"] = value; }
        }

        [ConfigurationProperty("language")]
        public string Language {
            get { return (string)this["language"]; }
            set { this["language"] = value; }
        }

        [ConfigurationProperty("regionCode")]
        [IntegerValidator(MaxValue = 5, MinValue = 0)]
        public int Region {
            get { return (int)this["regionCode"]; }
            set { this["regionCode"] = value; }
        }

        public static void ValidateCity(object candidateValue) {
            string value = (string)candidateValue;
            if (value.ToLower() == "paris") {
                throw new Exception("City cannot be Paris");
            }
        }

    }
}
