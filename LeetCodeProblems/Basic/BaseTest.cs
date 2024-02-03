namespace LeetCodeProblems.Basic;

public abstract class BaseTest
{
    protected int _secondsToSolve = 2;
    protected long  _memoryUsedThreshold = 2048;
    
    [SetUp]
    public abstract void Setup();
}