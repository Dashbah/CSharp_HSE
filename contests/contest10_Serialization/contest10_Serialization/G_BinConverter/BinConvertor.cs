namespace contest10_Serialization.G_BinConverter;

public class BinConvertor
{
    static void Convert()
    {
        var inputLines = File.ReadAllLines("input.txt");
        ushort[] arr = new ushort[inputLines.Length];
        for (int i = 0; i < inputLines.Length; i++) {
            arr[i] = ushort.Parse(inputLines[i]);
        }

        using (BinaryWriter writer = new BinaryWriter(File.Open("output.bin", FileMode.OpenOrCreate))) {
            foreach (var num in arr) {
                writer.Write(num);
            }
        }
    }
}