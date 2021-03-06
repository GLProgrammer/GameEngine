﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_engine
{
    public partial class Minesweeper : Form
    {
        public Minesweeper()
        {
            InitializeComponent();
            eng = new Engine(this, 1, 0, false);
        }

        private Engine eng;
        private Random rnd;
        /// <summary>
        /// 0=Not revealed; empty   1=Not revealed; mine    10=Not revealed; empty; marked      11=Not revealed; mine; marked       20=Revealed; empty      21=Revealed; mine
        /// </summary>
        private int[,] playField;
        private FormObject[,] drawField;

        private bool end = false;

        private const int gameField_locX = 33;
        private const int gameField_locY = 62;
        private const int gameField_sizeX = 600;
        private const int gameField_sizeY = 600;

        public delegate void ClickToMineRect(MouseEventArgs e);

        Image tile_empty = Image.FromFile("../../Texture/minesweeper_empty.png");
        Image tile_hidden = Image.FromFile("../../Texture/minesweeper_tile.png");
        Image tile_flag = Image.FromFile("../.../Texture/minesweeper_flag.png");
        Image tile_flag_bad = Image.FromFile("../../Texture/minesweeper_flag_bad.png");
        Image tile_bomb = Image.FromFile("../../Texture/minesweeper_bomb.png");
        Image tile_bomb_activated = Image.FromFile("../../Texture/minesweeper_bomb_activated.png");


        private void button1_Click(object sender, EventArgs e)
        {
            end = false;
            ClickToMineRect del = new ClickToMineRect(Minesweeper_MouseClickAtRect);

            if (seed.Text.Replace(" ", "") == "")
                rnd = new Random();
            else
                rnd = new Random(seed.Text.GetHashCode());

            mineMarksLeft.Text = ((int)mines.Value).ToString();


            if (mines.Value > sizeX.Value * sizeX.Value)
                mines.Value = sizeX.Value * sizeX.Value;

            playField = new int[(int)sizeX.Value, (int)sizeX.Value];
            drawField = new FormObject[(int)sizeX.Value, (int)sizeX.Value];

            for (int i = 0; i < (int)sizeX.Value; i++)
            {
                for (int j = 0; j < (int)sizeX.Value; j++)
                {
                    FormObject obj = new FormObject(gameField_locX + (i * gameField_sizeX / (float)sizeX.Value), gameField_locY + (j * gameField_sizeY / (float)sizeX.Value), gameField_sizeX / (float)sizeX.Value, gameField_sizeY / (float)sizeX.Value, false, true, del, tile_hidden);
                    drawField[i, j] = obj;
                }
            }

            eng.RemoveAll();

            int minesPlaced = 0;

            while (minesPlaced < mines.Value)
            {
                int x = rnd.Next(0, (int)sizeX.Value);
                int y = rnd.Next(0, (int)sizeX.Value);

                if (playField[x, y] == 0)
                {
                    playField[x, y] = 1;
                    FormObject obj = new FormObject(gameField_locX + (x * gameField_sizeX / (float)sizeX.Value), gameField_locY + (y * gameField_sizeY / (float)sizeX.Value), gameField_sizeX / (float)sizeX.Value, gameField_sizeY / (float)sizeX.Value, false, true, del, tile_hidden);
                    eng.Remove(drawField[x, y]);
                    drawField[x, y] = obj;
                    minesPlaced++;
                }
            }


            for (int i = 0; i < drawField.GetLength(0); i++)
            {
                for (int j = 0; j < drawField.GetLength(1); j++)
                {
                    eng.Add(drawField[i, j]);
                }
            }

            //eng.Start();
            //eng.Draw();
        }

        private void Minesweeper_FormClosing(object sender, FormClosingEventArgs e)
        {
            eng.Stop();
            eng = null;
        }

        DateTime lastClick;
        private void Minesweeper_MouseClickAtRect(MouseEventArgs e)
        {
            int x = e.X - gameField_locX;
            int y = e.Y - gameField_locY;

            x = (int)(x / (gameField_sizeX / (float)sizeX.Value));
            y = (int)(y / (gameField_sizeY / (float)sizeX.Value));

            // On doubleclick (the last click was before 350ms or earlier)
            #region DoubleClick
            if (DateTime.Now - lastClick < TimeSpan.FromMilliseconds(350))
            {
                if ((e.Button == MouseButtons.Left || e.Button == MouseButtons.Right) && playField[x, y] == 20)
                {
                    int mines = NumberOfNearMines(x, y);

                    int detected = 0;
                    for (int i = -1; i <= 1; i++)
                    {
                        if (x + i < 0 || x + i >= playField.GetLength(0))
                            continue;

                        for (int j = -1; j <= 1; j++)
                        {
                            if (y + j < 0 || y + j >= playField.GetLength(1))
                                continue;

                            if (playField[x + i, y + j] == 10 || playField[x + i, y + j] == 11)
                                detected++;
                        }
                    }

                    // Reveal all mines in 3x3 square. If there is a bomb, BOOM it
                    if (detected == mines)
                    {
                        for (int i = -1; i <= 1; i++)
                        {
                            if (x + i < 0 || x + i >= playField.GetLength(0))
                                continue;

                            for (int j = -1; j <= 1; j++)
                            {
                                if (y + j < 0 || y + j >= playField.GetLength(1))
                                    continue;

                                if (playField[x + i, y + j] == 0)
                                {
                                    playField[x + i, y + j] = 20;

                                    eng.Remove(drawField[x + i, y + j]);
                                    drawField[x + i, y + j].texture = tile_empty;
                                    if (NumberOfNearMines(x + i, y + j) > 0)
                                        drawField[x + i, y + j].textToDraw = NumberOfNearMines(x + i, y + j).ToString();
                                    else
                                        RevealWhiteTiles(x + i, y + j);

                                    eng.Add(drawField[x + i, y + j]);
                                }
                                // BOOM
                                else if (playField[x + i, y + j] == 1)
                                {
                                    // Reveal all tiles
                                    for (int a = 0; a < playField.GetLength(0); a++)
                                    {
                                        for (int b = 0; b < playField.GetLength(1); b++)
                                        {
                                            eng.Remove(drawField[a, b]);

                                            if (playField[a, b] == 0 || playField[a, b] == 10)
                                            {
                                                if (playField[a, b] == 0)
                                                    drawField[a, b].texture = tile_empty;
                                                else
                                                    drawField[a, b].texture = tile_flag_bad;
                                                playField[a, b] = 20;
                                            }
                                            else if (playField[a, b] == 1)
                                            {
                                                playField[a, b] = 21;
                                                drawField[a, b].texture = tile_bomb;
                                            }

                                            if (playField[a, b] != 21 && playField[a, b] != 11)
                                            {
                                                int nmbr = NumberOfNearMines(a, b);
                                                if (nmbr > 0)
                                                    drawField[a, b].textToDraw = nmbr.ToString();
                                            }

                                            if (a == x + i && b == y + j)
                                                drawField[a, b].texture = tile_bomb_activated;

                                            if (drawField[a, b].texture == tile_flag_bad)
                                                drawField[a, b].textToDraw = "";

                                            eng.Add(drawField[a, b]);
                                        }
                                    }

                                    end = true;
                                    lastClick = DateTime.Now;
                                    return;
                                }
                            }
                        }
                    }
                }
            }
            lastClick = DateTime.Now;
            #endregion
            #region Left button
            if (e.Button == MouseButtons.Left)
            {
                // Reveal position; if marked -> remove mark

                if (playField[x, y] == 0)
                {
                    playField[x, y] = 20;

                    eng.Remove(drawField[x, y]);
                    drawField[x, y].texture = tile_empty;
                    if (NumberOfNearMines(x, y) > 0)
                        drawField[x, y].textToDraw = NumberOfNearMines(x, y).ToString();
                    else
                        RevealWhiteTiles(x, y);

                    eng.Add(drawField[x, y]);
                }
                else if (playField[x, y] == 1)
                {
                    // Reveal all tiles
                    for (int i = 0; i < playField.GetLength(0); i++)
                    {
                        for (int j = 0; j < playField.GetLength(1); j++)
                        {
                            eng.Remove(drawField[i, j]);

                            if (playField[i, j] == 0 || playField[i, j] == 10)
                            {
                                if (playField[i, j] == 0)
                                    drawField[i, j].texture = tile_empty;
                                else
                                    drawField[i, j].texture = tile_flag_bad;
                                playField[i, j] = 20;
                            }
                            else if (playField[i, j] == 1)
                            {
                                playField[i, j] = 21;
                                drawField[i, j].texture = tile_bomb;
                            }

                            if (playField[i, j] != 21 && playField[i, j] != 11)
                            {
                                int nmbr = NumberOfNearMines(i, j);
                                if (nmbr > 0)
                                    drawField[i, j].textToDraw = nmbr.ToString();
                            }

                            if (i == x && j == y)
                                drawField[i, j].texture = tile_bomb_activated;

                            if (drawField[i, j].texture == tile_flag_bad)
                                drawField[i, j].textToDraw = "";

                            eng.Add(drawField[i, j]);
                        }
                    }

                    end = true;
                }
                else if (playField[x, y] == 10 || playField[x, y] == 11)
                {
                    if (playField[x, y] == 10)
                    {
                        playField[x, y] = 0;

                        eng.Remove(drawField[x, y]);
                        drawField[x, y].texture = tile_hidden;
                        eng.Add(drawField[x, y]);
                    }
                    else
                    {
                        playField[x, y] = 1;

                        eng.Remove(drawField[x, y]);
                        drawField[x, y].texture = tile_hidden;
                        eng.Add(drawField[x, y]);
                    }

                    mineMarksLeft.Text = (int.Parse(mineMarksLeft.Text) + 1).ToString();
                }

            }
            #endregion
            #region Right button
            else if (e.Button == MouseButtons.Right)
            {
                if (playField[x, y] == 0)
                {
                    playField[x, y] = 10;

                    eng.Remove(drawField[x, y]);
                    drawField[x, y].texture = tile_flag;
                    eng.Add(drawField[x, y]);
                    mineMarksLeft.Text = (int.Parse(mineMarksLeft.Text) - 1).ToString();
                }
                else if (playField[x, y] == 1)
                {
                    playField[x, y] = 11;

                    eng.Remove(drawField[x, y]);
                    drawField[x, y].texture = tile_flag;
                    eng.Add(drawField[x, y]);
                    mineMarksLeft.Text = (int.Parse(mineMarksLeft.Text) - 1).ToString();
                }
                else if (playField[x, y] == 10)
                {
                    playField[x, y] = 0;

                    eng.Remove(drawField[x, y]);
                    drawField[x, y].texture = tile_hidden;
                    eng.Add(drawField[x, y]);
                    mineMarksLeft.Text = (int.Parse(mineMarksLeft.Text) + 1).ToString();
                }
                else if (playField[x, y] == 11)
                {
                    playField[x, y] = 1;

                    eng.Remove(drawField[x, y]);
                    drawField[x, y].texture = tile_hidden;
                    eng.Add(drawField[x, y]);
                    mineMarksLeft.Text = (int.Parse(mineMarksLeft.Text) + 1).ToString();
                }
            }
            #endregion

            if (int.Parse(mineMarksLeft.Text) == 0 && (from a in playField.OfType<int>() where a == 1 select a).Count() == 0)
            {
                MessageBox.Show("You've won! Congratulations!", "Minesweeper Winner");
                end = true;
            }
        }
        // TODO: Pridat ikonku vybuchle bomby + pri prohre zobrazit vsechny cisla

        private int NumberOfNearMines(int x, int y)
        {
            int number = 0;

            for (int i = -1; i <= 1; i++)
            {
                if (x + i < 0 || x + i >= playField.GetLength(0))
                    continue;

                for (int j = -1; j <= 1; j++)
                {
                    if (y + j < 0 || y + j >= playField.GetLength(1))
                        continue;

                    if (playField[x + i, y + j] == 1 || playField[x + i, y + j] == 11 || playField[x + i, y + j] == 21)
                        number++;
                }
            }

            return number;
        }


        private void Minesweeper_MouseDown(object sender, MouseEventArgs e)
        {
            if (!end)
                eng.MouseClick(e);
        }

        private void RevealWhiteTiles(int x, int y)
        {
            // If this tile is white, mark as revealed
            if (NumberOfNearMines(x, y) == 0)
            {
                if (playField[x, y] == 0)
                {
                    playField[x, y] = 20;

                    eng.Remove(drawField[x, y]);
                    drawField[x, y].texture = tile_empty;
                    if (NumberOfNearMines(x, y) > 0)
                        drawField[x, y].textToDraw = NumberOfNearMines(x, y).ToString();
                    eng.Add(drawField[x, y]);
                    MarkAllNeighbourTilesAsRevealed(x, y);
                }
            }

            // Go thr. all neighbour tiles. If there are white, call them recursively
            for (int i = -1; i <= 1; i++)
            {
                if (x + i < 0 || x + i >= playField.GetLength(0))
                    continue;

                for (int j = -1; j <= 1; j++)
                {
                    if (y + j < 0 || y + j >= playField.GetLength(1))
                        continue;

                    if (i == 0 && j == 0)
                        continue;

                    if (playField[x + i, y + j] == 0 && NumberOfNearMines(x + i, y + j) == 0)
                    {
                        RevealWhiteTiles(x + i, y + j);
                    }
                }
            }
        }

        private void MarkAllNeighbourTilesAsRevealed(int x, int y)
        {
            for (int i = -1; i <= 1; i++)
            {
                if (x + i < 0 || x + i >= playField.GetLength(0))
                    continue;

                for (int j = -1; j <= 1; j++)
                {
                    if (y + j < 0 || y + j >= playField.GetLength(1))
                        continue;

                    if (i == 0 && j == 0)
                        continue;

                    if (playField[x + i, y + j] == 0 && NumberOfNearMines(x + i, y + j) > 0)
                    {
                        playField[x + i, y + j] = 20;

                        eng.Remove(drawField[x + i, y + j]);
                        drawField[x + i, y + j].texture = tile_empty;
                        if (NumberOfNearMines(x + i, y + j) > 0)
                            drawField[x + i, y + j].textToDraw = NumberOfNearMines(x + i, y + j).ToString();
                        eng.Add(drawField[x + i, y + j]);
                    }
                }
            }
        }
    }
}
