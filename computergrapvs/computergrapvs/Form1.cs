using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao.OpenGl;
using Tao.Platform.Windows;

namespace computergrapvs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SimpleOpenGlControl.initializeContexts();
            Gl.glClearColor(0.1f, 0.39f, 0.88f, 1);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity(); 
            Gl.glColor3f(1, 1, 1);
            Gl.glEnable(Gl.GL_CULL_FACE ); 
            Gl.glCullFace(Gl.GL_BACK );
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Gl.glFrustum(-2, 2, 1.5, 1.5, 1,40);
        }   

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
