using System.Diagnostics;

namespace LeetCodeProblems.Basic;

public abstract class BaseTest<TInput1, TInput2,TOutput> : BaseTest
{
    protected List<TInput1> _inputs = new();
    protected List<TInput2> _inputs2 = new();
    protected List<TOutput> _outputs = new();

    protected abstract TOutput Solve(TInput1 input1, TInput2 input2);

    [Test]
    public virtual void Test()
    {
        var stopWatch = new Stopwatch();
        for (var i = 0; i < _inputs.Count; i++)
        {
            stopWatch.Reset();
            stopWatch.Start();
            var result = Solve(_inputs[i], _inputs2[i]);
            stopWatch.Stop();
            Assert.That(result, Is.EqualTo(_outputs[i]));
            Assert.That(stopWatch.Elapsed.Seconds, Is.LessThan(_secondsToSolve));
            Console.WriteLine($"{GetType().Name} test {i} time : {stopWatch.Elapsed.Nanoseconds} ns");
        }
    }
}