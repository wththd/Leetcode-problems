using System.Diagnostics;
using LeetCodeProblems.Basic;

namespace LeetCodeProblems.Medium.AddTwoNumbers;

public class AddTwoNumbers : BaseTest<ListNode, ListNode, ListNode>
{ 
    public override void Setup()
    {
        _inputs = new List<ListNode>
        {
            new(2, new ListNode(4, new ListNode(3))),
            new(),
            new(9, new ListNode(9, new ListNode(9,
                new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9))))))),
            new(2, new ListNode(4, new ListNode(9))),
            new(9),
        };
        
        _inputs2 = new List<ListNode>
        {
            new(5, new ListNode(6, new ListNode(4))),
            new(),
            new(9, new ListNode(9, new ListNode(9,
                new ListNode(9)))),
            new(5, new ListNode(6, new ListNode(4,
                new ListNode(9)))),
            // [1,9,9,9,9,9,9,9,9,9]
            new(1, new ListNode(9, new ListNode(9,
                new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9,
                    new ListNode(9, new ListNode(9))))))))))
        };
        
        _outputs = new List<ListNode>
        {
            new(7, new ListNode(0, new ListNode(8))),
            new(),
            new(8, new ListNode(9, new ListNode(9,
                new ListNode(9, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(1)))))))),
            new(7, new ListNode(0, new ListNode(4, new ListNode(0, new ListNode(1))))),
            // 0,0,0,0,0,0,0,0,0,0,1
            new(0, new ListNode(0, new ListNode(0,
                new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, 
                    new ListNode(0, new ListNode(0, new ListNode(1))))))))))),
        };
    }

    protected override ListNode Solve(ListNode input1, ListNode input2)
    {
        var resultNode = new ListNode();
        var currentNode = resultNode;
        var addition = 0;

        while (input1 != null || input2 != null || addition != 0) {
            var firstNodeValue = input1?.val ?? 0;
            var secondNode = input2?.val ?? 0;

            var sum = firstNodeValue + secondNode + addition;
            addition = sum / 10;

            currentNode.next = new ListNode(sum % 10);
            currentNode = currentNode.next;

            input1 = input1?.next;
            input2 = input2?.next;
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
            //Assert.That(stopWatch.Elapsed.Seconds, Is.LessThan(_secondsToSolve));
            Console.WriteLine($"{GetType().Name} test {i} time : {stopWatch.Elapsed.Nanoseconds} ns");
        }
    }
}