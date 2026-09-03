using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace deneAI;

public partial class startscreen : Form
{
    public startscreen()
    {
        InitializeComponent();
    }

    private void startscreen_Load(object sender, EventArgs e)
    {

    }

    private void button2_Click(object sender, EventArgs e)
    {
        this.Hide();
        new Advanced().Show();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        Hide();
        new Ollama().Show();
    }
}
