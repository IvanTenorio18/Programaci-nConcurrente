using System.Windows.Forms.Design;

namespace Filosofos
{
    public partial class Form1 : Form
    {
        //Declaramos los tenedores para despues utilizarlos en el semaforo
        public bool tenedor1 = true,
            tenedor2 = true,
            tenedor3 = true,
            tenedor4 = true,
            tenedor5 = true;
        // Esto significa que dos procesos estan ejecutandoce y tres estan en espera
        public Semaphore semaforo = new Semaphore(2, 3); 
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for(int i = 1; i < 5; i++)
            {
                //HILOS
                Thread f1 = new Thread(fil1);
                Thread f2 = new Thread(fil2);
                Thread f3 = new Thread(fil3);
                Thread f4 = new Thread(fil4);
                Thread f5 = new Thread(fil5);
                f1.Start();
                f2.Start();
                f3.Start();
                f4.Start();
                f5.Start();
            }
            
        }

        //if donde indica si el primer filosofo esta comiendo y agarra los tenedores
        public void fil1()
        {
            semaforo.WaitOne();//Indica que comienza el semaforo
            if(tenedor1 == true && tenedor2 == true)//Se utilizaran tenedor 1 y 2
            {
                tenedor1 = false;//Indica que se utilizara el tenedor 1
                tenedor2 = false;//Indica que se utilizara el tenedor 2
                Invoke((Delegate)new Action(() =>
                {
                    filosofo1.Visible = false; //Indica que la primer imagen no se visualiza
                    come.Visible = true;//La segunda imagen donde indica que esta comiendo se visualiza
                    ten1.Visible = false;//Los tenedores 1 y 2 desaparecen 
                    ten2.Visible = false;
                }));
                Thread.Sleep(2000);//Tiempo de espera 
            }
            Invoke((Delegate)new Action(() =>
            {
              filosofo1.Visible =true;//El filosofo que no come se visualiza
              come.Visible = false;//La imagen del filosofo que come no se visualiza
                ten1.Visible = true;//Los tenedores 1 y 2 se visualizan
                ten2.Visible = true;
            }));
            tenedor2 = true;
            tenedor3 = true;
            semaforo.Release();//se reinicia el semaforo
        }
        public void fil2()
        {
            semaforo.WaitOne();
            if(tenedor2 == true && tenedor3 == true)//Se utilizara tenedor 2 y 3
            {
                tenedor2 = false;//Indica que se utilizara el tenedor 2
                tenedor3 = false;//Indica que se utilizara el tenedor 3
                Invoke((Delegate)new Action(() =>
                {
                    filosofo2.Visible = false;
                    comer1.Visible = true;
                    ten2.Visible=false;
                    ten3.Visible = false;
                }));
                Thread.Sleep(2000);
            }
            Invoke((Delegate)new Action(() =>
            {
                filosofo2.Visible=true;
                comer1.Visible=false;
                ten2.Visible = true;
                ten3.Visible = true;
            }));
            tenedor3=true;
            tenedor4 = true;
            semaforo.Release();
        }
        public void fil3()
        {
            semaforo.WaitOne();
            if (tenedor3 == true && tenedor4 == true)//Se utilizaran tenedor 3 y 4
            {
                tenedor3 = false;//Indica que se utilizara el tenedor 3
                tenedor4 = false;//Indica que se utilizara el tenedor 4
                Invoke((Delegate)new Action(() =>
                {
                    filosofo3.Visible = false;
                    comer2.Visible = true;
                    ten3.Visible=false;
                    ten4.Visible=false;
                }));
                Thread.Sleep(2000);
            }
            Invoke((Delegate)new Action(() =>
            {
                filosofo3.Visible = true;
                comer2.Visible=false;
                ten3.Visible = true;
                ten4.Visible = true;
            }));
            tenedor4=true;
            tenedor5=true;
            semaforo.Release();
        }
        public void fil4()
        {
            semaforo.WaitOne();
            if (tenedor4 == true && tenedor5 == true){//se utiliza tenedor 4 y 5
                tenedor4 = false;//Indica que se utilizara el tenedor 4
                tenedor5 = false;//Indica que se utilizara el tenedor 5
                Invoke((Delegate)new Action(() =>
                {
                    filosofo4.Visible = false;
                    comer3.Visible = true;
                    ten4.Visible = false;
                    ten5.Visible = false;
                }));
                Thread.Sleep(2000);
            }
            Invoke((Delegate)new Action(() =>
            {
                filosofo4.Visible = true;
                comer3.Visible = false;
                ten4.Visible = true;
                ten5.Visible = true;
            }));
            tenedor5 = true;
            tenedor1 = true;
            semaforo.Release();
        }
        public void fil5()
        {
            semaforo.WaitOne();
            if (tenedor5 == true && tenedor1 == true)//Se utilizaran tenedor 5 y 1
            {
                tenedor5 = false;//Indica que se utilizara el tenedor 5
                tenedor1 = false;//Indica que se utilizara el tenedor 1
                Invoke((Delegate)new Action(() =>
                {
                    filosofo5.Visible = false;
                    comer4.Visible = true;
                    ten5.Visible = false;
                    ten1.Visible = false;
                }));
                Thread.Sleep(2000);
            }
            Invoke((Delegate)new Action(() =>
            {
                filosofo5.Visible = true;
                comer4.Visible = false;
                ten5.Visible = true;
                ten1.Visible = true;
            }));
            tenedor5 = true;
            tenedor1 = true;
            semaforo.Release();
        }
    }
}