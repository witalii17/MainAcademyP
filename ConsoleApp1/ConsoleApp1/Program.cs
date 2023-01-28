using ConsoleApp1;
// See https://aka.ms/new-console-template for more information

#region InitPlayers

for (int j=0; j< Console.WindowHeight-1; j+=2)
{
    
    Console.SetCursorPosition(0, j);
    for (int i=0; i < Console.WindowWidth; i++)
    {
        Console.Write("=");
    }


}
#endregion

#region Player
int players_count = (Console.WindowHeight - 2) / 2;
Player[] players = new Player[players_count];
ConsoleColor init_color = Console.ForegroundColor;
Random rnd = new Random();

for (int j = 1, i = 0; j < Console.WindowHeight - 2; j += 2, i++)
{
    Console.SetCursorPosition(0, j);
    players[i].left = 0;
    players[i].top = j;
    players[i].color = (ConsoleColor)rnd.Next((int)ConsoleColor.DarkBlue, (int)ConsoleColor.Yellow);
    Console.ForegroundColor = players[i].color;
    Console.Write("***");
    Thread.Sleep(10);

}
#endregion

#region Game

while (true)
{
    int next_step = rnd.Next(0, players_count);
    Player p=players[next_step];
    Console.SetCursorPosition(p.left++, p.top);
    Console.ForegroundColor = p.color;
    Console.Write(" ***");
    players[next_step] = p;
    if (p.left == Console.WindowWidth-3)
        break;
    Thread.Sleep(5);
    Console.CursorVisible = false;
}


#endregion

Console.WriteLine();
Console.ReadKey();
