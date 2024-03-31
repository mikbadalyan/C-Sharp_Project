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
namespace C_Sharp_Project
{
    public partial class MainWindow : Window
    {
        public static int[,] ChessBoard = {
                                { -50,      -30,    -33,     -90,     -1000,    -33,    -30,      -50 },
                                { 0,      0,    0,     0,     0,      0,    0,      0 },
                                {  0,       0,      0,       0,       0,        0,      0,        0   },
                                {  0,       0,      0,       0,       0,        0,      0,        0   },
                                {  0,       0,      0,       0,       0,        0,      0,        0   },
                                {  0,       0,      0,       0,       0,        0,      0,        0   },
                                {  10,      10,     10,      10,      10,       10,     10,       10  },
                                {  50,      30,     33,      90,      1000,     33,     30,       50  }
        };

        bool White_Pawn_One = false, White_Pawn_Two = false, White_Pawn_Three = false, White_Pawn_Four = false, White_Pawn_Five = false, White_Pawn_Six = false, White_Pawn_Seven = false, White_Pawn_Eight = false, White_King = false, White_Knight_One = false, White_Knight_Two = false, White_Bishop_One = false, White_Bishop_Two = false, White_Rook_One = false, White_Rook_Two = false, White_Queen = false;
        double DeltaX, DeltaY;
        int WhitePawn_One_Position_Y = 6, WhitePawn_One_Position_X = 0, WhitePawn_Two_Position_Y = 6, WhitePawn_Two_Position_X = 1, WhitePawn_Three_Position_Y = 6, WhitePawn_Three_Position_X = 2, WhitePawn_Four_Position_Y = 6, WhitePawn_Four_Position_X = 3, WhitePawn_Five_Position_Y = 6, WhitePawn_Five_Position_X = 4, WhitePawn_Six_Position_Y = 6, WhitePawn_Six_Position_X = 6, WhitePawn_Seven_Position_Y = 6, WhitePawn_Seven_Position_X = 6, WhitePawn_Eight_Position_Y = 6, WhitePawn_Eight_Position_X = 7, WhiteKing_Position_Y = 7, WhiteKing_Position_X = 4, WhiteQueen_Position_Y = 7, WhiteQueen_Position_X = 3, WhiteBishop_One_Position_Y = 7, WhiteBishop_One_Position_X = 2, WhiteKnight_One_Position_Y = 7, WhiteKnight_One_Position_X = 1, WhiteRook_One_Position_Y = 7, WhiteRook_One_Position_X = 0, WhiteKnight_Two_Position_Y = 7, WhiteKnight_Two_Position_X = 6, WhiteBishop_Two_Position_Y = 7, WhiteBishop_Two_Position_X = 5, WhiteRook_Two_Position_Y = 7, WhiteRook_Two_Position_X = 7;
        int BlackKnight_Position_Y = 0, BlackKnight_Position_X = 6, BlackKnight_Two_Position_Y = 0, BlackKnight_Two_Position_X = 1, BlackBishop_Position_Y = 0, BlackBishop_Position_X = 5, BlackBishop_Two_Position_Y = 0, BlackBishop_Two_Position_X = 2, BlackRook_Position_Y = 0, BlackRook_Position_X = 7, BlackRook_Two_Position_Y = 0, BlackRook_Two_Position_X = 0, BlackKing_Position_Y = 0, BlackKing_Position_X = 4, BlackKnight_Position_Ytemp = 0, BlackKnight_Position_Xtemp = 6, BlackKnight_Two_Position_Ytemp = 0, BlackKnight_Two_Position_Xtemp = 1, BlackBishop_Position_Ytemp = 0, BlackBishop_Position_Xtemp = 5, BlackBishop_Two_Position_Ytemp = 0, BlackBishop_Two_Position_Xtemp = 5, BlackRook_Position_Ytemp = 0, BlackRook_Position_Xtemp = 2, BlackRook_Two_Position_Ytemp = 0, BlackRook_Two_Position_Xtemp = 0;
        bool Rook_V = false, Bishop_V = false, Knight_V = false, Rook_V_second = false, Bishop_V_second = false, Knight_V_second = false;
        public MainWindow()
        {
            InitializeComponent();
            StackPanel.SetZIndex(WhitePawn_One, 1);
            StackPanel.SetZIndex(WhiteKing, 1);
            StackPanel.SetZIndex(WhiteQueen, 1);
            StackPanel.SetZIndex(WhiteBishop_One, 1);
            StackPanel.SetZIndex(WhiteBishop_Two, 1);
            StackPanel.SetZIndex(WhiteKnight_One, 1);
            StackPanel.SetZIndex(WhiteKnight_Two, 1);
            StackPanel.SetZIndex(WhiteRook_One, 1);
            StackPanel.SetZIndex(WhiteRook_Two, 1);


            
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
        void MouseU(FrameworkElement aaa, ref int x, ref int y, ref bool bb, int value)
        {
            bb = false;
            aaa.Margin = new Thickness((int)(aaa.Margin.Left + 25) / 50 * 50, (int)(aaa.Margin.Top + 25) / 50 * 50, 0, 0);
            ChessBoard[(int)(aaa.Margin.Top + 25) / 50, (int)(aaa.Margin.Left + 25) / 50] = value;
            ChessBoard[y, x] = 0;
            y = (int)(aaa.Margin.Top + 25) / 50;
            x = (int)(aaa.Margin.Left + 25) / 50;
            Second_Point();

        }

        void WhiteKing_MouseDown(object sender, MouseButtonEventArgs e)
        {

            MouseD(sender, e, WhiteKing, ref White_King);

        }

        void WhiteKing_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MouseU(WhiteKing, ref WhiteKing_Position_X, ref WhiteKing_Position_Y, ref White_King, 1000);
            

        }

        void WhitePawn_One_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MouseD(sender, e, WhitePawn_One, ref White_Pawn_One);

        }

        void WhitePawn_One_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MouseU(WhitePawn_One, ref WhitePawn_One_Position_X, ref WhitePawn_One_Position_Y, ref White_Pawn_One, 10);

        }

        void WhitePawn_Two_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MouseD(sender, e, WhitePawn_Two, ref White_Pawn_Two);

        }

        void WhitePawn_Two_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MouseU(WhitePawn_Two, ref WhitePawn_Two_Position_X, ref WhitePawn_Two_Position_Y, ref White_Pawn_Two, 10);

        }

        void WhitePawn_Three_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MouseD(sender, e, WhitePawn_Three, ref White_Pawn_Three);

        }

        void WhitePawn_Three_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MouseU(WhitePawn_Three, ref WhitePawn_Three_Position_X, ref WhitePawn_Three_Position_Y, ref White_Pawn_Three, 10);

        }

        void WhitePawn_Four_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MouseD(sender, e, WhitePawn_Four, ref White_Pawn_Four);

        }

        void WhitePawn_Four_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MouseU(WhitePawn_Four, ref WhitePawn_Four_Position_X, ref WhitePawn_Four_Position_Y, ref White_Pawn_Four, 10);

        }

        void WhitePawn_Five_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MouseD(sender, e, WhitePawn_Five, ref White_Pawn_Five);

        }

        void WhitePawn_Five_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MouseU(WhitePawn_Five, ref WhitePawn_Five_Position_X, ref WhitePawn_Five_Position_Y, ref White_Pawn_Five, 10);

        }

        void WhitePawn_Six_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MouseD(sender, e, WhitePawn_Six, ref White_Pawn_Six);

        }

        void WhitePawn_Six_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MouseU(WhitePawn_Six, ref WhitePawn_Six_Position_X, ref WhitePawn_Six_Position_Y, ref White_Pawn_Six, 10);

        }

        void WhitePawn_Seven_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MouseD(sender, e, WhitePawn_Seven, ref White_Pawn_Seven);

        }

        void WhitePawn_Seven_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MouseU(WhitePawn_Seven, ref WhitePawn_Seven_Position_X, ref WhitePawn_Seven_Position_Y, ref White_Pawn_Seven, 10);

        }

        void WhitePawn_Eight_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MouseD(sender, e, WhitePawn_Eight, ref White_Pawn_Eight);

        }

        void WhitePawn_Eight_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MouseU(WhitePawn_Eight, ref WhitePawn_Eight_Position_X, ref WhitePawn_Eight_Position_Y, ref White_Pawn_Eight, 10);

        }
        void WhiteQueen_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MouseD(sender, e, WhiteQueen, ref White_Queen);

        }

        void WhiteQueen_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MouseU(WhiteQueen, ref WhiteQueen_Position_X, ref WhiteQueen_Position_Y, ref White_Queen, 90);

        }

        void WhiteBishop_One_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MouseD(sender, e, WhiteBishop_One, ref White_Bishop_One);

        }

        void WhiteBishop_One_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MouseU(WhiteBishop_One, ref WhiteBishop_One_Position_X, ref WhiteBishop_One_Position_Y, ref White_Bishop_One, 33);

        }

        void WhiteKnight_One_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MouseD(sender, e, WhiteKnight_One, ref White_Knight_One);

        }

        void WhiteKnight_One_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MouseU(WhiteKnight_One, ref WhiteKnight_One_Position_X, ref WhiteKnight_One_Position_Y, ref White_Knight_One, 30);

        }

        void WhiteKnight_Two_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MouseD(sender, e, WhiteKnight_Two, ref White_Knight_Two);

        }

        void WhiteKnight_Two_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MouseU(WhiteKnight_Two, ref WhiteKnight_Two_Position_X, ref WhiteKnight_Two_Position_Y, ref White_Knight_Two, 30);

        }

        void WhiteRook_One_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MouseD(sender, e, WhiteRook_One, ref White_Rook_One);

        }

        void WhiteRook_One_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MouseU(WhiteRook_One, ref WhiteRook_One_Position_X, ref WhiteRook_One_Position_Y, ref White_Rook_One, 50);

        }

        void WhiteRook_Two_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MouseD(sender, e, WhiteRook_Two, ref White_Rook_Two);

        }

        void WhiteRook_Two_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MouseU(WhiteRook_Two, ref WhiteRook_Two_Position_X, ref WhiteRook_Two_Position_Y, ref White_Rook_Two, 50);

        }

        void WhiteBishop_Two_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MouseD(sender, e, WhiteBishop_Two, ref White_Bishop_Two);

        }

        void WhiteBishop_Two_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MouseU(WhiteBishop_Two, ref WhiteBishop_Two_Position_X, ref WhiteBishop_Two_Position_Y, ref White_Bishop_Two, 33);

        }

        void Eat(int x, int y)
        {

            string im = "aaaaaaaaaaaaaaaa";
            BitmapImage bitmap1 = new BitmapImage(new Uri(im, UriKind.RelativeOrAbsolute));
            switch (ChessBoard[y, x])
            {
                case 10:
                    WhitePawn_One.Source = bitmap1;
                    break;
                case 30:

                    break;

                case 33:

                    break;

                case 50:

                    break;

                case 90:

                    break;
            }

        }


        int Rook(int BlackRook_Position_Ytemp, int BlackRook_Position_Xtemp)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if ((j == BlackRook_Position_Xtemp || i == BlackRook_Position_Ytemp) && ChessBoard[i, j] == 1000)
                    {
                        if (j == BlackRook_Position_Xtemp)
                        {
                            for (int l = 1; l < Math.Abs(WhiteKing_Position_Y - BlackRook_Position_Ytemp); l++)
                            {
                                if (WhiteKing_Position_Y > BlackRook_Position_Ytemp && ChessBoard[BlackRook_Position_Ytemp + l, j] != 0)
                                {
                                    return 0;
                                }
                                if (WhiteKing_Position_Y < BlackRook_Position_Ytemp && ChessBoard[BlackRook_Position_Ytemp - l, j] != 0)
                                {
                                    return 0;
                                }
                            }
                        }
                        else
                        {
                            for (int l = 1; l < Math.Abs(WhiteKing_Position_X - BlackRook_Position_Xtemp); l++)
                            {
                                if (WhiteKing_Position_X > BlackRook_Position_Xtemp && ChessBoard[i, BlackRook_Position_Xtemp + l] != 0)
                                {
                                    return 0;
                                }
                                if (WhiteKing_Position_X < BlackRook_Position_Xtemp && ChessBoard[i, BlackRook_Position_Xtemp - l] != 0)
                                {
                                    return 0;
                                }
                            }
                        }
                        if (ChessBoard[BlackRook_Position_Ytemp, BlackRook_Position_Xtemp] >= 0 && ChessBoard[BlackRook_Position_Ytemp, BlackRook_Position_Xtemp] != 1000)
                        {
                            if (ChessBoard[BlackRook_Position_Ytemp, BlackRook_Position_Xtemp] > 0)
                            {
                               
                                Eat(BlackRook_Position_Ytemp, BlackRook_Position_Xtemp);
                            }
                            ChessBoard[BlackRook_Position_Y, BlackRook_Position_X] = 0;
                            BlackRook_Position_Y = BlackRook_Position_Ytemp;
                            BlackRook_Position_X = BlackRook_Position_Xtemp;
                            ChessBoard[BlackRook_Position_Y, BlackRook_Position_X] = -50;
                            BlackRook_One.Margin = new Thickness(BlackRook_Position_Xtemp * 50, BlackRook_Position_Ytemp * 50, 0, 0);
                            return 11;
                        }
                    }
                }
            }
            return 0;
        }



        int Bishop(int BlackBishop_Position_Ytemp, int BlackBishop_Position_Xtemp)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Math.Abs(BlackBishop_Position_Ytemp - i) == Math.Abs(BlackBishop_Position_Xtemp - j) && ChessBoard[i, j] == 1000)
                    {
                        for (int l = 1; l < Math.Abs(WhiteKing_Position_Y - BlackBishop_Position_Ytemp); l++)
                        {
                            if (WhiteKing_Position_Y > BlackBishop_Position_Ytemp && WhiteKing_Position_X < BlackBishop_Position_Xtemp && ChessBoard[BlackBishop_Position_Ytemp + l, BlackBishop_Position_Xtemp - l] != 0)
                            {
                                return 0;
                            }
                            if (WhiteKing_Position_Y > BlackBishop_Position_Ytemp && WhiteKing_Position_X > BlackBishop_Position_Xtemp && ChessBoard[BlackBishop_Position_Ytemp + l, BlackBishop_Position_Xtemp + l] != 0)
                            {
                                return 0;
                            }
                            if (WhiteKing_Position_Y < BlackBishop_Position_Ytemp && WhiteKing_Position_X < BlackBishop_Position_Xtemp && ChessBoard[BlackBishop_Position_Ytemp - l, BlackBishop_Position_Xtemp - l] != 0)
                            {
                                return 0;
                            }
                            if (WhiteKing_Position_Y < BlackBishop_Position_Ytemp && WhiteKing_Position_X > BlackBishop_Position_Xtemp && ChessBoard[BlackBishop_Position_Ytemp - l, BlackBishop_Position_Xtemp + l] != 0)
                            {
                                return 0;
                            }
                        }
                        if (ChessBoard[BlackBishop_Position_Ytemp, BlackBishop_Position_Xtemp] >= 0 && ChessBoard[BlackBishop_Position_Ytemp, BlackBishop_Position_Xtemp] != 1000)
                        {
                            ChessBoard[BlackBishop_Position_Y, BlackBishop_Position_X] = 0;
                            BlackBishop_Position_Y = BlackBishop_Position_Ytemp;
                            BlackBishop_Position_X = BlackBishop_Position_Xtemp;
                            ChessBoard[BlackBishop_Position_Y, BlackBishop_Position_X] = -33;
                            BlackBishop_One.Margin = new Thickness(BlackBishop_Position_Xtemp * 50, BlackBishop_Position_Ytemp * 50, 0, 0);
                            return 11;
                        }
                    }
                }
            }
            return 0;
        }

        int Bishop_Two(int BlackBishop_Position_Ytemp, int BlackBishop_Position_Xtemp)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Math.Abs(BlackBishop_Position_Ytemp - i) == Math.Abs(BlackBishop_Position_Xtemp - j) && ChessBoard[i, j] == 1000)
                    {
                        for (int l = 1; l < Math.Abs(WhiteKing_Position_Y - BlackBishop_Position_Ytemp); l++)
                        {
                            if (WhiteKing_Position_Y > BlackBishop_Position_Ytemp && WhiteKing_Position_X < BlackBishop_Position_Xtemp && ChessBoard[BlackBishop_Position_Ytemp + l, BlackBishop_Position_Xtemp - l] != 0)
                            {
                                return 0;
                            }
                            if (WhiteKing_Position_Y > BlackBishop_Position_Ytemp && WhiteKing_Position_X > BlackBishop_Position_Xtemp && ChessBoard[BlackBishop_Position_Ytemp + l, BlackBishop_Position_Xtemp + l] != 0)
                            {
                                return 0;
                            }
                            if (WhiteKing_Position_Y < BlackBishop_Position_Ytemp && WhiteKing_Position_X < BlackBishop_Position_Xtemp && ChessBoard[BlackBishop_Position_Ytemp - l, BlackBishop_Position_Xtemp - l] != 0)
                            {
                                return 0;
                            }
                            if (WhiteKing_Position_Y < BlackBishop_Position_Ytemp && WhiteKing_Position_X > BlackBishop_Position_Xtemp && ChessBoard[BlackBishop_Position_Ytemp - l, BlackBishop_Position_Xtemp + l] != 0)
                            {
                                return 0;
                            }
                        }
                        if (ChessBoard[BlackBishop_Position_Ytemp, BlackBishop_Position_Xtemp] >= 0 && ChessBoard[BlackBishop_Position_Ytemp, BlackBishop_Position_Xtemp] != 1000)
                        {
                            ChessBoard[BlackBishop_Two_Position_Y, BlackBishop_Two_Position_X] = 0;
                            BlackBishop_Two_Position_Y = BlackBishop_Position_Ytemp;
                            BlackBishop_Two_Position_X = BlackBishop_Position_Xtemp;
                            ChessBoard[BlackBishop_Two_Position_Y, BlackBishop_Two_Position_X] = -33;
                            BlackBishop_Two.Margin = new Thickness(BlackBishop_Position_Xtemp * 50, BlackBishop_Position_Ytemp * 50, 0, 0);
                            return 11;
                        }
                    }
                }
            }
            return 0;
        }


        int Knight(int BlackKnight_Position_Ytemp, int BlackKnight_Position_Xtemp)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (((Math.Abs(BlackKnight_Position_Ytemp - i) == 2 && Math.Abs(BlackKnight_Position_Xtemp - j) == 1) || (Math.Abs(BlackKnight_Position_Ytemp - i) == 1 && Math.Abs(BlackKnight_Position_Xtemp - j) == 2)) && ChessBoard[i, j] == 1000)
                    {
                        if (ChessBoard[BlackKnight_Position_Ytemp, BlackKnight_Position_Xtemp] >= 0 && ChessBoard[BlackKnight_Position_Ytemp, BlackKnight_Position_Xtemp] != 1000)
                        {
                            ChessBoard[BlackKnight_Position_Y, BlackKnight_Position_X] = 0;
                            BlackKnight_Position_X = BlackKnight_Position_Xtemp;
                            BlackKnight_Position_Y = BlackKnight_Position_Ytemp;
                            ChessBoard[BlackKnight_Position_Y, BlackKnight_Position_X] = -30;
                            BlackKnight_One.Margin = new Thickness(BlackKnight_Position_Xtemp * 50, BlackKnight_Position_Ytemp * 50, 0, 0);

                            return 11;
                        }
                    }
                }
            }
            return 0;
        }

        int Knight_Two(int BlackKnight_Position_Ytemp, int BlackKnight_Position_Xtemp)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (((Math.Abs(BlackKnight_Position_Ytemp - i) == 2 && Math.Abs(BlackKnight_Position_Xtemp - j) == 1) || (Math.Abs(BlackKnight_Position_Ytemp - i) == 1 && Math.Abs(BlackKnight_Position_Xtemp - j) == 2)) && ChessBoard[i, j] == 1000)
                    {
                        if (ChessBoard[BlackKnight_Position_Ytemp, BlackKnight_Position_Xtemp] >= 0 && ChessBoard[BlackKnight_Position_Ytemp, BlackKnight_Position_Xtemp] != 1000)
                        {
                            ChessBoard[BlackKnight_Two_Position_Y, BlackKnight_Two_Position_X] = 0;
                            BlackKnight_Two_Position_X = BlackKnight_Position_Xtemp;
                            BlackKnight_Two_Position_Y = BlackKnight_Position_Ytemp;
                            ChessBoard[BlackKnight_Two_Position_Y, BlackKnight_Two_Position_X] = -30;
                            BlackKnight_Two.Margin = new Thickness(BlackKnight_Position_Xtemp * 50, BlackKnight_Position_Ytemp * 50, 0, 0);

                            return 11;
                        }
                    }
                }
            }
            return 0;
        }

        void Second_Point() {

            BlackRook_Position_Ytemp = BlackRook_Position_Y;
            BlackRook_Position_Xtemp = BlackRook_Position_X;
            BlackBishop_Position_Ytemp = BlackBishop_Position_Y;
            BlackBishop_Position_Xtemp = BlackBishop_Position_X;
            BlackKnight_Position_Xtemp = BlackKnight_Position_X;
            BlackKnight_Position_Ytemp = BlackKnight_Position_Y;
            BlackKnight_Two_Position_Xtemp = BlackKnight_Two_Position_X;
            BlackKnight_Two_Position_Ytemp = BlackKnight_Two_Position_Y;
            BlackBishop_Two_Position_Ytemp = BlackBishop_Two_Position_Y;
            BlackBishop_Two_Position_Xtemp = BlackBishop_Two_Position_X;
            for (int i = 0; i < 8; i++) {
                for (int j = 0; j < 8; j++) {
                    if ((j == BlackRook_Position_Xtemp || i == BlackRook_Position_Ytemp) && ChessBoard[i, j] >= 0) {
                        Rook_V = false;
                        if (j == BlackRook_Position_Xtemp) {
                            for (int l = 1; l < Math.Abs(i - BlackRook_Position_Ytemp); l++) {
                                if (i > BlackRook_Position_Ytemp && ChessBoard[BlackRook_Position_Ytemp + l, j] != 0) {
                                    Rook_V = true;
                                    break;
                                }
                                if (i < BlackRook_Position_Ytemp && ChessBoard[BlackRook_Position_Ytemp - l, j] != 0) {
                                    Rook_V = true;
                                    break;
                                }
                            }
                        } else
                        {
                            for (int l = 1; l < Math.Abs(j - BlackRook_Position_Xtemp); l++)
                            {
                                if (j > BlackRook_Position_Xtemp && ChessBoard[i, BlackRook_Position_Xtemp + l] != 0)
                                {
                                    Rook_V = true;
                                    break;
                                }
                                if (j < BlackRook_Position_Xtemp && ChessBoard[i, BlackRook_Position_Xtemp - l] != 0)
                                {
                                    Rook_V = true;
                                    break;
                                }
                            }
                        }
                        if (!Rook_V)
                        {
                            if (Rook(i, j) == 11)
                            {
                                
                                return;
                            }
                        }
                    }
                    if (Math.Abs(BlackBishop_Position_Ytemp - i) == Math.Abs(BlackBishop_Position_Xtemp - j) && ChessBoard[i, j] >= 0)
                    {
                        Bishop_V = false;
                        for (int l = 1; l < Math.Abs(i - BlackBishop_Position_Ytemp); l++)
                        {
                            if (i > BlackBishop_Position_Ytemp && j < BlackBishop_Position_Xtemp && ChessBoard[BlackBishop_Position_Ytemp + l, BlackBishop_Position_Xtemp - l] != 0)
                            {
                                Bishop_V = true;
                            }
                            if (i > BlackBishop_Position_Ytemp && j > BlackBishop_Position_Xtemp && ChessBoard[BlackBishop_Position_Ytemp + l, BlackBishop_Position_Xtemp + l] != 0)
                            {
                                Bishop_V = true;
                            }
                            if (i < BlackBishop_Position_Ytemp && j < BlackBishop_Position_Xtemp && ChessBoard[BlackBishop_Position_Ytemp - l, BlackBishop_Position_Xtemp - l] != 0)
                            {
                                Bishop_V = true;
                            }
                            if (i < BlackBishop_Position_Ytemp && j > BlackBishop_Position_Xtemp && ChessBoard[BlackBishop_Position_Ytemp - l, BlackBishop_Position_Xtemp + l] != 0)
                            {
                                Bishop_V = true;
                            }
                        }
                        if (!Bishop_V)
                        {
                            if (Bishop(i, j) == 11)
                            {
                                
                                return;
                            }
                        }
                    }

                    if (Math.Abs(BlackBishop_Two_Position_Ytemp - i) == Math.Abs(BlackBishop_Two_Position_Xtemp - j) && ChessBoard[i, j] >= 0)
                    {
                        Bishop_V_second = false;
                        for (int l = 1; l < Math.Abs(i - BlackBishop_Two_Position_Ytemp); l++)
                        {
                            if (i > BlackBishop_Two_Position_Ytemp && j < BlackBishop_Two_Position_Xtemp && ChessBoard[BlackBishop_Two_Position_Ytemp + l, BlackBishop_Two_Position_Xtemp - l] != 0)
                            {
                                Bishop_V_second = true;
                            }
                            if (i > BlackBishop_Two_Position_Ytemp && j > BlackBishop_Two_Position_Xtemp && ChessBoard[BlackBishop_Two_Position_Ytemp + l, BlackBishop_Two_Position_Xtemp + l] != 0)
                            {
                                Bishop_V_second = true;
                            }
                            if (i < BlackBishop_Two_Position_Ytemp && j < BlackBishop_Two_Position_Xtemp && ChessBoard[BlackBishop_Two_Position_Ytemp - l, BlackBishop_Two_Position_Xtemp - l] != 0)
                            {
                                Bishop_V_second = true;
                            }
                            if (i < BlackBishop_Two_Position_Ytemp && j > BlackBishop_Two_Position_Xtemp && ChessBoard[BlackBishop_Two_Position_Ytemp - l, BlackBishop_Two_Position_Xtemp + l] != 0)
                            {
                                Bishop_V_second = true;
                            }
                        }
                        if (!Bishop_V_second)
                        {
                            if (Bishop_Two(i, j) == 11)
                            {

                                return;
                            }
                        }
                    }

                    if (((Math.Abs(BlackKnight_Position_Ytemp - i) == 2 && Math.Abs(BlackKnight_Position_Xtemp - j) == 1) || (Math.Abs(BlackKnight_Position_Ytemp - i) == 1 && Math.Abs(BlackKnight_Position_Xtemp - j) == 2)) && ChessBoard[i, j] >= 0)
                    {
                        if (Knight(i, j) == 11)
                        {
                           
                            return;
                        }
                    }
                    if (((Math.Abs(BlackKnight_Two_Position_Ytemp - i) == 2 && Math.Abs(BlackKnight_Two_Position_Xtemp - j) == 1) || (Math.Abs(BlackKnight_Two_Position_Ytemp - i) == 1 && Math.Abs(BlackKnight_Two_Position_Xtemp - j) == 2)) && ChessBoard[i, j] >= 0)
                    {
                        if (Knight_Two(i, j) == 11)
                        {

                            return;
                        }
                    }
                }
            }
           
        }



    }














    }
