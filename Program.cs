internal class Program
{
    private static void Main(string[] args)
    {
        double?[] dailyRevenue = {
            1200.0, 1300.0, null, 1500.0, 1100.0, 1250.0, null,
            1600.0, 1400.0, 1350.0, null, null, 1700.0, 1750.0,
        };

        var validRevenues = dailyRevenue
        .Where(d => d.HasValue)
        .Select(d => d.Value);

        //Utilizando LINQ (a forma mais performática)
        double minRevenueLinq = validRevenues.Min();

        double maxRevenueLinq = validRevenues.Max();

        double anualAvaregeLinq = validRevenues.Average();

        int annualAverageLinq = dailyRevenue
            .Where(d => d.HasValue && d.Value > anualAvaregeLinq)
            .Count();

        Console.WriteLine("Menor faturamento: " + minRevenueLinq);
        Console.WriteLine("Maior faturamento: " + maxRevenueLinq);
        Console.WriteLine("Média anual de faturamento: " + anualAvaregeLinq);
        Console.WriteLine("Número de dias com faturamento acima da média anual: " + annualAverageLinq);

        //Não Utilizando LINQ

        double? minRevenue = null;
        double? maxRevenue = null;
        double? avaregeRevenue = null;
        double? sumRevenue = 0;
        int numDaysRevenue = 0;
        int daysAboveAverage = 0;
        foreach (double? revenue in dailyRevenue)
        {
            if(revenue.HasValue)
            {
        //Aqui opto por uma solução que fere a responsabilidade única porém aproveita um único loop para fazer o cálculo, creio que assim fica mais performático, fica pior para testar também.
                if(!minRevenue.HasValue || revenue.Value < minRevenue)
                {
                    minRevenue = revenue;
                }
                if(!maxRevenue.HasValue || revenue.Value> maxRevenue) 
                {
                    maxRevenue= revenue;
                }
                sumRevenue+= revenue.Value;
                numDaysRevenue++;

            }
        }
        avaregeRevenue = sumRevenue / numDaysRevenue;
       
        foreach (double? revenue in dailyRevenue)
        {
            if (revenue.HasValue && revenue.Value > avaregeRevenue)
            {
                daysAboveAverage++;
            }
        }
        Console.WriteLine("Menor faturamento: " + minRevenue);
        Console.WriteLine("Maior faturamento: " + maxRevenue);
        Console.WriteLine("Média anual de faturamento: " + avaregeRevenue);
        Console.WriteLine("Número de dias com faturamento acima da média anual: " + daysAboveAverage);
    }
}
