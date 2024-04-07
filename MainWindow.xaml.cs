using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Media;
using static C_Sharp_Project.MainWindow;
namespace C_Sharp_Project
{
    public partial class MainWindow : Window
    {


        public static int[,] ChessBoard = {
                                { -50,     -30,    -33,     -90,     -1000,    -33,    -30,      -50  },
                                { -10,     -10,    -10,     -10,     -10,      -10,    -10,      -10  },
                                {  0,       0,      0,       0,       0,        0,      0,        0   },
                                {  0,       0,      0,       0,       0,        0,      0,        0   },
                                {  0,       0,      0,       0,       0,        0,      0,        0   },
                                {  0,       0,      0,       0,       0,        0,      0,        0   },
                                {  10,      10,     10,      10,      10,       10,     10,       10  },
                                {  50,      30,     33,      90,      1000,     33,     30,       50  }
        };





        public class ChessPiece
        {
            public FrameworkElement name;
            public int figure_x;
            public int figure_y;
            public bool figure;
            public int figure_xtemp;
            public int figure_ytemp;
            public int target_x;
            public int target_y;
            public int value;
        }

        public class Rookk : ChessPiece
        {
            

            public Rookk()
            {
                value = -50;
            }
            public void Rook_Move()
            {
                Rook_Check(target_y, target_x);
                if (!figure)
                {

                    ChessBoard[figure_y, figure_x] = 0;
                    figure_y = target_y;
                    figure_x = target_x;
                    
                    ChessBoard[figure_y, figure_x] = value;
                    name.Margin = new Thickness(figure_x * 50, figure_y * 50, 0, 0);
                    

                }
                return;
            }

            public void Rook_Check(int i, int j)
            {
                figure = false;
                if (j == figure_xtemp)
                {
                    for (int l = 1; l < Math.Abs(i - figure_ytemp); l++)
                    {
                        if (i > figure_ytemp && ChessBoard[figure_ytemp + l, j] != 0)
                        {
                            figure = true;
                            break;
                        }
                        if (i < figure_ytemp && ChessBoard[figure_ytemp - l, j] != 0)
                        {
                            figure = true;
                            break;
                        }
                    }
                }
                else
                {
                    for (int l = 1; l < Math.Abs(j - figure_xtemp); l++)
                    {
                        if (j > figure_xtemp && ChessBoard[i, figure_xtemp + l] != 0)
                        {
                            figure = true;
                            break;
                        }
                        if (j < figure_xtemp && ChessBoard[i, figure_xtemp - l] != 0)
                        {
                            figure = true;
                            break;
                        }
                    }
                }


                return;
            }
        }

        public class Bishop : ChessPiece
        {
            
            
            public void Bishop_Move()
            {
                Bishop_Check(target_y, target_x);
                if (!figure)
                {

                    ChessBoard[figure_y, figure_x] = 0;
                    figure_y = target_y;
                    figure_x = target_x;
                    
                    ChessBoard[figure_y, figure_x] = -33;
                    name.Margin = new Thickness(figure_x * 50, figure_y * 50, 0, 0);
                   

                }
                return;
            }

            public void Bishop_Check(int i, int j)
            {
                figure = false;
                for (int l = 1; l < Math.Abs(i - figure_ytemp); l++)
                {
                    if (i > figure_ytemp && j < figure_xtemp && ChessBoard[figure_ytemp + l, figure_xtemp - l] != 0)
                    {
                        figure = true;
                    }
                    if (i > figure_ytemp && j > figure_xtemp && ChessBoard[figure_ytemp + l, figure_xtemp + l] != 0)
                    {
                        figure = true;
                    }
                    if (i < figure_ytemp && j < figure_xtemp && ChessBoard[figure_ytemp - l, figure_xtemp - l] != 0)
                    {
                        figure = true;
                    }
                    if (i < figure_ytemp && j > figure_xtemp && ChessBoard[figure_ytemp - l, figure_xtemp + l] != 0)
                    {
                        figure = true;
                    }
                }

                return;
            }
        }

        public class Knight : ChessPiece
        {
            
            public Knight()
            {
                value = -30;
            }

            public void Knight_Move()
            {
                if (!figure)
                {

                    ChessBoard[figure_y, figure_x] = 0;
                    figure_y = target_y;
                    figure_x = target_x;
                    
                    ChessBoard[figure_y, figure_x] = value;
                    name.Margin = new Thickness(figure_x * 50, figure_y * 50, 0, 0);


                }
                return;
            }

           
        }

        public class Queen : ChessPiece
        {
            
            public Queen()
            {
                value = -90;
            }

            public void Queen_Move()
            {
                if (!figure)
                {

                    ChessBoard[figure_y, figure_x] = 0;
                    figure_y = target_y;
                    figure_x = target_x;
                    
                    ChessBoard[figure_y, figure_x] = value;
                    name.Margin = new Thickness(figure_x * 50, figure_y * 50, 0, 0);


                }
                return;
            }

            public void Queen_Check(int i, int j)
            {
                figure = false;
                if (j == figure_xtemp)
                {
                    for (int l = 1; l < Math.Abs(i - figure_ytemp); l++)
                    {
                        if (i > figure_ytemp && ChessBoard[figure_ytemp + l, j] != 0)
                        {
                            figure = true;
                            break;
                        }
                        if (i < figure_ytemp && ChessBoard[figure_ytemp - l, j] != 0)
                        {
                            figure = true;
                            break;
                        }
                    }
                }
                else if (Math.Abs(figure_ytemp - i) == Math.Abs(figure_xtemp - j))
                {
                    for (int l = 1; l < Math.Abs(i - figure_ytemp); l++)
                    {
                        if (i > figure_ytemp && j < figure_xtemp && ChessBoard[figure_ytemp + l, figure_xtemp - l] != 0)
                        {
                            figure = true;
                        }
                        if (i > figure_ytemp && j > figure_xtemp && ChessBoard[figure_ytemp + l, figure_xtemp + l] != 0)
                        {
                            figure = true;
                        }
                        if (i < figure_ytemp && j < figure_xtemp && ChessBoard[figure_ytemp - l, figure_xtemp - l] != 0)
                        {
                            figure = true;
                        }
                        if (i < figure_ytemp && j > figure_xtemp && ChessBoard[figure_ytemp - l, figure_xtemp + l] != 0)
                        {
                            figure = true;
                        }
                    }
                }
                else
                {
                    for (int l = 1; l < Math.Abs(j - figure_xtemp); l++)
                    {
                        if (j > figure_xtemp && ChessBoard[i, figure_xtemp + l] != 0)
                        {
                            figure = true;
                            break;
                        }
                        if (j < figure_xtemp && ChessBoard[i, figure_xtemp - l] != 0)
                        {
                            figure = true;
                            break;
                        }
                    }
                }

                return;
            }
        }

        public class King : ChessPiece
        {
            
            public King()
            {
                value = -1000;
            }

            public void King_Move()
            {
                if (!figure)
                {

                    ChessBoard[figure_y, figure_x] = 0;
                    figure_y = target_y;
                    figure_x = target_x;
                    
                    ChessBoard[figure_y, figure_x] = value;
                    name.Margin = new Thickness(figure_x * 50, figure_y * 50, 0, 0);


                }
                return;
            }

        }

        public class Pawn : ChessPiece
        {
            
            public Pawn()
            {
                value = -10;
            }

            public void Pawn_Move(int amenamec)
            {
                if (amenamec == 0)
                {
                    ChessBoard[figure_y, figure_x] = 0;
                    figure_y = target_y;
                    ChessBoard[figure_y, figure_x] = -10;
                    name.Margin = new Thickness(figure_x * 50, figure_y * 50, 0, 0);
                    return;
                }
                else
                {
                    ChessBoard[figure_y, figure_x] = 0;
                    figure_x = target_x;
                    figure_y = target_y;

                    
                    ChessBoard[figure_y, figure_x] = -10;
                    name.Margin = new Thickness(figure_x * 50, figure_y * 50, 0, 0);
                    return;
                }
                
            }

            public void Pawn_Check()
            {
                figure = false;
                if (ChessBoard[figure_y + 1, figure_x] != 0)
                {
                    figure = true;
                }
            }
        }






        bool White_Pawn_One = false, White_Pawn_Two = false, White_Pawn_Three = false, White_Pawn_Four = false, White_Pawn_Five = false, White_Pawn_Six = false, White_Pawn_Seven = false, White_Pawn_Eight = false, White_King = false, White_Knight_One = false, White_Knight_Two = false, White_Bishop_One = false, White_Bishop_Two = false, White_Rook_One = false, White_Rook_Two = false, White_Queen = false;
        double DeltaX, DeltaY;
        int WhitePawn_One_Position_Y = 6, WhitePawn_One_Position_X = 0, WhitePawn_Two_Position_Y = 6, WhitePawn_Two_Position_X = 1, WhitePawn_Three_Position_Y = 6, WhitePawn_Three_Position_X = 2, WhitePawn_Four_Position_Y = 6, WhitePawn_Four_Position_X = 3, WhitePawn_Five_Position_Y = 6, WhitePawn_Five_Position_X = 4, WhitePawn_Six_Position_Y = 6, WhitePawn_Six_Position_X = 5, WhitePawn_Seven_Position_Y = 6, WhitePawn_Seven_Position_X = 6, WhitePawn_Eight_Position_Y = 6, WhitePawn_Eight_Position_X = 7, WhiteKing_Position_Y = 7, WhiteKing_Position_X = 4, WhiteQueen_Position_Y = 7, WhiteQueen_Position_X = 3, WhiteBishop_One_Position_Y = 7, WhiteBishop_One_Position_X = 2, WhiteKnight_One_Position_Y = 7, WhiteKnight_One_Position_X = 1, WhiteRook_One_Position_Y = 7, WhiteRook_One_Position_X = 0, WhiteKnight_Two_Position_Y = 7, WhiteKnight_Two_Position_X = 6, WhiteBishop_Two_Position_Y = 7, WhiteBishop_Two_Position_X = 5, WhiteRook_Two_Position_Y = 7, WhiteRook_Two_Position_X = 7;
        Pawn Pawn1, Pawn2, Pawn3, Pawn4, Pawn5, Pawn6, Pawn7, Pawn8;
        King King1;
        Queen Queen1;
        Bishop Bishop1, Bishop2;
        Knight Knight1, Knight2;
        Rookk Rook1, Rook2;
        
        
        
        
        
        public MainWindow()
        {
            InitializeComponent();
            StackPanel.SetZIndex(WhitePawn_One, 1);
            StackPanel.SetZIndex(WhitePawn_Two, 1);
            StackPanel.SetZIndex(WhitePawn_Three, 1);
            StackPanel.SetZIndex(WhitePawn_Four, 1);
            StackPanel.SetZIndex(WhitePawn_Five, 1);
            StackPanel.SetZIndex(WhitePawn_Six, 1);
            StackPanel.SetZIndex(WhitePawn_Seven, 1);
            StackPanel.SetZIndex(WhitePawn_Eight, 1);
            StackPanel.SetZIndex(WhiteKing, 1);
            StackPanel.SetZIndex(WhiteQueen, 1);
            StackPanel.SetZIndex(WhiteBishop_One, 1);
            StackPanel.SetZIndex(WhiteBishop_Two, 1);
            StackPanel.SetZIndex(WhiteKnight_One, 1);
            StackPanel.SetZIndex(WhiteKnight_Two, 1);
            StackPanel.SetZIndex(WhiteRook_One, 1);
            StackPanel.SetZIndex(WhiteRook_Two, 1);

            Rook1 = new Rookk();
            Rook1.figure_x = 7;
            Rook1.figure_y = 0;
            Rook1.figure_xtemp = 7;
            Rook1.figure_ytemp = 0;
            Rook1.figure = false;
            Rook1.name = BlackRook_One;

            Rook2 = new Rookk();
            Rook2.figure_x = 0;
            Rook2.figure_y = 0;
            Rook2.figure_xtemp = 0;
            Rook2.figure_ytemp = 0;
            Rook2.figure = false;
            Rook2.name = BlackRook_Two;

            Bishop1 = new Bishop();
            Bishop1.figure_x = 5;
            Bishop1.figure_y = 0;
            Bishop1.figure_xtemp = 5;
            Bishop1.figure_ytemp = 0;
            Bishop1.figure = false;
            Bishop1.name = BlackBishop_One;

            Bishop2 = new Bishop();
            Bishop2.figure_x = 2;
            Bishop2.figure_y = 0;
            Bishop2.figure_xtemp = 2;
            Bishop2.figure_ytemp = 0;
            Bishop2.figure = false;
            Bishop2.name = BlackBishop_Two;

            Knight1 = new Knight();
            Knight1.figure_x = 6;
            Knight1.figure_y = 0;
            Knight1.figure_xtemp = 6;
            Knight1.figure_ytemp = 0;
            Knight1.figure = false;
            Knight1.name = BlackKnight_One;

            Knight2 = new Knight();
            Knight2.figure_x = 1;
            Knight2.figure_y = 0;
            Knight2.figure_xtemp = 1;
            Knight2.figure_ytemp = 0;
            Knight2.figure = false;
            Knight2.name = BlackKnight_Two;

            Queen1 = new Queen();
            Queen1.figure_x = 3;
            Queen1.figure_y = 0;
            Queen1.figure_xtemp = 3;
            Queen1.figure_ytemp = 0;
            Queen1.figure = false;
            Queen1.name = BlackQueen;

            King1 = new King();
            King1.figure_x = 4;
            King1.figure_y = 0;
            King1.figure_xtemp = 4;
            King1.figure_ytemp = 0;
            King1.figure = false;
            King1.name = BlackKing;

            Pawn1 = new Pawn();
            Pawn1.figure_x = 7;
            Pawn1.figure_y = 1;
            Pawn1.figure_xtemp = 7;
            Pawn1.figure_ytemp = 1;
            Pawn1.figure = false;
            Pawn1.name = BlackPawn_One;

            Pawn2 = new Pawn();
            Pawn2.figure_x = 6;
            Pawn2.figure_y = 1;
            Pawn2.figure_xtemp = 6;
            Pawn2.figure_ytemp = 1;
            Pawn2.figure = false;
            Pawn2.name = BlackPawn_Two;

            Pawn3 = new Pawn();
            Pawn3.figure_x = 5;
            Pawn3.figure_y = 1;
            Pawn3.figure_xtemp = 5;
            Pawn3.figure_ytemp = 1;
            Pawn3.figure = false;
            Pawn3.name = BlackPawn_Three;

            Pawn4 = new Pawn();
            Pawn4.figure_x = 4;
            Pawn4.figure_y = 1;
            Pawn4.figure_xtemp = 4;
            Pawn4.figure_ytemp = 1;
            Pawn4.figure = false;
            Pawn4.name = BlackPawn_Four;

            Pawn5 = new Pawn();
            Pawn5.figure_x = 3;
            Pawn5.figure_y = 1;
            Pawn5.figure_xtemp = 3;
            Pawn5.figure_ytemp = 1;
            Pawn5.figure = false;
            Pawn5.name = BlackPawn_Five;

            Pawn6 = new Pawn();
            Pawn6.figure_x = 2;
            Pawn6.figure_y = 1;
            Pawn6.figure_xtemp = 2;
            Pawn6.figure_ytemp = 1;
            Pawn6.figure = false;
            Pawn6.name = BlackPawn_Six;

            Pawn7 = new Pawn();
            Pawn7.figure_x = 1;
            Pawn7.figure_y = 1;
            Pawn7.figure_xtemp = 1;
            Pawn7.figure_ytemp = 1;
            Pawn7.figure = false;
            Pawn7.name = BlackPawn_Seven;

            Pawn8 = new Pawn();
            Pawn8.figure_x = 0;
            Pawn8.figure_y = 1;
            Pawn8.figure_xtemp = 0;
            Pawn8.figure_ytemp = 1;
            Pawn8.figure = false;
            Pawn8.name = BlackPawn_Eight;

        }

        void Window_MouseMove(object sender, MouseEventArgs e)
        {

            if (White_Pawn_One == true)
                WhitePawn_One.Margin = new Thickness(e.GetPosition(this).X - DeltaX, e.GetPosition(this).Y - DeltaY, 0, 0);
            if (White_Pawn_Two == true)
                WhitePawn_Two.Margin = new Thickness(e.GetPosition(this).X - DeltaX, e.GetPosition(this).Y - DeltaY, 0, 0);
            if (White_Pawn_Three == true)
                WhitePawn_Three.Margin = new Thickness(e.GetPosition(this).X - DeltaX, e.GetPosition(this).Y - DeltaY, 0, 0);
            if (White_Pawn_Four == true)
                WhitePawn_Four.Margin = new Thickness(e.GetPosition(this).X - DeltaX, e.GetPosition(this).Y - DeltaY, 0, 0);
            if (White_Pawn_Five == true)
                WhitePawn_Five.Margin = new Thickness(e.GetPosition(this).X - DeltaX, e.GetPosition(this).Y - DeltaY, 0, 0);
            if (White_Pawn_Six == true)
                WhitePawn_Six.Margin = new Thickness(e.GetPosition(this).X - DeltaX, e.GetPosition(this).Y - DeltaY, 0, 0);
            if (White_Pawn_Seven == true)
                WhitePawn_Seven.Margin = new Thickness(e.GetPosition(this).X - DeltaX, e.GetPosition(this).Y - DeltaY, 0, 0);
            if (White_Pawn_Eight == true)
                WhitePawn_Eight.Margin = new Thickness(e.GetPosition(this).X - DeltaX, e.GetPosition(this).Y - DeltaY, 0, 0);
            if (White_King == true)
                WhiteKing.Margin = new Thickness(e.GetPosition(this).X - DeltaX, e.GetPosition(this).Y - DeltaY, 0, 0);
            if (White_Queen == true)
                WhiteQueen.Margin = new Thickness(e.GetPosition(this).X - DeltaX, e.GetPosition(this).Y - DeltaY, 0, 0);
            if (White_Knight_One == true)
                WhiteKnight_One.Margin = new Thickness(e.GetPosition(this).X - DeltaX, e.GetPosition(this).Y - DeltaY, 0, 0);
            if (White_Knight_Two == true)
                WhiteKnight_Two.Margin = new Thickness(e.GetPosition(this).X - DeltaX, e.GetPosition(this).Y - DeltaY, 0, 0);
            if (White_Bishop_One == true)
                WhiteBishop_One.Margin = new Thickness(e.GetPosition(this).X - DeltaX, e.GetPosition(this).Y - DeltaY, 0, 0);
            if (White_Bishop_Two == true)
                WhiteBishop_Two.Margin = new Thickness(e.GetPosition(this).X - DeltaX, e.GetPosition(this).Y - DeltaY, 0, 0);
            if (White_Rook_One == true)
                WhiteRook_One.Margin = new Thickness(e.GetPosition(this).X - DeltaX, e.GetPosition(this).Y - DeltaY, 0, 0);
            if (White_Rook_Two == true)
                WhiteRook_Two.Margin = new Thickness(e.GetPosition(this).X - DeltaX, e.GetPosition(this).Y - DeltaY, 0, 0);

        }

        void MouseD(object sender, MouseButtonEventArgs e, FrameworkElement aaa, ref bool bb)
        {
            if (e.ButtonState == e.LeftButton)
            {
                bb = true;
                DeltaX = e.GetPosition(this).X - aaa.Margin.Left;
                DeltaY = e.GetPosition(this).Y - aaa.Margin.Top;


            }
        }
        void MouseU(FrameworkElement aaa, ref int x, ref int y, ref bool bb, int value, ref int[,] ChessBoard)
        {
            bb = false;
            aaa.Margin = new Thickness((int)(aaa.Margin.Left + 25) / 50 * 50, (int)(aaa.Margin.Top + 25) / 50 * 50, 0, 0);
         
            ChessBoard[(int)(aaa.Margin.Top + 25) / 50, (int)(aaa.Margin.Left + 25) / 50] = value;
            ChessBoard[y, x] = 0;
            y = (int)(aaa.Margin.Top + 25) / 50;   
            x = (int)(aaa.Margin.Left + 25) / 50;
            Utel_Sev(y, x);
            return;
        }

        void WhiteKing_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MouseD(sender, e, WhiteKing, ref White_King);
        }

        void WhiteKing_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MouseU(WhiteKing, ref WhiteKing_Position_X, ref WhiteKing_Position_Y, ref White_King, 1000, ref ChessBoard);
            First_Point();
        }

        void WhitePawn_One_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MouseD(sender, e, WhitePawn_One, ref White_Pawn_One);

        }

        void WhitePawn_One_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MouseU(WhitePawn_One, ref WhitePawn_One_Position_X, ref WhitePawn_One_Position_Y, ref White_Pawn_One, 10, ref ChessBoard);
            First_Point();
        }

        void WhitePawn_Two_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MouseD(sender, e, WhitePawn_Two, ref White_Pawn_Two);
        }

        void WhitePawn_Two_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MouseU(WhitePawn_Two, ref WhitePawn_Two_Position_X, ref WhitePawn_Two_Position_Y, ref White_Pawn_Two, 10, ref ChessBoard);
            First_Point();
        }

        void WhitePawn_Three_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MouseD(sender, e, WhitePawn_Three, ref White_Pawn_Three);
        }

        void WhitePawn_Three_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MouseU(WhitePawn_Three, ref WhitePawn_Three_Position_X, ref WhitePawn_Three_Position_Y, ref White_Pawn_Three, 10, ref ChessBoard);
            First_Point();
        }

        void WhitePawn_Four_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MouseD(sender, e, WhitePawn_Four, ref White_Pawn_Four);
        }

        void WhitePawn_Four_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MouseU(WhitePawn_Four, ref WhitePawn_Four_Position_X, ref WhitePawn_Four_Position_Y, ref White_Pawn_Four, 10, ref ChessBoard);
            First_Point();
        }

        void WhitePawn_Five_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MouseD(sender, e, WhitePawn_Five, ref White_Pawn_Five);
        }

        void WhitePawn_Five_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MouseU(WhitePawn_Five, ref WhitePawn_Five_Position_X, ref WhitePawn_Five_Position_Y, ref White_Pawn_Five, 10, ref ChessBoard);
            First_Point();
        }

        void WhitePawn_Six_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MouseD(sender, e, WhitePawn_Six, ref White_Pawn_Six);
        }

        void WhitePawn_Six_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MouseU(WhitePawn_Six, ref WhitePawn_Six_Position_X, ref WhitePawn_Six_Position_Y, ref White_Pawn_Six, 10, ref ChessBoard);
            First_Point();
        }

        void WhitePawn_Seven_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MouseD(sender, e, WhitePawn_Seven, ref White_Pawn_Seven);
        }

        void WhitePawn_Seven_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MouseU(WhitePawn_Seven, ref WhitePawn_Seven_Position_X, ref WhitePawn_Seven_Position_Y, ref White_Pawn_Seven, 10, ref ChessBoard);
            First_Point();
        }

        void WhitePawn_Eight_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MouseD(sender, e, WhitePawn_Eight, ref White_Pawn_Eight);
        }

        void WhitePawn_Eight_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MouseU(WhitePawn_Eight, ref WhitePawn_Eight_Position_X, ref WhitePawn_Eight_Position_Y, ref White_Pawn_Eight, 10, ref ChessBoard);
            First_Point();
        }
        void WhiteQueen_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MouseD(sender, e, WhiteQueen, ref White_Queen);
        }

        void WhiteQueen_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MouseU(WhiteQueen, ref WhiteQueen_Position_X, ref WhiteQueen_Position_Y, ref White_Queen, 90, ref ChessBoard);
            First_Point();
        }

        void WhiteBishop_One_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MouseD(sender, e, WhiteBishop_One, ref White_Bishop_One);
        }

        void WhiteBishop_One_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MouseU(WhiteBishop_One, ref WhiteBishop_One_Position_X, ref WhiteBishop_One_Position_Y, ref White_Bishop_One, 33, ref ChessBoard);
            First_Point();
        }

        void WhiteKnight_One_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MouseD(sender, e, WhiteKnight_One, ref White_Knight_One);
        }

        void WhiteKnight_One_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MouseU(WhiteKnight_One, ref WhiteKnight_One_Position_X, ref WhiteKnight_One_Position_Y, ref White_Knight_One, 30, ref ChessBoard);
            First_Point();
        }

        void WhiteKnight_Two_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MouseD(sender, e, WhiteKnight_Two, ref White_Knight_Two);
        }

        void WhiteKnight_Two_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MouseU(WhiteKnight_Two, ref WhiteKnight_Two_Position_X, ref WhiteKnight_Two_Position_Y, ref White_Knight_Two, 30, ref ChessBoard);
            First_Point();
        }

        void WhiteRook_One_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MouseD(sender, e, WhiteRook_One, ref White_Rook_One);
        }

        void WhiteRook_One_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MouseU(WhiteRook_One, ref WhiteRook_One_Position_X, ref WhiteRook_One_Position_Y, ref White_Rook_One, 50, ref ChessBoard);
            First_Point();
        }

        void WhiteRook_Two_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MouseD(sender, e, WhiteRook_Two, ref White_Rook_Two);
        }

        void WhiteRook_Two_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MouseU(WhiteRook_Two, ref WhiteRook_Two_Position_X, ref WhiteRook_Two_Position_Y, ref White_Rook_Two, 50, ref ChessBoard);
            First_Point();
        }

        void WhiteBishop_Two_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MouseD(sender, e, WhiteBishop_Two, ref White_Bishop_Two);
        }

        void WhiteBishop_Two_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MouseU(WhiteBishop_Two, ref WhiteBishop_Two_Position_X, ref WhiteBishop_Two_Position_Y, ref White_Bishop_Two, 33, ref ChessBoard);
            First_Point();
        }
        
  

        void Utel(int i, int j)
        {
            string im = "aaaaaaaaaaaaaaaa";
            BitmapImage bitmap1 = new BitmapImage(new Uri(im, UriKind.RelativeOrAbsolute));
            if (i == WhiteKnight_One_Position_Y && j == WhiteKnight_One_Position_X)
            {
                WhiteKnight_One.Source = bitmap1;
                WhiteKnight_One_Position_Y = -100;
                WhiteKnight_One_Position_X = -100;
            }
            else if (i == WhiteKnight_Two_Position_Y && j == WhiteKnight_Two_Position_X)
            {
                WhiteKnight_Two.Source = bitmap1;
                WhiteKnight_Two_Position_Y = -100;
                WhiteKnight_Two_Position_X = -100;
            }
            else if (i == WhiteBishop_One_Position_Y && j == WhiteBishop_One_Position_X)
            {
                WhiteBishop_One.Source = bitmap1;
                WhiteBishop_One_Position_Y = -100;
                WhiteBishop_One_Position_X = -100;
            }
            else if (i == WhiteBishop_Two_Position_Y && j == WhiteBishop_Two_Position_X)
            {
                WhiteBishop_Two.Source = bitmap1;
                WhiteBishop_Two_Position_Y = -100;
                WhiteBishop_Two_Position_X = -100;
            }
            else if (i == WhiteQueen_Position_Y && j == WhiteQueen_Position_X)
            {
                WhiteQueen.Source = bitmap1;
                WhiteQueen_Position_Y = -100;
                WhiteQueen_Position_X = -100;
            }
            else if (i == WhiteRook_One_Position_Y && j == WhiteRook_One_Position_X)
            {
                WhiteRook_One.Source = bitmap1;
                WhiteRook_One_Position_Y = -100;
                WhiteRook_One_Position_X = -100;
            }
            else if (i == WhiteRook_Two_Position_Y && j == WhiteRook_Two_Position_X)
            {
                WhiteRook_Two.Source = bitmap1;
                WhiteRook_Two_Position_Y = -100;
                WhiteRook_Two_Position_X = -100;
            }
            else if (i == WhitePawn_One_Position_Y && j == WhitePawn_One_Position_X)
            {
                WhitePawn_One.Source = bitmap1;
                WhitePawn_One_Position_Y = -100;
                WhitePawn_One_Position_X = -100;
            }
            else if (i == WhitePawn_Two_Position_Y && j == WhitePawn_Two_Position_X)
            {
                WhitePawn_Two.Source = bitmap1;
                WhitePawn_Two_Position_Y = -100;
                WhitePawn_Two_Position_X = -100;
            }
            else if (i == WhitePawn_Three_Position_Y && j == WhitePawn_Three_Position_X)
            {
                WhitePawn_Three.Source = bitmap1;
                WhitePawn_Three_Position_Y = -100;
                WhitePawn_Three_Position_X = -100;
            }
            else if (i == WhitePawn_Four_Position_Y && j == WhitePawn_Four_Position_X)
            {
                WhitePawn_Four.Source = bitmap1;
                WhitePawn_Four_Position_Y = -100;
                WhitePawn_Four_Position_X = -100;
            }
            else if (i == WhitePawn_Five_Position_Y && j == WhitePawn_Five_Position_X)
            {
                WhitePawn_Five.Source = bitmap1;
                WhitePawn_Five_Position_Y = -100;
                WhitePawn_Five_Position_X = -100;
            }
            else if (i == WhitePawn_Six_Position_Y && j == WhitePawn_Six_Position_X)
            {
                WhitePawn_Six.Source = bitmap1;
                WhitePawn_Six_Position_Y = -100;
                WhitePawn_Six_Position_X = -100;
            }
            else if (i == WhitePawn_Seven_Position_Y && j == WhitePawn_Seven_Position_X)
            {
                WhitePawn_Seven.Source = bitmap1;
                WhitePawn_Seven_Position_Y = -100;
                WhitePawn_Seven_Position_X = -100;
            }
            else if (i == WhitePawn_Eight_Position_Y && j == WhitePawn_Eight_Position_X)
            {
                WhitePawn_Eight.Source = bitmap1;
                WhitePawn_Eight_Position_Y = -100;
                WhitePawn_Eight_Position_X = -100;
            }
            
            return;

        }

        void Utel_Sev(int i, int j)
        {
            string im = "aaaaaaaaaaaaaaaa";
            BitmapImage bitmap1 = new BitmapImage(new Uri(im, UriKind.RelativeOrAbsolute));
            if (i == Knight1.figure_y && j == Knight1.figure_x)
            {
                BlackKnight_One.Source = bitmap1;
                Knight1.figure_x = -10000;
                Knight1.figure_y = -200;
            }
            else if (i == Knight2.figure_y && j == Knight2.figure_x)
            {
                BlackKnight_Two.Source = bitmap1;
                Knight2.figure_x = -10000;
                Knight2.figure_x = -200;
            }
            else if (i == Bishop1.figure_y && j == Bishop1.figure_x)
            {
                BlackBishop_One.Source = bitmap1;
                Bishop1.figure_x = -10000;
                Bishop1.figure_y = -200;
            }
            else if (i == Bishop2.figure_y && j == Bishop2.figure_x)
            {
                BlackBishop_Two.Source = bitmap1;
                Bishop2.figure_x = -10000;
                Bishop2.figure_x = -200;
            }
            else if (i == Queen1.figure_y && j == Queen1.figure_x)
            {
                BlackQueen.Source = bitmap1;
                Queen1.figure_x = -10000;
                Queen1.figure_y = -200;
            }
            else if (i == Rook1.figure_y && j == Rook1.figure_x)
            {
                BlackRook_One.Source = bitmap1;
                Rook1.figure_x = -10000;
                Rook1.figure_y = -200;
            }
            else if (i == Rook2.figure_y && j == Rook2.figure_x)
            {
                BlackRook_Two.Source = bitmap1;
                Rook2.figure_x = -10000;
                Rook2.figure_y = -200;
            }
            else if (i == Pawn1.figure_y && j == Pawn1.figure_x)
            {
                BlackPawn_One.Source = bitmap1;
                Pawn1.figure_x = -10000;
                Pawn1.figure_y = -200;
            }
            else if (i == Pawn2.figure_y && j == Pawn2.figure_x)
            {
                BlackPawn_Two.Source = bitmap1;
                Pawn2.figure_x = -10000;
                Pawn2.figure_y = -200;
            }
            else if (i == Pawn3.figure_y && j == Pawn3.figure_x)
            {
                BlackPawn_Three.Source = bitmap1;
                Pawn3.figure_x = -10000;
                Pawn3.figure_y = -200;
            }
            else if (i == Pawn4.figure_y && j == Pawn4.figure_x)
            {
                BlackPawn_Four.Source = bitmap1;
                Pawn4.figure_x = -10000;
                Pawn4.figure_y = -200;
            }
            else if (i == Pawn5.figure_y && j == Pawn5.figure_x)
            {
                BlackPawn_Five.Source = bitmap1;
                Pawn5.figure_x = -10000;
                Pawn5.figure_y = -200;
            }
            else if (i == Pawn6.figure_y && j == Pawn6.figure_x)
            {
                BlackPawn_Six.Source = bitmap1;
                Pawn6.figure_x = -10000;
                Pawn6.figure_y = -200;
            }
            else if (i == Pawn7.figure_y && j == Pawn7.figure_x)
            {
                BlackPawn_Seven.Source = bitmap1;
                Pawn7.figure_x = -10000;
                Pawn7.figure_y = -200;
            }
            else if (i == Pawn8.figure_y && j == Pawn8.figure_x)
            {
                BlackPawn_Eight.Source = bitmap1;
                Pawn8.figure_x = -10000;
                Pawn8.figure_y = -200;
            }
            else if (i == King1.figure_y && j == King1.figure_x)
            {
                BlackKing.Source = bitmap1;
                King1.figure_x = -10000;
                King1.figure_y = -200;
            }

            return;
        }


       


        

        void Pawnns(int i, int j, ref int amenamec)
        {
            if (ChessBoard[i, j] > amenamec && ChessBoard[i, j] != 1000 )
            {
                if (ChessBoard[i, j] != 0)
                {
                    amenamec = ChessBoard[i, j];
                } else if (ChessBoard[i, j] == 0 && ChessBoard[i + 1, j] == 0)
                {
                    amenamec = 0;
                }
               
                
            }
            return;
        }

        int amenamec = -1;

        void choose()
        {
            amenamec = -1;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if ((((i - Pawn1.figure_ytemp) == 1 && (Pawn1.figure_xtemp - j) == 1) || ((i - Pawn1.figure_ytemp) == 1 && (j - Pawn1.figure_xtemp) == 1)) && ChessBoard[i, j] >= 0 && ChessBoard[Pawn1.figure_ytemp, Pawn1.figure_xtemp] == -10)
                    {
                        Pawnns(i, j, ref amenamec);
                        
                    }
                    if ((((i - Pawn2.figure_ytemp) == 1 && (Pawn2.figure_xtemp - j) == 1) || ((i - Pawn2.figure_ytemp) == 1 && (j - Pawn2.figure_xtemp) == 1)) && ChessBoard[i, j] >= 0 && ChessBoard[Pawn2.figure_ytemp, Pawn2.figure_xtemp] == -10)
                    {
                        Pawnns(i, j, ref amenamec);

                    }
                    if ((((i - Pawn3.figure_ytemp) == 1 && (Pawn3.figure_xtemp - j) == 1) || ((i - Pawn3.figure_ytemp) == 1 && (j - Pawn3.figure_xtemp) == 1)) && ChessBoard[i, j] >= 0 && ChessBoard[Pawn3.figure_ytemp, Pawn3.figure_xtemp] == -10)
                    {
                        Pawnns(i, j, ref amenamec);

                    }
                    if ((((i - Pawn4.figure_ytemp) == 1 && (Pawn4.figure_xtemp - j) == 1) || ((i - Pawn4.figure_ytemp) == 1 && (j - Pawn4.figure_xtemp) == 1)) && ChessBoard[i, j] >= 0 && ChessBoard[Pawn4.figure_ytemp, Pawn4.figure_xtemp] == -10)
                    {
                        Pawnns(i, j, ref amenamec);

                    }
                    if ((((i - Pawn5.figure_ytemp) == 1 && (Pawn5.figure_xtemp - j) == 1) || ((i - Pawn5.figure_ytemp) == 1 && (j - Pawn5.figure_xtemp) == 1)) && ChessBoard[i, j] >= 0 && ChessBoard[Pawn5.figure_ytemp, Pawn5.figure_xtemp] == -10)
                    {
                        Pawnns(i, j, ref amenamec);

                    }
                    if ((((i - Pawn6.figure_ytemp) == 1 && (Pawn6.figure_xtemp - j) == 1) || ((i - Pawn6.figure_ytemp) == 1 && (j - Pawn6.figure_xtemp) == 1)) && ChessBoard[i, j] >= 0 && ChessBoard[Pawn6.figure_ytemp, Pawn6.figure_xtemp] == -10)
                    {
                        Pawnns(i, j, ref amenamec);

                    }
                    if ((((i - Pawn7.figure_ytemp) == 1 && (Pawn7.figure_xtemp - j) == 1) || ((i - Pawn7.figure_ytemp) == 1 && (j - Pawn7.figure_xtemp) == 1)) && ChessBoard[i, j] >= 0 && ChessBoard[Pawn7.figure_ytemp, Pawn7.figure_xtemp] == -10)
                    {
                        Pawnns(i, j, ref amenamec);

                    }
                    if ((((i - Pawn8.figure_ytemp) == 1 && (Pawn8.figure_xtemp - j) == 1) || ((i - Pawn8.figure_ytemp) == 1 && (j - Pawn8.figure_xtemp) == 1)) && ChessBoard[i, j] >= 0 && ChessBoard[Pawn8.figure_ytemp, Pawn8.figure_xtemp] == -10)
                    {
                        Pawnns(i, j, ref amenamec);

                    }
                    if ((j == Queen1.figure_xtemp || i == Queen1.figure_ytemp || Math.Abs(Queen1.figure_ytemp - i) == Math.Abs(Queen1.figure_xtemp - j)) && ChessBoard[i, j] >= 0)
                    {
                        Queen1.Queen_Check(i, j);
                        if (!Queen1.figure)
                        {

                            if (ChessBoard[i, j] > amenamec)
                            {
                                amenamec = ChessBoard[i, j];
                            }
                            

                        }

                    }
                    if ((j == Rook1.figure_xtemp || i == Rook1.figure_ytemp) && ChessBoard[i, j] >= 0)
                    {
                        Rook1.Rook_Check(i, j);
                        if (!Rook1.figure)
                        {

                            if (ChessBoard[i, j] > amenamec)
                            {
                                amenamec = ChessBoard[i, j];
                            }
                         
                        }

                    }

                    if ((j == Rook2.figure_xtemp || i == Rook2.figure_ytemp) && ChessBoard[i, j] >= 0)
                    {
                        Rook2.Rook_Check(i, j);
                        if (!Rook2.figure)
                        {

                            if (ChessBoard[i, j] > amenamec)
                            {
                                amenamec = ChessBoard[i, j];
                            }
                            

                        }

                    }
                    if (Math.Abs(Bishop1.figure_ytemp - i) == Math.Abs(Bishop1.figure_xtemp - j) && ChessBoard[i, j] >= 0)
                    {
                        Bishop1.Bishop_Check(i, j);
                        if (!Bishop1.figure)
                        {
                            if (ChessBoard[i, j] > amenamec)
                            {
                                amenamec = ChessBoard[i, j];
                            }
                            
                        }
                    }

                    if (Math.Abs(Bishop2.figure_ytemp - i) == Math.Abs(Bishop2.figure_xtemp - j) && ChessBoard[i, j] >= 0)
                    {
                        Bishop2.Bishop_Check(i, j);
                        if (!Bishop2.figure)
                        {
                            if (ChessBoard[i, j] > amenamec)
                            {
                                amenamec = ChessBoard[i, j];
                            }
                            
                        }
                    }



                    if (((Math.Abs(Knight1.figure_ytemp - i) == 2 && Math.Abs(Knight1.figure_xtemp - j) == 1) || (Math.Abs(Knight1.figure_ytemp - i) == 1 && Math.Abs(Knight1.figure_xtemp - j) == 2)) && ChessBoard[i, j] >= 0)
                    {
                        if (ChessBoard[i, j] > amenamec)
                        {
                            amenamec = ChessBoard[i, j];
                        }
                        
                    }
                    if (((Math.Abs(Knight2.figure_ytemp - i) == 2 && Math.Abs(Knight2.figure_xtemp - j) == 1) || (Math.Abs(Knight2.figure_ytemp - i) == 1 && Math.Abs(Knight2.figure_xtemp - j) == 2)) && ChessBoard[i, j] >= 0)
                    {
                        if (ChessBoard[i, j] > amenamec)
                        {
                            amenamec = ChessBoard[i, j];
                        }
                        
                    }
                    if (((Math.Abs(King1.figure_ytemp - i) == 1 && Math.Abs(King1.figure_xtemp - j) == 0) || (Math.Abs(King1.figure_ytemp - i) == 0 && Math.Abs(King1.figure_xtemp - j) == 1) || (Math.Abs(King1.figure_ytemp - i) == 1 && Math.Abs(King1.figure_xtemp - j) == 1)) && ChessBoard[i, j] >= 0)
                    {
                        if (ChessBoard[i, j] > amenamec)
                        {
                            amenamec = ChessBoard[i, j];
                        }
                       
                    }
                }
            }

            return;
        }
        
        void First_Point()
        {

            Rook1.figure_xtemp = Rook1.figure_x;
            Rook1.figure_ytemp = Rook1.figure_y;

            Rook2.figure_xtemp = Rook2.figure_x;
            Rook2.figure_ytemp = Rook2.figure_y;

            Bishop1.figure_xtemp = Bishop1.figure_x;
            Bishop1.figure_ytemp = Bishop1.figure_y;

            Bishop2.figure_xtemp = Bishop2.figure_x;
            Bishop2.figure_ytemp = Bishop2.figure_y;

            Knight1.figure_xtemp = Knight1.figure_x;
            Knight1.figure_ytemp = Knight1.figure_y;

            Knight2.figure_xtemp = Knight2.figure_x;
            Knight2.figure_ytemp = Knight2.figure_y;

            Queen1.figure_xtemp = Queen1.figure_x;
            Queen1.figure_ytemp = Queen1.figure_y;

            Pawn1.figure_xtemp = Pawn1.figure_x;
            Pawn1.figure_ytemp = Pawn1.figure_y;

            Pawn2.figure_xtemp = Pawn2.figure_x;
            Pawn2.figure_ytemp = Pawn2.figure_y;

            Pawn3.figure_xtemp = Pawn3.figure_x;
            Pawn3.figure_ytemp = Pawn3.figure_y;

            Pawn4.figure_xtemp = Pawn4.figure_x;
            Pawn4.figure_ytemp = Pawn4.figure_y;

            Pawn5.figure_xtemp = Pawn5.figure_x;
            Pawn5.figure_ytemp = Pawn5.figure_y;

            Pawn6.figure_xtemp = Pawn6.figure_x;
            Pawn6.figure_ytemp = Pawn6.figure_y;

            Pawn7.figure_xtemp = Pawn7.figure_x;
            Pawn7.figure_ytemp = Pawn7.figure_y;

            Pawn8.figure_xtemp = Pawn8.figure_x;
            Pawn8.figure_ytemp = Pawn8.figure_y;

            King1.figure_xtemp = King1.figure_x;
            King1.figure_ytemp = King1.figure_y;


            choose();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Pawn1.target_x = j;
                    Pawn1.target_y = i;
                    Pawn2.target_x = j;
                    Pawn2.target_y = i;
                    Pawn3.target_x = j;
                    Pawn3.target_y = i;
                    Pawn4.target_x = j;
                    Pawn4.target_y = i;
                    Pawn5.target_x = j;
                    Pawn5.target_y = i;
                    Pawn6.target_x = j;
                    Pawn6.target_y = i;
                    Pawn7.target_x = j;
                    Pawn7.target_y = i;
                    Pawn8.target_x = j;
                    Pawn8.target_y = i;
                    Bishop1.target_x = j;
                    Bishop1.target_y = i;
                    Bishop2.target_x = j;
                    Bishop2.target_y = i;
                    Knight1.target_x = j;
                    Knight1.target_y = i;
                    Knight2.target_x = j;
                    Knight2.target_y = i;
                    Rook1.target_x = j;
                    Rook1.target_y = i;
                    Rook2.target_x = j;
                    Rook2.target_y = i;
                    King1.target_x = j;
                    King1.target_y = i;
                    Queen1.target_y = i;
                    Queen1.target_x = j;



                    if ((((i - Pawn1.figure_ytemp) == 1 && (Pawn1.figure_xtemp - j) == 1) || ((i - Pawn1.figure_ytemp) == 1 && (j - Pawn1.figure_xtemp) == 1)) && ChessBoard[i, j] == amenamec && ChessBoard[Pawn1.figure_ytemp, Pawn1.figure_xtemp] == -10)
                    {
                        Pawn1.Pawn_Move(amenamec);
                        if (!Pawn1.figure)
                        {
                            Utel(i, j);
                            return;
                        }
                       
                    }
                    if ((((i - Pawn2.figure_ytemp) == 1 && (Pawn2.figure_xtemp - j) == 1) || ((i - Pawn2.figure_ytemp) == 1 && (j - Pawn2.figure_xtemp) == 1)) && ChessBoard[i, j] == amenamec && ChessBoard[Pawn2.figure_ytemp, Pawn2.figure_xtemp] == -10)
                    {
                        Pawn2.Pawn_Move(amenamec);
                        if (!Pawn2.figure)
                        {
                            Utel(i, j);
                            return;
                        }
                        
                    }
                    if ((((i - Pawn3.figure_ytemp) == 1 && (Pawn3.figure_xtemp - j) == 1) || ((i - Pawn3.figure_ytemp) == 1 && (j - Pawn3.figure_xtemp) == 1)) && ChessBoard[i, j] == amenamec && ChessBoard[Pawn3.figure_ytemp, Pawn3.figure_xtemp] == -10)
                    {
                        Pawn3.Pawn_Move(amenamec);
                        if (!Pawn3.figure)
                        {
                            Utel(i, j);
                            return;
                        }
                        
                    }
                    if ((((i - Pawn4.figure_ytemp) == 1 && (Pawn4.figure_xtemp - j) == 1) || ((i - Pawn4.figure_ytemp) == 1 && (j - Pawn4.figure_xtemp) == 1)) && ChessBoard[i, j] == amenamec && ChessBoard[Pawn4.figure_ytemp, Pawn4.figure_xtemp] == -10)
                    {
                        Pawn4.Pawn_Move(amenamec);
                        if (!Pawn4.figure)
                        {
                            Utel(i, j);
                            return;
                        }
                        
                    }
                    if ((((i - Pawn5.figure_ytemp) == 1 && (Pawn5.figure_xtemp - j) == 1) || ((i - Pawn5.figure_ytemp) == 1 && (j - Pawn5.figure_xtemp) == 1)) && ChessBoard[i, j] == amenamec && ChessBoard[Pawn5.figure_ytemp, Pawn5.figure_xtemp] == -10)
                    {
                        Pawn5.Pawn_Move(amenamec);
                        if (!Pawn5.figure)
                        {
                            Utel(i, j);
                            return;
                        }
                        
                    }
                    if ((((i - Pawn6.figure_ytemp) == 1 && (Pawn6.figure_xtemp - j) == 1) || ((i - Pawn6.figure_ytemp) == 1 && (j - Pawn6.figure_xtemp) == 1)) && ChessBoard[i, j] == amenamec && ChessBoard[Pawn6.figure_ytemp, Pawn6.figure_xtemp] == -10)
                    {
                        Pawn6.Pawn_Move(amenamec);
                        if (!Pawn6.figure)
                        {
                            Utel(i, j);
                            return;
                        }
                       
                    }
                    if ((((i - Pawn7.figure_ytemp) == 1 && (Pawn7.figure_xtemp - j) == 1) || ((i - Pawn7.figure_ytemp) == 1 && (j - Pawn7.figure_xtemp) == 1)) && ChessBoard[i, j] == amenamec && ChessBoard[Pawn7.figure_ytemp, Pawn7.figure_xtemp] == -10)
                    {
                        Pawn7.Pawn_Move(amenamec);
                        if (!Pawn7.figure)
                        {
                            Utel(i, j);
                            return;
                        }
                        
                    }
                    if ((((i - Pawn8.figure_ytemp) == 1 && (Pawn8.figure_xtemp - j) == 1) || ((i - Pawn8.figure_ytemp) == 1 && (j - Pawn8.figure_xtemp) == 1)) && ChessBoard[i, j] == amenamec && ChessBoard[Pawn8.figure_ytemp, Pawn8.figure_xtemp] == -10)
                    {
                        Pawn8.Pawn_Move(amenamec);
                        if (!Pawn8.figure)
                        {
                            Utel(i, j);
                            return;
                        }
                        
                    }
                    if ((j == Queen1.figure_xtemp || i == Queen1.figure_ytemp || Math.Abs(Queen1.figure_ytemp - i) == Math.Abs(Queen1.figure_xtemp - j)) && ChessBoard[i, j] == amenamec)
                    {
                        Queen1.Queen_Check(i, j);
                        
                        Queen1.Queen_Move();
                        if (!Queen1.figure)
                        {
                            Utel(i, j);
                            return;
                        }
                        

                        

                    }
                    if ((j == Rook1.figure_xtemp || i == Rook1.figure_ytemp) && ChessBoard[i, j] == amenamec)
                    {
                        

                        Rook1.Rook_Move();
                        if (!Rook1.figure)
                        {
                            Utel(i, j);
                            return;
                        }
                        
                    }

                    if ((j == Rook2.figure_xtemp || i == Rook2.figure_ytemp) && ChessBoard[i, j] == amenamec)
                    {
                      

                        Rook2.Rook_Move();
                        if (!Rook2.figure)
                        {
                            Utel(i, j);
                            return;
                        }
                        
                      
                    }
                    if ((Math.Abs(Bishop1.figure_ytemp - i) == Math.Abs(Bishop1.figure_xtemp - j)) && ChessBoard[i, j] == amenamec)
                    {
                        
                        Bishop1.Bishop_Move();
                        if (!Bishop1.figure)
                        {
                            Utel(i, j);
                            return;
                        }
                        
                    }

                    if ((Math.Abs(Bishop2.figure_ytemp - i) == Math.Abs(Bishop2.figure_xtemp - j)) && ChessBoard[i, j] == amenamec)
                    {
                        
                        Bishop2.Bishop_Move();
                        if (!Bishop2.figure)
                        {
                            Utel(i, j);
                            return;
                        }
                        
                    }



                    if (((Math.Abs(Knight1.figure_ytemp - i) == 2 && Math.Abs(Knight1.figure_xtemp - j) == 1) || (Math.Abs(Knight1.figure_ytemp - i) == 1 && Math.Abs(Knight1.figure_xtemp - j) == 2)) && ChessBoard[i, j] == amenamec)
                    {
                        Knight1.Knight_Move();
                        if (!Knight1.figure)
                        {
                            Utel(i, j);
                            return;
                        }
                    
                    }
                    if (((Math.Abs(Knight2.figure_ytemp - i) == 2 && Math.Abs(Knight2.figure_xtemp - j) == 1) || (Math.Abs(Knight2.figure_ytemp - i) == 1 && Math.Abs(Knight2.figure_xtemp - j) == 2)) && ChessBoard[i, j] == amenamec)
                    {
                        Knight2.Knight_Move();
                        if (!Knight2.figure)
                        {
                            Utel(i, j);
                            return;
                        }
                        
                    }
                    if (((Math.Abs(King1.figure_ytemp - i) == 1 && Math.Abs(King1.figure_xtemp - j) == 0) || (Math.Abs(King1.figure_ytemp - i) == 0 && Math.Abs(King1.figure_xtemp - j) == 1) || (Math.Abs(King1.figure_ytemp - i) == 1 && Math.Abs(King1.figure_xtemp - j) == 1)) && ChessBoard[i, j] == amenamec)
                    {
                        King1.King_Move();
                        if (!King1.figure)
                        {
                            Utel(i, j);
                            return;
                        }
                        
                    }


                }
                

            }

            













        }
   
    
    
    
    
    
    
    





    
    }
}
