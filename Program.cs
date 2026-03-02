using System.Diagnostics;
using ra1nyxin.RandomIpGen;

const string fileName = "ips.txt";
const int count = 10000;

Console.WriteLine($"[INFO] 正在生成 {count} 个公网 IPv4 地址...");
Stopwatch sw = Stopwatch.StartNew();

using (StreamWriter writer = new StreamWriter(fileName))
{
    for (int i = 0; i < count; i++)
    {
        string ip = NetworkUtils.GetRandomIp(noLocal: true);
        writer.WriteLine(ip);
    }
}

sw.Stop();
Console.WriteLine($"[SUCCESS] 生成完毕！耗时: {sw.ElapsedMilliseconds}ms");
Console.WriteLine($"[FILE] 结果已保存至: {Path.GetFullPath(fileName)}");
