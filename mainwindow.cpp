#include "mainwindow.h"
#include "ui_mainwindow.h"
#include<minesweeper.h>
#include<clickablelabel.h>
#include<stdio.h>

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
    this->ui->frame->setGeometry(10,50,500,500);
    Minesweeper *mine = new Minesweeper();
    mine->generate_field(10,10,9);
    for(int i=0;i<10;i++)
    {
        for(int j=0;j<10;j++){            
            ClickableLabel *label = new ClickableLabel(this->ui->frame);
            label->setObjectName(QString::fromUtf8("label2"));
            label->setGeometry(QRect(i*32, j*32 ,32, 32));
            label->setProperty("cell_type", mine->matrix[i][j]);
            label->setPixmap(QPixmap(QString::fromUtf8(":/brick/brick_wall.png")));
            label->show();            
            connect(label, SIGNAL(clicked()), this, SLOT(on_label_clicked()));
        }
    }
    mine->print_matrix(10,10);
}

void MainWindow::on_label_clicked()
{
    QLabel *label = (QLabel *)sender();
    int value = label->property("cell_type").toInt();
    printf("%d\n", value);
    if(value==-1)
        label->setPixmap(QPixmap(QString::fromUtf8(":/bomb_icon/1218_32x32.png")));
    else if(value==1)
        label->setPixmap(QPixmap(QString::fromUtf8(":/one_icon/one_page.png")));
    else if(value==2)
        label->setPixmap(QPixmap(QString::fromUtf8(":/two_icon/two_page.png")));
    else if(value==3)
        label->setPixmap(QPixmap(QString::fromUtf8(":/three_icon/three_page.png")));
    else if(value==4)
        label->setPixmap(QPixmap(QString::fromUtf8(":/four_icon/four_page.png")));
    else
        label->setPixmap(QPixmap(QString::fromUtf8(":/empty_icon/empty.png")));

}

