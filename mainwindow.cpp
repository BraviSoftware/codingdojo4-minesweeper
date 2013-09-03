#include "mainwindow.h"
#include "ui_mainwindow.h"
#include<clickablelabel.h>
#include<stdio.h>
#include<QMouseEvent>
#include<QMessageBox>

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
    this->mine = new Minesweeper();
    this->mine->generate_field(10,10,9);
    for(int i=0;i<10;i++)
    {
        for(int j=0;j<10;j++){            
            ClickableLabel *label = new ClickableLabel(this->ui->frame);
            label->setObjectName(QString::fromUtf8("label2"));
            label->setGeometry(QRect(i*32, j*32 ,32, 32));
            label->setProperty("cell_type", mine->matrix[i][j]);
            label->setProperty("mark", false);
            label->setProperty("x_coord",i);
            label->setProperty("y_coord",j);
            label->setPixmap(QPixmap(QString::fromUtf8(":/brick/brick_wall.png")));
            label->show();
            this->mine->labels[i][j] = label;
            connect(label, &ClickableLabel::clicked, this, &MainWindow::on_label_clicked);
        }
    }
    mine->print_matrix(10,10);
}

void MainWindow::on_label_clicked(QMouseEvent *event)
{
    if(event->button()==Qt::LeftButton){
        this->click_on_brick();
    }
    else if(event->button()==Qt::RightButton){
        this->mark_brick();
    }
}

void MainWindow::click_on_brick()
{
    QLabel *label = (QLabel *)sender();
    int value = label->property("cell_type").toInt();
    bool marked = label->property("mark").toBool();
    if(marked){
        label->setPixmap(QPixmap(QString::fromUtf8(":/brick/brick_wall.png")));
        label->setProperty("mark", false);
        return;
    }

    if(value==-1){
        label->setPixmap(QPixmap(QString::fromUtf8(":/bomb_icon/1218_32x32.png")));
        QMessageBox::information(this->ui->centralwidget, QString::fromUtf8("Sorry!"),
                   QString::fromUtf8("You clicked on a bomb! You lost!"),QMessageBox::Ok);
        return;
    }
    else if(value==1)
        label->setPixmap(QPixmap(QString::fromUtf8(":/one_icon/one_page.png")));
    else if(value==2)
        label->setPixmap(QPixmap(QString::fromUtf8(":/two_icon/two_page.png")));
    else if(value==3)
        label->setPixmap(QPixmap(QString::fromUtf8(":/three_icon/three_page.png")));
    else if(value==4)
        label->setPixmap(QPixmap(QString::fromUtf8(":/four_icon/four_page.png")));
    else{
        label->setPixmap(QPixmap(QString::fromUtf8(":/empty_icon/empty.png")));
        int x = label->property("x_coord").toInt();
        int y = label->property("y_coord").toInt();
        this->clear_empty_neighbors(x,y, 4);
    }
}

void MainWindow::mark_brick()
{
    QLabel *label = (QLabel *)sender();
    label->setProperty("mark", true);
    label->setPixmap(QPixmap(QString::fromUtf8(":/flagged_icon/flagged.png")));
}

void MainWindow::clear_empty_neighbors(int x, int y, int lado)
{
    if(x<0 || y<0)
        return;
    if(x>=this->mine->width || y>=this->mine->height)
        return;

    ClickableLabel *mine = this->mine->labels[x][y];
    int value = mine->property("cell_type").toInt();

    if(value==0){
        mine->setPixmap(QPixmap(QString::fromUtf8(":/empty_icon/empty.png")));
    } else if(value==1)
        mine->setPixmap(QPixmap(QString::fromUtf8(":/one_icon/one_page.png")));
    else if(value==2)
        mine->setPixmap(QPixmap(QString::fromUtf8(":/two_icon/two_page.png")));
    else if(value==3)
        mine->setPixmap(QPixmap(QString::fromUtf8(":/three_icon/three_page.png")));
    else if(value==4)
        mine->setPixmap(QPixmap(QString::fromUtf8(":/four_icon/four_page.png")));
    if(value!=0)
        return;
    if(lado == 0 || lado ==4){
        this->clear_empty_neighbors(x+1, y, 0);
        this->clear_empty_neighbors(x, y+1, 0);
    }
    if(lado==1 || lado ==4 ){
        this->clear_empty_neighbors(x-1, y, 1);
        this->clear_empty_neighbors(x, y-1, 1);
    }
    if(lado==2 || lado ==4 ){
        this->clear_empty_neighbors(x+1, y, 2);
        this->clear_empty_neighbors(x, y-1, 2);
    }
    if(lado==3 || lado ==4 ){
        this->clear_empty_neighbors(x-1, y, 3);
        this->clear_empty_neighbors(x, y+1, 3);
    }
}
