using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace vvma {
    class Config {

        public TestCommand[] TestCommands { get; set; } = new TestCommand[0];

        public int StartNote { get; set; }

        public int EndNote { get; set; }

        public string MidiInPort { get; set; }

        public int MidiChannel { get; set; }

        public string ServerAddress { get; set; } = "192.168.4.1";

        public int ServerPort { get; set; } = 5233;

        public static Config Open(string file) {    
            var content = File.ReadAllText(file);
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(PascalCaseNamingConvention.Instance)
                .IgnoreUnmatchedProperties()
                .Build();
            return deserializer.Deserialize<Config>(content);
        }

    }

    class TestCommand {
        public string Name { get; set; }

        public string Value { get; set; }

        public override string ToString() => $"{Name} ({Value})";
    }
}
