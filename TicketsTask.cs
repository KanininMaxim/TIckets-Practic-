using System.Numerics;

namespace Tickets;

public class TicketsTask
{

    public static BigInteger Solve(int halfLen, int totalSum)
    {
        if (totalSum % 2 != 0)
            return 0;

        var sum = totalSum / 2;
        var opt = new BigInteger[halfLen + 1, sum + 1];

        for (int i = 0; i <= (sum > 9 ? 9 : sum); i++)
            opt[1, i] = 1;

        for (var n = 2; n <= halfLen && opt[halfLen, sum] == 0; n++)
            for (var k = 0; k <= sum && opt[halfLen, sum] == 0; k++)
                opt[n, k] = RestoreAnswer(opt, n, k);

        return opt[halfLen, sum] * opt[halfLen, sum];
    }

    private static BigInteger RestoreAnswer(BigInteger[,] opt, int n, int k)
    {
        var result = new BigInteger();

        for (var l = 0; l <= 9 && l <= k; l++)
            result += opt[n - 1, k - l];

        return result;
    }
}
