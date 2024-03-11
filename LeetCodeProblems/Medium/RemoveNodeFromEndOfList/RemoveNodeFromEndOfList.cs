using System.Diagnostics;
using LeetCodeProblems.Basic;
using LeetCodeProblems.Common;

namespace LeetCodeProblems.Medium;
public class RemoveNodeFromEndOfList : BaseTest<ListNode, int, ListNode>
{
    public override void Setup()
    {
        _inputs = new List<ListNode>
        {
            new(1, new ListNode(2, new ListNode(3,
                new ListNode(4, new ListNode(5))))),
            new(1),
            new(1, new ListNode(2)),
            new(1, new ListNode(2, new ListNode(3)))
        };

        _inputs2 = new List<int>
        {
            2, 1, 1, 3
        };

        _outputs = new List<ListNode>
        {
            new(1, new ListNode(2, new ListNode(3,
                new ListNode(5)))),
            new(),
            new(1),
            new(2, new ListNode(3))
        };
    }

    protected override ListNode Solve(ListNode? input, int input2)
    {
        var resultNode = new ListNode();
        var currentNode = resultNode;
        var length = 0;
        var tempNode = input;
        while (tempNode != null)
        {
            length++;
            tempNode = tempNode.next;
        }

        for (var i = 0; i < length - input2; i++)
        {
            currentNode.next = new ListNode(input.val);
            input = input.next;
            currentNode = currentNode.next;
        }
        
        input = input?.next;
        if (input != null)
        {
            currentNode.next = new ListNode(input.val);
            currentNode = currentNode.next;
            input = input.next;
            while (input != null)
            {
                currentNode.next = new ListNode(input.val);
                input = input.next;
                currentNode = currentNode.next;
            }
        }

        return resultNode.next;
    }
    
    [Test]
    public override void Test()
    {
        var stopWatch = new Stopwatch();
        for (var i = 0; i < _inputs.Count; i++)
        {
            stopWatch.Reset();
            stopWatch.Start();
            var result = Solve(_inputs[i], _inputs2[i]);
            stopWatch.Stop();
            Assert.IsTrue(_outputs[i].Equals(result));
            Assert.That(stopWatch.Elapsed.Seconds, Is.LessThan(_secondsToSolve));
            Console.WriteLine($"{GetType().Name} test {i} time : {stopWatch.Elapsed.Nanoseconds} ns");
        }
    }
}