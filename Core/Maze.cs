﻿using System;
using System.Text;


namespace Game_Zodiac.Core
{
    public class Maze
    {
        public static Character character1 = new Character(1, 1, 7);
        
        public const int GameWidth = 150; //ширина
        public const int GameHeight = 49; //высота

        public const int LabWidth = 20; //ширина карты лабиринта
        public const int LabHeight = 20; //высота карты лабиринта

        public const double Fov = Math.PI / 3; //угол
        public const double Depth = 16; //глубина, до которой может дойти игрок
        public const double ElapsedTime = 0.06; //каждый раз подсчет времени операции

        public static readonly StringBuilder Map = new StringBuilder(); //карта
        public static readonly char[] Screen = new char[GameHeight * GameWidth]; //содание игровой консоли, экран

        //иницилизация карты
        public static void Init(Monster monster1, Monster monster2, Monster monster3)
        {

            Map.Clear();
            MapGeneration.Filing();
            MapGeneration.Floor(monster1, monster2, monster3);
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    Map.Append(MapGeneration.MapArray[i, j]);
                }
            }
        }

        //состояние
        public static void Stats()
        {
            char[] stats = $"X: {character1.X}, Y: {character1.Y}, FPS: {(int)(1 / Maze.ElapsedTime)}".ToCharArray();
            stats.CopyTo(Maze.Screen, 0);
        }

        public static void Draw2D(Character player)
        {
            //вывод 2D карты
            for (int x = 0; x < Maze.LabWidth; x++)
            {
                for (int y = 0; y < Maze.LabHeight; y++)
                {
                    Maze.Screen[(y + 1) * Maze.GameWidth + x] = Maze.Map[y * Maze.LabWidth + x];
                }
            }

            //игрок на 2D карте
            Maze.Screen[(int)(character1.Y + 1) * Maze.GameWidth + (int)(character1.X)] = player.Symbol;
        }

    }
}