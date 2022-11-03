using System;
using System.Text;
using System.IO;
using System.Text.Json;

namespace serial{

    public class SerialTest {
        public static void SerializeNow(string path, SerialData s) {
            string jsonStr = JsonSerializer.Serialize(s);
            File.WriteAllText(path, jsonStr);

        }
        public static SerialData DeSerializeNow(string path) {
            string jsonStr = File.ReadAllText(path);
            SerialData s = JsonSerializer.Deserialize<SerialData>(jsonStr);
            return s;
        }
        public static void Main(string[] args) {
            SerialData s = new SerialData();
            string path = "./.data.dat";
            Console.WriteLine("Attempting to serialize data......");
            SerializeNow(path, s);
            Console.WriteLine("Data has been successfully serialized!");
            Console.WriteLine("Attempting to deserialize data......");
            SerialData s2 = DeSerializeNow(path);
            Console.WriteLine("Data has been successfully deserialized!");
            Console.WriteLine($"{s2.name} - {s2.email} - Wins: {s2.wins} - Losses: {s2.losses}");
        }

        private static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }
    }

    public class SerialData{
        public int wins = 0;
        public int losses = 0;
        public string name = "Visual";
        public string email = "admin@serialize";

        public SerialData(){
            wins = 1;
        }
    }
}
