#include "mainwindow.h"
#include "ui_mainwindow.h"
#include<QLabel>
#include<minesweeper.h>

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);
}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::on_pushButton_clicked()
{
    //QObjectList list = this->ui->frame->children();
    //QObjectList::Iterator it(list);
    //while ( it.current() ) {
        //delete it.current();
        //++it;
    //}

    Minesweeper *mine = new Minesweeper();
    mine->generate_field(10,10,9);
    for(int i=0;i<10;i++)
    {
        for(int j=0;j<10;j++){            
            QLabel *label = new QLabel(this->ui->frame);
            label->setObjectName(QString::fromUtf8("label2"));
            label->setGeometry(QRect(i*32, j*32 ,32, 32));
            if(mine->matrix[i][j]==-1)
                label->setPixmap(QPixmap(QString::fromUtf8(":/bomb_icon/1218_32x32.png")));
            else if(mine->matrix[i][j]==1)
                label->setPixmap(QPixmap(QString::fromUtf8(":/one_icon/one_page.png")));
            else if(mine->matrix[i][j]==2)
                label->setPixmap(QPixmap(QString::fromUtf8(":/two_icon/two_page.png")));
            else if(mine->matrix[i][j]==3)
                label->setPixmap(QPixmap(QString::fromUtf8(":/two_icon/two_page.png")));
            else if(mine->matrix[i][j]==4)
                label->setPixmap(QPixmap(QString::fromUtf8(":/two_icon/two_page.png")));
            else
                label->setPixmap(QPixmap(QString::fromUtf8(":/brick/brick_wall.png")));
            label->show();
        }
    }
    mine->print_matrix(10,10);
}

