Console.OutputEncoding = System.Text.Encoding.UTF8;
DateTime ahora = DateTime.Now;
Console.WriteLine("Fecha: " + ahora.ToString("12/10/2026"));
Console.WriteLine("Hora: " + ahora.ToString("16:00"));
Console.WriteLine("Dia de la semana: " + ahora.DayOfWeek);
Console.WriteLine("Faltan: " + (19  - ahora.Hour) + " horas para el cierre .");