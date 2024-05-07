
﻿using System;
using System.Numerics;

internal class Enemy
{
    public string Name { get; }
    public int Level { get; set; } // 재원님 set 설정 
    public int Hp { get; set; }
    public int NowHp { get; set; }
    public int Exp { get; set; } // 재원님 추가 설정
    public int Atk { get; set; } // 재원님 set 설정
    public bool IsDead { get; set; }

    public Enemy(string name, int level, int hp, int nowHp,int atk, int exp, bool isDead = false)

    {
        Name = name;
        Level = level;
        Hp = hp;
        NowHp = nowHp;
        Atk = atk;
        Exp = exp; // 재원님 추가설정
        IsDead = isDead;
    }


    internal void PrintEnemyStatDescription(bool withNumber = false, int idx = 0)
    {

    }

    internal void Died()
    {
        IsDead = true;
    }

    public Enemy Clone()
    {
        var clone = new Enemy(Name, Level, Hp, NowHp , Atk, Exp);
        return clone;
    }

    public static void Attack(int enemyCount, List<Enemy> randomEnemies, Player player)
    {
        Console.Clear();

        ConsoleUtility.ShowTitle("■ Battle!! ■");
        Console.WriteLine("");

        for (int i = 0; i < enemyCount; i++)
        {
            if (randomEnemies[i].NowHp > 0)
            {
                Console.WriteLine($"Lv{randomEnemies[i].Level} {randomEnemies[i].Name} 의 공격!\n{player.Name} 을(를) 맞췄습니다. [데미지 : {randomEnemies[i].Atk}]\n");
            }
            else
            {

            }
        }

        int sumAtk = randomEnemies.Sum(randomEnemies => randomEnemies.IsDead ? 0 : randomEnemies.Atk);

        Console.WriteLine("\n");
        Console.WriteLine("[내정보]");
        Console.WriteLine($"Lv.{(player.Level.ToString("00"))} {player.Name} {player.Job}\nHp {player.Hp - sumAtk}/{player.Hp}");
        Console.WriteLine("");
        Console.WriteLine("0. 다음\n");
        switch (ConsoleUtility.PromptMenuChoice(0, 0))
        {
            case 0:
                break;
        }
    }
}
