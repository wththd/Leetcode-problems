namespace LeetCodeProblems.Medium.AddTwoNumbers;

public class ListNode
{
    public int val;
    public ListNode? next;

    public ListNode(int val = 0, ListNode? next = null)
    {
        this.val = val;
        this.next = next;
    }

    public override bool Equals(object? obj)
    {
        var objToCheck = this;
        var targetObj = (ListNode)obj;
        if (targetObj == null)
        {
            return false;
        }
        
        Console.WriteLine($"{objToCheck.val} {targetObj.val}");
        if (objToCheck.val != targetObj.val)
        {
            return false;
        }
        
        while (objToCheck.next != null)
        {
            objToCheck = objToCheck.next;
            targetObj = targetObj.next;
            Console.WriteLine($"{objToCheck.val} {targetObj?.val}");
            if (objToCheck.val != targetObj?.val)
            {
                return false;
            }
        }

        return true;
    }
}