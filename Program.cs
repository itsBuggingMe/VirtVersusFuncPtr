using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace VirtVersusFuncPtr;

[DisassemblyDiagnoser]
public unsafe class VirtVersusFuncPtr
{
    static void Main() => BenchmarkRunner.Run<VirtVersusFuncPtr>();

    static int Add(int a) => a;

    private IVirt _virtual = null!;
    private Impl _normal = null!;
    private delegate*<int, int> _pointer;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _pointer = &Add;
        _virtual = new Impl();
        _normal = new Impl();
    }

    [Benchmark]
    public void Virtual()
    {
        _virtual.Call(0);
        _virtual.Call(0);
        _virtual.Call(0);
        _virtual.Call(0);
    }

    [Benchmark]
    public void Pointer()
    {
        _pointer(0);
        _pointer(0);
        _pointer(0);
        _pointer(0);
    }

    [Benchmark]
    public void Normal()
    {
        _normal.Call(0);
        _normal.Call(0);
        _normal.Call(0);
        _normal.Call(0);
    }

    internal class Impl : IVirt
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public int Call(int a) => a;
    }

    internal interface IVirt
    {
        int Call(int a);
    }
}
