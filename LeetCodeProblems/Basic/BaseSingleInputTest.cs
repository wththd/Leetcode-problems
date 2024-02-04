using System.Diagnostics;

namespace LeetCodeProblems.Basic;

public abstract class BaseTest<TInput, TOutput> : BaseTest
{
    protected List<TInput> _inputs = new();
    protected List<TOutput> _outputs = new();
    
    protected abstract TOutput Solve(TInput input);
    
    [Test]
    public virtual void Test()
    {
        var stopWatch = new Stopwatch();
        for (var i = 0; i < _inputs.Count; i++)
        {
            stopWatch.Reset();
            stopWatch.Start();
            var result = Solve(_inputs[i]);
            stopWatch.Stop();
            Assert.That(result, Is.EqualTo(_outputs[i]));
            Assert.That(stopWatch.Elapsed.Seconds, Is.LessThan(_secondsToSolve));
            Console.WriteLine($"{GetType().Name} test {i} time in milli: {stopWatch.ElapsedMilliseconds}");
        }
    }
}