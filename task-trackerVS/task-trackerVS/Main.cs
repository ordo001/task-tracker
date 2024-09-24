namespace task_trackerVS
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private int count = 0;
        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
        private Point dragCursorPoint;
        private Point dragCardPoint;
        private void cardsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserControlCard card = new UserControlCard()
            {
                BorderStyle = BorderStyle.FixedSingle
            };

            count++;
            Point cursorPos = Cursor.Position;
            Point localPos = this.PointToClient(cursorPos);
            //Point delta = new Point(Cursor.Position.X - dragCursorPoint.X, Cursor.Position.Y - dragCursorPoint.Y);
            card.Location = localPos;

            //Button deleteButton = new Button
            //{
            //    Text = "Delete",
            //    Location = new Point(Cursor.Position.X, Cursor.Position.Y),
            //    Size = new Size(60, 25)
            //};

            //card.AllowDrop = true;


            //deleteButton.Click += (s, args) =>
            //{
            //    // Удаление карточки по нажатию кнопки
            //    this.Controls.Remove(card);
            //    count--;
            //};
            //card.Controls.Add(deleteButton);


            Controls.Add(card);
        }
    }
}
