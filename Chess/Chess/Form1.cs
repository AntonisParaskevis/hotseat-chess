using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess // This application uses the Control.Draggable package from nuget.org.
{
    public partial class Form1 : Form
    {
        //Create and iniitalize an object of the ChessClock class, so that we can use the chess clock feature
        ChessClock clock = new ChessClock();
        public Form1()
        {
            InitializeComponent();
        }

        class ChessClock 
        {
            // The minutes and the seconds remaining for Player 1 and Player 2 respectively will be stored in these variables
            public sbyte player1_minutes, player1_seconds, player2_minutes, player2_seconds;

            //Display a message saying that Player 1 (White) has lost due to running out of time
            public void player1_time_lose()
            {
                MessageBox.Show("White's time is up","White has lost");
            }

            // Display a message saying that Player 2 (Black) has lost due to running out of time
            public void player2_time_lose()
            {
                MessageBox.Show("Black's time is up", "Black has lost");
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
                        
        }

        // Click this button to end Player 1's turn
        private void button2_Click(object sender, EventArgs e) 
        {
            // Pause Player 1's time, since their turn has ended
            timer1.Enabled = false;

            //Resume Player 2's time, since their turn has started
            timer2.Enabled = true;

            // Disable Player 1's "end move" button, so that it can't be clicked when it's the other player's turn
            button2.Enabled = false;

            // Enable Player 2's "end move" button, so they can click it to end their move when they're done with it
            button1.Enabled = true;
        }

        // Click this button to end Player 2's turn
        private void button1_Click(object sender, EventArgs e)
        {
            // Pause Player 2's time, since their turn has ended
            timer2.Enabled = false;

            //Resume Player 1's time, since their turn has started
            timer1.Enabled = true;

            // Disable Player 2's "end move" button, so that it can't be clicked when it's the other player's turn
            button1.Enabled = false;

            // Enable Player 1's "end move" button, so they can click it to end their move when they're done with it
            button2.Enabled = true;
        }

        // Click this button to start the game
        private void button3_Click(object sender, EventArgs e)
        {
            // Check if both players have entered their names in the respective textboxes, so the game can start
            // Essentially the program checks if neither name textbox contains blank characters or no characters at all
            // At least one non-blank character must be inserted in each textbox so the game can start
            if (!String.IsNullOrWhiteSpace(textBox1.Text) && !String.IsNullOrWhiteSpace(textBox2.Text))
            {
                // Player 1 (White)'s  time starts running
                timer1.Enabled = true; 

                // Both name fields are made non-editable so players can't edit them in mid-game
                textBox1.Enabled = false;
                textBox2.Enabled = false;

                // Disable the "Start Game" button once the game has started, so that it can't be disrupted
                button3.Enabled = false;

                // Enable Player 1's "end move" button, so they can click it to end their move when they're done with it
                button2.Enabled = true;

                // Set the available time of both players to 15 minutes
                clock.player1_minutes = 15;
                clock.player1_seconds = 0;
                clock.player2_minutes = 15;
                clock.player2_seconds = 0;

                //Make all pieces on the form draggable 
                ControlExtension.Draggable(pictureBox2, true);
                ControlExtension.Draggable(pictureBox3, true);
                ControlExtension.Draggable(pictureBox4, true);
                ControlExtension.Draggable(pictureBox5, true);
                ControlExtension.Draggable(pictureBox6, true);
                ControlExtension.Draggable(pictureBox7, true);
                ControlExtension.Draggable(pictureBox8, true);
                ControlExtension.Draggable(pictureBox9, true);
                ControlExtension.Draggable(pictureBox10, true);
                ControlExtension.Draggable(pictureBox11, true);
                ControlExtension.Draggable(pictureBox12, true);
                ControlExtension.Draggable(pictureBox13, true);
                ControlExtension.Draggable(pictureBox14, true);
                ControlExtension.Draggable(pictureBox15, true);
                ControlExtension.Draggable(pictureBox16, true);
                ControlExtension.Draggable(pictureBox17, true);
                ControlExtension.Draggable(pictureBox18, true);
                ControlExtension.Draggable(pictureBox19, true);
                ControlExtension.Draggable(pictureBox20, true);
                ControlExtension.Draggable(pictureBox21, true);
                ControlExtension.Draggable(pictureBox22, true);
                ControlExtension.Draggable(pictureBox23, true);
                ControlExtension.Draggable(pictureBox24, true);
                ControlExtension.Draggable(pictureBox25, true);
                ControlExtension.Draggable(pictureBox26, true);
                ControlExtension.Draggable(pictureBox27, true);
                ControlExtension.Draggable(pictureBox28, true);
                ControlExtension.Draggable(pictureBox29, true);
                ControlExtension.Draggable(pictureBox30, true);
                ControlExtension.Draggable(pictureBox31, true);
                ControlExtension.Draggable(pictureBox32, true);
                ControlExtension.Draggable(pictureBox33, true);
            }
            else // If at least 1 player hasn't entered their name, display a message saying that the game can't start because of it
            {
                MessageBox.Show("At least one player hasn't enter their name.","The game can't start");
            }
        }

        // Player 1's clock. 1 tick = 1000 ms = 1 second
        private void timer1_Tick(object sender, EventArgs e)
        {
            // Reduce the seconds in Player 1's clock by 1
            clock.player1_seconds--;

            // When the seconds reach zero, reduce the minutes by one, and reset the seconds to 59
            // The clock can display zero seconds, but no less than that
            if (clock.player1_seconds == -1)
            {
                clock.player1_minutes--;
                clock.player1_seconds = 59;

                // Update the time in the GUI appropriately
                label4.Text = "Time: " + clock.player1_minutes + ":" + "00";
            }
            // Display the seconds correctly, even if the seconds left in the current minute are less than 10
            if (clock.player1_seconds < 10) 
            {
                label4.Text = "Time: " + clock.player1_minutes + ":0" + clock.player1_seconds;
            }
            else 
            {
                label4.Text = "Time: " + clock.player1_minutes + ":" + clock.player1_seconds;
            }
            // When the time is up, pause both timers and display the message saying that White has lost
            if (clock.player1_seconds == -1 && clock.player1_minutes == 0)
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                clock.player1_time_lose();
            }
        }

        private void timer2_Tick(object sender, EventArgs e) // Same for Player 2's clock
        {
            clock.player2_seconds--;
            if (clock.player2_seconds == -1)
            {
                clock.player2_minutes--;
                clock.player2_seconds = 59;
                label1.Text = "Time: " + clock.player2_minutes + ":" + "00";
            }
            if (clock.player2_seconds < 10)
            {
                label1.Text = "Time: " + clock.player2_minutes + ":" + "0" + clock.player2_seconds;
            }
            else
            {
                label1.Text = "Time: " + clock.player2_minutes + ":" + clock.player2_seconds;
            }
            if (clock.player2_seconds == -1 && clock.player2_minutes == 0)
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                clock.player2_time_lose();
            }
        }
    }
}
